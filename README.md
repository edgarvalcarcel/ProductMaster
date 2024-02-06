﻿# ProductMaster Solution for Tekton Labs
## Run
To run the web application:

```bash
cd .\src\Web\
dotnet watch run
```

## Run Test

The solution contains unit, integration, and functional tests.

To run the tests:
```bash
dotnet test
```

## Technologies

The project contains the following technology:
```bash
•	ASP.NET Core 8
•	Entity Framework Core 8
•	MediatR
•	AutoMapper
•	FluentValidation
•	NUnit, FluentAssertions, Moq & Respawn
•	Fluent Assertions
•	Lazy Cache
•	RestSharp
•	Serilog
•	Moq
•	Nunit
•	Bogus
 ```
## Database
The project is configured for SQL server, once downloaded to your local PC, proceed to edit the file: appsettings.json located in the following projects:
```bash
•	src/Web
•	test/Application.FunctionalTests/
 ```
these are the changes:
```bash
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=YourPC\\YourInstance;Initial Catalog=ProductMasterDb;User ID=YourUser;Password=YourPassword;MultipleActiveResultSets=True;Connect Timeout=100;Encrypt=False;"
  }
 ```
  
When you run the application the database will be automatically created, and be populated (if necessary) and the latest migrations will be applied.
Running database migrations is easy. Ensure you add the following flags to your command (values assume you are executing from repository root)
 ```
--project src/Infrastructure
--startup-project src/Web
--output-dir Data/Migrations
 ```
For example, to add a new migration from the root folder:
```bash
dotnet ef migrations add "SampleMigration" --project src\Infrastructure --startup-project src\Web --output-dir Data\Migrations
 ```
to run migrations: 
```bash
 dotnet ef database update -s  .\src\Web -v --context ProductMasterDbContext --project .\src\Infrastructure
 ```
## Help
edgarvalcarcel@hotmail.com
