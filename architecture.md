# Architecture — VRT Observability Integration Project

## Project Overview

This project implements a full observability stack on AWS for a multi-service voting application. The goal is to demonstrate the three pillars of observability — **Logging**, **Metrics**, and **Distributed Tracing** — and to show how correlating all three enables fast incident detection and root cause analysis (target: under 10 minutes).

The project is carried out in collaboration with VRT, who provided a sandboxed AWS environment. The chosen application is the **Docker Example Voting App**, an open-source multi-service application without built-in observability, allowing the team to integrate all three pillars from scratch.

---

## Application Architecture

The application is based on the [Docker Example Voting App](https://github.com/dockersamples/example-voting-app). It consists of five services that communicate across two network tiers.

### Services

| Service | Language | Role |
|---------|----------|------|
| **vote** | Python (Flask + Gunicorn) | Frontend — allows users to cast a vote (Cats vs Dogs) |
| **redis** | Redis (alpine) | Message queue — temporarily stores incoming votes |
| **worker** | C# (.NET 7) | Background processor — reads votes from Redis and writes to PostgreSQL |
| **db** | PostgreSQL 15 | Persistent storage — stores processed votes |
| **result** | Node.js (Express + Socket.IO) | Frontend — displays live vote results |

### Communication Flow

```
User (browser)
    │
    ▼
[vote :8080]  ── POST vote ──►  [redis]
                                    │
                                    ▼
                               [worker]  ──► [db (postgres)]
                                                   │
[result :8081] ◄── SQL query every 1s ────────────┘
    │
    ▼
User (browser, live results via WebSocket)
```

### Networks

- **front-tier** — connects `vote` and `result` services (user-facing)
- **back-tier** — connects `redis`, `worker`, `db`, `vote`, and `result` (internal)

### Ports

| Service | Host Port | Container Port |
|---------|-----------|----------------|
| vote    | 8080      | 80             |
| result  | 8081      | 80 / 4000      |

---

## Infrastructure

The application is deployed on **AWS** within a VRT-provided sandbox environment.

### AWS Setup

- **Compute**: EC2 (Ubuntu/Amazon Linux) with Docker and Docker Compose, or ECS containers
- **Networking**: VPC with public subnets (vote, result) and private subnets (worker, db, redis)
- **Security Groups**:
  - Vote & Result: port 80/443 open to the internet
  - Worker & Redis: accessible only from internal services
  - PostgreSQL: accessible only from the worker service
- **Database**: PostgreSQL running in a Docker container on EC2, or Amazon RDS

### Repository Structure

```
.
├── app/                        # Application source code
│   ├── docker-compose.yml      # Local development compose file
│   ├── vote/                   # Python Flask voting frontend
│   ├── result/                 # Node.js result frontend
│   ├── worker/                 # C# .NET background worker
│   ├── seed-data/              # Optional: seed the DB with test votes
│   ├── healthchecks/           # Health check scripts for Redis and PostgreSQL
│   └── run-app.md              # Instructions to run the app locally
├── observability/              # Observability configuration (to be implemented)
│   ├── logging/                # Logging stack configuration
│   ├── metrics/                # Metrics stack configuration
│   └── tracing/                # Tracing stack configuration
├── infrastructure/             # AWS infrastructure definitions
│   └── aws/                    # AWS-specific configuration
├── scenarios/                  # Fault injection scenarios
├── docs/                       # Project documentation and decision records
│   ├── help/                   # Project explanation and planning documents
│   └── keuze/                  # Tool selection research and decisions
└── architecture.md             # This document
```

---

## Observability Stack

The observability strategy is based on three pillars. The team chose **open-source tools** over SaaS solutions for full control, no vendor lock-in, and predictable cost at scale.

### Pillar 1 — Logging

**Purpose**: Centralize logs from all services so that the *why* of a problem can be identified.

Each service produces logs. These are collected, forwarded to a central backend, and made searchable. Alerts are configured on error patterns (e.g. `ERROR`, `500`, `timeout`).

**Evaluated options**:
- AWS CloudWatch Logs (native, managed, pay-per-volume)
- ELK Stack (Elasticsearch + Logstash + Kibana) — powerful, complex setup
- Grafana Loki — lightweight, integrates natively with Grafana
- Fluentd / Fluent Bit — log collectors/forwarders

### Pillar 2 — Metrics

**Purpose**: Provide quantitative indicators (CPU, memory, request rate, error rate, latency) to detect *that* a problem exists.

Metrics exporters are deployed on each service and scraped by a central collector. Dashboards visualise service health. Alerts fire when thresholds are exceeded.

**Evaluated options**:
- AWS CloudWatch Metrics (native, managed, pay-per-metric)
- Prometheus + Grafana — open-source industry standard
- AWS Managed Prometheus + Managed Grafana
- Datadog — SaaS, full-featured

### Pillar 3 — Distributed Tracing

**Purpose**: Follow a request end-to-end across all services to locate *where* a problem is occurring.

Each service is instrumented to emit trace spans. A trace collector aggregates them, and a tracing backend provides visualisation of the full request lifecycle.

**Evaluated options**:
- AWS X-Ray (native AWS integration)
- Jaeger (CNCF open source, widely adopted)
- Zipkin (open source, simpler)
- OpenTelemetry (vendor-neutral SDK/collector — sends data to Jaeger, X-Ray, or Tempo)

### Tool Selection Rationale

Open-source tools were chosen over SaaS for the following reasons:

- **No recurring costs** — costs remain constant regardless of data volume
- **No vendor lock-in** — configuration lives in the repository as code
- **Full transparency** — the full behaviour of each tool is inspectable and modifiable
- **Industry adoption** — tools like Prometheus (created by SoundCloud), Jaeger (created by Uber), and Loki (Grafana Labs) are used in production at large organisations

SaaS tools are faster to set up initially, but open source wins on the long term for a project where control and cost predictability are priorities.

---

## Correlation Between Pillars

The key objective is to correlate all three pillars using a shared **Trace ID**:

| Pillar  | Shows... | How it uses Trace ID |
|---------|----------|----------------------|
| Metrics | *That* a problem exists | Exemplars or annotations linking metrics to traces |
| Traces  | *Where* the problem is (which service) | Trace ID is the primary identifier |
| Logs    | *Why* the problem occurred (error detail) | Each log line includes the Trace ID |

This enables the following incident investigation workflow:

1. **Metrics** trigger an alert — e.g. error rate spikes on the `result` service
2. **Traces** identify the failing service and the specific request path
3. **Logs** expose the root cause — e.g. a `connection refused` to PostgreSQL

---

## Fault Injection Scenarios

The following failure scenarios are defined to validate the observability stack. The target detection time for each scenario is under 10 minutes.

| Scenario | Action | Expected Detection |
|----------|--------|--------------------|
| Frontend crash | Stop the `vote` or `result` container | Metrics: service DOWN alert |
| Backend/worker crash | Stop the `worker` container | Metrics: vote processing stops; logs: no writes to DB |
| Database unavailable | Cut access to `db` (change Security Group or stop container) | Logs: `connection refused`; traces: DB span fails |
| High latency | Inject artificial delay (e.g. `sleep 5s`) in the worker | Traces: abnormally long span; metrics: response time increases |
| Application error | Introduce a bug on a specific route | Logs: exception stack trace; traces: error on the affected span |

Each scenario is documented with:
- A screenshot of the normal state (before)
- The action taken to inject the fault
- Screenshots of dashboards, traces, and logs showing the detection
- The time from fault injection to identification of root cause

---

## Running the Application Locally

### Prerequisites

- Docker and Docker Compose installed

### Start

```bash
cd app
docker compose up -d
```

### Access

- **Vote**: [http://localhost:8080](http://localhost:8080)
- **Results**: [http://localhost:8081](http://localhost:8081)

### Seed test data (optional)

```bash
cd app
docker compose --profile seed up -d
```

### Stop

```bash
cd app
docker compose down
```

---

## Key Dates

| Date | Milestone |
|------|-----------|
| Sprint 1–2 | Research & tool selection |
| Sprint 3–4 | Deploy application on AWS |
| Sprint 5–7 | Implement logging, metrics, and tracing |
| Sprint 8–9 | Fault injection scenarios and validation |
| **1 April** | **Demo 1 — MVP**: working app + at least one pillar + one live failure scenario |
| June | Final delivery and presentation |

---

## Further Documentation

- [`docs/help/ProjetVRT_Explication.md`](docs/help/ProjetVRT_Explication.md) — Full project explanation and sprint planning (French)
- [`docs/help/ProjetVRT_Uitleg_NL.md`](docs/help/ProjetVRT_Uitleg_NL.md) — Project explanation (Dutch)
- [`docs/keuze/toolkeuze.md`](docs/keuze/toolkeuze.md) — Observability tool selection research (Dutch)
- [`docs/keuze/app-keuze.md`](docs/keuze/app-keuze.md) — Application selection research (Dutch)
- [`app/run-app.md`](app/run-app.md) — How to run the application locally
