const { NodeSDK } = require('@opentelemetry/sdk-node');
const { OTLPTraceExporter } = require('@opentelemetry/exporter-trace-otlp-http');
const { trace } = require('@opentelemetry/api');

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

/** Trace when a new client connects to the result page */
function traceClientConnected(socketId) {
  const span = trace.getTracer('result-service').startSpan('client-connected');
  span.setAttribute('socket.id', socketId);
  span.end();
}

/** Trace when vote scores change (new vote processed) */
function traceScoresUpdated(cats, dogs) {
  const span = trace.getTracer('result-service').startSpan('scores-updated');
  span.setAttribute('votes.cats', cats);
  span.setAttribute('votes.dogs', dogs);
  span.end();
}

module.exports = { traceClientConnected, traceScoresUpdated };
