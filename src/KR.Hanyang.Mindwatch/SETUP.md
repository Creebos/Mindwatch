# Running Mindwatch

# Setup Explaination

The Application is containerized with docker and consists of the following containers:

- Mindwatch-API (.NET Core Web API)
- Mindwatch-Database (SQL Server 2022)
- Mindwatch-Frontend (TBD)

It is setup with docker compose and supports build Automatic Rebuild, if run with Visual Studio.

Notice: Switching between running manually by docker-compose and running over Visual Studio, results in a name conflict of the database container (to be fixed). In order to get it running again, you can delete the old containers.

# Entity Framework Migrations

1. Open Console (PMC for example)
2. Navigate to Project Folder: cd KR.Hanyang.Mindwatch.Infrastructure.Persistence
3. Change Project in Dropdown

**Create new Migration:**

dotnet ef migrations add MIGRATIONNAME --output-dir Migrations --startup-project ../KR.Hanyang.Mindwatch.API

**Apply all pending Migrations**
NOTE: This is not necessary since Migrations are applied on startup
dotnet ef database update --startup-project ../KR.Hanyang.Mindwatch.API
