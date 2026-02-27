# Toolkeuze — Observability Stack

> **Status: IN ONDERZOEK**
> Dit document is een lopend onderzoek. De definitieve keuze is nog niet gemaakt. Doel is om elke tool grondig te vergelijken zodat wij onze keuze 100% kunnen verantwoorden.

---

## Stap 1 — Open Source of SaaS?

De eerste beslissing is niet welke tool we kiezen, maar uit welke categorie.

### SaaS

SaaS-tools (Datadog, New Relic, Honeycomb...) zijn diensten waar je een abonnement voor betaalt. Je installeert een agent, logt in en alles werkt — in enkele minuten. De leverancier zorgt voor updates, beheer en support. Maar de prijs stijgt mee met hoeveel data je verstuurt: je betaalt per GB, per server, per miljoen traces. Je data gaat naar de servers van een ander bedrijf. Je dashboards en instellingen zitten opgesloten in hun systeem — als je stopt met betalen, kun je die niet meenemen naar een andere tool.

### Open Source

Open source tools (Jaeger, Prometheus, Loki...) installeer je zelf op je eigen servers. De code is publiek beschikbaar: je ziet exact wat er met je data gebeurt, hoe alles werkt — niets is verborgen. Je bent niet afhankelijk van één bedrijf: als een leverancier de prijs verhoogt of een functie schrapt, zit je bij SaaS vast. Bij open source kies je zelf wat je doet. De tools worden verbeterd door duizenden mensen wereldwijd die ze zelf gebruiken. De setup vraagt meer tijd en je beheert alles zelf, maar de enige kost is de server die je toch al nodig hebt voor de applicatie.

### Onze keuze: Open Source

SaaS is sneller om op te zetten — dat is een eerlijk voordeel. Maar we kiezen open source omdat het dingen biedt die SaaS niet heeft.

SaaS beheert alles automatisch, maar bij open source bepaal jij hoe alles werkt: hoeveel data je bijhoudt, hoe lang, wat je filtert. Dat geeft meer vrijheid. SaaS heeft officiële support, maar de community rond tools zoals Prometheus en Jaeger is enorm — gedragen door engineers van Google, Microsoft en Red Hat.

Je steekt meer tijd in de setup, maar in ruil heb je geen maandelijkse kosten die stijgen met gebruik, geen leverancier die morgen de regels verandert, en al je instellingen staan als bestanden in je eigen project.

Op **korte termijn** is SaaS sneller en eenvoudiger. Op **lange termijn** wint open source: de kost blijft gelijk ongeacht hoeveel data je hebt, je zit niet vast aan één leverancier, en je past alles aan zoals je wil.

**Uber** heeft Jaeger zelf gebouwd voor hun eigen systemen. **SoundCloud** heeft Prometheus gemaakt. **Bloomberg** en **GitLab** draaien deze zelfde tools in productie. Dit zijn geen studententools — dit is wat grote bedrijven ook gebruiken.

---

## Stap 2 — Toolkeuze per pijler

### Pijler 1: Distributed Tracing

Distributed tracing volgt een request van begin tot einde doorheen alle services. Elke stap heet een **span**, een volledige keten van spans heet een **trace**. Het doel is te zien waar een request traag wordt, waar het faalt, en welke service verantwoordelijk is.

#### Onderzochte open source tools

**Zipkin** is gemaakt door Twitter en is de oudste open source tracing tool. Simpel op te zetten, lage leercurve. Maar Zipkin staat in **maintenance-only mode** — er komen geen nieuwe features meer, enkel nog afhankelijkheidsupdates. Voor een nieuw project bouw je niet op een tool die niet meer actief ontwikkeld wordt. Bovendien heeft Zipkin geen native OpenTelemetry support — een adapter is nodig. Afgevallen.

