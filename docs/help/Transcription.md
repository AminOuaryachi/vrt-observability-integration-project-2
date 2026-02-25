00000200  00001711

Als het te vertellen heeft. Ja, mensen jaar oud inmiddels. Wat heb je? Wat zijn jouw keuze? Dingen die je hebt.

00001713  00002622

De stoer Asos, de andere Crystal.

00002624  00004515

Zoals en deze wachten tot dat om te zien dat dit. En digital consultant Ja, Ilias. Keek je naar televisie?

00004517  00010709

Maar het verhaal van die Ik zal van jou. We gaan nu niet verder, Laten we dan wat typen. Dank je wel. Ik denk dat het nu is aan de mensen van de van de VRT. Ik laat het aan jullie twee om te kiezen dat er eerst komt. Ik ben al een minuut, dus dan zal ik misschien starten. Dus ik ben ermee.

00010711  00014206

Ondertussen ook met Axel die twintig jaar hier en ik ben dan 49. Ik ben dat team lid van het team waar de product owner van is. Kort Ik ben 1015 jaar lang Java web developer geweest en dan scrummaster slash teamcoach geworden voor heel wat firma's waaronder ook Base, Telenet, Proximus, KPN. In Nederland en is nu VRT. Mijn hobby's zijn ook sport, maar ik zal specifieker zijn, ik doe full contact karate.

00014208  00015419

Ik weet niet of dat jullie sport ook iets van gevechtssport is of niet en dat ik door kickboksen acro.

00015421  00021206

En verder ben ik ook actief op de muziekacademie. Ik speel heel wat muziekinstrumenten en ik heb twee kindjes. Maar mijn grootste hobby is live action role play. In het weekend met mensen wapens op elkaar slagen en zien wat er harder slaagt.

00021208  00021519

Heel, heel mooi. Ja.

00021521  00024607

Alright, ik ben dan zoals je al zegt naar een kortfilm, maar ik heb toen ik twintig was ook zes jaar gewerkt als architect assistent ingenieur bij de VRT. Dat start from the bottom dan weer hier. Ik ben 26 en ik heb een dochter. Ik ben 27, ik heb een dochter. Ik ben dus 130. Dat ik Hajime.

00024609  00030922

En ja, eigenlijk net als je man en dan de dochter bezig zijn doe ik niks anders dan leven. Dus dat is zowat whisky drinken en whisky drinken en ik ben er bijna. Ik ben 220 Meer eten en gerechten en.

00030924  00034010

S avonds. Super! Dank je wel! Dankjewel voor de voorstelling. Ik stel voor dat we overgaan naar het onderwerp Distributed tracing binnen apps en we hebben een omschrijving. Ja, project omschrijving is een beetje verkeerd, dus niet enkel distributed tracing. Ik zal misschien al beginnen mijn project een beetje te omkaderen dat licht. Dus Het is heel goed dat jullie willen vertellen dat wat CRT is state of the art apps omgeving.

00034010  00043000

Dus jullie hadden echt wel en mijn next gen tech werken ook door werkgevers over heel België, Benelux en eigenlijk over heel de wereld. Zet de 60 tot 70% op always dus always heb je altijd heel goede goede job posities. Ja het is ook ja. Heel goed dat jullie daar direct mee beginnen, want dan kunnen jullie direct al aangeven wat De werkgevers van jullie hebben met awards gewerkt, want daar vragen ze meestal euhm project zelf is niet dus dat met tracing, maar observeer build die in zijn algemeen observeer build die bevat drie pilaren, waaronder distributed tracing, maar de twee andere pilaren zijn ook metrics en logging, dus alles bijvoorbeeld van A tot Z.

00043000  00045522

Van dat een gebruiker een site opent zoals VRT nieuws of Sporza dat dan artikel klikt, gaat die request langs verschillende checkpoints om het zo te zeggen. Dus je hebt de frontend, je hebt de backend daartussen waarschijnlijk nog andere microservices aangesproken worden zoals een server en een DRM server. De login server om te zien of dat de user authentication is of niet.

00045524  00052404

