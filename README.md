# Bookstore-API

## TEKNIKTEST
### Projektbeskrivning

Det här projektet innefattar en serie förbättringar och utökningar av ett befintligt bibliotekssystem skrivet i .NET C#. Här är en sammanfattning av de huvudsakliga uppgifterna och de förändringar som har implementerats:

1. **Flytt av Hårdkodad Databaslänk till Konfigurationsfil:**
   - Länken till databasens XML-fil som tidigare var hårdkodad i `LibraryRepository.cs` har flyttats till en konfigurationsfil (`web.config` eller `appsettings.json`). Detta gör det möjligt för användare att ändra sökvägen till databasen utan att behöva kompilera om koden.

2. **Bygg en Webbsida för Bokinformation via ISBN:**
   - En enkel webbapplikation har skapats som kan kommunicera med `BookInfoController` för att söka efter böcker via ISBN. 
   - Webbplatsen är byggd med HTML och använder JavaScript/jQuery för att skicka och ta emot data från API:t. Informationen som returneras från API:t visas på webbplatsen.

3. **Felhantering och Validering av Inkommande Data:**
   - API:t har utökats med validering för att säkerställa att inkommande strängar inte är null, tomma eller enbart innehåller blanksteg. Om ogiltig data skickas in returnerar API:t ett felmeddelande istället för att krascha.
   - Om en bok inte hittas, hanteras detta på webbplatsen så att användaren tydligt ser att ett fel har inträffat, istället för att visa "Book not found!".

4. **Utökad Sökfunktionalitet:**
   - Sökfunktionen har utökats för att stödja sökningar baserade på titel och författare, förutom ISBN. Resultatet är en lista med alla träffar som matchar sökkriterierna.

5. **Lägg till Nya Böcker i Biblioteket:**
   - En POST-metod har lagts till i API:t för att möjliggöra skapandet av nya bokobjekt i XML-filen.
   - Metoden anropar en intern SET-metod i `LibraryRepository` som hanterar insättningen av nya böcker.

6. **Ny Vy för Att Skicka Nya Bokvärden till API:t:**
   - En ny vy på webbplatsen har skapats där användare kan lägga till nya böcker. Denna vy validerar att inga fält är tomma eller innehåller enbart blanksteg. Felmeddelanden visas vid ogiltig inmatning.

7. **Funktion för Att Skicka Bokförslag till API:t:**
   - En funktion har implementerats som tillåter användare att skicka bokförslag till API:t, inklusive namn på personen som skickar förslaget, författarens namn och boktitel.
   - API:t skapar en mapp med dagens datum om den inte redan finns och sparar en fil med förslaget i mappen. Filnamnet följer en specifik formatstandard och använder auto-increment vid namnkonflikter.

Dessa förbättringar och utökningar har gjorts för att öka flexibiliteten, användarvänligheten och funktionaliteten i bibliotekssystemet. Projektet innehåller nu en mer robust felhantering, en förbättrad sökfunktion och möjligheter för användare att enkelt lägga till nya böcker och föreslå nya titlar.
