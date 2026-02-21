# VRT Project — Observability op AWS

## 1. Wat is het project?

Jullie moeten een volledig **observability**-systeem opzetten op een **AWS**-infrastructuur die door de VRT wordt aangeboden. Het gaat niet alleen om "distributed tracing" — het is veel breder dan dat.

**In een zin**: Een webapplicatie deployen en vervolgens een volledig monitoringsysteem opzetten waarmee je een probleem binnen 10 minuten kunt detecteren en lokaliseren.

---

## 2. De 3 pijlers van Observability

Het project is gebaseerd op **3 pijlers** die je moet opzetten en aan elkaar moet koppelen:

### Pijler 1 — Logging (Logs)
- Elke server/service produceert logs in tekstformaat
- Je moet ze **centraliseren** op een plek zodat je ze kunt raadplegen
- Voorbeeld: wanneer een gebruiker VRT Nieuws bezoekt, genereert elke service (frontend, backend, DB) logs

### Pijler 2 — Metrics
- Cijfermatige indicatoren om te weten of een service **UP of DOWN** is, de prestaties, CPU/geheugengebruik, enz.
- Meer gericht op de **applicatie**
- Voorbeeld: gemiddelde responstijd, aantal requests per seconde, foutpercentage

### Pijler 3 — Distributed Tracing
- Een **request van begin tot einde volgen** door alle services (frontend -> backend -> API -> database, enz.)
- Gebruikt concepten van **spans**: elke stap/checkpoint van het request met de duur en metadata
- Meer gericht op het **netwerk**
- Voorbeeld: een gebruiker klikt op een artikel -> het request gaat via de frontend, dan de backend, dan de authenticatieserver, dan de DB -> je ziet elke stap

### Het einddoel
**De 3 pijlers aan elkaar koppelen** met een gemeenschappelijke identifier (trace ID), zodat bij een probleem:
- De **metrics** tonen DAT er een probleem is
- De **traces** tonen WAAR het probleem zit (welke service)
- De **logs** tonen WAAROM er een probleem is (het detail van de fout)

---

## 3. Wat jullie concreet moeten doen

### Stap A — Een full-stack applicatie deployen
- Frontend + Backend + Database + API op de AWS-omgeving
- Jullie hoeven deze app NIET zelf te maken
- Zoek een bestaande "Hello World" app op **GitHub** (zoek op "mock full stack app", Docker-ready repos)
- AWS Labs heeft ook leerpositories met apps die klaar zijn om te deployen

### Stap B — Tools kiezen voor elke pijler
Voor elk van de 3 pijlers een tool kiezen:
- **Open source** tools (te vinden op GitHub)
- **Eigen AWS-services** (geintegreerd in de AWS-console)

### Stap C — Jullie keuzes documenteren
Voor elke gekozen tool uitleggen:
- **Waarom** deze tool en niet een andere
- De **voordelen** (pros)
- De **nadelen** (cons)
- De **kosten** (implementatietijd vs managed service)
- De relevantie **korte termijn vs middellange termijn vs lange termijn**

### Stap D — Storingscenario's maken
- Opzettelijk fouten injecteren (frontend uitschakelen, backend laten crashen, enz.)
- Aantonen dat jullie observability-systeem het probleem detecteert en lokaliseert
- Elk scenario documenteren

---

## 4. De AWS-omgeving

- De VRT biedt een **geisoleerde AWS-omgeving** (sandbox)
- Elke student krijgt een **individuele login per e-mail** (tijdelijk wachtwoord dat gewijzigd moet worden)
- Jullie hebben **volledige admin-rechten**
- De VRT zet **kostenalarmen** -> geen stress over onbedoelde uitgaven
- Jullie kunnen alles doen via de **AWS-console** (webinterface)
- **Alles moet in deze sandbox draaien**, niet ergens anders

### Belangrijke AWS-services om te kennen
- **Categorie Compute**: EC2 (virtuele machines), ECS (containers), Fargate (serverless containers)
- AWS heeft +160 services — jullie hoeven niet alles te gebruiken
- Kies op basis van jullie behoeften en onderbouw de keuze

---

## 5. Communicatie en ondersteuning

- **Teams-kanaal** met ~6 personen aan VRT-kant + jullie 5
- Stel alle vragen die jullie willen (er zijn geen domme vragen)
- Antwoord de **volgende werkdag**
- Als jullie vastlopen: vraag een **call/meeting** in plaats van alleen te chatten
- De coach (docent) kan ook bemiddelen indien nodig

