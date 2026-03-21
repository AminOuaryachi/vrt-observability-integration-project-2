const { NodeSDK } = require('@opentelemetry/sdk-node');
const { OTLPTraceExporter } = require('@opentelemetry/exporter-trace-otlp-http');
const { getNodeAutoInstrumentations } = require('@opentelemetry/auto-instrumentations-node');

const sdk = new NodeSDK({
  serviceName: 'result-service',
  traceExporter: new OTLPTraceExporter({
    url: 'http://otel-collector:4318/v1/traces',
  }),
  instrumentations: [
    getNodeAutoInstrumentations({
      // Disable fs instrumentation — generates too much noise (realpathSync, readFileSync)
      '@opentelemetry/instrumentation-fs': { enabled: false },
      // Disable pg instrumentation — result polls DB every second, generates thousands of spans
      '@opentelemetry/instrumentation-pg': { enabled: false },
    }),
  ],
});

sdk.start();
