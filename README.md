
    I denna uppgift skall vi implementera databashantering och REST API för en e-handel.

---
## Grundläggande krav

<input type="checkbox" disabled/> Det ska gå att skapa nya proukter som lagras i en databas(SQL-Server eller MongoDB)

<input type="checkbox" disabled/> Det ska gå att ändra och ta bort produkter i databasen

<input type="checkbox" disabled/> Det ska gå att markera att produkter utgått ur sortimentet 

<input type="checkbox" disabled/> Det ska gå att hämta alla produkter

<input type="checkbox" disabled/> Det ska gå att söka efter en produkt på produktens namn eller produktnummer

<input type="checkbox" disabled/> Kunder ska kunna registrera sig och uppgifterna skall lagras i databasen.

<input type="checkbox" disabled/> Kunder ska kunna uppdatera sina uppgifter

<input type="checkbox" disabled/> Det ska gå att lista alla Kunder

<input type="checkbox" disabled/> Det ska gå söka efter kunder på e-post adress

<input type="checkbox" disabled/> När en kund anmäler sig/köper placerar en order måste vi kunna spåra vilken/vilka produkter som kunden har köpt

---
## Detaljkrav

### För en produkt skall följande uppgifter lagras i databasen

* Produktnummer
* Produktnamn
* Produktbeskrivning
* Pris
* Produktkategori (Mejeri, elektronik, husgeråd eller liknande)
* Status (om den finns i eller har utgått ur sortimentet)

---

### För en deltagare skall följande information lagras

* Förnamn
* Efternamn
* E-post
* Mobilnummer
* Adressuppgifter

---
## Designkrav

REST Api-lösningen skall utvecklas enligt objektorienterade principer och använda följa Single Responsibility Principle.

* All databaskommunikation skall också ske med hjälp av Repository Pattern.

---

## Användargränssnitt
Här lämnas det fritt, antingen kan vi använda JavaScript, React, Vue.js, Blazor eller ASP.NET MVC för att implementera en applikation för att kommunicera med REST Api-lösningen. Klientapplikationen skall kunna presentera och hantera produkter och deltagare enligt de grundläggande kraven ovan.

---

## Bedömning
### Godkänt(G)

<input type="checkbox" disabled/> En API-specifikation ska skrivas och bifogas i repositoryt.

<input type="checkbox" disabled/> Denna specifikation ska tydligt redogöra för alla endpoints och deras funktion.

<input type="checkbox" disabled/> För att få godkänt skall alla delar för produkthantering vara implementerade. 

<input type="checkbox" disabled/> Kravet på att följa Single Responsibility Principle skall vara implementerat.

<input type="checkbox" disabled/> Repository Pattern skall vara implementerat och användas för all databaskommunikation.

<input type="checkbox" disabled/> En klientapplikation skall nyttja REST Api:et och uppfylla designkraven.

---
### Väl godkänt(VG)
<input type="checkbox" disabled/> För väl godkänt skall alla krav på G nivån vara uppfyllda. Förutom detta skall REST Api:et även implementera Unit of Work mönstret.

<input type="checkbox" disabled/> Klientapplikationen skall dessutom kunna hantera deltagare och presentation av vilka kurser som deltagaren har valt att anmäla sig till eller köpt.

<input type="checkbox" disabled/> Man ska dessutom nyttja rollbaseerad autentisering med JWT. Antingen egenimplementerat, OAuth eller med Identity Server.

<input type="checkbox" disabled/> Om en Admin är inloggad ska man få tillgång till en admin-sida där man kan se kunder och ordrar samt ändra i sortimentet.
