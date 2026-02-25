# Toolkeuze — Observability Stack

> **Status: IN ONDERZOEK**
> Dit document is een lopend onderzoek. De definitieve keuze is nog niet gemaakt. Doel is om elke tool grondig te vergelijken zodat wij onze keuze 100% kunnen verantwoorden — zoals VRT zelf in 2015-2016 ook heeft moeten doen voor honderden systemen.

---

## Aanpak en kader

VRT gaf ons de vrijheid om zowel **open source tools** als **AWS-beheerde diensten** te kiezen, maar verwacht een volledige onderbouwing:
- Wat zijn de voor- en nadelen van elke tool?
- Wanneer gebruik je deze tool wel, wanneer niet?
- Wat is de afweging tussen implementatietijd en kostprijs?
- Is de keuze geschikt voor **short term** (POC/demo), **medium term** of **long term** (productie)?

---

## Pijler 1: Logging

### Kandidaten

---

#### 1.1 Grafana Loki + Promtail

**Wat is het?**
Loki is een log-aggregatiesysteem van Grafana Labs. Het indexeert geen volledige loginhoud, enkel labels (zoals servicenaam, loglevel). Promtail is de agent die logs van Docker-containers verzamelt en naar Loki stuurt.

| | |
|---|---|
| **Type** | Open source (gratis) |
| **Opslag** | Labels-gebaseerd (geen full-text index) |
| **RAM gebruik** | ~100–200 MB |
| **Setup tijd** | ~30 min via Docker Compose |
| **Leercurve** | Laag tot gemiddeld |

**Voordelen**
- Gratis en open source
- Lichtgewicht: veel minder geheugen dan ELK omdat het geen volledige tekst indexeert
- Native integratie met Grafana (zelfde UI voor logs, metrics en traces)
- Promtail leest automatisch Docker container logs zonder code-aanpassingen
- Actief onderhouden door Grafana Labs, grote community

**Nadelen**
- Geen full-text zoeken: je kunt niet zoeken op willekeurige woorden in een log, enkel op labels en via regex
- Minder krachtig voor complexe log-analyse dan Elasticsearch
- Relatief jong project (2018), minder volwassen dan ELK

**Wanneer wel gebruiken?**
- Als logs vooral gefilterd worden op service, level (ERROR/INFO), of trace ID
- Als geheugen en resources beperkt zijn (kleine EC2 instance)
- Als je Grafana al gebruikt voor metrics → alles in één dashboard

**Wanneer niet gebruiken?**
- Als je full-text zoeken nodig hebt over miljoenen logs (bijv. zoeken op een klantnaam)
- Als compliance vereist dat logs jarenlang doorzoekbaar zijn op inhoud
- Bij grote productieomgevingen met honderden services → Elasticsearch schaalt beter

**Short/Medium/Long term?**
- ✅ Short term (POC/demo): uitstekend
- ✅ Medium term (groeiende startup): goed
- ⚠️ Long term (enterprise schaal): mogelijk te beperkt, ELK of managed oplossing overwegen

---

#### 1.2 Elasticsearch + Logstash + Kibana (ELK Stack)

**Wat is het?**
De klassieke log-stack. Logstash verzamelt logs, Elasticsearch slaat ze op en indexeert volledig, Kibana visualiseert.

| | |
|---|---|
| **Type** | Open source (gratis) + betaalde enterprise versie |
| **Opslag** | Full-text geïndexeerd |
| **RAM gebruik** | 2–8 GB minimum |
| **Setup tijd** | 2–4 uur, complex configuratie |
| **Leercurve** | Hoog |

**Voordelen**
- Industrie-standaard voor grote log-volumes
- Krachtige full-text zoekfunctionaliteit
- Flexibele queries (Kibana Query Language)
- Zeer schaalbaar voor enterprise gebruik

