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

/** Trace when a new client connects to the result page */
function traceClientConnected(socketId) {
  const span = trace.getTracer('result-service').startSpan('client-connected');
  span.setAttribute('socket.id', socketId);
  span.end();
}

/** Trace when vote scores change — with child span for the broadcast to clients */
function traceScoresUpdated(cats, dogs, emitFn) {
  const tracer = trace.getTracer('result-service');
  const parentSpan = tracer.startSpan('scores-updated');
  parentSpan.setAttribute('votes.cats', cats);
  parentSpan.setAttribute('votes.dogs', dogs);

  const ctx = trace.setSpan(context.active(), parentSpan);
  context.with(ctx, () => {
    const childSpan = tracer.startSpan('broadcast-to-clients');
    emitFn();
    childSpan.end();
  });

  parentSpan.end();
}

module.exports = { traceClientConnected, traceScoresUpdated };
