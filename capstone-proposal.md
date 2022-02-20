### Name of Student:

 Hannah Young

### Name of Project:

**Visscher**: named after [Clae Jansz. Visscher](https://en.wikipedia.org/wiki/Claes_Jansz._Visscher), a Dutch engraver and mapmaker who created the most famous [Leo Belgicus](https://en.wikipedia.org/wiki/Leo_Belgicus).

### Project's Goal:
A website for mapping historical events. 

The goal of Visscher is to visualize history. While studying history I would always find the maps to be the most interesting part of history textbooks. Maps give a visual way of connecting the **whats** and **whens** of history and have alaways been an important part of the study of history. Visscher will give the user the opportunity to make their own historical maps anywhere on the world. They will be able to see **where** history happened.

### MVP Features:
* The UI will be a simple one-page website with a map that will place pins on major historical events.
* The map will be fully interactable: the user should be able to pan and zoom in real-time. 
* The map should be able to zoom out to a global view, and zoom into a regional view with enough detail to make out major geographical and political features such as rivers, mountains, country borders, and major cities.
* Pins generated and placed on map of at least one category of historical events.
* The user should be able to filter pins by date.
* The pins should change density with respect to zoom sanely in order to provide a good UX (exact mechanics TBD).

### Technology

The API and client will be completely separate and interact only through API calls and responses.

________

#### API:
* [C#/.NET](https://dotnet.microsoft.com/en-us/languages/csharp)
* [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-6.0) Web API
* [HTML Agility Pack](https://html-agility-pack.net/)
* [Newtonsoft](https://www.newtonsoft.com/json)
* [MariaDB](https://mariadb.org/)

#### Client:
* [Node.js](https://nodejs.org/)
* [React](https://reactjs.org/)
* [OpenLayers](https://openlayers.org/)

### Stretch Goals and Required Technologies
1. Hosting.
2. Integrate vintage map styling.
3. Ability to generate pins of additional categories of historical events.
4. Add information to pins such as countries or people involved.
5. Allow filtering based on (3) above.
6. Group pins based on overarching historical context (I.e., pins related to WW2).

### What additional tools, frameworks, libraries, APIs, or other resources will these additional features require?
* Hosting:
    * Azure (tentative: may check out Heroku, AWS, or others)
        * [Azure Web App Service](https://azure.microsoft.com/en-us/services/app-service/web/)
        * [Azure managed databases](https://azure.microsoft.com/en-us/solutions/databases/)
* Vintage basemap [(example)](https://nation.maps.arcgis.com/home/webmap/viewer.html?webmap=ccbfec91e19d4f9fb0769af361c31516)
* (3) - (4) above will be a refinment of the scraping and data manipulation that shouldn't require new technologies

### Additional

I will be scraping Wikipedia for my database using .NET's built-in [HTTP features](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-6.0). Web scraping should not be performed haphazardly: rapid and repeated HTTP requests can place tremendous stress on a website and threaten its intended purpose. All of my web scraping will be done in an ethical manner. I have carefully read [Wikipedia's Terms of Use](https://foundation.wikimedia.org/wiki/Terms_of_Use/en#Our_Terms_of_Use) and [robots.txt](https://en.wikipedia.org/robots.txt) and will follow both by properly limiting my requests. I will also clearly document how I am limiting my requests at the time when my scraping module have been designed and built.

### Design Documents

[API design](./design.png).

[Model design](./modeL_design.png)