Al die spinnenweb om het zo te zeggen wordt heel moeilijk als je daar geen observe build op hebt. Dus als zit het te fijn en er gaat iets kapot, dan hebt ge die drie pilaren nodig die je observeert. Build die vorm schept metrics om te tonen van is iets up of down, eh de logs. Elke server produceert logs, Elk systeem produceert logs in tekstformaat.

00052406  00055901

Dan hebt ge. De derde is dus distributed tracing. Tracing werkt meer als. En inderdaad, voor de mensen die interesse hebben in netwerk en spans, Dus dat is effectief de request van begin tot op het einde en verschillende spans van hoe lang dat elke checkpoint heeft geduurd, alle metadata die daarin zit en de moeilijkheidsgraad die erin gaat zijn om die drie pilaren met een idee aan elkaar te linken, zodat je eigenlijk alles gecorreleerd kunt terugvinden.

00055901  00062511

Dat dialoog bij die triggers hoort en dat die triggers bij die Patrick hoort en zo maakt ge elk uw eigen leven later ook gemakkelijker. Als je in een team gaat zitten en dat team is verantwoordelijk voor de uptime van verschillende systemen. En ik had dan s nachts opgebeld door je dan en één over house stalken, pinpointen waar dat het probleem zich vaststelt vooruitgaat.

00062511  00065706

Daarom ook wij gaan jullie een geïsoleerde AWS omgeving geven, dus jullie gaan toegang krijgen met veel admin op die apps omgeving. Wij zorgen wel voor de servers gelijk. Wij zetten de CrossCup op de apps omgeving zodat jullie geen per ongeluk uh € 3.000 op één seconde kunnen spenderen. Dus wij zullen die alarmen wel zetten. Dus no worries, jullie krijgen ook volledige admin rechten dus jullie gaan niks wsl Kelly of API's moeten doen.

00065706  00072022

Jullie kunnen gewoon alles bijeen klikken via de user interface op uh de alias console zelf via de webbrowser om dan al eigenlijk een look en feel te hebben. Van welke services zijn er? Hoe kunnen we die inderdaad bijeen klikken dus. En uh. Dus daar gaat jullie omgeving zijn en we bieden jullie ook een chat ter beschikking. Dat kan teams zijn of een selecte connect.

00072024  00074519

Dat is jullie keuze. Maar en dan kan daar altijd een vraag gesteld worden en dan de volgende werkdag zal mijn collega's hier en daar wel steun bieden van. Als jullie specifieke expertise nodig hebben of specifieke vragen hebben omtrent de service, kunnen jullie die daar altijd stellen en dan zal de volgende werkdag meestal daar wel op geantwoord worden. Dat is dat.

00074521  00081103

En de scope van het project is inderdaad jullie moeten dus een full. Uh ja, ik gebruik nog de term lamp stack, maar dat is heel oldskool. Maar dus een hele USB stick deployen gewoon en gewoon een USB stick. Gewoon een frontend, een backend, een database en een API of zo. Wat dingen daartussen zodat jullie dat eigenlijk zelf kunnen simuleren.

00081103  00084918

Van een request dat binnenkomt op de frontend die helemaal naar achter gaat en respons teruggeeft. En dan ook in een scenario uitschrijven waar dat jullie expres een fout in injecteren zodat er iets crasht zoals de frontend. Of dat jullie zelf de frontend efkes afzetten of de backend afzetten met de stopknop en zien hoe dat dan eigenlijk. De monitoring die jullie dan gaan opzetten voor dit project, de observe build die daarop gaat reageren en of dat die effectief het probleem kan pinpointen en een timeframe van laten we zeggen binnen 10 minuten kunt ge zien waar het probleem dus in zit.

00084918  00092607

Dus jullie taken gaan zijn van een tool uit te kiezen voor woord voor elke pilaar. Dus een tool kiezen voor logs, een tool kiezen voor metrics en een tool kiezen voor voor tracing. Daar hebben jullie meer vrijheid in van wat jullie gaan doen. Dus jullie gaan dan ook zelf moeten research doen. Want uh, we hebben voor dit doel gekozen, want uh de uitleg daarbij, want er zijn heel veel tools, dus jullie mogen opensource dingen gebruiken van GitHub, maar jullie mogen ook observaties gebruiken die in apps zelf zitten.

00092609  00095320

