# Swim School Registration API

A .NET 10 minimal API using EF Core 10 and SQLite.

## Requirements

- .NET 10 SDK
- SQLite command-line tool (`sqlite3`) to load the optional sample data

Restore the local EF Core CLI tool and build from the repository root:

```bash
dotnet tool restore
dotnet build SwimSchool.Api/SwimSchool.Api.csproj
```

## Run the API

Start the API on port 5087:

```bash
ASPNETCORE_URLS=http://localhost:5087 dotnet run --project SwimSchool.Api/SwimSchool.Api.csproj
```

The SQLite connection string is configured in `SwimSchool.Api/appsettings.json`.

## Endpoints

| Method | URL | Status |
| --- | --- | --- |
| GET | `http://localhost:5087/health` | Opens and closes the SQLite connection and reports its status. |
| GET | `http://localhost:5087/classes?hasSpots=true` | Scaffolded; the LINQ query and response projection are still to be implemented. `hasSpots` is optional. |

Enrollment write endpoints have not been implemented.

## Database

The project includes the `InitialCreate` migration. Apply it from the repository root with:

```bash
dotnet ef database update \
  --project SwimSchool.Api/SwimSchool.Api.csproj \
  --startup-project SwimSchool.Api/SwimSchool.Api.csproj
```

To add a future migration, use the same project arguments:

```bash
dotnet ef migrations add <MigrationName> \
  --project SwimSchool.Api/SwimSchool.Api.csproj \
  --startup-project SwimSchool.Api/SwimSchool.Api.csproj
```

The repository includes repeatable sample data in `SwimSchool.Api/SampleData.sql`. After applying the migration, execute it against the same SQLite database file used by the API. For example, from the repository root if the database file is `swimschool.db`:

```bash
sqlite3 swimschool.db < SwimSchool.Api/SampleData.sql
```

The script creates three capacity-2 classes with zero, one, and two enrollments.
