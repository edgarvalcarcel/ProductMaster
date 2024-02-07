﻿# ProductMaster Solution for Tekton Labs
## Download & Run
To run the web application:

```bash
Download or clone the repository: **ProductMaster,** unzip the file: **ProductMaster-master.zip** to
the folder you want.once unzipped. Proceed to select the ProductMaster.sln file to be opened with
Visual Studio 2022
 ```

```bash
Already in Visual Studio, select the project: Web as the main project

You can do this by selecting the project: **Web** and right clicking on it and on the pop-up menu
select the option **Set as startup project**
 ```

```bash
As a last step, make sure the execution is established in IIS Express (just for this test) and that the
 **web** project is established.
 ```

```bash
Don't forget to edit the files: appsettings.json located in the projects:
 **Project Web
 **Project Test: Application.FunctionalTests
 ```

these are the changes:
```bash
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=YourPC\\YourInstance;Initial Catalog=ProductMasterDb;User ID=YourUser;Password=YourPassword;MultipleActiveResultSets=True;Connect Timeout=100;Encrypt=False;"
  }
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
![RackMultipart20240207-1-5ylvis_html_e057d18cc71e2ee8](https://github.com/edgarvalcarcel/ProductMaster/assets/7807698/867e7d99-0dc5-4388-9b1b-e879bd7e6d0a)

![ProductMaster-2](https://github.com/edgarvalcarcel/ProductMaster/assets/7807698/311c75c3-ab9a-4eb3-afdf-dfc80e6ca788)

![ProductMaster-3](https://github.com/edgarvalcarcel/ProductMaster/assets/7807698/863b5e44-4627-4bc3-9361-da19c77d0f4c)
![ProductMaster-4](https://github.com/edgarvalcarcel/ProductMaster/assets/7807698/3d815244-0a99-483f-ad65-c6b047f5f27f)
![ProductMaster-5](https://github.com/edgarvalcarcel/ProductMaster/assets/7807698/e1f39ce8-89a5-498c-bd0d-0a9f7c6494d7)