Maar dan moeten jullie wel altijd de keuze de keuze kunnen uitschrijven van waarom heb je voor dit specifiek bijvoorbeeld een AWS service bijvoorbeeld genomen in plaats van een opensource tool dat elk zijn eigen kracht en de voordelen en nadelen daarbij beschrijft? Van uh. Want we hadden inderdaad te weinig tijd, dus daarom hadden we webservices gebruikt of de opensource tools lukt gewoon en de service is tien keer beter.

00095322  00101618

Dus dat jullie ook een beetje kostenefficiënt de wijs gaan met jullie eigen tijd, maar ook de tijd van hoe dat in het echte leven is moeten wij altijd de kosten afweging doen van ja, een consultant vraagt een uurtarief. Hoe lang gaat dat nodig zijn om dat zelf tempo te implementeren versus dat we gewoon een tool gebruiken dat allemaal wisselt.

00101618  00104402

Dus dat is ook altijd een heel belangrijke oefening voor jullie later Van Je kunt alles zelf bouwen in deze wereld, maar is het kosten gewijs interessant voor de werkgever, Want hij betaalt u uiteindelijk op het einde van de dag en als ik bijvoorbeeld een advies tool kan gebruiken en en implementeren een half uur of ik ga dat zelf maken in dertig dagen ja nee, tuurlijk, voor die half uur kiezen.

00104404  00105014

Dat is het. Zo globaal zijn daar al enkele vragen. We.

00105016  00111503

Voor mij was wel duidelijk jullie kunnen ook op gevoel als jullie gewoon de term observe ability in Linux op tikken, kunnen jullie ook alles zien van verschillende vendors van data. Ze hebben heel goede lessen over het thema Observatory, hoe dat spans eruitzien, hoe dat precies eruit zien. Dus het internet is ook jullie vriend. Hebben.

00111505  00111905

Ja.

00111907  00115404

In feite de vragen of eerste vragen die opborrelen. Alle vragen zijn toegestaan, dus als we later vragen hebben, kunnen we dat stellen in op teams heb ik gezegd ja, die moet sowieso een groepje hebben. Of ja, ja, ja oké, ik zal ons team met jullie team toevoegen. Wij zijn ongeveer met zes collega's en dan jullie met vijf en dan zal die daar allemaal in inzitten.

00115406  00122001

Ik vroeg me af waar dan in. Je hebt het over over een een simulatie van zo'n zonder een full stack en dan en een en een isoleerde omgeving. Hebben jullie zelf een idee van een inhoudelijk voorbeeld om zo'n gesprek te bouwen? Iemand is inderdaad de content stack kan simuleren, maar heb je in mijn voorbeeldje vanuit de wereld hypothesen gevonden?

00122003  00130019

Ik zeg maar iets. De website veertien UCB bijvoorbeeld. En ik vraag me gewoon af als je iets moet simuleren of dat het daar niet beter een voorbeeldje tonen. Want ja, ja, onze systemen simuleren, dat gaat sowieso niet lukken. Die dan te complex. Maar wij. Wat wij wel vooral aan studenten zeggen is als hij gewoon op GitHub intikt op Google uhm, mock up full abstract dan gaat ge sowieso reposten dat waar mensen effectief full stack apps met front en dekkend API's ertussen al klaar hebben staan en die gewoon via Docker opspuiten zijn.

00130021  00131123

Oké ja. Dus er zijn genoeg Hello World applicaties op GitHub. Dat dat.

00131200  00134612

Ook nog eens bijvoorbeeld. Wat ik ook zou aanraden is Labs zelf is heel opensource, investeert, dus zij hebben zelf op GitHub ook heel veel learning repos staan ter beschikking voor studenten en ik denk dat er ook eentje tussen zit voor observe build die. Dat is ook een app. Zij kunnen geven aan jullie dat jullie kunnen deployen op de apps omgeving met stappen uitgelegd en en dan kunnen zij ook scenario's zoals aanleveren van hoe dat je effectief een failure kunt maken.

00134614  00141314

Dus zij hebben ook een heel groot arsenaal van knowledge links staan. Nu ik denk voor én voor de studenten. Jullie hoorden taal ethiek drie die drie pijlers. Ik denk dat dat al een nu een een, een redelijke verdeelsleutel kan kan zijn. I. Ik hoor al dat jullie tools moeten kiezen en je had moeten een voorbeeld staat kiezen had moeten doen.

