# Trello Kaarten — VRT Observability Project

---

## Lijst: BACKLOG

> Alle taken die nog gedaan moeten worden

---

## Lijst: SPRINT 1 — Onderzoek & Opzet (Week 1-2)

### Kaart 1: AWS-accounts opzetten
**Labels:** Setup, Prioriteit Hoog
**Toegewezen aan:** Iedereen
**Geschatte duur:** 1 dag
**Checklist:**
- [ ] Login-mail van VRT ontvangen
- [ ] Inloggen op de AWS-console
- [ ] Tijdelijk wachtwoord wijzigen
- [ ] MFA activeren (indien nodig)
- [ ] Console verkennen: regio, beschikbare services bekijken

---

### Kaart 2: Communicatie & projecttools opzetten
**Labels:** Setup, Prioriteit Hoog
**Toegewezen aan:** Projectleider
**Geschatte duur:** 1 dag
**Checklist:**
- [ ] Teams-kanaal met VRT-team joinen
- [ ] Trello-bord aanmaken en teamleden uitnodigen
- [ ] GitHub-repository aanmaken
- [ ] Afspraken vastleggen: stand-up tijdstip, communicatieregels
- [ ] Eerste stand-up inplannen

---

### Kaart 3: Full-stack demo-app kiezen
**Labels:** Onderzoek, Prioriteit Hoog
**Toegewezen aan:** 2 personen
**Geschatte duur:** 2-3 dagen
**Beschrijving:**
Zoek op GitHub een Hello World full-stack applicatie die Docker-ready is. Minimaal: frontend + backend + database. De app moet makkelijk te deployen zijn met docker-compose.
**Checklist:**
- [ ] Zoeken op GitHub: "microservices demo app docker-compose"
- [ ] Minimaal 3 kandidaat-apps vinden
- [ ] Elke app evalueren op: Docker-ready, documentatie, aantal services, programmeertaal
- [ ] Voorbeelden bekijken: Google Online Boutique, Weaveworks Sock Shop, Spring PetClinic
- [ ] AWS Labs repos bekijken voor observability-demo-apps
- [ ] Beste app kiezen en keuze documenteren
- [ ] App lokaal testen met docker-compose

---

### Kaart 4: Onderzoek tools voor Logging
**Labels:** Onderzoek, Pijler Logs
**Toegewezen aan:** Team Logs (2 personen)
**Geschatte duur:** 3-4 dagen
**Beschrijving:**
Onderzoek en vergelijk minimaal 3 tools voor gecentraliseerde logging. Maak een vergelijkingsdocument met voor- en nadelen.
**Checklist:**
- [ ] AWS CloudWatch Logs onderzoeken (AWS-natief)
- [ ] ELK Stack onderzoeken (Elasticsearch + Logstash + Kibana)
- [ ] Grafana Loki onderzoeken (open source, lichtgewicht)
- [ ] Fluentd / Fluent Bit onderzoeken (logverzamelaars)
- [ ] Vergelijkingstabel maken: installatie, kosten, schaalbaarheid, integratie
- [ ] Voor- en nadelen per tool documenteren
- [ ] Aanbeveling formuleren met onderbouwing

---

### Kaart 5: Onderzoek tools voor Metrics
**Labels:** Onderzoek, Pijler Metrics
**Toegewezen aan:** Team Metrics (2 personen)
**Geschatte duur:** 3-4 dagen
**Beschrijving:**
Onderzoek en vergelijk minimaal 3 tools voor metrics en monitoring. Maak een vergelijkingsdocument met voor- en nadelen.
**Checklist:**
- [ ] AWS CloudWatch Metrics onderzoeken (AWS-natief)
- [ ] Prometheus + Grafana onderzoeken (open source standaard)
- [ ] AWS Managed Prometheus + Managed Grafana onderzoeken
- [ ] Datadog onderzoeken (SaaS, gratis proefversie)
- [ ] Vergelijkingstabel maken: soorten metrics, dashboards, alerting, kosten
- [ ] Voor- en nadelen per tool documenteren
- [ ] Aanbeveling formuleren met onderbouwing

---

