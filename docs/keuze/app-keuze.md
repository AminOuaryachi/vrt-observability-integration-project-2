# App-keuze — Demo-applicatie voor Observability

## Onderzochte apps

### 1. Docker Awesome-Compose (React + Express + MongoDB)
- **Repo:** https://github.com/docker/awesome-compose/tree/master/react-express-mongodb
- **Services:** 3 (Frontend, Backend, Database)
- **Talen:** JavaScript
- **Docker-compose:** Ja
- **Observability:** Geen

### 2. Docker Example Voting App
- **Repo:** https://github.com/dockersamples/example-voting-app
- **Services:** 5 (Vote Frontend, Redis, Worker, PostgreSQL, Result Frontend)
- **Talen:** Python, C#, Node.js
- **Docker-compose:** Ja
- **Observability:** Geen

### 3. ebosas/microservices (Go + RabbitMQ + PostgreSQL + Redis + React)
- **Repo:** https://github.com/ebosas/microservices
- **Services:** 5 (Frontend, Backend, RabbitMQ, PostgreSQL, Redis)
- **Talen:** Go, TypeScript
- **Docker-compose:** Ja
- **Observability:** Geen
- **Extra:** Bevat kant-en-klare AWS deploy (CloudFormation voor ECS/Fargate)

### 4. OpenTelemetry Astronomy Shop
- **Repo:** https://github.com/open-telemetry/opentelemetry-demo
- **Services:** 11+ microservices
- **Talen:** Go, Python, Java, Node.js, .NET, PHP, Ruby
- **Docker-compose:** Ja
- **Observability:** Ja — volledige stack reeds ingebouwd (Jaeger, Prometheus, Grafana)

### 5. AWS Labs (one-observability-demo, EKS demo)
- **Repo:** https://github.com/aws-samples/one-observability-demo
- **Services:** Meerdere (Lambda, ECS, EKS)
- **Docker-compose:** Nee (CloudFormation/EKS)
- **Observability:** Ja — CloudWatch, X-Ray reeds ingebouwd

## Vergelijking

| Criterium | Awesome-Compose | Voting App | ebosas | OTel Demo | AWS Labs |
|-----------|----------------|------------|--------|-----------|----------|
| Aantal services | 3 | 5 | 5 | 11+ | Meerdere |
| Frontend | Ja (React) | Ja (2x: Vote + Result) | Ja (React) | Ja | Ja |
| Hops per request | 1 | 3-4 | 3-4 | 5+ | Meerdere |
| Talen | 1 | 3 | 2 | 7+ | Meerdere |
| Observability ingebouwd | Nee | Nee | Nee | Ja | Ja |
| AWS deploy ingebouwd | Nee | Nee | Ja | Nee | Ja |

## Gekozen: Docker Example Voting App

### Waarom de Voting App?
- **5 services met 3-4 hops** — voldoende om distributed tracing goed te demonstreren
- **2 frontends** (Vote + Result) — meerdere ingangspunten om te monitoren
- **3 programmeertalen** (Python, C#, Node.js) — toont aan dat observability over verschillende talen werkt
- **Geen ingebouwde observability** — wij bouwen de volledige stack zelf op
- **Officieel Docker voorbeeld** — goed gedocumenteerd, grote community, veel tutorials beschikbaar

### Waarom niet OpenTelemetry Demo en AWS Labs?
Beide hebben reeds een volledige observability-stack ingebouwd. Het doel van ons project is om zelf de drie pijlers (logging, metrics, tracing) op te zetten. We wilden bewust een app zonder observability zodat we alles zelf kunnen integreren en begrijpen.

### Waarom niet Awesome-Compose?
Slechts 3 services met 1 hop — onvoldoende om distributed tracing goed te demonstreren. Maar 1 programmeertaal, minder interessant om te tonen.

### Waarom niet ebosas/microservices?
Deze repo bevat kant-en-klare AWS deployment scripts (CloudFormation). Wij wilden zelf leren hoe we de applicatie op AWS deployen en de infrastructuur opzetten. Later kunnen we eventueel zelf een geautomatiseerde deployment bouwen op basis van onze eigen ervaring.