**Nadelen**
- Zwaar: vereist minimaal 2 GB RAM voor Elasticsearch alleen
- Complex om op te zetten en te onderhouden
- Logstash zelf is ook resource-intensief (JVM)
- Op kleine EC2 instances moeilijk draaibaar

**Wanneer wel gebruiken?**
- Als je full-text zoeken echt nodig hebt
- Bij grote teams en veel log-volume (honderden GB per dag)
- Als compliance of security auditing vereist is

**Wanneer niet gebruiken?**
- Voor demo of POC projecten (te zwaar)
- Op kleine servers (t2.micro, t3.small)
- Als je team de setup tijd niet heeft

**Short/Medium/Long term?**
- ❌ Short term: te zwaar en te complex
- ⚠️ Medium term: enkel als full-text search vereist is
- ✅ Long term (enterprise): uitstekend

---

#### 1.3 AWS CloudWatch Logs

**Wat is het?**
AWS-beheerde log service. Volledig geïntegreerd in het AWS ecosysteem. Geen extra setup nodig als je al op AWS draait.

| | |
|---|---|
| **Type** | Beheerde AWS dienst (betalend boven gratis laag) |
| **Opslag** | AWS S3-backed |
| **RAM gebruik** | 0 (serverless) |
| **Setup tijd** | ~5–15 min (AWS console klikken) |
| **Leercurve** | Laag |

**Voordelen**
- Bijna geen setup: CloudWatch agent installeert in een paar klikken
- Volledig geïntegreerd met andere AWS diensten (alarms, Lambda, EC2)
- Geen server om te beheren
- Automatische retentie-instellingen

**Nadelen**
- **Betalend**: $0.50 per GB ingested + $0.03 per GB opslag per maand → bij hoog volume loopt dit op
- **Vendor lock-in**: logs zijn alleen via AWS tools doorzoekbaar
- Beperkte visualisatie: CloudWatch dashboards zijn minder flexibel dan Grafana
- Query language (CloudWatch Insights) is minder krachtig dan Loki of Elasticsearch

**Wanneer wel gebruiken?**
- Als je team AWS al volledig gebruikt en geen extra tools wil beheren
- Als budget geen probleem is
- Als integratie met AWS alarms/Lambda triggers vereist is

**Wanneer niet gebruiken?**
- Als je tool-onafhankelijk wilt blijven (geen vendor lock-in)
- Als budget beperkt is (studentenproject, startup)
- Als je Grafana al gebruikt voor metrics → extra complexiteit door 2 aparte systemen

**Short/Medium/Long term?**
- ✅ Short term: snel op te zetten
- ⚠️ Medium term: kosten stijgen bij groei
- ⚠️ Long term: vendor lock-in is een risico

---

#### 1.4 Fluentd / Fluent Bit

**Wat is het?**
Log-collector en router. Verzamelt logs en stuurt ze naar een backend (Elasticsearch, Loki, CloudWatch...). Géén eigen opslag of visualisatie.

**Voordelen**
- Lichtgewicht (Fluent Bit: ~450 KB)
- Flexibel: kan naar meerdere backends tegelijk sturen
- CNCF project

**Nadelen**
- Geen opslag of visualisatie zelf: altijd combineren met een backend
- Voegt complexiteit toe bovenop een andere tool

**Wanneer wel gebruiken?**
- Als je logs naar meerdere bestemmingen wilt sturen tegelijk
- In combinatie met Kubernetes (standaard log-forwarder in veel K8s setups)

**Wanneer niet gebruiken?**
- Als je al Promtail hebt (dan is Fluentd redundant)
- Voor eenvoudige demo-setups

---

### Logging — Vergelijkingstabel