### Kaart 6: Onderzoek tools voor Tracing
**Labels:** Onderzoek, Pijler Tracing
**Toegewezen aan:** Team Tracing (2 personen)
**Geschatte duur:** 3-4 dagen
**Beschrijving:**
Onderzoek en vergelijk minimaal 3 tools voor distributed tracing. Maak een vergelijkingsdocument met voor- en nadelen.
**Checklist:**
- [ ] AWS X-Ray onderzoeken (AWS-natief)
- [ ] Jaeger onderzoeken (open source, CNCF)
- [ ] Zipkin onderzoeken (open source)
- [ ] OpenTelemetry onderzoeken (verzamelaar/SDK, geen backend)
- [ ] Vergelijkingstabel maken: taalinstrumentatie, visualisatie, integratie, kosten
- [ ] Voor- en nadelen per tool documenteren
- [ ] Aanbeveling formuleren met onderbouwing

---

### Kaart 7: Toolkeuze-document opstellen
**Labels:** Documentatie, Prioriteit Hoog
**Toegewezen aan:** Iedereen
**Geschatte duur:** 1-2 dagen
**Beschrijving:**
Het onderzoek van de 3 teams samenvoegen in een enkel document. Per pijler: gekozen tool, waarom, voor- en nadelen, kosten, korte/middellange/lange termijn afweging.
**Checklist:**
- [ ] Onderzoeksresultaten van Team Logs samenvoegen
- [ ] Onderzoeksresultaten van Team Metrics samenvoegen
- [ ] Onderzoeksresultaten van Team Tracing samenvoegen
- [ ] Kostenanalyse toevoegen (open source vs AWS-services)
- [ ] Korte termijn vs lange termijn afweging beschrijven
- [ ] Document naar VRT sturen voor feedback

---

## Lijst: SPRINT 2 — App deployen op AWS (Week 3-4)

### Kaart 8: EC2-instantie aanmaken en team verbinden
**Labels:** Infrastructuur, Prioriteit Hoog
**Toegewezen aan:** 1 persoon (de rest volgt stap "SSH verbinden")
**Geschatte duur:** 1 dag
**Beschrijving:**
Eén EC2-instantie aanmaken voor het hele team. Alle 5 teamleden werken op dezelfde server via SSH. Geen aparte VPC nodig — de standaard VPC van AWS is voldoende. De Security Group wordt ingesteld tijdens het aanmaken van de EC2, niet als aparte stap. Het .pem bestand wordt gedeeld met het team via Teams.
**Checklist:**
- [ ] EC2-instantie lanceren (Ubuntu 22.04 LTS, t3.medium aanbevolen)
- [ ] Tijdens aanmaken: Security Group instellen met poorten 22 (SSH), 5000 (Vote), 5001 (Result)
- [ ] Key pair aanmaken en downloaden (.pem bestand)
- [ ] .pem bestand delen met het team via Teams
- [ ] Iedereen verbindt via SSH:
  - Mac/Linux: chmod 400 <key>.pem → ssh -i <key>.pem ubuntu@<publiek-ip>
  - Windows: PowerShell openen → ssh -i <key>.pem ubuntu@<publiek-ip>
    (als permissie-fout: icacls <key>.pem /inheritance:r /grant:r "%username%:R")
- [ ] Controleren dat iedereen kan inloggen op de server

---

### Kaart 9: Voting App deployen op de EC2
**Labels:** Infrastructuur, Prioriteit Hoog
**Toegewezen aan:** 2 personen
**Geschatte duur:** 1 dag
**Beschrijving:**
De Voting App klonen en opstarten op de EC2 via Docker Compose. Docker moet geïnstalleerd worden op de server.
**Checklist:**
- [ ] Docker installeren: sudo apt update && sudo apt install -y docker.io docker-compose-plugin
- [ ] Gebruiker toevoegen aan Docker groep: sudo usermod -aG docker ubuntu (daarna opnieuw inloggen)
- [ ] GitHub-repo klonen: git clone <repo-url>
- [ ] App starten vanuit de /app/ map: docker compose up -d
- [ ] Controleren dat alle 5 containers draaien: docker compose ps

---

### Kaart 10: Deployment valideren

**Labels:** Testen, Prioriteit Hoog
**Toegewezen aan:** Iedereen
**Geschatte duur:** 1 dag
**Checklist:**
- [ ] Vote frontend openen in de browser: http://<publiek-ip>:5000
- [ ] Result frontend openen in de browser: http://<publiek-ip>:5001
- [ ] Een stem uitbrengen en controleren dat het resultaat verschijnt
- [ ] Controleren dat alle 5 containers actief zijn: docker compose ps
- [ ] Architectuurschema tekenen en opslaan in de repo

