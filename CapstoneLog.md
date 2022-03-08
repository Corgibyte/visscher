<!-- Log to track hours for Epicodus Capstone requirements -->

### Research, Planning & Work Log
#### Friday, 02/18/2022

* **0800-0930:** Researched JavaScript map libraries and their documentation to make a final decision. Final decision: OpenLayers.
* **0930-1015:** Read about web scraping ethics in general and Wikipedia's Terms of Use and robots.txt in particular.
* **1015-1120:** Write capstone-proposal.
* **1120-1200:** Begin design of API logical structure and endpoints (incomplete).
* **1300-1330:** Continue designing API logical structure (still incomplete).
* **1330-1400:** Study C# generics.
* **1400-1515:** Design model (complete: see [model_design.png](./model_design.png))
* **1515-16:30:** Reading OpenLayer documentation and working through HelloWorld tutorial.

#### Friday, 02/25/2022

* **0800-0930:** Implement initial model.
* **0930-1030:** Research ASP.NET Core Singleton Services. Work on implementing HttpService.
* **1030-1200:** WIP: implementing HttpService/Parsing pipeline.
* **1300-1400:** Finish implementing HttpService
* **1400-1545:** WIP implementing Battle.Parse. WIP fixing issues with HttpService/Entity.
* **1545-1615:** Come to crushing realization that HttpService can't work as a singleton with the current architecture. Cry a little.
* **1615-1715:** Try to re-design architecture. 

#### Saturday, 02/26/2022

* **14:30-15:00:** Fix Entity/HttpService issue with a single line of code.
* **15:00-15:45:** Follow Serilog documentation to install and configure for logging.
* **15:45-17:00:** Implement logging of parsing and test with seeded database data.
* **19:45-20:00:** Fix database seeding issues.
* **20:00-21:30:** Implement AlphabeticalBattle.Parse.
* **21:30-22:00:** Troubleshoot parsing/populating Battle database table.

#### Sunday, 02/27/2022

* **05:30-06:15:** Continue to troubleshoot parsing/populating Battle database table. Complete?
* **06:15-06:30:** Continue to troubleshoot parsing/populating Battle database table. This one will work!
* **06:30-07:00:** Continue to troubleshoot parsing/populating Battle database table. There's no way this doesn't work!
* **07:00-08:00:** Implement basic BattlesController. **Milestone: Backend MVP done!**

#### Friday, 03/04/2022

* **10:00-12:00:** Read GeoJSON spec. Work on custom JSON converter to convert class correctly.
* **13:00-14:00:** Finish implementing custom JSON converter to conform to GeoJSON.
* **14:00-15:30:** Create React app and begin trying to implement OpenLayers.

#### Monday, 03/07/2022
* **14:45-15:45:** Finish implementing React and OpenLayers.

#### Tuesday, 03/08/2022
* **08:00-08:30:** Implement API call into React.
* **08:30-09:45:** Work on implementing API data into OpenLayers.
* **09:45-10:30:** Fix longitude negative sign bug. (I know East from West, really!) 
* **10:30-11:15:** Finish implementing API data into OpenLayers. Points now render with text.