---

## 6. Waarom dit project belangrijk is

- **AWS is alomtegenwoordig** op de arbeidsmarkt (60-70% van de functies vragen AWS)
- Observability is wat de VRT echt gebruikt om VRT Nieuws, Sporza, enz. te monitoren
- Echte oefening: de VRT heeft dezelfde oefening gedaan in 2015-2016 voor honderden systemen
- Het raakt aan netwerk, security en systeembeheer
- Het komt direct op jullie **CV**

---

## 7. Belangrijke data

| Datum | Wat |
|-------|-----|
| Nu | AWS-logins ontvangen, onderzoek starten |
| Volgende week | Projectplan + eerste beslissingen |
| **1 april** | **Demo 1 — MVP**: iets dat werkt, ook al is het eenvoudig |
| Juni | Eindoplevering |

---

## 8. Projectplan — Trello-kaarten

### Lijst: BACKLOG (te doen)
> Alle geidentificeerde taken die nog niet gestart zijn

- [ ] AWS-logins ontvangen en configureren (elk teamlid)
- [ ] AWS-console verkennen en beschikbare services begrijpen
- [ ] Hello World full-stack apps zoeken op GitHub (Docker-ready)
- [ ] Observability-tools onderzoeken voor Logs
- [ ] Observability-tools onderzoeken voor Metrics
- [ ] Observability-tools onderzoeken voor Tracing
- [ ] Open source tools vergelijken met eigen AWS-services (voor elke pijler)
- [ ] Document voor toolkeuze opstellen (pros/cons/kosten)
- [ ] Full-stack app deployen op AWS
- [ ] Pijler Logging configureren op de gedeployde app
- [ ] Pijler Metrics configureren op de gedeployde app
- [ ] Pijler Tracing configureren op de gedeployde app
- [ ] De 3 pijlers aan elkaar koppelen (gemeenschappelijk trace ID)
- [ ] Storingscenario's maken (fault injection)
- [ ] Elk scenario testen en valideren
- [ ] Scenario's en resultaten documenteren
- [ ] Demo van 1 april voorbereiden (MVP)
- [ ] Eindpresentatie voorbereiden

---

### Lijst: SPRINT 1 — Onderzoek & Setup (Week 1-2)

**Kaart 1: AWS-accounts opzetten**
- Beschrijving: Elk teamlid configureert zijn AWS-toegang, wijzigt zijn wachtwoord, verkent de console
- Toegewezen aan: Iedereen
- Geschatte duur: 1 dag

**Kaart 2: Communicatie opzetten**
- Beschrijving: Teams-kanaal met het VRT-team joinen, Trello configureren, communicatieregels vastleggen
- Toegewezen aan: 1 persoon (projectleider)
- Geschatte duur: 1 dag

**Kaart 3: Full-stack app zoeken**
- Beschrijving: 2-3 kandidaat-apps vinden op GitHub, evalueren (Docker-ready, goede documentatie, meerdere microservices), de beste kiezen
- Toegewezen aan: 1-2 personen
- Geschatte duur: 2-3 dagen

**Kaart 4: Logging-tools onderzoeken**
- Beschrijving: 3-4 tools identificeren (bijv.: ELK Stack, AWS CloudWatch Logs, Fluentd, Loki), pros/cons/kosten vergelijken, een keuze aanbevelen
- Toegewezen aan: Team Logs (2 personen)
- Geschatte duur: 3-4 dagen

**Kaart 5: Metrics-tools onderzoeken**
- Beschrijving: 3-4 tools identificeren (bijv.: Prometheus + Grafana, AWS CloudWatch Metrics, Datadog), pros/cons/kosten vergelijken, een keuze aanbevelen
- Toegewezen aan: Team Metrics (2 personen)
- Geschatte duur: 3-4 dagen

**Kaart 6: Tracing-tools onderzoeken**
- Beschrijving: 3-4 tools identificeren (bijv.: Jaeger, AWS X-Ray, Zipkin, OpenTelemetry), pros/cons/kosten vergelijken, een keuze aanbevelen
- Toegewezen aan: Team Tracing (2 personen)
- Geschatte duur: 3-4 dagen