00141314  00144308

Correcte documentatie verzamelen. Je zal proactief moeten communiceren met het team maar ook dan zijn team om dan extra informatie op te vragen. Dus denk dat er wel van alles is. Van bouwblokjes nadenken over nadenken om om een initiële planning op te stellen. Nu als het gaat om om toegangen. Bogdan wat voor hebben zij een login nodig? Hebben ze meerdere logins nodig?

00144311  00151903

Hoe zie je dat precies? Dus elke student krijgt zijn eigen login toegestuurd via mail. Daar zullen wij voorzien, dus wij gaan sowieso nog een account aanmaken. Dus dan moeten we eerst nog afspreken van wanneer gaat dit project effectief live? En dan gaan wij elk elke student een aparte login sturen die dan via een url dat wij provide via die console login kunnen gaan aanmelden en daaruit hebben jullie volledige admin rechten op uh om dingen samen te stellen.

00151905  00155202

Ja ja ja sorry euhm dat is dus dat is handig om te weten. Tools zoals Trello en zo gaan jullie zelf hier moeten kiezen. Trello kan zelf onder Microsoft of jullie eigen school natuurlijk waarschijnlijk Trello gratis aanbieden, dus jullie kunnen voor projectmanagement kiezen. Jullie zelf maar en omgeving en tool uitmaken. Dus voor de compute gedeelte moeten jullie volledig gebruik maken van die sandbox omgeving.

00155204  00161807

Dus alles moet ook uiteindelijk in de portal in de cloud op het einde van de stage opdracht. Ja ja ja ja ja ja ehm. Maar qua puur qua qua qua hosting. Op de de kaart zijn de. Tijdens de opbouw van het project kan men al direct gebruik maken van die omgeving. Of ja, jawel, oké, ja zowat. Dus studenten kunnen we rechtstreeks werken, dus dat ook.

00161809  00164107

Ja, ja, ja, ja. Oké, dan is dat dan is dat duidelijk. Oké, nu sowieso is de bedoeling is dat de studenten eerst 111 ruwe planning uitwerken. Nu wil dan al een interne meeting voorzien binnen twee dagen Nu, ik weet niet of dat dat van jullie als dat lukt of niet of als dat de stijl is, kunnen we dat ook altijd verplaatsen.

00164107  00170614

Mocht dat mocht dat nodig zijn. Denk daar eens een keer of bespreek de eerste keer onderling nu dat je de opdracht hoort. Het is ook duidelijk dat de opdracht met heel wat mogelijkheden te achterhalen en en een kies waarin je inderdaad de vrijheid creëert om iets om iets uit te werken. Dus kies een bijzonder stuk kies tools kan ook zijn heel wat tijd nodig had om de juiste tools te kiezen.

00170616  00173513

Loop er ook niet aan vast. Ik bedoel, haat moet moeten. Keuzes maken kun je eindeloos blijven vergelijken. De tijd is ook beperkt natuurlijk, maar zoals dat bord aan elkaar geeft is belangrijk van te kijken naar de de pro's en contra's hier. Dus als je de moeite doet om tools te gaan bekijken en te gebruiken hebt die energie daarin investeert om die willen te maken, maak daar dan ook een neerslag van.

00173513  00180221

Die maakt duidelijk waarom dat dat voor iets kiest en soms dat is ook een real world problem dat ik aan jullie geef, want we hebben deze oefening in 2015 bij de VRT moeten doen tot 2016, waar de staf zegt we hebben honderden systemen en jullie zijn verantwoordelijk voor de tools te kiezen. En eens dat die keuzes gemaakt zijn in data aan al die honderden systemen dat dat gebruiken.

00180223  00182519

Dus je hebt wel die verantwoordelijkheid, want als later je verkeerde vraagt van dat je inderdaad doordachte keuze kunt maken op pro's en con's, want dat gaat heel hard geschaald worden. En je kunt dan niet zeggen als iedereen de tools in gebruik heeft genomen om dan een maand later zei ja nee, dat was toch niet de juiste tool? Ja nee, terugsturen.

00182521  00190302