**Apache SkyWalking** is een volledig APM platform: tracing, metrics, logs én profiling in één. Gebruikt door grote bedrijven zoals Alibaba en Huawei. Maar het vereist 32GB RAM en 8 CPU cores voor een volledige setup, heeft een hoge leercurve en biedt veel meer dan wat we nodig hebben voor tracing. Overkill. Afgevallen.

**SigNoz** is een moderne open source tool gebouwd op OpenTelemetry met ClickHouse als opslag. Goede UI, actief ontwikkeld. Maar SigNoz is een **alternatief voor Grafana** — het vervangt de volledige visualisatielaag. Als wij Grafana als centrale tool gebruiken voor alle drie de pijlers, past SigNoz niet in de architectuur. Afgevallen.

Dit laat twee serieuze kandidaten over: **Jaeger** en **Grafana Tempo**.

---

#### Jaeger vs Grafana Tempo

**Jaeger** is gemaakt door Uber in 2015 voor hun eigen microservices omgeving. Opengesteld als open source in 2017 en overgedragen aan de CNCF, waar het in 2019 het hoogste volwassenheidsniveau behaalde: Graduated — hetzelfde niveau als Kubernetes. In november 2024 werd Jaeger v2 uitgebracht, waarbij de OpenTelemetry Collector intern gebruikt wordt. Het heeft 22.500 GitHub stars en 1.359 actieve bijdragers van 597 verschillende bedrijven.

**Grafana Tempo** is gemaakt door Grafana Labs in 2020. Het gebruikt object storage (S3) in plaats van een database, waardoor opslagkosten laag blijven. Het heeft geen eigen UI — alles gaat via Grafana. Het heeft 5.100 GitHub stars.

**Schaalbaarheid**

Beide tools schalen horizontaal: elk onderdeel kan apart uitgebreid worden zonder downtime. Tempo heeft een voordeel op lange termijn omdat S3 oneindig schaalt zonder extra server. Jaeger heeft Elasticsearch of Cassandra nodig als storage backend, die apart beheerd moet worden.

**Onderhoudsvriendelijkheid**

Tempo is eenvoudiger te onderhouden: minder onderdelen, geen database op eigen servers. Jaeger vereist actief beheer van de storage backend — indexen opkuisen, retentie instellen, performantie bewaken. Jaeger v1 bereikte einde levensduur op 31 december 2025, v2 is de huidige versie.

**Leercurve**

Jaeger heeft een eigen UI die direct bruikbaar is. Tempo heeft geen eigen UI — je moet TraceQL leren en alles gaat via Grafana. Beide tools vereisen kennis van distributed tracing concepten (spans, trace ID, context propagation) en OpenTelemetry SDK configuratie.

**Zoekfunctie**

Dit is het beslissende verschil. Jaeger laat toe te zoeken op servicenaam, HTTP status, fouttype, duur en willekeurige attributen. In de praktijk weet je de trace ID nooit op voorhand — je ziet een probleem en wil alle traces vinden die gefaald hebben of traag waren. Tempo kan enkel zoeken op trace ID of via TraceQL queries. Voor het debuggen van failure scenarios — wat een kernonderdeel is van dit project — is Jaeger's zoekfunctie een echte operationele noodzaak.

**Community en gebruik in productie**

Jaeger is een CNCF Graduated project met 22.500 stars. In de onderzochte community threads kiezen engineers die hun stack opnieuw opbouwen expliciet voor Jaeger. Grafana Tempo wordt beschreven als "iets om later te implementeren" en heeft een kleinere community van 5.100 stars.

---

#### Onze keuze: Jaeger + OpenTelemetry

Tempo wint op schaalbaarheid en opslagkosten op lange termijn — dat erkennen we. Voor een omgeving met miljoenen traces per dag en een groot opslagbudget is Tempo de betere keuze.

Maar Jaeger wint op de criteria die voor ons project het meeste wegen. De zoekfunctie is geen bijzaak: zonder de mogelijkheid om traces te filteren op servicenaam, fouttype of duur kun je failure scenarios niet efficiënt debuggen. Jaeger heeft ook een grotere, volwassenere community — CNCF Graduated tegenover een Grafana Labs intern project. De storage overhead van Elasticsearch is reëel maar beheersbaar voor onze schaal.

