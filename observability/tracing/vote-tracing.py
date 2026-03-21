from opentelemetry import trace
from opentelemetry.sdk.trace import TracerProvider
from opentelemetry.sdk.trace.export import BatchSpanProcessor
from opentelemetry.sdk.resources import Resource
from opentelemetry.exporter.otlp.proto.http.trace_exporter import OTLPSpanExporter
from opentelemetry.instrumentation.flask import FlaskInstrumentor
from opentelemetry.instrumentation.redis import RedisInstrumentor
from opentelemetry.trace import StatusCode


def record_exception(span, exc):
    """Mark a span as error and record the exception details."""
    if span and span.is_recording():
        span.set_status(StatusCode.ERROR, str(exc))
        span.record_exception(exc)


def add_vote_attributes(span, vote, voter_id):
    """Add vote details to the current span so they appear in Jaeger."""
    if span and span.is_recording():
        span.set_attribute("vote.option", vote)
        span.set_attribute("vote.voter_id", voter_id)


def init_tracing(app):
    provider = TracerProvider(resource=Resource({"service.name": "vote-service"}))
    provider.add_span_processor(BatchSpanProcessor(OTLPSpanExporter(
        endpoint="http://otel-collector:4318/v1/traces"
    )))
    trace.set_tracer_provider(provider)
    FlaskInstrumentor().instrument_app(app, excluded_urls="/static/.*")
    RedisInstrumentor().instrument()