**Kaart 7: Document toolkeuze**
- Beschrijving: Het onderzoek van de 3 teams samenvoegen in een enkel document met onderbouwing, presenteren aan de VRT voor feedback
- Toegewezen aan: Iedereen samen
- Geschatte duur: 1-2 dagen

---

### Lijst: SPRINT 2 — App deployen (Week 3-4)

**Kaart 8: App deployen op AWS**
- Beschrijving: De gekozen app deployen op de AWS-omgeving (EC2 of ECS), zorgen dat frontend/backend/DB communiceren
- Toegewezen aan: 2 personen
- Geschatte duur: 3-5 dagen

**Kaart 9: AWS-netwerk configureren**
- Beschrijving: VPC, Security Groups, subnetten, zorgen dat de services onderling communiceren
- Toegewezen aan: 1 persoon
- Geschatte duur: 2-3 dagen

**Kaart 10: Valideren dat de app werkt**
- Beschrijving: De app end-to-end testen, controleren dat requests van frontend naar backend naar DB gaan
- Toegewezen aan: Iedereen
- Geschatte duur: 1 dag

---

### Lijst: SPRINT 3 — Observability opzetten (Week 5-7)

**Kaart 11: Logging implementeren**
- Beschrijving: De gekozen logging-tool installeren en configureren, alle services aansluiten, controleren dat de logs binnenkomen
- Toegewezen aan: Team Logs
- Geschatte duur: 5-7 dagen

**Kaart 12: Metrics implementeren**
- Beschrijving: De gekozen metrics-tool installeren en configureren, dashboards maken, alerts configureren (UP/DOWN, latentie, fouten)
- Toegewezen aan: Team Metrics
- Geschatte duur: 5-7 dagen

**Kaart 13: Tracing implementeren**
- Beschrijving: De gekozen tracing-tool installeren en configureren, de app instrumenteren om spans te genereren, end-to-end traces controleren
- Toegewezen aan: Team Tracing
- Geschatte duur: 5-7 dagen

**Kaart 14: De 3 pijlers koppelen**
- Beschrijving: Logs + metrics + traces koppelen met een gemeenschappelijke identifier (trace ID), zodat je van de ene pijler naar de andere kunt navigeren
- Toegewezen aan: Iedereen samen
- Geschatte duur: 3-5 dagen

---

### Lijst: SPRINT 4 — Storingscenario's & Demo (Week 8-9)

**Kaart 15: Storingscenario's maken**
- Beschrijving: 3-4 scenario's definieren (frontend crash, backend crash, DB down, hoge latentie), indien mogelijk scripten
- Toegewezen aan: 2 personen
- Geschatte duur: 2-3 dagen

**Kaart 16: Scenario's testen**
- Beschrijving: Elk scenario uitvoeren, controleren dat de observability het probleem detecteert, detectietijd meten (<10 min)
- Toegewezen aan: Iedereen
- Geschatte duur: 2-3 dagen

**Kaart 17: Resultaten documenteren**
- Beschrijving: Voor elk scenario documenteren: wat kapot ging, wat de tools toonden, in hoeveel tijd, screenshots
- Toegewezen aan: 1-2 personen
- Geschatte duur: 2 dagen

**Kaart 18: MVP-demo voorbereiden (1 april)**
- Beschrijving: Een presentatie voorbereiden die de gedeployde app toont, de 3 pijlers in actie, minstens 1 werkend storingsscenario
- Toegewezen aan: Iedereen
- Geschatte duur: 2-3 dagen

---

### Lijst: SPRINT 5 — Verbetering & Afronding (Na demo 1)

**Kaart 19: Feedback van de demo verwerken**
- Beschrijving: De opmerkingen van de VRT en de coach toepassen
- Toegewezen aan: Iedereen

**Kaart 20: Pijlers verbeteren en aanvullen**
- Beschrijving: Ontbrekende functionaliteiten toevoegen, dashboards verbeteren, meer scenario's toevoegen
- Toegewezen aan: Per team

**Kaart 21: Einddocumentatie**
- Beschrijving: De volledige architectuur, keuzes en procedures documenteren zodat iemand anders het kan overnemen
- Toegewezen aan: Iedereen

**Kaart 22: Eindpresentatie**
- Beschrijving: De eindpresentatie voorbereiden en oefenen
- Toegewezen aan: Iedereen

---

### Lijst: IN UITVOERING
> Kaarten waaraan momenteel gewerkt wordt (hierheen verplaatsen vanuit de actieve sprint)