OpenTelemetry wordt gebruikt als instrumentatielaag in alle services van de Voting App. De SDKs zijn beschikbaar voor Python, .NET en Node.js. Jaeger v2 gebruikt de OpenTelemetry Collector intern — onze instrumentatiecode is niet gebonden aan Jaeger. Als we later naar Tempo willen, wijzigen we enkel de exporter configuratie.

**Waarom niet Tempo:** beperkte zoekfunctie, geen eigen UI, kleinere community.
**Waarom niet Zipkin:** maintenance-only mode, geen native OpenTelemetry support.
**Waarom niet SkyWalking:** overkill, 32GB RAM vereist, te hoge leercurve.
**Waarom niet SigNoz:** vervangt Grafana, past niet in onze architectuur.

---

### Pijler 2: Metrics

Metrics zijn cijfers die in de tijd worden bijgehouden: hoeveel requests per seconde, hoeveel geheugen een service gebruikt, hoeveel fouten er optreden. Het doel is patronen zien, alerts instellen en snel reageren op problemen.

#### Onderzochte open source tools

**InfluxDB** is een tijdreeksdatabase met een push model — applicaties sturen data actief naar InfluxDB. Het is ontworpen voor IoT en sensordata, heeft een eigen querytaal (Flux) en is gevoelig voor geheugenproblemen bij hoge cardinality. Het is niet ontworpen voor applicatie- en infrastructuurmonitoring zoals wij nodig hebben. Afgevallen.

**Grafana Mimir** is geen standalone tool maar een uitbreiding op Prometheus voor lange-termijn opslag. Het is ontworpen voor miljarden actieve metrics, vereist Kubernetes en meerdere microservices om te draaien. Bedoeld voor grote organisaties met een dedicated platform team. Voor onze situatie is dit overkill. Afgevallen.

Dit laat twee serieuze kandidaten over: **Prometheus** en **VictoriaMetrics**.

---

#### Prometheus vs VictoriaMetrics

**Prometheus** is gemaakt door SoundCloud in 2012 en overgedragen aan de CNCF, waar het in 2018 Graduated status behaalde — hetzelfde niveau als Kubernetes en het tweede project ooit na Kubernetes. Het gebruikt een pull model: Prometheus haalt zelf metrics op van services via een HTTP `/metrics` endpoint. Het heeft 126.000 GitHub stars en wordt gebruikt in productie door Netflix, Google, Uber, Slack en meer dan 580 andere bedrijven. Prometheus 3.0 (november 2024) voegde native OpenTelemetry OTLP ingestion toe.

**VictoriaMetrics** is gemaakt in 2018 als een efficiëntere vervanging voor Prometheus. Het gebruikt 7x minder RAM en schijfruimte, heeft ingebouwde horizontale schaling en is geschikt voor jarenlange retentie zonder extra tools. Het is volledig Prometheus-compatibel: dezelfde exporters, dezelfde PromQL querytaal. Het heeft 16.200 GitHub stars.

**Schaalbaarheid**

VictoriaMetrics wint duidelijk: ingebouwde horizontale schaling via aparte componenten (vminsert, vmselect, vmstorage), geen externe tools nodig. Prometheus schaalt niet horizontaal — je hebt Thanos of Mimir nodig voor echte schaling, wat de complexiteit sterk verhoogt.

**Onderhoudsvriendelijkheid**

VictoriaMetrics is eenvoudiger te onderhouden op lange termijn: één binary, geen externe storage backend nodig. Prometheus vereist extra tools (Thanos, Cortex) voor lange-termijn retentie, wat de operationele last verhoogt.

**Leercurve**

