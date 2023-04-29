    I denna uppgift skall vi implementera databashantering och REST API för en e-handel.

---

## [api specification](./details/apispecification.md)

---

## Grundläggande krav

- [x] Det ska gå att skapa nya proukter som lagras i en databas(SQL-Server eller MongoDB)

- [x] Det ska gå att ändra och ta bort produkter i databasen

- [x] Det ska gå att markera att produkter utgått ur sortimentet

- [x] Det ska gå att hämta alla produkter

- [x] Det ska gå att söka efter en produkt på produktens namn eller produktnummer

- [x] Kunder ska kunna registrera sig och uppgifterna skall lagras i databasen.

- [x] Kunder ska kunna uppdatera sina uppgifter

- [x] Det ska gå att lista alla Kunder

- [x] Det ska gå söka efter kunder på e-post adress

- [x] När en kund anmäler sig/köper placerar en order måste vi kunna spåra vilken/vilka produkter som kunden har köpt

---

## Detaljkrav

### För en produkt skall följande uppgifter lagras i databasen

- Produktnummer
- Produktnamn
- Produktbeskrivning
- Pris
- Produktkategori (Mejeri, elektronik, husgeråd eller liknande)
- Status (om den finns i eller har utgått ur sortimentet)

---

### För en deltagare skall följande information lagras

- Förnamn
- Efternamn
- E-post
- Mobilnummer
- Adressuppgifter

---

## Designkrav

REST Api-lösningen skall utvecklas enligt objektorienterade principer och använda följa Single Responsibility Principle.

- All databaskommunikation skall också ske med hjälp av Repository Pattern.

---

## Användargränssnitt

Här lämnas det fritt, antingen kan vi använda JavaScript, React, Vue.js, Blazor eller ASP.NET MVC för att implementera en applikation för att kommunicera med REST Api-lösningen. Klientapplikationen skall kunna presentera och hantera produkter och deltagare enligt de grundläggande kraven ovan.

---

## Bedömning

### Godkänt(G)

- [x] En API-specifikation ska skrivas och bifogas i repositoryt.

- [x] Denna specifikation ska tydligt redogöra för alla endpoints och deras funktion.

- [x] För att få godkänt skall alla delar för produkthantering vara implementerade.

- [x] Kravet på att följa Single Responsibility Principle skall vara implementerat.

- [x] Repository Pattern skall vara implementerat och användas för all databaskommunikation.

- [x] En klientapplikation skall nyttja REST Api:et och uppfylla designkraven.

---

### Väl godkänt(VG)

- [x] För väl godkänt skall alla krav på G nivån vara uppfyllda. Förutom detta skall REST Api:et även implementera Unit of Work mönstret.

- [x] Klientapplikationen skall dessutom kunna hantera deltagare och presentation av vilka kurser som deltagaren har valt att anmäla sig till eller köpt.

- [x] Man ska dessutom nyttja rollbaseerad autentisering med JWT. Antingen egenimplementerat, OAuth eller med Identity Server.

- [x] Om en Admin är inloggad ska man få tillgång till en admin-sida där man kan se kunder och ordrar samt ändra i sortimentet.