### Lijst: IN REVIEW
> Afgeronde kaarten die wachten op validatie

### Lijst: AFGEROND
> Gevalideerde en afgesloten kaarten

---

## 9. Gedetailleerde technische stappen — Van begin tot eind

### Fase 1: Voorbereiding (Week 1)

#### 1.1 — Toegang configureren
```
- De mail van VRT ontvangen met AWS-credentials
- Inloggen op de AWS-console via de verstrekte URL
- Het tijdelijke wachtwoord wijzigen
- MFA (Multi-Factor Authentication) activeren indien gevraagd
- De console verkennen: beschikbare services bekijken, geconfigureerde regio checken
```

#### 1.2 — De AWS-omgeving begrijpen
```
- De gebruikte AWS-regio identificeren (waarschijnlijk eu-west-1 Ireland of eu-central-1 Frankfurt)
- De servicelimieten controleren (kostencaps ingesteld door VRT)
- Vertrouwd raken met: EC2, ECS, VPC, IAM, CloudWatch
- Elk teamlid verkent een andere service en maakt een samenvatting voor de anderen
```

#### 1.3 — Applicatie zoeken
```
- Zoeken op GitHub: "microservices demo app docker-compose"
- Bekende voorbeelden:
  -> Google Cloud Microservices Demo (Online Boutique)
  -> Weaveworks Sock Shop
  -> Spring PetClinic Microservices
  -> AWS Labs repos
- Selectiecriteria:
  -> Docker-ready (docker-compose.yml aanwezig)
  -> Meerdere services die met elkaar communiceren (minimum: frontend + backend + DB)
  -> Goede documentatie
  -> Niet te complex maar voldoende om echt verkeer te simuleren
```

---

### Fase 2: Toolonderzoek (Week 2)

#### 2.1 — Tools voor Logging
```
Te evalueren opties:
- AWS CloudWatch Logs (eigen AWS-service, makkelijk te integreren, betaald per volume)
- ELK Stack (Elasticsearch + Logstash + Kibana) — open source, krachtig, complex om op te zetten
- Grafana Loki — open source, lichtgewicht, goed geintegreerd met Grafana
- Fluentd / Fluent Bit — open source logverzamelaars

Voor elke tool documenteren:
- Gemak van installatie
- Kosten (gratis vs betaald vs AWS credits)
- Schaalbaarheid
- Integratie met de andere pijlers
- Community en documentatie
```

#### 2.2 — Tools voor Metrics
```
Te evalueren opties:
- AWS CloudWatch Metrics (eigen, makkelijk, betaald)
- Prometheus + Grafana (open source, industriestandaard)
- AWS Managed Prometheus + Managed Grafana
- Datadog (SaaS, gratis proefversie, zeer compleet)

Voor elke tool documenteren:
- Ondersteunde soorten metrics
- Mogelijkheid om dashboards te maken
- Alertingsysteem
- Integratie met de andere pijlers
```

#### 2.3 — Tools voor Tracing
```
Te evalueren opties:
- AWS X-Ray (eigen, goede AWS-integratie)
- Jaeger (open source, CNCF, zeer gebruikt)
- Zipkin (open source, eenvoudig)
- OpenTelemetry (open source standaard voor het verzamelen van traces, logs, metrics)
  -> Opmerking: OpenTelemetry is geen backend, het is een verzamelaar/SDK
  -> Het stuurt de gegevens naar Jaeger, X-Ray, of iets anders

Voor elke tool documenteren:
- Ondersteuning van de programmeertalen van de gekozen app
- Gemak van instrumentatie
- Visualisatie van traces
- Integratie met de andere pijlers
```

#### 2.4 — Definitieve beslissing
```
- Teamvergadering om het onderzoek te vergelijken
- 1 tool per pijler kiezen (of een geintegreerde oplossing zoals OpenTelemetry + Grafana Stack)
- Het onderbouwingsdocument opstellen
- Naar de VRT sturen voor feedback/validatie
```

---

### Fase 3: App deployen op AWS (Week 3-4)

#### 3.1 — AWS-netwerk configureren (VPC)
```
- Een VPC (Virtual Private Cloud) aanmaken of de standaard gebruiken
- Publieke subnetten aanmaken (voor de frontend) en prive subnetten (voor backend/DB)
- Security Groups configureren (firewall):
  -> Frontend: poort 80/443 open naar het publiek
  -> Backend: poort alleen toegankelijk vanuit de frontend
  -> Database: poort alleen toegankelijk vanuit de backend
- Een Internet Gateway configureren voor externe toegang
```