| Criterium | Loki + Promtail | ELK Stack | CloudWatch | Fluentd |
|-----------|----------------|-----------|------------|---------|
| Kostprijs | Gratis | Gratis (self-hosted) | Betalend | Gratis |
| RAM gebruik | ~100-200 MB | 2-8 GB | 0 (serverless) | ~10-50 MB |
| Setup tijd | 30 min | 2-4 uur | 5-15 min | 30 min + backend |
| Full-text zoeken | Nee (enkel labels) | Ja | Beperkt | Nee (router) |
| Grafana integratie | Nativ | Via plugin | Via plugin | Via plugin |
| Vendor lock-in | Geen | Geen | AWS | Geen |
| Short term (demo) | ✅ | ❌ | ✅ | ⚠️ |
| Long term (prod) | ⚠️ | ✅ | ⚠️ | ✅ |

### Voorlopige richting voor logging
→ **Loki + Promtail** lijkt het meest geschikt voor onze context: gratis, lichtgewicht, native Grafana, snel op te zetten. Maar we moeten nog onderzoeken of de beperkte zoekfunctionaliteit voldoende is voor onze scenario's.

---

## Pijler 2: Metrics

### Kandidaten

---

#### 2.1 Prometheus + Grafana

**Wat is het?**
Prometheus is een time-series database die metrics ophaalt (pull model) via HTTP `/metrics` endpoints. Grafana visualiseert de metrics in dashboards.

| | |
|---|---|
| **Type** | Open source (gratis) |
| **Model** | Pull: Prometheus scrapet de services |
| **RAM gebruik** | ~200–500 MB |
| **Setup tijd** | ~1 uur |
| **Leercurve** | Gemiddeld (PromQL query taal) |

**Voordelen**
- Gratis en open source (CNCF graduated project)
- De facto standaard voor container metrics — documentatie en tutorials zijn enorm
- Grote bibliotheek van exporters: Redis exporter, PostgreSQL exporter, Node.js, Python...
- PromQL is krachtig voor het berekenen van rates, percentiles, alerts
- Grafana dashboards zijn te importeren (duizenden kant-en-klare dashboards op grafana.com)

**Nadelen**
- Pull model: elke service moet een `/metrics` endpoint blootstellen (soms extra exporter nodig)
- Geen lange-termijn opslag zonder extra tools (Thanos, Cortex)
- PromQL heeft leercurve
- Geen ingebouwde alerting UI (Alertmanager apart installeren)

**Wanneer wel gebruiken?**
- Als je containers/microservices monitort
- Als je Grafana al gebruikt (alles in één systeem)
- Als je PromQL queries wilt schrijven voor geavanceerde alerts

**Wanneer niet gebruiken?**
- Als services geen HTTP endpoint kunnen blootstellen (bijv. embedded systemen)
- Als je lange historische opslag nodig hebt zonder extra tooling
- Als het team geen tijd heeft om PromQL te leren

**Short/Medium/Long term?**
- ✅ Short term: goed (snel + gratis)
- ✅ Medium term: uitstekend
- ✅ Long term: uitstekend (met Thanos voor HA)

---

#### 2.2 AWS CloudWatch Metrics

**Wat is het?**
AWS-beheerde metrics service. EC2, RDS, ECS publiceren automatisch metrics naar CloudWatch zonder configuratie.

| | |
|---|---|
| **Type** | Beheerde AWS dienst |
| **Model** | Push (automatisch voor AWS services) |
| **Setup tijd** | 0 min voor AWS services, 15 min voor custom metrics |
| **Leercurve** | Laag |

**Voordelen**
- AWS services (EC2, RDS) rapporteren automatisch metrics — geen configuratie
- Geïntegreerd met CloudWatch Alarms en SNS voor notifications
- Geen server om te beheren
- Ondersteunt custom metrics via API

**Nadelen**
- **Betalend**: $0.30 per metric per maand voor custom metrics
- Beperkte flexibiliteit in dashboards vs Grafana
- Vendor lock-in
- Geen metrics voor applicatie-level data tenzij je de CloudWatch SDK integreert in elke service

