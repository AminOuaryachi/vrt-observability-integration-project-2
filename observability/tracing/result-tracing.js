const { NodeSDK } = require('@opentelemetry/sdk-node');
const { OTLPTraceExporter } = require('@opentelemetry/exporter-trace-otlp-http');
const { trace, context } = require('@opentelemetry/api');

// No auto-instrumentation — result-service polls every second and generates too much noise
// Only manual spans are used: client-connected and scores-updated
const sdk = new NodeSDK({
  serviceName: 'result-service',
  traceExporter: new OTLPTraceExporter({
    url: 'http://otel-collector:4318/v1/traces',
  }),
  instrumentations: [],
});

sdk.start();

/** Trace when vote scores change — with child spans for DB result and broadcast */
function traceScoresUpdated(cats, dogs, connectedClients, emitFn) {
  const tracer = trace.getTracer('result-service');
  const parentSpan = tracer.startSpan('scores-updated');
  parentSpan.setAttribute('votes.cats', cats);
  parentSpan.setAttribute('votes.dogs', dogs);

  const ctx = trace.setSpan(context.active(), parentSpan);
  context.with(ctx, () => {
    // Child span: DB query result
    const dbSpan = tracer.startSpan('query-votes-from-db');
    dbSpan.setAttribute('db.system', 'postgresql');
    dbSpan.setAttribute('db.operation', 'SELECT');
    dbSpan.setAttribute('votes.cats', cats);
    dbSpan.setAttribute('votes.dogs', dogs);
    dbSpan.end();

    // Child span: broadcast to clients
    const childSpan = tracer.startSpan('broadcast-to-clients');
    childSpan.setAttribute('connected.clients', connectedClients);
    emitFn();
    childSpan.end();
  });

  parentSpan.end();
}

module.exports = { traceScoresUpdated };