Beide tools gebruiken PromQL als querytaal — wie Prometheus leert, kan ook VictoriaMetrics gebruiken. Prometheus heeft een grotere documentatiebasis, meer tutorials en een veel actievere community. Voor iemand die voor het eerst met metrics werkt, is er meer hulpmateriaal beschikbaar voor Prometheus.

**Exporters en integraties**

Prometheus heeft het grootste ecosysteem van exporters: redis_exporter, postgres_exporter, node_exporter — allemaal goed gedocumenteerd en actief onderhouden. VictoriaMetrics is compatibel met alle Prometheus exporters, maar heeft zelf geen eigen exporters.

**Community en volwassenheid**

Prometheus: 126.000 GitHub stars, CNCF Graduated, 580+ bedrijven in productie, 23.000 bijdragende organisaties. VictoriaMetrics: 16.200 stars, actief maar kleinere community. Het verschil in documentatie, tutorials en community support is significant.

---

#### Onze keuze: Prometheus + Grafana

VictoriaMetrics wint op schaalbaarheid en opslagkosten op lange termijn — dat erkennen we. Voor een omgeving met miljarden metrics en jarenlange retentie is VictoriaMetrics de betere keuze.

Maar voor onze situatie wint Prometheus. We monitoren 5 services — dat is ver verwijderd van de schaal waar VictoriaMetrics zijn voordelen toont. Prometheus heeft exporters voor alle services in de Voting App: redis_exporter voor Redis, postgres_exporter voor PostgreSQL, en client libraries voor Python, .NET en Node.js. De community is 8x groter, wat betekent dat elke vraag of elk probleem al duizenden keren beantwoord is. Prometheus 3.0 ondersteunt nu native OpenTelemetry OTLP — de instrumentatiecode in onze services werkt direct met Prometheus zonder extra configuratie.

Grafana is de visualisatielaag: de Prometheus datasource is ingebouwd in Grafana, duizenden kant-en-klare dashboards zijn beschikbaar, en de combinatie Prometheus + Grafana is de meest gedocumenteerde setup in de industrie.

**Waarom niet VictoriaMetrics:** schaalbaarheidsvoordelen niet relevant voor onze schaal, kleinere community, minder tutorials beschikbaar.
**Waarom niet Mimir:** overkill, vereist Kubernetes, bedoeld voor grote organisaties.
**Waarom niet InfluxDB:** push model, verkeerde use case, andere querytaal, geheugenproblemen.

### Pijler 3: Logging

Logging gaat over tekstberichten die services produceren tijdens hun werking: foutmeldingen, informatiemeldingen, waarschuwingen. Het doel is die berichten centraal verzamelen, doorzoeken en koppelen aan de bijhorende traces en metrics.

#### Onderzochte open source tools

**ELK Stack (Elasticsearch + Logstash + Kibana)** is de klassieke logging oplossing. Elasticsearch indexeert de volledige inhoud van elk logbericht voor krachtige full-text search. Maar dit vereist minimum 8-16GB RAM, complexe JVM-tuning en actief beheer van shards, indices en data lifecycle. Bovendien heeft Elastic in 2021 de licentie gewijzigd naar SSPL — niet meer volledig open source. Te zwaar en te complex voor onze situatie. Afgevallen.

**OpenSearch** is een Apache 2.0 fork van Elasticsearch gemaakt door AWS. Dezelfde resource vereisten als ELK, 40-140% trager, en de AWS-specifieke integraties zijn voor ons niet relevant. Afgevallen.

**Fluentd en Fluent Bit** zijn geen storage backends maar **log collectors**: ze verzamelen logs en sturen ze door naar een backend zoals Loki of Elasticsearch. Fluent Bit (CNCF Graduated, ~450KB voetafdruk) is de lichtgewicht versie, Fluentd (CNCF Graduated, 650+ plugins) is de flexibelere versie. Ze zijn een aanvulling op een storage tool, geen keuze op zichzelf.