**Wanneer wel gebruiken?**
- Als je enkel AWS infrastructure metrics nodig hebt (CPU, RAM, disk van EC2)
- Als het team geen tijd heeft voor Prometheus setup

**Wanneer niet gebruiken?**
- Als je applicatie-level metrics (aantal votes, response time per endpoint) wilt
- Als Grafana al gebruikt wordt

**Short/Medium/Long term?**
- ✅ Short term: voor infra metrics
- ⚠️ Medium term: kostprijs stijgt
- ❌ Long term: vendor lock-in en kosten

---

#### 2.3 Datadog

**Wat is het?**
Volledig beheerde monitoring SaaS. Combineert metrics, logs en traces in één platform.

**Voordelen**
- Alles in één (metrics, logs, traces, dashboards, alerts)
- Automatische service discovery
- Uitstekende UX

**Nadelen**
- **Zeer duur**: $15–23 per host per maand
- Vendor lock-in
- Niet realistisch voor studentenproject

**Wanneer wel gebruiken?**
- Grote bedrijven met budget en kleine DevOps teams
- Wanneer implementatietijd kostbaarder is dan licentiekosten

**Wanneer niet gebruiken?**
- Studentenproject
- Wanneer je zelf wilt begrijpen hoe observability werkt

---

#### 2.4 InfluxDB + Telegraf + Grafana (TIG Stack)

**Wat is het?**
InfluxDB is een time-series database, Telegraf verzamelt metrics (push model), Grafana visualiseert.

**Voordelen**
- Push model: services sturen metrics actief → geen `/metrics` endpoint nodig
- Flexibele query taal (Flux)

**Nadelen**
- Minder community support dan Prometheus voor containeromgevingen
- Extra tool (Telegraf) bovenop wat je al nodig hebt
- InfluxDB 2.x is minder volwassen in de open source versie

---

### Metrics — Vergelijkingstabel

| Criterium | Prometheus + Grafana | CloudWatch | Datadog | InfluxDB |
|-----------|---------------------|------------|---------|---------|
| Kostprijs | Gratis | Betalend | Duur | Gratis (OSS) |
| Model | Pull | Push (AWS) | Push | Push |
| App-level metrics | Ja (via exporters) | Beperkt | Ja | Ja |
| Dashboards | Grafana | CloudWatch | Ingebouwd | Grafana |
| Vendor lock-in | Geen | AWS | Datadog | Geen |
| Community | Enorm | Gemiddeld | Groot | Gemiddeld |
| Short term | ✅ | ✅ | ⚠️ (duur) | ⚠️ |
| Long term | ✅ | ⚠️ | ✅ | ⚠️ |

### Voorlopige richting voor metrics
→ **Prometheus + Grafana** is de standaard in de industrie voor containeromgevingen. We moeten nog de exporters onderzoeken voor Redis en PostgreSQL.

---

## Pijler 3: Distributed Tracing

### Kandidaten

---

#### 3.1 Jaeger

**Wat is het?**
Open source distributed tracing systeem, gecreëerd door Uber. CNCF graduated project.

| | |
|---|---|
| **Type** | Open source (gratis) |
| **Protocols** | Jaeger native, Zipkin, OTLP |
| **RAM gebruik** | ~200 MB (all-in-one) |
| **Setup tijd** | ~30 min |
| **Taalondersteuning** | Python, .NET, Node.js, Go, Java... |

