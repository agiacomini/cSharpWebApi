<p align="center"> 
    <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="200" height="200"/> </a> 
    <a href="https://dotnet.microsoft.com/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dot-net/dot-net-original-wordmark.svg" alt="dotnet" width="200" height="200"/> </a> 
</p>


# Project Description

# How to Install and Run the Project

Project Settings

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
                "DefaultConnection": "server=127.0.0.1;port=<PORT_CONNECTION>;uid=<USER_NAME>;pwd=<PASSWORD>;database=cSharpWebApiDatabase",
            }
        }

## DB Context

Update "Program.cs" file to indicate whitch property use ("appsenttings.json") for build service that is responsible for defining the DbContext  

        // DB PostgreSQL - Install our DBContext
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContext<DatabaseContext>(options => {
            options.UseNpgsql(connectionString);
        });

## Entity Framework

Install ...

## Migrations

Update Database executing the migrations (from "Migrations" folder) with following commands:

```bash
# List All Migrations
$ dotnet ef migrations list

# Apply Migrations 
$ dotnet ef database update
```

# How to Use the Project