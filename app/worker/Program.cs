// === APPLICATION CODE ===
using System;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json;
using Npgsql;
using StackExchange.Redis;

// === OBSERVABILITY: OpenTelemetry tracing imports ===
// Note: tracing config for .NET must stay in the source code (compiled at build time)
// For Python and Node.js, tracing config is separated in observability/tracing/
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Worker
{
    public class Program
    {
        // === OBSERVABILITY: ActivitySource is the .NET equivalent of a tracer ===
        private static readonly ActivitySource ActivitySource = new("Worker");

        public static int Main(string[] args)
        {
            // === OBSERVABILITY: Initialize tracing — sends traces to OTel Collector → Jaeger ===
            using var tracerProvider = Sdk.CreateTracerProviderBuilder()
                .SetResourceBuilder(ResourceBuilder.CreateDefault().AddService("worker-service"))
                .AddSource("Worker")
                .AddOtlpExporter(opt => {
                    opt.Endpoint = new Uri("http://otel-collector:4317");
                })
                .Build();

            try
            {
                var pgsql = OpenDbConnection("Server=db;Username=postgres;Password=postgres;");
                var redisConn = OpenRedisConnection("redis");
                var redis = redisConn.GetDatabase();

                // Keep alive is not implemented in Npgsql yet. This workaround was recommended:
                // https://github.com/npgsql/npgsql/issues/1214#issuecomment-235828359
                var keepAliveCommand = pgsql.CreateCommand();
                keepAliveCommand.CommandText = "SELECT 1";

                var definition = new { vote = "", voter_id = "" };
                while (true)
                {
                    // Slow down to prevent CPU spike, only query each 100ms
                    Thread.Sleep(100);

                    // Reconnect redis if down
                    if (redisConn == null || !redisConn.IsConnected) {
                        Console.WriteLine("Reconnecting Redis");
                        redisConn = OpenRedisConnection("redis");
                        redis = redisConn.GetDatabase();
                    }
                    string json = redis.ListLeftPopAsync("votes").Result;
                    if (json != null)
                    {
                        var vote = JsonConvert.DeserializeAnonymousType(json, definition);
                        Console.WriteLine($"Processing vote for '{vote.vote}' by '{vote.voter_id}'");

                        var voteLabel = vote.vote == "a" ? "Cats" : "Dogs";

                        // === OBSERVABILITY: Start a trace span for each vote processed ===
                        using var activity = ActivitySource.StartActivity("process-vote");
                        activity?.SetTag("vote", voteLabel);
                        activity?.SetTag("voter_id", vote.voter_id);

                        // === OBSERVABILITY: Child span for reading vote from Redis queue ===
                        using (var redisReadActivity = ActivitySource.StartActivity("read-vote-from-redis"))
                        {
                            redisReadActivity?.SetTag("queue", "votes");
                            redisReadActivity?.SetTag("vote", voteLabel);
                        }

                        try
                        {
                            // Reconnect DB if down
                            if (!pgsql.State.Equals(System.Data.ConnectionState.Open))
                            {
                                Console.WriteLine("Reconnecting DB");
                                pgsql = OpenDbConnection("Server=db;Username=postgres;Password=postgres;");
                            }
                            else
                            { // Normal +1 vote requested
                                UpdateVote(pgsql, vote.voter_id, vote.vote);
                            }
                        }
                        catch (Exception ex)
                        {
                            // === OBSERVABILITY: Mark span as error so it appears in Jaeger error filter ===
                            activity?.SetStatus(ActivityStatusCode.Error, ex.Message);
                            activity?.RecordException(ex);
                            throw;
                        }
                    }
                    else
                    {
                        keepAliveCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
                return 1;
            }
        }

        private static NpgsqlConnection OpenDbConnection(string connectionString)
        {
            NpgsqlConnection connection;

            while (true)
            {
                try
                {
                    connection = new NpgsqlConnection(connectionString);
                    connection.Open();
                    break;
                }
                catch (SocketException)
                {
                    Console.Error.WriteLine("Waiting for db");
                    Thread.Sleep(1000);
                }
                catch (DbException)
                {
                    Console.Error.WriteLine("Waiting for db");
                    Thread.Sleep(1000);
                }
            }

            Console.Error.WriteLine("Connected to db");

            var command = connection.CreateCommand();
            command.CommandText = @"CREATE TABLE IF NOT EXISTS votes (
                                        id VARCHAR(255) NOT NULL UNIQUE,
                                        vote VARCHAR(255) NOT NULL
                                    )";
            command.ExecuteNonQuery();

            return connection;
        }

        private static ConnectionMultiplexer OpenRedisConnection(string hostname)
        {
            // Use IP address to workaround https://github.com/StackExchange/StackExchange.Redis/issues/410
            var ipAddress = GetIp(hostname);
            Console.WriteLine($"Found redis at {ipAddress}");

            while (true)
            {
                try
                {
                    Console.Error.WriteLine("Connecting to redis");
                    return ConnectionMultiplexer.Connect(ipAddress);
                }
                catch (RedisConnectionException)
                {
                    Console.Error.WriteLine("Waiting for redis");
                    Thread.Sleep(1000);
                }
            }
        }

        private static string GetIp(string hostname)
            => Dns.GetHostEntryAsync(hostname)
                .Result
                .AddressList
                .First(a => a.AddressFamily == AddressFamily.InterNetwork)
                .ToString();

        private static void UpdateVote(NpgsqlConnection connection, string voterId, string vote)
        {
            // === OBSERVABILITY: Child span for the database operation (INSERT first vote, UPDATE if changing vote) ===
            using var activity = ActivitySource.StartActivity("save-vote-to-db");
            activity?.SetTag("db.system", "postgresql");
            activity?.SetTag("voter_id", voterId);
            activity?.SetTag("vote", vote == "a" ? "Cats" : "Dogs");

            var command = connection.CreateCommand();
            try
            {
                command.CommandText = "INSERT INTO votes (id, vote) VALUES (@id, @vote)";
                command.Parameters.AddWithValue("@id", voterId);
                command.Parameters.AddWithValue("@vote", vote);
                activity?.SetTag("db.operation", "INSERT");
                command.ExecuteNonQuery();
            }
            catch (DbException)
            {
                command.CommandText = "UPDATE votes SET vote = @vote WHERE id = @id";
                activity?.SetTag("db.operation", "UPDATE");
                command.ExecuteNonQuery();
            }
            finally
            {
                command.Dispose();
            }
        }
    }
}