**Voordelen**
- Gratis en open source (gecreëerd door Uber voor hun eigen microservices)
- CNCF graduated: actief onderhouden, grote community
- All-in-one Docker image perfect voor dev/demo
- Grafana datasource plugin beschikbaar → traces zichtbaar naast logs en metrics
- Ondersteunt alle talen van de Voting App (Python, C#/.NET, Node.js)
- Werkt met OpenTelemetry SDK (geen vendor lock-in voor instrumentatie)

**Nadelen**
- All-in-one slaat data op in geheugen → herstart = traces weg (voor productie: Cassandra/Elasticsearch backend nodig)
- UI is functioneel maar minder mooi dan sommige alternatieven
- Minder actieve ontwikkeling dan Grafana Tempo

**Wanneer wel gebruiken?**
- Demo en POC: all-in-one image is ideaal
- Als Grafana al gebruikt wordt (native datasource)
- Multi-language omgevingen

**Wanneer niet gebruiken?**
- Als traces meerdere weken bewaard moeten worden (dan Cassandra/ES backend instellen)
- Als de UI een harde vereiste is

**Short/Medium/Long term?**
- ✅ Short term: uitstekend (all-in-one)
- ✅ Medium term: goed (met persistente opslag)
- ⚠️ Long term: Tempo of Jaeger met Cassandra overwegen

---

#### 3.2 Grafana Tempo

**Wat is het?**
Open source tracing backend van Grafana Labs. Gebouwd voor kostenefficiënte opslag via object storage (S3, GCS).

**Voordelen**
- Gratis en open source
- Goedkope opslag via S3 (cents per GB)
- Native Grafana integratie
- Ondersteunt OTLP, Jaeger, Zipkin formaten

**Nadelen**
- **Geen eigen UI**: traces alleen bekijken via Grafana (geen standalone trace explorer)
- Jonger project dan Jaeger → minder community resources
- Vereist een object storage backend voor productie (extra configuratie)

**Wanneer wel gebruiken?**
- Als Grafana al centraal staat en je geen aparte trace UI wilt
- Als je goedkope lange-termijn opslag wilt via S3

**Wanneer niet gebruiken?**
- Als je een standalone trace UI wilt voor collega's die geen Grafana kennen
- Voor een eerste demo (meer configuratie dan Jaeger all-in-one)

**Short/Medium/Long term?**
- ⚠️ Short term: meer setup dan Jaeger
- ✅ Medium term: uitstekend
- ✅ Long term: kostenefficiënt

---

#### 3.3 Zipkin

**Wat is het?**
Oorspronkelijk open source tracing systeem van Twitter.

**Voordelen**
- Simpel op te zetten
- Goed gedocumenteerd (oud project)

**Nadelen**
- Minder actief onderhouden dan Jaeger of Tempo
- Kleiner ecosysteem
- Minder integraties

**Wanneer wel gebruiken?**
- Als bestaande code al Zipkin gebruikt

**Wanneer niet gebruiken?**
- Nieuw project: kies Jaeger of Tempo (actiever onderhouden)

---

#### 3.4 AWS X-Ray

**Wat is het?**
AWS-beheerde distributed tracing service.

**Voordelen**
- Geïntegreerd met AWS Lambda, ECS, API Gateway
- Geen server om te beheren
- Service map automatisch gegenereerd

**Nadelen**
- **Betalend**: $5 per miljoen traces (gratis laag: eerste 100k gratis)
- Vendor lock-in: AWS X-Ray SDK moet in elke service geïntegreerd worden
- Als je later van AWS wisselt, moet je alle instrumentatie herschrijven
- Geen Grafana integratie

**Wanneer wel gebruiken?**
- Als je volledig in het AWS ecosysteem zit (Lambda, ECS)
- Als je de AWS SDK toch al gebruikt

**Wanneer niet gebruiken?**
- Als je vendor lock-in wilt vermijden
- Als je OpenTelemetry gebruikt (dan is Jaeger/Tempo beter)
- Multi-cloud of cloud-agnostische strategie

---

#### 3.5 OpenTelemetry (instrumentatielaag)

> **Belangrijk:** OpenTelemetry is **geen** tracing backend — het is de SDK/standaard om traces, metrics en logs te *verzamelen*. Je combineert OpenTelemetry altijd met een backend (Jaeger, Tempo, X-Ray...).

**Voordelen**
- Open standaard (CNCF): geen vendor lock-in voor instrumentatie
- SDKs voor Python, .NET, Node.js, Go, Java...
- Als je later van Jaeger naar Tempo of X-Ray wilt: enkel de exporter wijzigen, niet de instrumentatiecode
- Gesteund door Google, Microsoft, AWS, Splunk, Datadog

**Wanneer gebruiken?**
- Altijd: gebruik OpenTelemetry als instrumentatielaag, dan kies je vrij de backend

---

### Tracing — Vergelijkingstabel

| Criterium | Jaeger | Grafana Tempo | Zipkin | AWS X-Ray |
|-----------|--------|--------------|--------|-----------|
| Kostprijs | Gratis | Gratis | Gratis | Betalend |
| Eigen UI | Ja | Nee (via Grafana) | Ja | Ja |
| Grafana integratie | Plugin | Nativ | Plugin | Nee |
| Languages | Alle (via OTel) | Alle (via OTel) | Beperkt | AWS SDK |
| Vendor lock-in | Geen | Geen | Geen | AWS |
| All-in-one Docker | Ja | Nee | Ja | N/A |
| Short term (demo) | ✅ | ⚠️ | ⚠️ | ✅ |
| Long term (prod) | ⚠️ | ✅ | ❌ | ⚠️ |

### Voorlopige richting voor tracing
→ **Jaeger + OpenTelemetry SDK** voor de demo fase (all-in-one, snel). Op lange termijn zou **Grafana Tempo** een betere keuze zijn voor productie omwille van de kostenefficiëntie.

---

## Overkoepelende afweging: Open Source vs AWS Diensten

VRT zei expliciet: beide mogen, maar je moet de keuze verantwoorden.

| Factor | Open Source (Loki/Prometheus/Jaeger) | AWS Diensten (CloudWatch/X-Ray) |
|--------|--------------------------------------|---------------------------------|
| Kostprijs | Gratis (enkel compute kost) | Betalend per gebruik |
| Vendor lock-in | Geen | Sterk (moeilijk te migreren) |
| Setup tijd | Meer initiële configuratie | Sneller via console |
| Onderhoud | Zelf verantwoordelijk | AWS beheert |
| Portabiliteit | Draait overal (AWS, Azure, on-premise) | Alleen op AWS |
| Leerwaarde | Hoog: je begrijpt de internals | Lager: abstractie laag |
| Productie gebruik | Ja (GitLab, Uber, Bloomberg) | Ja (bij AWS-native bedrijven) |

**Redenering voor dit project:**
Het doel van het project is om de drie pijlers zelf op te bouwen en te begrijpen. AWS-diensten abstraheren te veel weg. Bovendien zijn de open source tools (Prometheus, Loki, Jaeger) dezelfde tools die VRT of andere grote bedrijven naast AWS tools gebruiken — het is geen "student speelgoed".

---

## Short / Medium / Long Term Perspectief

(Gebaseerd op het kader dat VRT aanhaalde in het gesprek)

| Termijn | Scenario | Logging | Metrics | Tracing |
|---------|----------|---------|---------|---------|
| **Short term** (demo, POC, dit project) | Snel opzetten, beperkte resources | Loki + Promtail | Prometheus + Grafana | Jaeger all-in-one + OTel |
| **Medium term** (groeiende startup, 6-12 maanden) | Meer volume, stabiliteit | Loki met persistente opslag | Prometheus + Alertmanager | Jaeger met Cassandra backend |
| **Long term** (enterprise, jaren) | Hoge beschikbaarheid, multi-team | Elasticsearch of managed Loki | Prometheus + Thanos (HA) | Grafana Tempo met S3 |

---

## Volgende stap

- [ ] Elk tool effectief uitproberen in Docker Compose
- [ ] Meten: hoeveel RAM verbruikt elk tool op onze EC2 instance?
- [ ] Testen: kunnen we een trace end-to-end zien in de Voting App?
- [ ] Definitieve keuze documenteren met concrete bevindingen
