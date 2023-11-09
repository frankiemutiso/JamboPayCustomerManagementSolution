# JamboPay Customer Management Solution

This project provides a backend API solution that streamlines the onboarding process for customer businesses.

### Setup Instructions
1. Clone the project.
2. Set up a local PostgreSQL database.
3. Update the `AppDbConnection` value in the `appsettings` file.
4. Run `dotnet ef database update` to populate the database with tables.
5. Run the project using your preferred IDE or execute the `dotnet run` command in the terminal.

### Project Structure
- `Controller`: Contains endpoints for handling various requests.
- `DTOs`: Maps properties appropriately to facilitate data transfer.
- `Models`: Defines entities that describe the database schema.
- `Data`: Contains the dbContext, mapping C# entities to the database.
- `Services`: Interfaces that bridge controllers and the database.
- `Migrations`: Holds migration files for database updates.

The diagram below shows the database design for the project

![DDD-0](https://github.com/frankiemutiso/JamboPayCustomerManagementSolution/assets/66528095/3b80b804-e1a4-4466-8ed5-d3e5bdd65f6a)