Loopt in een bepaalde richting. Uiteraard kunnen je niet zomaar terugkeren. En dat om het heel cru te stellen. En dat wordt dan zei ook van die hebben betaald die per uur dienen. Consultant. Het komt er natuurlijk ook niet. Ja, eigenlijk alles dat jullie doen, elk uur dat jullie werken aan dit project. Hoe je zien in een commerciële omgeving als allee, als als de opbouw van als die facturering dus als opdrachtgever hadden ook niet onbeperkt het kapitaal hebben om dat te doen, van data heen moet moeten en een plan opstellen.

00190304  00192810

Probeer daar zoveel mogelijk aan te houden. Tijd begroten, dat is een belangrijk onderdeel in het project. Schatten hoeveel tijd wel te gebruiken. Laat dat ook voor aan u, aan uw opdrachtgevers en om te zien. Dan is het eigenlijk wel realistisch. Dan kan een opdracht hier ook zijn. Sorry, maar is wel heel veel tijd om tools te kiezen of voor een ander onderdeel van het van het project te gaan.

00192810  00195224

Dan kunnen dat ook een keer meer en meer een aanvoelen. En bovenal verdeel de taken. Ook dat is heel belangrijk dat je dat doet in dit project. Daarvoor zijn er ook zo'n projecten om te leren, taken te verdelen en ook om te dienen. Te communiceren binnen een team. Omdat dat iedereen wel zijn verantwoordelijkheid ook effectief opneemt En dat je voor elkaar kunt staan bij problemen.

00195301  00201812

Maar goed, niet dat dat per se iets, iets iets nieuws is. En je mocht ook de keuzes van de tools zo formuleren van deze tools zijn goed om als je een long als short term Peugeot hebt versus je hebt een medium period dat je krijgt versus long term, want dat is ook iets wat wij moeten doen als uh als ingenieurs later in ons werk.

00201814  00203903

Als ze zeggen van oké we willen een proof of concept launchen, dan mag max drie maanden duren. Dan gaat hij een andere toolset aanbieden en integreren dan als ze zeggen van hé we moet uh, we hebben zes maanden of een jaar lang de tijd, dus om een heel dwaas voorbeeld te geven je kunt een virtual machine hebben voor een proof of concept waar je opslag op draait.

00203905  00204207

Op midterm kunt ge.

00204209  00210211

Op op containers draaien en long term kunt ge dan een tool kiezen als Kubernetes. Als je een jaar de tijd hebt en moet kunnen schalen. Dus je kunt ook zo een ranglijst van de aanmaak van tools van short term voor die methode, voor dat long term of dat is ook altijd stuk. Ja.

00210213  00212820

Maar jullie zullen ook direct zien, want ik heb hier een mix van en sommige zijn inderdaad meer intern. Netwerken zal meer en meer in de cybersecurity, dus jullie gaan met die drie pilaren elk een beetje ook in aanraking kunnen komen met elk aspect. Want tracing gaat inderdaad meer op netwerkniveau zijn omdat je dan echt met die spans zit, terwijl de matrix alles echt heel applicatie is en minder met netwerken te maken heeft.

00212822  00215418

Maar dan ook als je daarmee bezig zijn gaan jullie ook zien hoe dat de information flow doorheen de tech straks doorheen gaat. En dat is ook iets voor een cybersecurity expert. Heel belangrijk om te weten van hoe zien zo'n request eruit? Hoe ziet de flow van app van punt A naar B uit en hoe kunnen we die flow secure?

00215420  00221802

En sowieso kijken naar de good practices. Ik bedoel, er zijn altijd vooral die dingen zijn een good practices en zijn er heel typische dingen die in die die opgevolgd worden. Om heel goeie reden meestal, dus daar kunnen ze een keuze maken. Ik denk hier vooral dat het als project kijkt. Het definieert de scope is breed, de tijd is beperkt.

00221804  00223517

Dat wil zeggen dat we uw scope gaan moeten afstemmen op iemand, data moeten maken, dat het voldoende evenwichtig is dat alles aan bod komt, maar ht ambities moeten bijstellen op basis van de tijd die het klikt.

00223519  00225006

En op een kleine vraag ook elke specifieke service moeten gebruiken of. Om alle services.