---

## Lijst: SPRINT 3 — Observability implementeren (Week 5-7)

### Kaart 11: Pijler Logging implementeren
**Labels:** Implementatie, Pijler Logs
**Toegewezen aan:** Team Logs
**Geschatte duur:** 5-7 dagen
**Beschrijving:**
De gekozen logging-tool installeren en configureren. Alle services aansluiten en controleren dat logs correct binnenkomen.
**Checklist:**
- [ ] Logging-agent installeren op elke service
- [ ] Logs centraliseren op een plek
- [ ] Filters aanmaken om fouten te vinden
- [ ] Alerts configureren op foutpatronen ("ERROR", "500", "timeout")
- [ ] Test: fout veroorzaken en controleren dat het in de logs verschijnt
- [ ] Documentatie schrijven: hoe het opgezet is, hoe het werkt

---

### Kaart 12: Pijler Metrics implementeren
**Labels:** Implementatie, Pijler Metrics
**Toegewezen aan:** Team Metrics
**Geschatte duur:** 5-7 dagen
**Beschrijving:**
De gekozen metrics-tool installeren en configureren. Dashboards en alerts opzetten.
**Checklist:**
- [ ] Metrics-exporters installeren (Node Exporter, app metrics)
- [ ] Metrics-verzameling configureren (scraping of agent)
- [ ] Dashboard "Globaal overzicht" maken: alle services UP/DOWN
- [ ] Dashboard per service maken: CPU, geheugen, latentie, fouten
- [ ] Alerts configureren: service DOWN, CPU > 80%, responstijd > 2s
- [ ] Test: service stoppen en controleren dat alert afgaat
- [ ] Documentatie schrijven

---

### Kaart 13: Pijler Tracing implementeren
**Labels:** Implementatie, Pijler Tracing
**Toegewezen aan:** Team Tracing
**Geschatte duur:** 5-7 dagen
**Beschrijving:**
De gekozen tracing-tool installeren en configureren. De app instrumenteren zodat spans gegenereerd worden.
**Checklist:**
- [ ] SDK of auto-instrumentatie toevoegen aan de app
- [ ] Tracing-collector configureren (OTel Collector of X-Ray Daemon)
- [ ] Tracing-backend configureren (Jaeger, X-Ray, of Tempo)
- [ ] Test: request doen en volledige trace controleren (frontend -> backend -> DB)
- [ ] Spans controleren: duur, metadata, fouten
- [ ] Test: kunstmatige latentie toevoegen en in traces zien
- [ ] Documentatie schrijven

---

### Kaart 14: De 3 pijlers correleren
**Labels:** Implementatie, Prioriteit Hoog
**Toegewezen aan:** Iedereen
**Geschatte duur:** 3-5 dagen
**Beschrijving:**
De drie pijlers aan elkaar koppelen zodat je van metrics naar traces naar logs kunt navigeren. Dit is het belangrijkste onderdeel van het project.
**Checklist:**
- [ ] Trace ID toevoegen aan alle logregels
- [ ] Trace ID koppelen aan metrics (exemplars of annotaties)
- [ ] Links configureren: metrics-dashboard -> traces -> logs
- [ ] Test: fout veroorzaken, starten bij metrics, doorlinken naar traces, dan naar logs
- [ ] Volledige correlatie documenteren met screenshots

---

## Lijst: SPRINT 4 — Storingscenario's & MVP-demo (Week 8-9)

### Kaart 15: Storingscenario's definieren en scripten
**Labels:** Testen, Prioriteit Hoog
**Toegewezen aan:** 2 personen
**Geschatte duur:** 2-3 dagen
**Checklist:**
- [ ] Scenario 1: Frontend crash (container stoppen)
- [ ] Scenario 2: Backend crash (container stoppen)
- [ ] Scenario 3: Database onbereikbaar (Security Group wijzigen)
- [ ] Scenario 4: Hoge latentie (sleep injecteren in backend)
- [ ] Scenario 5: Applicatiefout (bug injecteren op specifieke route)
- [ ] Scripts schrijven om scenario's automatisch uit te voeren

---

