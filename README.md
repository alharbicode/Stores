# Stores API

An ASP.NET Core Web API solution for store-related operations. The solution includes a separate client project.

## Tech stack

- .NET 6
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

## Run locally

```bash
dotnet restore Stores/Stores.csproj
dotnet run --project Stores/Stores.csproj
```

Set a valid database connection in `Stores/appsettings.json` before using the API.

## Structure

- `Stores/` — API source code
- `CLINT/` — client project
- `Stores.sln` — Visual Studio solution
