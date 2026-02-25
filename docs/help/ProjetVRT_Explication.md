# Projet VRT — Observability sur AWS

## 1. C'est quoi le projet ?

Vous devez mettre en place un systeme d'**observability** (observabilite) complet sur une infrastructure **AWS** fournie par la VRT. Ce n'est pas juste du "distributed tracing" — c'est plus large que ca.

**En une phrase** : Deployer une application web, puis mettre en place un systeme de monitoring complet qui permet de detecter et localiser un probleme en moins de 10 minutes.

---

## 2. Les 3 piliers de l'Observability

Le projet repose sur **3 piliers** qu'il faut mettre en place et corréler ensemble :

### Pilier 1 — Logging (Logs)
- Chaque serveur/service produit des logs en format texte
- Il faut les **centraliser** dans un seul endroit pour pouvoir les consulter
- Exemple : quand un utilisateur visite VRT Nieuws, chaque service (frontend, backend, DB) genere des logs

### Pilier 2 — Metrics
- Des indicateurs chiffres pour savoir si un service est **UP ou DOWN**, ses performances, son utilisation CPU/memoire, etc.
- C'est plus oriente **application**
- Exemple : temps de reponse moyen, nombre de requetes par seconde, taux d'erreur

### Pilier 3 — Distributed Tracing
- Suivre une **requete de bout en bout** a travers tous les services (frontend -> backend -> API -> base de donnees, etc.)
- Utilise des concepts de **spans** : chaque etape/checkpoint de la requete avec sa duree et ses metadonnees
- C'est plus oriente **reseau**
- Exemple : un utilisateur clique sur un article -> la requete passe par le frontend, puis le backend, puis le serveur d'authentification, puis la DB -> on voit chaque etape

