<p align="center">cSharpWebApi</p>


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