### Kaart 16: Scenario's uitvoeren en valideren
**Labels:** Testen
**Toegewezen aan:** Iedereen
**Geschatte duur:** 2-3 dagen
**Checklist:**
- [ ] Elk scenario uitvoeren
- [ ] Controleren dat observability het probleem detecteert
- [ ] Detectietijd meten (doel: < 10 minuten)
- [ ] Screenshots nemen van dashboards, traces, logs
- [ ] Pad documenteren van detectie tot oorzaak

---

### Kaart 17: Resultaten documenteren
**Labels:** Documentatie
**Toegewezen aan:** 1-2 personen
**Geschatte duur:** 2 dagen
**Checklist:**
- [ ] Per scenario: wat kapot ging, wat de tools toonden, detectietijd
- [ ] Screenshots toevoegen
- [ ] Conclusies per scenario
- [ ] Samenvatting: welke tool was het nuttigst per scenario

---

### Kaart 18: MVP-demo voorbereiden (1 april)
**Labels:** Presentatie, Prioriteit Hoog
**Toegewezen aan:** Iedereen
**Geschatte duur:** 2-3 dagen
**Checklist:**
- [ ] Presentatie maken (15-20 minuten)
- [ ] Live demo voorbereiden: app tonen, 3 pijlers in actie
- [ ] Minimaal 1 storingsscenario live demonstreren
- [ ] Architectuurschema klaarzetten
- [ ] Toolkeuze-document bijvoegen
- [ ] Presentatie oefenen als team
- [ ] Backup-plan als live demo faalt (screenshots/video)

---

## Lijst: SPRINT 5 — Verbetering & Afronding (Na demo 1 -> Juni)

### Kaart 19: Feedback van demo verwerken
**Labels:** Verbetering
**Toegewezen aan:** Iedereen
**Checklist:**
- [ ] Feedback van VRT verzamelen
- [ ] Feedback van coach verzamelen
- [ ] Actiepunten bepalen en verdelen

---

### Kaart 20: Pijlers verbeteren en aanvullen
**Labels:** Verbetering
**Toegewezen aan:** Per team
**Checklist:**
- [ ] Ontbrekende functionaliteiten toevoegen
- [ ] Dashboards verbeteren
- [ ] Meer scenario's toevoegen
- [ ] Correlatie tussen pijlers optimaliseren

---

### Kaart 21: Einddocumentatie schrijven
**Labels:** Documentatie, Prioriteit Hoog
**Toegewezen aan:** Iedereen
**Checklist:**
- [ ] Volledige architectuur documenteren
- [ ] Toolkeuzes en onderbouwing finaliseren
- [ ] Installatieprocedures beschrijven (zodat iemand het kan overnemen)
- [ ] Geleerde lessen (lessons learned) opschrijven

---

### Kaart 22: Eindpresentatie voorbereiden
**Labels:** Presentatie, Prioriteit Hoog
**Toegewezen aan:** Iedereen
**Checklist:**
- [ ] Eindpresentatie maken
- [ ] Live demo voorbereiden (alle 3 pijlers + scenario's)
- [ ] Presentatie oefenen
- [ ] Vragen voorbereiden die de jury kan stellen

---

## Lijst: IN UITVOERING
> Kaarten waaraan momenteel gewerkt wordt

## Lijst: IN REVIEW
> Afgeronde kaarten die wachten op validatie

## Lijst: AFGEROND
> Gevalideerde en afgesloten kaarten

---

## Labels overzicht

| Label | Kleur (Trello) | Betekenis |
|-------|----------------|-----------|
| Prioriteit Hoog | Rood | Moet eerst gedaan worden |
| Setup | Geel | Eenmalige opzet-taken |
| Onderzoek | Blauw | Research en vergelijking |
| Infrastructuur | Paars | AWS en netwerk |
| Implementatie | Groen | Bouwen en configureren |
| Testen | Oranje | Testen en valideren |
| Documentatie | Lichtblauw | Documentatie schrijven |
| Presentatie | Roze | Demo en presentatie |
| Pijler Logs | Donkerblauw | Taken voor het Logs-team |
| Pijler Metrics | Donkergroen | Taken voor het Metrics-team |
| Pijler Tracing | Donkerpaars | Taken voor het Tracing-team |
| Verbetering | Grijs | Na de eerste demo |