**VictoriaLogs** is gemaakt door het VictoriaMetrics team. Technisch sterker dan Loki: 30x minder RAM dan ELK, 94% snellere queries dan Loki, en ondersteunt high-cardinality labels (zoals user_id of trace_id als label) — iets wat Loki niet kan. Maar het is een jonger project met een kleinere community en een eigen querytaal (LogsQL) die niet aansluit bij de rest van onze stack.

Dit laat één serieuze kandidaat over: **Grafana Loki**.

---

#### Grafana Loki

Loki is gemaakt door Grafana Labs in 2018 en is de logging component van het LGTM stack (Loki + Grafana + Tempo + Mimir). Het heeft 27.700 GitHub stars en wordt actief ontwikkeld met regelmatige releases.

**Hoe het werkt**

Loki indexeert niet de volledige inhoud van logberichten — alleen de labels (metadata zoals servicenaam, loglevel, environment). De eigenlijke loginhoud wordt opgeslagen als gecomprimeerde blokken in object storage. Dit maakt Loki veel lichter dan Elasticsearch, maar betekent ook dat je niet op willekeurige woorden kunt zoeken zonder een label te gebruiken.

**Promtail** is de log collector die bij Loki hoort. Het leest automatisch de logs van Docker containers, voegt labels toe en stuurt ze naar Loki. Geen code-aanpassingen nodig in de applicaties.

**Schaalbaarheid**

Loki schaalt horizontaal: elk component (distributor, ingester, querier) kan apart uitgebreid worden. De grootste Loki clusters verwerken meer dan 1 Tbps aan data. Voor kleinere deployments volstaat één container.

**Onderhoudsvriendelijkheid**

Loki is eenvoudiger dan ELK: geen JVM-tuning, geen shard management, geen index rotatie. De enige vereiste is object storage (S3 of lokale schijf). Minder componenten betekent minder onderhoud.

**Leercurve**

LogQL is de querytaal van Loki, gebaseerd op PromQL. Wie Prometheus al kent, leert LogQL snel. Basisqueries zijn eenvoudig. Complexe queries vereisen meer inzicht in de label-structuur.

**Beperkingen**

Loki heeft geen full-text search: je kunt niet zoeken op willekeurige woorden in een logbericht tenzij je labels gebruikt. High-cardinality labels (zoals user_id of IP-adres per log entry) breken de performantie. Voor onze Voting App — met vaste servicelagen en bekende labels — is dit geen probleem.

---

#### Onze keuze: Grafana Loki + Promtail

VictoriaLogs is technisch efficiënter — dat erkennen we. Het is sneller en ondersteunt high-cardinality labels die Loki niet aankan.

Maar Loki wint door zijn positie in het ecosysteem. Het gebruikt exact dezelfde labels als Prometheus — servicenaam, environment, loglevel zijn identieke labels in beide tools. Dit betekent dat correlatie tussen logs en metrics automatisch werkt in Grafana zonder extra configuratie. Samen met Jaeger (traces) en Prometheus (metrics) vormt Loki een samenhangende stack waarbij alle drie de pijlers dezelfde labels delen en naar elkaar kunnen linken vanuit één Grafana dashboard.

VictoriaLogs zou een andere querytaal introduceren die niet aansluit bij PromQL en LogQL. Loki integreert native in Grafana — ingebouwde datasource, geen plugin nodig.

De beperkingen van Loki — geen full-text search, geen high-cardinality — zijn niet relevant voor de Voting App. Onze logs hebben vaste servicelagen met bekende labels.

**Waarom niet ELK:** te zwaar, licentiewijziging, operationele complexiteit overkill voor onze schaal.
**Waarom niet OpenSearch:** zelfde gewicht als ELK, trager, AWS-specifiek.
**Waarom niet VictoriaLogs:** kleinere community, andere querytaal, ecosysteem sluit niet aan op onze stack.
**Fluentd / Fluent Bit:** geen vervanging voor Loki maar kunnen als alternatieve log collector gebruikt worden naast Promtail.
