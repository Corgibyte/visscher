## Visscher API

By Hannah Young

This web API is designed to scrape historic events from Wikipedia as necessary, store that data, and provide it upon request through HTTP API Requests to the Visscher client.

### Technologies Used

- C#
- .NET
- mariadb
- Entity Framework
- Swagger / OpenAPI

### Description

TODO

<!-- TODO -->

### Setup

#### Requirements

* [git](https://git-scm.com)
* [.NET](https://dotnet.microsoft.com/en-us/)
* [MySQL](https://www.mysql.com/)

#### To Start Web API

1. Download and install the [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) as required for your system. Be sure to add the .NET sdk to your PATH
2. Use terminal to navigate to desired parent directory and use `git clone https://github.com/Corgibyte/visscher.git Visscher.Solution`
3. Navigate into the project directory nested inside the .Solution directory: `cd Visscher.Solution/Visscher`
4. Create an appsettings.json file: `touch appsettings.json`
5. Edit the new appsettings.json file and add the following, making sure to replace the indicated sections with your MySQL user ID and password:
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=visscher_api;uid=[YOUR MYSQL USER ID];pwd=[YOUR MYSQL PASSWORD];"
  }
}
```
6. Back in the terminal, in the Visscher directory build the project: `dotnet restore`
7. Create database from migration data: `dotnet ef database update`
8. Run project: `dotnet run`

### Accessing the Web API

API endpoints can be accessed using a client such as [Postman](https://www.postman.com/) or programatically using your own client. Endpoint testing can also be performed on the Swagger documentation accessed at `http://localhost:5000/swagger`

--------------------

## Endpoints

TODO

<!-- TODO -->


### Known bugs:

* None

### License

[Hippocratic License 3.0](https://github.com/Corgibyte/visscher/blob/main/LICENSE.md), Copyright 2022 Hannah Young.
