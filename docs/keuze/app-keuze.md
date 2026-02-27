# App-keuze — Demo-applicatie voor Observability

> **Status: DEFINITIEF**
> Dit document legt vast welke applicatie gekozen is als basis voor ons observability project, en waarom elke andere kandidaat afgevallen is.

---

## Wat we zoeken

De gekozen applicatie is de basis waarop we de volledige observability stack bouwen. Het is geen eindproduct op zich — het is een middel om logging, metrics en distributed tracing te demonstreren. Daarom stellen we drie harde eisen.

**Voldoende services en hops.** Distributed tracing heeft pas zin als een request door meerdere services gaat. Met één service zie je een trace van één stap — dat toont niets aan. We willen minimaal drie services en drie à vier hops per request, zodat we kunnen tonen hoe een fout of vertraging doorgegeven wordt van service tot service.

**Meerdere programmeertalen.** Één van de sterke punten van OpenTelemetry is dat de instrumentatie taal-onafhankelijk werkt. Dat kun je alleen aantonen als de applicatie zelf meerdere talen gebruikt. Eén taal is onvoldoende.

**Geen ingebouwde observability.** Als de applicatie al Prometheus, Jaeger of Grafana bevat, bouw je niets zelf. Het doel van dit project is om de drie pijlers zelf op te zetten en te begrijpen. We wilden bewust starten met een blanco observability-vlak.

---

## Onderzochte applicaties

### Docker Awesome-Compose (React + Express + MongoDB)

Deze applicatie heeft drie services: een React frontend, een Express backend en een MongoDB database. De setup is eenvoudig en goed gedocumenteerd. Maar drie services met één programmeertaal en slechts één hop — de frontend praat direct met de backend — is onvoldoende om distributed tracing te demonstreren. Je ziet enkel het enkelvoudige pad van frontend naar backend, zonder dat een request verder doorgegeven wordt aan andere services. Afgevallen.

### OpenTelemetry Astronomy Shop

De OpenTelemetry Demo is een webshop met meer dan elf microservices, geschreven in zeven verschillende programmeertalen waaronder Go, Python, Java, .NET, PHP en Ruby. Het bevat al een volledige observability stack: Jaeger, Prometheus en Grafana zijn reeds ingebouwd en geconfigureerd.

Dat is net het probleem. Wij willen de observability stack zelf opzetten. Als alles al ingebouwd is, leer je niet hoe het werkt — je leert enkel hoe je een bestaande configuratie beheert. Bovendien zijn elf microservices in zeven talen op korte termijn moeilijk te begrijpen als team. Afgevallen.

### AWS Labs (one-observability-demo)

AWS Labs biedt een observability demo die Lambda, ECS en EKS combineert met CloudWatch en X-Ray als monitoringtools. Er is geen Docker Compose beschikbaar — alles wordt uitgerold via CloudFormation of EKS. De observability is al ingebouwd en volledig gekoppeld aan AWS-diensten.

Dit valt af om twee redenen. Ten eerste willen we open source tools opzetten, niet AWS-specifieke tools. Ten tweede leer je niets over de opbouw van een observability stack als alles al geconfigureerd is door AWS. Afgevallen.

### ebosas/microservices (Go + RabbitMQ + PostgreSQL + Redis + React)

Deze applicatie heeft vijf services in twee programmeertalen: Go en TypeScript. Het bevat geen ingebouwde observability. De services communiceren via RabbitMQ, wat een realistische microservices architectuur simuleert. Het heeft ook kant-en-klare AWS deployment scripts via CloudFormation voor ECS en Fargate.

Dat laatste is precies wat ons deed afhaken. De CloudFormation scripts voor AWS deployment zijn al aanwezig — het werk dat wij zelf wilden doen is hier al gedaan. We wilden bewust leren hoe we een applicatie op AWS deployen en de infrastructuur stap voor stap opzetten. Een kant-en-klare deployment neemt dat leerproces weg. Afgevallen.

---

## Onze keuze: Docker Example Voting App

De Voting App is een officieel Docker voorbeeld met vijf services: een Vote frontend in Python, een Redis wachtrij, een Worker service in .NET (C#), een PostgreSQL database en een Result frontend in Node.js. Een gebruiker brengt een stem uit via de Vote frontend — die stem gaat naar Redis, wordt opgepikt door de Worker, opgeslagen in PostgreSQL en getoond via de Result frontend. Dat is drie à vier hops per request.

**Aantal services en hops.** Vijf services met een duidelijke keten van afhankelijkheden. Een request trekt een pad door Vote → Redis → Worker → PostgreSQL → Result. Dat is precies het soort keten waarbij distributed tracing zijn meerwaarde toont: je ziet elke stap, je ziet waar een fout optreedt, je ziet waar vertraging begint.

**Drie programmeertalen.** Python, C# en Node.js in dezelfde applicatie. Elk met een eigen OpenTelemetry SDK. Dit laat toe te tonen dat de instrumentatie dezelfde werkt ongeacht de taal — hetzelfde trace ID stroomt door Python, C# en Node.js als één samenhangende keten.

**Geen ingebouwde observability.** De Voting App heeft geen Prometheus, geen Jaeger, geen logs aggregatie. Alles beginnen we zelf van nul. Dat is geen gebrek — dat is precies wat we nodig hebben.

**Twee frontends.** Een Vote frontend en een Result frontend geven ons twee aparte ingangspunten om te monitoren. We kunnen de load op elke frontend apart meten en vergelijken.

**Officieel Docker voorbeeld.** De applicatie is goed gedocumenteerd, actief onderhouden en heeft een grote community. Er zijn veel tutorials en referenties beschikbaar, wat de opstartdrempel verlaagt.

**Waarom niet Awesome-Compose:** slechts één hop, één programmeertaal, onvoldoende voor distributed tracing.
**Waarom niet OpenTelemetry Demo:** observability al ingebouwd, te veel services, te hoge complexiteit om mee te beginnen.
**Waarom niet AWS Labs:** observability al ingebouwd, geen Docker Compose, AWS-specifieke tools in plaats van open source.
**Waarom niet ebosas/microservices:** kant-en-klare AWS deployment scripts aanwezig, we wilden de deployment zelf leren opzetten.