00225008  00230424

Die ze alles kiezen maar eerst heeft. Heeft per product zeggen. Heeft een heel breed aanbod en 160 services dat is ook elk gecategoriseerd.

00230501  00232917

Zoals dingen waar jullie waarschijnlijk veel aan drukken is de categorie compute. In de computer hebt ge vier min services zoals C2 dat ze allebei hun virtual machine product. Uh. En ge hebt dan ook zo ESX. Dat is de container rijst omgeving dus die ervoor gaat. En je hebt ook manage burnouts.

00232919  00234509

Maar zoals drie zegt, dat beperkt dat altijd. Ik zal ook leverbare Metal Kubernetes servers op spinnen bij de klanten, maar ze hebben niet meestal het budget ervoor.

00234511  00241022

Oké, oké. Ja dus hoor. Dit is een hele grote speelt in scope bepaling. Keuzes maken. Ehm ja, we moet. Het is een trechter mentaliteit en staat breed. Daar moet groep kunnen focus gaan bepalen. Dus het voordeel is hebt heel veel keuze. Maar het nadeel is je hebt heel veel keuze.

00241024  00241502

Op hetzelfde.

00241504  00243319

Safa Ik stel voor dat ik er nog een vraag over leg en dus op 1 april is uh onze eerste demo die we toch moeten voorstellen. Uhm uh. Vraag is.

00243321  00250115

Alleen als we dan mogen weten is wat uw mogelijke verwachtingen op de demo i wou maar moeten kunnen doen. Moet al bijna af zijn. Of dan gewoon misschien het minimum hebben of moet zeggen dat ge moet een MVP minimum minimum viable product moet aanbieden. Zijn moet iets hebben dat werkt, iets kleins, maar het hoeft nog niet met alle toeters en bellen te zijn.

00250117  00252606

Maar het moet wel aangeven dat laten we zeggen dat de op de verticale as één van de alles alle puntjes aangetikt hebt, dat je iets iets werkbaar hebt en dan kunnen en die tweede fase kunnen verder gaan gaan verbreden. Het is dus moeten zien vanuit een uh het een het een agile principe dus that means meestal iets kleins al werkt en dan kunnen van daaruit verder uitbouwen.

00252608  00255801

Ik denk wel wat dat je best wel doet is. Je hebt daar ook verschillende inhoudelijke keuzes die je kunt maken in. Ik hoor hier al de drie P's, daar de drie pilaren. Je kunt zeggen van ik ga het minimum viable product maken voor elk van de drie pilaren het minimale en dat dan verder in het begin. Kan ook zijn dat je zegt van niet weten te bekeken dat en we zien dat we dan een bepaalde volgorde gaan hanteren en die pilaren kan die?

00255803  00262602

Uhm dat zijn zaken. Ik kan daar geen uitspraken over doen. Dat zijn zaken die je eigenlijk door, door door te communiceren met je opdrachtgever gaan ontdekken. Van van van hoe pak je zoiets aan? Ik durf ook gewoon te vragen er zijn geen domme vragen alleen te zijn. Wel domme vragen. De verhaallijn die stelt. En niet Ik bedoel, we kunnen altijd alle vragen stellen aan onze goeie vrienden Tante Betsy, maar die haar niet het antwoord kan geven dat mensen geven.

00262602  00263412

Niet natuurlijk als ganse dagen mee mee bezig zijn. En ook wel omdat je inderdaad een keuze moet maken in.

00263414  00265616

Ja maar dus weet gewoon je moet inderdaad 1111 iets hebben dat dat dat werkt, maar dan moet je nog niet alle toeters en bellen zijn. De bedoeling is ook van zo'n een een tussentijdse, zo'n tussentijds moment. Een tussentijdse oplevering is om te zien van waar moet er nog bijgestuurd worden. Dat is ook het mooie aan zo'n project is net dat we allee.

00265622  00271909

Dus sowieso de bedoeling is. Niet dat je nu in die eerste fase niet moet begeleid worden. Absoluut wel, maar het is gewoon veel van wat we zien van gaat het de goeie richting is. En door elementen tussen momenten te werken worden ook voor een stukje gedwongen om om te haal om toch al iets. Goed, en dat zal concreter worden naarmate de tijd vordert.

