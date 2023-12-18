# Basic Login/Register API
This repository contains a basic Login and Registration API with simple authentication. 

**Project Fignma Mindmap**: https://www.figma.com/file/21uNqYdlW3ffDs4FGY1XXA/01_Project---Basic-Login%2FRegister-API-Mindmap?type=whiteboard&node-id=3-750&t=NQtlwVRUTNWcGqWz-0
### Tech Stack
 Language = C#
 Framework = .NET v7/SDK 7
 Database Client = Sqlite v3 
 Persistence Client = Dapper 


## PHASE 1 (console app vs web API. Establish a database via a console app and convert it to web API.)

1. **User Model**

    a.  _Data_: User{FirstName, LastName, Email, Username, Password}
   
   ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/ec4da183-f781-4446-a5e2-94f2ce011bac)

2. **User Database** (user.db) *See Add User Method in User Repository* I didn't use the sqlite3 cli commands to create the database.

    a. Database manager

  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/41bba5d9-17cb-48e4-8bb0-e2ce1154abe0)

3.**User Repository** with simple CRUD operation. (GetAllUsers, GetUser, AddUser)
  3a. Write a method to create DB in User Repo 
  
  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/839df7fa-fc76-40a2-a989-02a3746f7d9e)
  
  3b. Write GetAllUsers and GetUserById methods to return User information
  
  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/c138ce5f-f16a-44ee-ab19-7c2e3cc21295)
  
  3c. Write the AddUsers method to add User information to the user.db table.
  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/dc0cd98e-7316-4293-a6c4-010371a5dd19)

  ## Convert to WebAPI
  4. Create a new web app and move logic to the Register Controller
      - Identify the logic related to user input, database interaction, and user creation from your console application.
      - For example, the user creation logic could go into an action method within the UserController.
    
        
  5. Update Dependencies:
      - Make sure to include the necessary dependencies (Dapper, System.Data.SQLite, etc.) in your web API project.

  6. Define Routes and Endpoints:
      - Define routes and endpoints for your API methods within the UserController.
      - For example, you might have a POST endpoint for user creation: POST /api/user/register.
    
        S/N: Update the AddUser method in the User Repository to try/catch block the block of code to 
  7. Modify User Input Handling
     
      7a. UserMapper

     ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/501291bb-5cba-4522-8b05-2d0833307ce4)

      7B. Payload (client data)
     
     ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/5ef20e80-b0be-4b48-9ea5-1abca47cbcc3)
  
   9. For a web API, user input won't be taken directly from the console. Instead, it will be received as HTTP requests.
       Update the user input handling logic in your controller to extract data from HTTP requests (e.g., using the FromBody attribute for POST requests).
  
   10. Test the API:
  Use tools like Postman or Swagger UI to test your API endpoints by sending HTTP requests and ensuring they function as expected.
   Verify that the user creation functionality works through the API.

   
