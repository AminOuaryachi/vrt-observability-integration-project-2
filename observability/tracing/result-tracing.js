const { NodeSDK } = require('@opentelemetry/sdk-node');
const { OTLPTraceExporter } = require('@opentelemetry/exporter-trace-otlp-http');
const { getNodeAutoInstrumentations } = require('@opentelemetry/auto-instrumentations-node');
const { trace } = require('@opentelemetry/api');

const sdk = new NodeSDK({
  serviceName: 'result-service',
  traceExporter: new OTLPTraceExporter({
    url: 'http://otel-collector:4318/v1/traces',
  }),
  instrumentations: [
    getNodeAutoInstrumentations({
      // Disable noisy instrumentations — only keep HTTP (express) for meaningful traces
      '@opentelemetry/instrumentation-fs': { enabled: false },
      '@opentelemetry/instrumentation-pg': { enabled: false },
      '@opentelemetry/instrumentation-dns': { enabled: false },
      '@opentelemetry/instrumentation-net': { enabled: false },
    }),
  ],
});

sdk.start();

const tracer = trace.getTracer('result-service');

/** Trace when a new client connects to the result page */
function traceClientConnected(socketId) {
  const span = tracer.startSpan('client-connected');
  span.setAttribute('socket.id', socketId);
  span.end();
}

/** Trace when vote scores change (new vote processed) */
function traceScoresUpdated(cats, dogs) {
  const span = tracer.startSpan('scores-updated');
  span.setAttribute('votes.cats', cats);
  span.setAttribute('votes.dogs', dogs);
  span.end();
}

module.exports = { traceClientConnected, traceScoresUpdated };