00271909  00273422

Nu is dat misschien allemaal nog wat vaag, maar toch eerst moeten inwerken en het en het topic, maar ook daarin inwerken. Zelf aan de hand en met je keuzes. Maar je kunt als hij wat kan hele boeken lezen.

00273424  00275507

En dat is ook niet de bedoeling. Zoveel zijn er veel dingen die het maar hebben Beperkte dit. Ja dat is het. Ja en durf ook. Durf ook onderling te delegeren als ze zegt van we verdienen het werk onder de drie pijlers verdeeld het werk om de drie pijlers hier als basis met metrics en andere, maar. Maar mijn laatste ben trouwens nummerke drie.

00275508  00281811

Verdienen de spans dan Alleen dat kun je al netjes verdelen. En dan natuurlijk elkaar goed op de hoogte houden van wat je geleerd hebt. Want als Tienen een impact heeft op het ander, dat is omdat dit dicht bij laat weten aan mekaar. Ja, ja.

00281813  00284504

Verdeel zeker dat werk, want dan niet vijf man met metrics bezig zijn. Voilà, twee man met tracing, twee personen met logs en twee met met met metrics dat je dat echt wel verdeel, anders had je dat inderdaad. Ja, ja, ik heb en ik raad ook wel aan om onderling ook dat deel stand up te houden, dat je dus met elkaar elkaar elke dag een beetje op de hoogte houdt van hoe laat de progressie is.

00284506  00291206

Dan kunt ge ook kijken als iemand effectief al een week lang vastzit op hetzelfde dat de rest kan inspringen. Ja ja, misschien nog wel meer dan vanuit de school. Dus eind juni wordt een dode door één persoon ineens. In dit geval is dat ik als ik merk dat er qua inhoudelijke inhoud en dat ik technisch niet zo meekunnen binnen het team van mijn docenten naar mij allemaal specialisaties.

00291207  00293324

Ik weet natuurlijk ook wel wie ik daarvoor kan aanspreken en we gaan ook intern binnen de school de juiste personen dingen aan vragen indien dat dat nodig is. Niet iedereen kan kan kan alles weten. Er zijn heel veel diverse verschillende soorten thema's, dus ik kan ook niet verwachten dat iedereen een ABS expert is. 1 juni gaan daar worden in.

00293401  00294508

Als jullie jullie moeten werken ga je daar nu worden. En inderdaad gaat dat heel gewoon op de CV staan als wat er op de arbeidsmarkt komt.

00294510  00295107

En ook zijn er nog vragen.

00295109  00301705

In een van mijn schoenen. Oké, nu belangrijkste is denk ik nu concrete vervolgafspraken. Dus al met al goed te gaan. Een mail krijgen met een login indien je toegang hebt tot die omgeving. Normaal gezien je toegang krijgen tot een communicatie omgeving in de teams. Uhm dus dat zit al goed. Maar weet ook natuurlijk dat je dan gaat moeten verdere afspraken maken met de opdrachtgever.

00301707  00304116

Ik zou het durf vragen stellen. Op zijn minst al handig dat je kunt chatten nu. Als je merkt dat een vastloopt, neem contact op met me als het neem contact op mijn boord dan uh. Desnoods plan je de metingen in. We hebben moderne communicatiemiddelen. Het is gewoon kort in de agenda te plannen. Dat moet ook allemaal niet, tenzij je niet alleen een specifiek probleem hebt.

00304116  00305921

En wat kan ik hier over babbelen? Kunt wel veel chatten, maar soms is een gesprek beter dus dan over die communicatie stap te zetten in. We leven in een tijd dat er nogal heel veel chat wordt zodat telefoneren ook niet meer zo populair is. Maar alstublieft, als er echt vastloopt, Hoe vroeger deed je dat zo'n beetje op de computer dat?

00305921  00310407

Dat is een leerproces.

00310409  00312805

Oké, dus wat betreft de speelzaal of wat dan weer in tijden van eenzaam na een afspraak vrijdag? Als er al de denkfout veel te kort ben, geef me een seintje dan. Dan verplaatsen dat wel naar naar naar naar volgende week. We gaan nu toch eerst niet in die hele studie moeten doen, maar weet ook die studie hadden moeten inplannen.