#### 3.2 — De applicatie deployen
```
Optie A — Met EC2 (virtuele machines):
  1. Een EC2-instantie lanceren (Ubuntu/Amazon Linux)
  2. Docker en Docker Compose installeren
  3. De GitHub-repo van de app klonen
  4. Starten met docker-compose up -d
  5. De Security Group configureren om de poorten bloot te stellen

Optie B — Met ECS (managed containers):
  1. Een ECS-cluster aanmaken
  2. Task Definitions definieren voor elke service
  3. ECS-services aanmaken
  4. Een Load Balancer (ALB) voor de frontend configureren
  5. Service discovery configureren voor communicatie tussen services

Aanbeveling: beginnen met EC2 (eenvoudiger), migreren naar ECS als de tijd het toelaat
```

#### 3.3 — De database configureren
```
- Eenvoudige optie: DB in een Docker-container (op EC2)
- AWS-optie: Amazon RDS (managed database)
- Zorgen dat de backend verbinding kan maken met de DB
- Testen met testgegevens
```

#### 3.4 — De deployment valideren
```
- De frontend openen via de browser (publiek IP van de instantie)
- Controleren dat de frontend communiceert met de backend
- Controleren dat de backend communiceert met de DB
- Enkele testrequests uitvoeren
- De architectuur documenteren met een schema
```

---

### Fase 4: Observability opzetten (Week 5-7)

#### 4.1 — Logging implementeren
```
1. Logverzameling configureren op elke service:
   - Een verzamelingsagent installeren (CloudWatch Agent, Fluent Bit, of Filebeat)
   - Of de Docker logging driver configureren om logs te versturen
2. Logs centraliseren op een plek (CloudWatch, Elasticsearch, of Loki)
3. Filters maken om snel fouten te vinden
4. Alerts configureren op foutpatronen (bijv.: "ERROR", "500", "timeout")
5. Testen: een fout veroorzaken en controleren dat deze verschijnt in de gecentraliseerde logs
```

#### 4.2 — Metrics implementeren
```
1. Metrics-exporters installeren op elke service:
   - Node Exporter (systeemmetrics: CPU, RAM, schijf)
   - Application metrics (responstijd, requests/sec)
2. Verzameling configureren (Prometheus scraping of CloudWatch)
3. Dashboards maken in Grafana of CloudWatch:
   - Dashboard "globaal overzicht": alle services UP/DOWN
   - Dashboard per service: CPU, geheugen, latentie, fouten
4. Alerts configureren:
   - Service DOWN -> onmiddellijk alert
   - CPU > 80% -> waarschuwingsalert
   - Responstijd > 2s -> waarschuwingsalert
5. Testen: een service stoppen en controleren dat het alert afgaat
```

#### 4.3 — Tracing implementeren
```
1. De applicatie instrumenteren:
   - De OpenTelemetry SDK (of X-Ray SDK) toevoegen in de code van de app
   - Of auto-instrumentatie gebruiken indien beschikbaar
2. De verzamelaar configureren (OpenTelemetry Collector of X-Ray Daemon)
3. De tracing-backend configureren (Jaeger, X-Ray, of Tempo)
4. Traces controleren:
   - Een request doen op de frontend
   - Controleren dat je de volledige trace ziet: frontend -> backend -> DB
   - Spans controleren: duur van elke stap, metadata
5. Testen: kunstmatige latentie toevoegen en controleren dat je deze ziet in de traces
```

#### 4.4 — De 3 pijlers koppelen
```
Dit is HET belangrijkste en moeilijkste deel:
1. Zorgen dat dezelfde Trace ID aanwezig is in:
   - De logs (elke logregel bevat het trace ID)
   - De traces (het trace ID is de hoofdidentifier)
   - De metrics (de Prometheus exemplars of annotaties)
2. Koppelingen configureren tussen de tools:
   - Vanuit een metrics-dashboard -> klikken om de gerelateerde traces te zien
   - Vanuit een trace -> klikken om de gerelateerde logs te zien
   - Vanuit een log -> klikken om de gerelateerde trace te zien
3. De correlatie testen:
   - Een fout veroorzaken
   - Beginnen bij de metrics (detectie van het probleem)
   - Volgen naar de traces (lokalisatie van de service)
   - Volgen naar de logs (detail van de fout)
```

