from opentelemetry import trace
from opentelemetry.sdk.trace import TracerProvider
from opentelemetry.sdk.trace.export import BatchSpanProcessor
from opentelemetry.sdk.resources import Resource
from opentelemetry.exporter.otlp.proto.http.trace_exporter import OTLPSpanExporter
from opentelemetry.instrumentation.flask import FlaskInstrumentor
from opentelemetry.instrumentation.redis import RedisInstrumentor


def init_tracing(app):
    provider = TracerProvider(resource=Resource({"service.name": "vote-service"}))
    provider.add_span_processor(BatchSpanProcessor(OTLPSpanExporter(
        endpoint="http://otel-collector:4318/v1/traces"
    )))
    trace.set_tracer_provider(provider)
    FlaskInstrumentor().instrument_app(app)
    RedisInstrumentor().instrument()
