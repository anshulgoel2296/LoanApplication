# LoanApplicationAPI

LoanApplicationAPI is a .NET 10 Web API that manages users and loan application statuses. It provides endpoints to create and query users and application status metadata. The project is intended to be opened in Visual Studio 2026 or run via the `dotnet` CLI.

## Features
- User creation and retrieval (`UserController`)
- Application status creation and retrieval (`ApplicationStatusController`)
- Loan Type creation and retrieval (`LoanTypeController`)
- Loan Application creation and management (`LoanApplicationController`)

## Requirements
- .NET 10 SDK
- Visual Studio 2026 (optional if running on Prod)
- SQL Server (or compatible database)

## Quick start

1. Clone the repository
   - `git clone <repo-url>`

2. Configure the database connection
   - Edit `appsettings.json` (or `appsettings.Development.json`) and set the `ConnectionStrings:DefaultConnection` value to point at your SQL Server instance.

   Example: { "ConnectionStrings": { "DefaultConnection": "Server=.;Database=LoanApplicationDb;Trusted_Connection=True;" } }

3. Restore dependencies and build
   - `dotnet restore`
   - `dotnet build`

4. Run
   - `dotnet run --project LoanApplicationAPI`
   - Or open `LoanApplicationAPI.sln` in Visual Studio 2026 and run the API.

## API Endpoints (examples)
- `POST /api/users` — Create a new user (body: `UserRequest`)
- `GET /api/users/{id}` — Get a user by id

Use Swagger/OpenAPI if the project exposes it (check startup configuration) or use tools like Postman.

Example `POST /api/users` body:  { "firstName": "Jane", "lastName": "Doe", "email": "jane.doe@example.com", "contactNumber": "+1234567890" }


## Database & Common Issues
- The API uses EF Core `DbContext` and `DbSet` properties (for example `UsersList`). If you see `SqlException: Invalid object name 'users'.`:
  - Ensure the database exists and migrations have been applied (`dotnet ef database update`). Please find the dbscripts in script.sql inside DBScript folder.
  - Confirm the `DbContext` mappings and table names match the database schema (check `OnModelCreating` or entity attributes).
  - Verify the `ConnectionStrings` used at runtime are correct (development vs production config).

