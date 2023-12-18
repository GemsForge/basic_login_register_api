# Basic User Authentication API
This project is a user authentication API built using C# with .NET 7, Dapper as the persistence client, and SQLite as the database. It provides endpoints to register users and authenticate them, using Swagger for endpoint testing.

**Project Fignma Mindmap**: https://www.figma.com/file/21uNqYdlW3ffDs4FGY1XXA/01_Project---Basic-Login%2FRegister-API-Mindmap?type=whiteboard&node-id=3-750&t=NQtlwVRUTNWcGqWz-0
### Features
 - Language: C#
 - Framework:.NET v7/SDK 7
 - Database: SQLite v3 
 - Persistence Client: Dapper
 - Payloads: Payloads: LoginRequestModel and RegisterRequestModel
 

## Getting Started
### Prerequisites
- .NET 7 SDK
- SQLite

### Installation
1. Clone the repository. `git clone https://github.com/your-username/user-authentication-api.git
`
2. Navigate to the project directory:
3. Build and run the project
   `dotnet build` & `dotnet run`

## Usage
1. Access Swagger UI by navigating to http://localhost:<port>/swagger in your web browser.
2. Register a user by providing the following information:
- First name
- Last name
- Email
- Username
- Password
3. Use the registered username and password to log in.
4. The API will verify the credentials against the database and return a "Login Successful!" message in the console.

## Endpoints
### POST/register
Register a new user.

Request Body(`RegisterRequestModel`):
```c sharp 
{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john@example.com",
  "username": "johndoe",
  "password": "secretpassword"
}
```
### POST/login
Authenticate an existing user.

Request Body(`LoginRequestModel`):
```c sharp
{
  "username": "johndoe",
  "password": "secretpassword"
}
```
   
