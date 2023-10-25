<p align="center"> 
    <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="200" height="200"/> </a> 
    <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="200" height="200"/> </a> 
</p>


# Project Description

Test project to experiment .NET framework features and C# coding techniques. It's a Web API project testing GET, POST, PUT, DELETE Http operation on data Entity that implement the "1-1", "1-n" and "n-n" relationships. 

# How to Install and Run the Project

Project Settings
<<<<<<< HEAD
1. [Prerequisites](#prerequisites) 
2. [DB Connection String](#db-connection-string) 
3. [DB Context](#db-context) 
4. [ORM - Microsoft Entity Framework](#orm---microsoft-entity-framework)
5. [Migrations](#migrations)
6. [Design Pattern](#design-pattern)
7. [Run Project](#run-project)
=======
1. Prerequisites
2. DB Connection String
3. DB Context
4. ORM - Microsoft Entity Framework
5. Migrations
6. Design Pattern
7. Run Project
>>>>>>> ef5ffde3d21c2609ee38ffc9b21c09b8bb32d02f

## Prerequisites

Install .NET Core SDK ("https://dotnet.microsoft.com/en-us/download") and test installation: 

```bash
$ dotnet --list-sdks
```

## DB Connection String

Edit file "appsettings.json" (in root folder) to create the default connecction string to link Database 

        {
            "Logging": {
                "LogLevel": {
                "Default": "Information",
                "Microsoft.AspNetCore": "Warning"
                }
            },
            "AllowedHosts": "*",
            "ConnectionStrings": {
                "DefaultConnection": "server=127.0.0.1;port=<PORT_CONNECTION>;uid=<USER_NAME>;pwd=<PASSWORD>;database=<DATABASE_NAME>",
            }
        }

## DB Context

Update "Program.cs" file to indicate whitch property use ("appsenttings.json") for build service that is responsible for defining the DbContext  

        // DB PostgreSQL - Install our DBContext
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DatabaseContext>(options => {
            options.UseNpgsql(connectionString);
        });

## ORM - Microsoft Entity Framework

Install the ORM (Object Relational Mapping) "Entity Framework Core" with following command to install the NuGet packages.

CLI (Command Line Interface)

```bash
$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer

$ dotnet add package Microsoft.EntityFrameworkCore.Tools

$ dotnet add package Microsoft.EntityFrameworkCore.Design

$ dotnet tool install --global dotnet-ef

$ dotnet tool update --global dotnet-ef
```

Otherwise use Package manager of the IDE.

The path "roo/Data" collects all Entity managed inside project. The Approch followed is that "Code First".


## Migrations

Update Database executing the migrations (from "Migrations" folder) with following commands:

```bash
# List All Migrations
$ dotnet ef migrations list

# Apply Migrations 
$ dotnet ef database update
```

## Design Pattern

Repository Pattern: separates data access via Controller (root/Controller/Api) from data updates operations (roo/Service).

## Run Project

```bash
# Build the project
$ dotnet build

# Run project 
$ dotnet run
```

# How to Use the Project

<<<<<<< HEAD
## Swagger

=======
>>>>>>> ef5ffde3d21c2609ee38ffc9b21c09b8bb32d02f
Connect to "localhost:5268/swagger/index.html" for testing the CRUD (Create, Read, Update, Delete) operations. The URLs are definied inside "launchSettings.json" file.