00312805  00314918

Haar moeten voor uzelf bepalen. Hoeveel tijd heb ik nu nemen om om dingen te bekijken gaat. Sowieso moeten op korte tijd een plan in staan en dat plan dus ook in het Engels. Dan heb je daar het woordje bold voor in bold wil zeggen ja ik je dat dat moeilijk te vertalen zo brutaal gewoon kiezen. Even moet en is een planning kiezen.

00314920  00320904

Een planning kunnen nog altijd bestaan, maar als je geen concrete planning maakt dan gaat er ook niks gebeuren. Of daar gaat alles uitgesteld worden of hadden niet kunnen zien of dat wel goed die planning en het vol zit. Ja, het wordt hier differentie kader dus durf daar ook stappen in te definiëren.

00320906  00324522

Ik had nog een vraag richting omgeving, maar dat zo snel mogelijk aangemaakt worden en bezorgd worden de gegevens of pas na een bepaalde tijd nu niet niet behandeld. Dan zal ik daarstraks richting het team bij ons communiceren dat onze filter dan die account aanmaakt. Normaal is dat heel snel proviand en dan ja de laatste. Volgende week maandag zullen jullie allemaal een mail ontvangen, elk ieder apart met dan jullie gegevens en ook hoe dat jullie.

00324524  00330919

De wachtwoord dan moeten veranderen want jullie krijgen dan in de link een one time paswoord die dan effectief veranderd moet worden. Dan kan ik dus nu ook voor. De studenten moesten nu zeggen van oei shit, ik weet niet waar dat moet beginnen, Laat dat doorgaan in vaderdag als dat van uw chat, maar ik zou zijn in eerste instantie.

00330921  00332903

Je hebt het woord, Je hebt de opname van deze meeting overlaat. Deze kan onderling voor een eerste plan van aanpak, dan hoor ik het wel of dat we dan in vrede afspreken of eventueel in de loop van volgende week, dan plannen we dat wel. En dat is allemaal geen probleem. We zijn er voor jullie en en dan ja, kan ik ook alleen maar zeggen.

00332903  00334619

Ik wens jullie veel succes met de opstart en ik van het project. En dan? Dan horen we elkaar later. Is goed. Nog een laatste vraag. Ja ja dus om echt zo.

00334621  00334900

Die.

00334902  00343710

Op GitHub zijn er weer de verschillende repos en sommige echt alles kiezen dus bijvoorbeeld een site, een site kiezen om om die site te traceren. Zo bijvoorbeeld. Of. Of moeten we zo'n specifieke een specifieke andere te kiezen? Moeten we echt? We hebben dus welke soort sites moeten we kiezen om die te traceren, enzoverder. Dus de de app stack zelf, de demo zelf waar jullie de tracing de logs en metrics van gaan capteren moet sowieso inhouse in onze apps omgeving de plaats zijn.

00343712  00351516

Jullie gaan sowieso alleen. Het is niet genoeg om gewoon inderdaad naar 14 december de trage start te nemen. Dus dat. Jullie gaan een Hello World webstek van en ik het op repo moeten vinden kiezen, deployen en vanuit daar bouwt ge dan eigenlijk die tree pillar. Dus vanaf dat ge uw Hello World webstek hebt zijn er super veel voorbeelden om gewoon de deployen heel snel vanaf dat dat opstaat kunnen jullie daarrond beginnen met die drie pilaren dan ook kritieke.

00351518  00355720

Niet oké. Zijn er nog vragen opmerkingen? We hebben voor mensen momenteel geen vragen. Oké, goed, dan denk ik dat we hier bij kunnen kunnen afronden. Ik was, ja ik heb het al gezegd. Kan iedereen veel succes en ik hoor het dan in de jullie zijn nu aan zet. Hoe ik zal ik het team. Ik zal dat gesprek dan direct aanmaken tussen mijn en jullie team en dan de invite zullen jullie wel in jullie mailbox één van deze twee passeren.

00355722  00361422

Oké goed, dank je. Zal dit, Dan kun je daar uitleggen?

00361424  00362312

Wat je daarvan.

00362314  00362607

Als jullie.

00362609  00362615

Hier.