---

### Fase 5: Storingscenario's & Tests (Week 8-9)

#### 5.1 — Scenario's definieren
```
Scenario 1: Frontend crash
- Actie: de frontend container/service stoppen
- Verwacht: metrics tonen frontend DOWN, alerts gaan af

Scenario 2: Backend crash
- Actie: de backend container/service stoppen
- Verwacht: frontend retourneert 500/502-fouten, traces tonen de fout op backend-niveau

Scenario 3: Database onbereikbaar
- Actie: DB-toegang afsluiten (Security Group wijzigen of service stoppen)
- Verwacht: backend retourneert fouten, logs tonen "connection refused"

Scenario 4: Hoge latentie
- Actie: kunstmatige latentie injecteren in de backend (sleep 5s)
- Verwacht: traces tonen een abnormaal lange span, metrics tonen een toename in responstijd

Scenario 5: Applicatiefout
- Actie: een bug injecteren die een specifieke route laat crashen
- Verwacht: logs tonen de exception, traces tonen de fout op de betreffende span
```

#### 5.2 — Uitvoeren en documenteren
```
Voor elk scenario:
1. Een screenshot nemen "voor" (normale toestand)
2. De storingsactie uitvoeren
3. De detectietijd meten
4. Screenshots nemen van dashboards, traces, logs
5. Het pad documenteren dat gevolgd is om de oorzaak te vinden
6. Doel: detectie binnen 10 minuten
7. De service herstellen en controleren dat het terugkeert naar normaal
```

---

### Fase 6: MVP-demo — 1 april

#### Wat klaar moet zijn:
```
- De full-stack app gedeployd en werkend op AWS
- Minimaal 1 pijler volledig werkend (idealiter alle 3 op basisniveau)
- Minstens 1 storingsscenario live demonstreerbaar
- Een document met toolkeuzes en onderbouwing
- Een architectuurschema
- Een duidelijke presentatie van 15-20 minuten
```

---

### Fase 7: Verbetering & Afronding (Na demo 1 -> Juni)

```
- De feedback van de VRT en de coach verwerken
- De ontbrekende pijlers aanvullen
- De dashboards en alerts verbeteren
- Meer storingscenario's toevoegen
- De correlatie tussen de pijlers optimaliseren
- De volledige einddocumentatie schrijven
- De eindpresentatie voorbereiden
```

---

## 10. Aanbevolen teamverdeling (5 personen)

| Rol | Wie | Verantwoordelijkheid |
|-----|-----|----------------------|
| Projectleider / Scrum Master | 1 persoon | Planning, communicatie VRT, Trello, standups |
| Team Logs | 2 personen | Onderzoek + implementatie van de pijler Logging |
| Team Metrics | 2 personen | Onderzoek + implementatie van de pijler Metrics |
| Team Tracing | 2 personen | Onderzoek + implementatie van de pijler Tracing |
| App Deployment | 2 personen | App deployen op AWS (daarna aansluiten bij een pijler) |

> Opmerking: de rollen overlappen (1 persoon kan in 2 teams zitten). De projectleider neemt ook deel aan een technische pijler.

---

## 11. Aanbevolen teamregels

- **Dagelijkse stand-up** (max 15 min): iedereen vertelt wat hij gisteren deed, wat hij vandaag doet, of hij vastzit
- **Trello bijwerken**: elke dag je kaarten verplaatsen
- **Communicatie met VRT**: vragen stellen in het Teams-kanaal, niet wachten tot je al dagen vastzit
- **Documentatie gaandeweg**: niet alles tot het einde uitstellen
- **Onderlinge review**: elk team presenteert regelmatig zijn werk aan de anderen
- **Tijdschatting**: voor elke taak de tijd schatten voor je begint, dan vergelijken met de werkelijke tijd

---

## 12. Nuttige bronnen om te starten

- **AWS Labs GitHub**: repos met apps en observability-tutorials
- **OpenTelemetry documentatie**: open source standaard voor observability
- **AWS Well-Architected Framework — Pijler Operational Excellence**: AWS best practices
- Zoeken op Google/YouTube: "observability on AWS tutorial", "distributed tracing explained"
- Zoeken op GitHub: "microservices demo docker-compose", "observability demo"
