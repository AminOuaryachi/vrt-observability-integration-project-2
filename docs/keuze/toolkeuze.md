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

*(In onderzoek — wordt aangevuld)*

### Pijler 1: Distributed Tracing

### Pijler 2: Metrics

### Pijler 3: Logging