### L'objectif final
**Correler ces 3 piliers ensemble** avec un identifiant commun (trace ID), pour qu'en cas de probleme :
- Les **metrics** montrent QU'il y a un probleme
- Les **traces** montrent OU est le probleme (quel service)
- Les **logs** montrent POURQUOI il y a un probleme (le detail de l'erreur)

---

## 3. Ce que vous devez faire concretement

### Etape A — Deployer une application full-stack
- Frontend + Backend + Database + API sur l'environnement AWS
- Vous n'avez PAS a creer cette app vous-memes
- Trouvez une app "Hello World" existante sur **GitHub** (cherchez "mock full stack app", des repos Docker-ready)
- AWS Labs a aussi des repos d'apprentissage avec des apps pretes a deployer

### Etape B — Choisir des outils pour chaque pilier
Pour chacun des 3 piliers, choisir un outil :
- Des outils **open source** (trouvables sur GitHub)
- Des **services AWS natifs** (integres dans la console AWS)

### Etape C — Documenter vos choix
Pour chaque outil choisi, expliquer :
- **Pourquoi** cet outil et pas un autre
- Les **avantages** (pros)
- Les **inconvenients** (cons)
- Le **cout** (temps d'implementation vs service manage)
- La pertinence **court terme vs moyen terme vs long terme**

### Etape D — Creer des scenarios de panne
- Volontairement injecter des erreurs (couper le frontend, crasher le backend, etc.)
- Demontrer que votre systeme d'observability detecte et localise le probleme
- Documenter chaque scenario

---

## 4. L'environnement AWS

- La VRT fournit un **environnement AWS isole** (sandbox)
- Chaque etudiant recoit un **login individuel par email** (mot de passe temporaire a changer)
- Vous avez des **droits admin complets**
- La VRT met des **alarmes de couts** -> pas de stress sur les depenses accidentelles
- Vous pouvez tout faire via la **console AWS** (interface web)
- **Tout doit tourner dans cette sandbox**, pas ailleurs

### Services AWS importants a connaitre
- **Categorie Compute** : EC2 (machines virtuelles), ECS (containers), Fargate (containers serverless)
- AWS a +160 services — vous n'avez pas besoin de tous les utiliser
- Choisissez en fonction de vos besoins et justifiez

---

## 5. Communication et support

- **Canal Teams** avec ~6 personnes cote VRT + vos 5
- Posez toutes les questions que vous voulez (pas de questions betes)
- Reponse le **jour ouvrable suivant**
- Si vous etes bloques : demandez un **call/meeting** plutot que chatter
- Le coach (prof) peut aussi faire le relais si besoin

---

## 6. Pourquoi ce projet est important

- **AWS est omnipresent** sur le marche du travail (60-70% des postes demandent AWS)
- L'observability est ce que la VRT utilise en vrai pour monitorer VRT Nieuws, Sporza, etc.
- Exercice reel : la VRT a fait ce meme travail de choix d'outils en 2015-2016 pour des centaines de systemes
- Ca touche au reseau, a la securite, au systeme admin
- Ca va directement sur votre **CV**

---

## 7. Dates cles

| Date | Quoi |
|------|------|
| Maintenant | Recevoir les logins AWS, commencer la recherche |
| Semaine prochaine | Plan de projet + premieres decisions |
| **1er avril** | **Demo 1 — MVP** : quelque chose qui marche, meme simple |
| Juin | Livraison finale |

---

## 8. Plan du projet — Cartes Trello

### Liste : BACKLOG (a faire)
> Toutes les taches identifiees mais pas encore commencees

- [ ] Recevoir et configurer les logins AWS (chaque membre)
- [ ] Explorer la console AWS et comprendre les services disponibles
- [ ] Rechercher des apps full-stack Hello World sur GitHub (Docker-ready)
- [ ] Rechercher les outils d'observability pour les Logs
- [ ] Rechercher les outils d'observability pour les Metrics
- [ ] Rechercher les outils d'observability pour le Tracing
- [ ] Comparer outils open source vs services AWS natifs (pour chaque pilier)
- [ ] Rediger le document de choix d'outils (pros/cons/couts)
- [ ] Deployer l'app full-stack sur AWS
- [ ] Configurer le pilier Logging sur l'app deployee
- [ ] Configurer le pilier Metrics sur l'app deployee
- [ ] Configurer le pilier Tracing sur l'app deployee
- [ ] Correler les 3 piliers ensemble (trace ID commun)
- [ ] Creer les scenarios de panne (fault injection)
- [ ] Tester et valider chaque scenario
- [ ] Documenter les scenarios et les resultats
- [ ] Preparer la demo du 1er avril (MVP)
- [ ] Preparer la presentation finale

---

### Liste : SPRINT 1 — Recherche & Setup (Semaine 1-2)

**Carte 1 : Setup des comptes AWS**
- Description : Chaque membre configure son acces AWS, change son mot de passe, explore la console
- Assigne a : Tous
- Duree estimee : 1 jour

**Carte 2 : Setup communication**
- Description : Rejoindre le canal Teams avec l'equipe VRT, configurer Trello, definir les regles de communication
- Assigne a : 1 personne (chef de projet)
- Duree estimee : 1 jour

**Carte 3 : Recherche app full-stack**
- Description : Trouver 2-3 apps candidates sur GitHub, les evaluer (Docker-ready, bonne doc, plusieurs microservices), choisir la meilleure
- Assigne a : 1-2 personnes
- Duree estimee : 2-3 jours

**Carte 4 : Recherche outils Logging**
- Description : Identifier 3-4 outils (ex: ELK Stack, AWS CloudWatch Logs, Fluentd, Loki), comparer pros/cons/couts, recommander un choix
- Assigne a : Equipe Logs (2 personnes)
- Duree estimee : 3-4 jours

**Carte 5 : Recherche outils Metrics**
- Description : Identifier 3-4 outils (ex: Prometheus + Grafana, AWS CloudWatch Metrics, Datadog), comparer pros/cons/couts, recommander un choix
- Assigne a : Equipe Metrics (2 personnes)
- Duree estimee : 3-4 jours

**Carte 6 : Recherche outils Tracing**
- Description : Identifier 3-4 outils (ex: Jaeger, AWS X-Ray, Zipkin, OpenTelemetry), comparer pros/cons/couts, recommander un choix
- Assigne a : Equipe Tracing (2 personnes)
- Duree estimee : 3-4 jours

**Carte 7 : Document de choix d'outils**
- Description : Consolider les recherches des 3 equipes dans un document unique avec justifications, presenter a la VRT pour feedback
- Assigne a : Tous ensemble
- Duree estimee : 1-2 jours

---

### Liste : SPRINT 2 — Deploiement de l'app (Semaine 3-4)

**Carte 8 : Deployer l'app sur AWS**
- Description : Deployer l'app choisie sur l'environnement AWS (EC2 ou ECS), s'assurer que frontend/backend/DB communiquent
- Assigne a : 2 personnes
- Duree estimee : 3-5 jours

**Carte 9 : Configurer le reseau AWS**
- Description : VPC, Security Groups, sous-reseaux, s'assurer que les services communiquent entre eux
- Assigne a : 1 personne
- Duree estimee : 2-3 jours

**Carte 10 : Valider que l'app fonctionne**
- Description : Tester l'app de bout en bout, verifier que les requetes passent du frontend au backend a la DB
- Assigne a : Tous
- Duree estimee : 1 jour

---

### Liste : SPRINT 3 — Mise en place Observability (Semaine 5-7)

**Carte 11 : Implementer le Logging**
- Description : Installer et configurer l'outil de logs choisi, connecter tous les services, verifier que les logs remontent
- Assigne a : Equipe Logs
- Duree estimee : 5-7 jours

**Carte 12 : Implementer les Metrics**
- Description : Installer et configurer l'outil de metrics choisi, creer des dashboards, configurer des alertes (UP/DOWN, latence, erreurs)
- Assigne a : Equipe Metrics
- Duree estimee : 5-7 jours

**Carte 13 : Implementer le Tracing**
- Description : Installer et configurer l'outil de tracing choisi, instrumenter l'app pour generer des spans, verifier les traces de bout en bout
- Assigne a : Equipe Tracing
- Duree estimee : 5-7 jours

**Carte 14 : Correler les 3 piliers**
- Description : Lier logs + metrics + traces avec un identifiant commun (trace ID), pour pouvoir naviguer d'un pilier a l'autre
- Assigne a : Tous ensemble
- Duree estimee : 3-5 jours

---

### Liste : SPRINT 4 — Scenarios de panne & Demo (Semaine 8-9)

**Carte 15 : Creer les scenarios de panne**
- Description : Definir 3-4 scenarios (crash frontend, crash backend, DB down, latence elevee), les scripter si possible
- Assigne a : 2 personnes
- Duree estimee : 2-3 jours

**Carte 16 : Tester les scenarios**
- Description : Executer chaque scenario, verifier que l'observability detecte le probleme, mesurer le temps de detection (<10 min)
- Assigne a : Tous
- Duree estimee : 2-3 jours

**Carte 17 : Documenter les resultats**
- Description : Pour chaque scenario, documenter : ce qui a ete casse, ce que les outils ont montre, en combien de temps, screenshots
- Assigne a : 1-2 personnes
- Duree estimee : 2 jours

**Carte 18 : Preparer la demo MVP (1er avril)**
- Description : Preparer une presentation qui montre l'app deployee, les 3 piliers en action, au moins 1 scenario de panne fonctionnel
- Assigne a : Tous
- Duree estimee : 2-3 jours

---

### Liste : SPRINT 5 — Amelioration & Finalisation (Apres demo 1)

**Carte 19 : Integrer le feedback de la demo**
- Description : Appliquer les retours de la VRT et du coach
- Assigne a : Tous

**Carte 20 : Ameliorer et completer les piliers**
- Description : Ajouter les fonctionnalites manquantes, ameliorer les dashboards, ajouter plus de scenarios
- Assigne a : Par equipe

**Carte 21 : Documentation finale**
- Description : Documenter toute l'architecture, les choix, les procedures, pour que quelqu'un d'autre puisse reprendre
- Assigne a : Tous

**Carte 22 : Presentation finale**
- Description : Preparer et repeter la presentation finale
- Assigne a : Tous

---

### Liste : EN COURS
> Les cartes en cours de travail (deplacer ici depuis le sprint actif)

### Liste : EN REVIEW
> Les cartes terminees en attente de validation

### Liste : TERMINE
> Les cartes validees et fermees

---

## 9. Etapes techniques detaillees — Du debut a la fin

### Phase 1 : Preparation (Semaine 1)

#### 1.1 — Configuration des acces
```
- Recevoir le mail de VRT avec les credentials AWS
- Se connecter a la console AWS via l'URL fournie
- Changer le mot de passe temporaire
- Activer le MFA (Multi-Factor Authentication) si demande
- Explorer la console : voir les services disponibles, la region configuree
```

#### 1.2 — Comprendre l'environnement AWS
```
- Identifier la region AWS utilisee (probablement eu-west-1 Ireland ou eu-central-1 Frankfurt)
- Verifier les limites de service (cost caps mis par VRT)
- Se familiariser avec : EC2, ECS, VPC, IAM, CloudWatch
- Chaque membre explore un service different et fait un resume aux autres
```

#### 1.3 — Recherche de l'application
```
- Chercher sur GitHub : "microservices demo app docker-compose"
- Exemples connus :
  -> Google Cloud Microservices Demo (Online Boutique)
  -> Weaveworks Sock Shop
  -> Spring PetClinic Microservices
  -> AWS Labs repos
- Criteres de selection :
  -> Docker-ready (docker-compose.yml present)
  -> Plusieurs services qui communiquent entre eux (minimum : frontend + backend + DB)
  -> Bonne documentation
  -> Pas trop complexe mais assez pour simuler du trafic reel
```

---

### Phase 2 : Recherche des outils (Semaine 2)

#### 2.1 — Outils pour le Logging
```
Options a evaluer :
- AWS CloudWatch Logs (service AWS natif, facile a integrer, payant au volume)
- ELK Stack (Elasticsearch + Logstash + Kibana) — open source, puissant, complexe a setup
- Grafana Loki — open source, leger, bien integre avec Grafana
- Fluentd / Fluent Bit — collecteurs de logs open source

Pour chaque outil documenter :
- Facilite d'installation
- Cout (gratuit vs payant vs AWS credits)
- Scalabilite
- Integration avec les autres piliers
- Communaute et documentation
```

#### 2.2 — Outils pour les Metrics
```
Options a evaluer :
- AWS CloudWatch Metrics (natif, facile, payant)
- Prometheus + Grafana (open source, standard de l'industrie)
- AWS Managed Prometheus + Managed Grafana
- Datadog (SaaS, trial gratuit, tres complet)

Pour chaque outil documenter :
- Types de metriques supportees
- Capacite a creer des dashboards
- Systeme d'alerting
- Integration avec les autres piliers
```

#### 2.3 — Outils pour le Tracing
```
Options a evaluer :
- AWS X-Ray (natif, bonne integration AWS)
- Jaeger (open source, CNCF, tres utilise)
- Zipkin (open source, simple)
- OpenTelemetry (standard open source pour collecter traces, logs, metrics)
  -> Note : OpenTelemetry n'est pas un backend, c'est un collecteur/SDK
  -> Il envoie les donnees vers Jaeger, X-Ray, ou autre

Pour chaque outil documenter :
- Support des langages de l'app choisie
- Facilite d'instrumentation
- Visualisation des traces
- Integration avec les autres piliers
```

#### 2.4 — Decision finale
```
- Reunion d'equipe pour comparer les recherches
- Choisir 1 outil par pilier (ou une solution integree comme OpenTelemetry + Grafana Stack)
- Rediger le document de justification
- Envoyer a la VRT pour feedback/validation
```

---

### Phase 3 : Deploiement de l'app sur AWS (Semaine 3-4)

#### 3.1 — Configurer le reseau AWS (VPC)
```
- Creer un VPC (Virtual Private Cloud) ou utiliser celui par defaut
- Creer des sous-reseaux publics (pour le frontend) et prives (pour backend/DB)
- Configurer les Security Groups (firewall) :
  -> Frontend : port 80/443 ouvert au public
  -> Backend : port accessible uniquement depuis le frontend
  -> Database : port accessible uniquement depuis le backend
- Configurer une Internet Gateway pour l'acces externe
```

#### 3.2 — Deployer l'application
```
Option A — Avec EC2 (machines virtuelles) :
  1. Lancer une instance EC2 (Ubuntu/Amazon Linux)
  2. Installer Docker et Docker Compose
  3. Cloner le repo GitHub de l'app
  4. Lancer avec docker-compose up -d
  5. Configurer le Security Group pour exposer les ports

Option B — Avec ECS (containers manages) :
  1. Creer un cluster ECS
  2. Definir des Task Definitions pour chaque service
  3. Creer des Services ECS
  4. Configurer un Load Balancer (ALB) devant le frontend
  5. Configurer le service discovery pour la communication inter-services

Recommandation : commencer par EC2 (plus simple), migrer vers ECS si le temps le permet
```

#### 3.3 — Configurer la base de donnees
```
- Option simple : DB dans un container Docker (sur EC2)
- Option AWS : Amazon RDS (base de donnees managee)
- S'assurer que le backend peut se connecter a la DB
- Tester avec des donnees de test
```

#### 3.4 — Valider le deploiement
```
- Acceder au frontend via le navigateur (IP publique de l'instance)
- Verifier que le frontend communique avec le backend
- Verifier que le backend communique avec la DB
- Faire quelques requetes de test
- Documenter l'architecture avec un schema
```

---

### Phase 4 : Mise en place de l'Observability (Semaine 5-7)

#### 4.1 — Implementer le Logging
```
1. Configurer la collecte des logs sur chaque service :
   - Installer un agent de collecte (CloudWatch Agent, Fluent Bit, ou Filebeat)
   - Ou configurer le logging driver Docker pour envoyer les logs
2. Centraliser les logs dans un seul endroit (CloudWatch, Elasticsearch, ou Loki)
3. Creer des filtres pour trouver rapidement les erreurs
4. Configurer des alertes sur les patterns d'erreur (ex: "ERROR", "500", "timeout")
5. Tester : provoquer une erreur et verifier qu'elle apparait dans les logs centralises
```

#### 4.2 — Implementer les Metrics
```
1. Installer les exporteurs de metriques sur chaque service :
   - Node Exporter (metriques systeme : CPU, RAM, disque)
   - Application metrics (temps de reponse, requetes/sec)
2. Configurer la collecte (Prometheus scraping ou CloudWatch)
3. Creer des dashboards dans Grafana ou CloudWatch :
   - Dashboard "vue globale" : tous les services UP/DOWN
   - Dashboard par service : CPU, memoire, latence, erreurs
4. Configurer des alertes :
   - Service DOWN -> alerte immediate
   - CPU > 80% -> alerte warning
   - Temps de reponse > 2s -> alerte warning
5. Tester : arreter un service et verifier que l'alerte se declenche
```

#### 4.3 — Implementer le Tracing
```
1. Instrumenter l'application :
   - Ajouter le SDK OpenTelemetry (ou X-Ray SDK) dans le code de l'app
   - Ou utiliser l'auto-instrumentation si disponible
2. Configurer le collecteur (OpenTelemetry Collector ou X-Ray Daemon)
3. Configurer le backend de tracing (Jaeger, X-Ray, ou Tempo)
4. Verifier les traces :
   - Faire une requete sur le frontend
   - Verifier qu'on voit la trace complete : frontend -> backend -> DB
   - Verifier les spans : duree de chaque etape, metadonnees
5. Tester : ajouter de la latence artificielle et verifier qu'on la voit dans les traces
```

#### 4.4 — Correler les 3 piliers
```
C'est LA partie la plus importante et la plus difficile :
1. S'assurer qu'un meme Trace ID est present dans :
   - Les logs (chaque ligne de log contient le trace ID)
   - Les traces (le trace ID est l'identifiant principal)
   - Les metriques (les exemplars Prometheus ou les annotations)
2. Configurer les liens entre les outils :
   - Depuis un dashboard de metrics -> cliquer pour voir les traces liees
   - Depuis une trace -> cliquer pour voir les logs lies
   - Depuis un log -> cliquer pour voir la trace liee
3. Tester la correlation :
   - Provoquer une erreur
   - Partir des metrics (detection du probleme)
   - Suivre vers les traces (localisation du service)
   - Suivre vers les logs (detail de l'erreur)
```

---

### Phase 5 : Scenarios de panne & Tests (Semaine 8-9)

#### 5.1 — Definir les scenarios
```
Scenario 1 : Crash du Frontend
- Action : arreter le container/service frontend
- Attendu : metrics montrent frontend DOWN, alertes se declenchent

Scenario 2 : Crash du Backend
- Action : arreter le container/service backend
- Attendu : frontend retourne des erreurs 500/502, traces montrent l'echec au niveau backend

Scenario 3 : Base de donnees inaccessible
- Action : couper l'acces DB (changer le Security Group ou arreter le service)
- Attendu : backend retourne des erreurs, logs montrent "connection refused"

Scenario 4 : Latence elevee
- Action : injecter de la latence artificielle dans le backend (sleep 5s)
- Attendu : traces montrent un span anormalement long, metrics montrent une augmentation du temps de reponse

Scenario 5 : Erreur applicative
- Action : injecter un bug qui fait crasher une route specifique
- Attendu : logs montrent l'exception, traces montrent l'erreur sur le span concerne
```

#### 5.2 — Executer et documenter
```
Pour chaque scenario :
1. Prendre un screenshot "avant" (etat normal)
2. Executer l'action de panne
3. Chronometrer le temps de detection
4. Prendre des screenshots des dashboards, traces, logs
5. Documenter le chemin suivi pour trouver la cause
6. Objectif : detection en moins de 10 minutes
7. Retablir le service et verifier le retour a la normale
```

---

### Phase 6 : Demo MVP — 1er Avril

#### Ce qui doit etre pret :
```
- L'app full-stack deployee et fonctionnelle sur AWS
- Au minimum 1 pilier completement fonctionnel (idealement les 3 au niveau basique)
- Au moins 1 scenario de panne demonstrable en live
- Un document de choix d'outils avec justifications
- Un schema d'architecture
- Une presentation claire de 15-20 minutes
```

---

### Phase 7 : Amelioration & Finalisation (Apres demo 1 -> Juin)

```
- Integrer le feedback de la VRT et du coach
- Completer les piliers qui manquent
- Ameliorer les dashboards et les alertes
- Ajouter plus de scenarios de panne
- Optimiser la correlation entre les piliers
- Rediger la documentation finale complete
- Preparer la presentation finale
```

---

## 10. Repartition recommandee de l'equipe (5 personnes)

| Role | Qui | Responsabilite |
|------|-----|----------------|
| Chef de projet / Scrum Master | 1 personne | Planning, communication VRT, Trello, standups |
| Equipe Logs | 2 personnes | Recherche + implementation du pilier Logging |
| Equipe Metrics | 2 personnes | Recherche + implementation du pilier Metrics |
| Equipe Tracing | 2 personnes | Recherche + implementation du pilier Tracing |
| Deploiement App | 2 personnes | Deployer l'app sur AWS (puis rejoint un pilier) |

> Note : les roles se chevauchent (1 personne peut etre dans 2 equipes). Le chef de projet participe aussi a un pilier technique.

---

## 11. Regles d'equipe recommandees

- **Stand-up quotidien** (15 min max) : chacun dit ce qu'il a fait hier, ce qu'il fait aujourd'hui, s'il est bloque
- **Mise a jour Trello** : deplacer ses cartes chaque jour
- **Communication avec VRT** : poser les questions dans le canal Teams, ne pas attendre d'etre bloque depuis des jours
- **Documentation au fur et a mesure** : ne pas tout laisser pour la fin
- **Review croisee** : chaque equipe presente son travail aux autres regulierement
- **Estimation du temps** : pour chaque tache, estimer le temps avant de commencer, puis comparer avec le temps reel

---

## 12. Ressources utiles pour commencer

- **AWS Labs GitHub** : repos avec des apps et tutoriels d'observability
- **OpenTelemetry documentation** : standard open source pour l'observability
- **AWS Well-Architected Framework — Pilier Operational Excellence** : bonnes pratiques AWS
- Chercher sur Google/YouTube : "observability on AWS tutorial", "distributed tracing explained"
- Chercher sur GitHub : "microservices demo docker-compose", "observability demo"
