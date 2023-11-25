# basic_login_register_api
This repository contains a basic Login and Registration API with simple authentication. 

**Project Fignma Mindmap**: https://www.figma.com/file/21uNqYdlW3ffDs4FGY1XXA/01_Project---Basic-Login%2FRegister-API-Mindmap?type=whiteboard&node-id=3-750&t=NQtlwVRUTNWcGqWz-0

## PHASE 1 (console app vs web API. Establish a database via a console app and convert it to web API.)

1.** User Model**
   1a.  _Data_: User{FirstName, LastName, Email, Username, Password}
   ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/ec4da183-f781-4446-a5e2-94f2ce011bac)

2. ** User Database** (user.db)
   a. _Database Client:_ sqlite3
   b. _Persistence client:_ dapper
2a.Database manager
  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/41bba5d9-17cb-48e4-8bb0-e2ce1154abe0)

3.** User Repository** with simple CRUD operation. (GetAllUsers, GetUser, AddUser)
  3a. Write a method to create DB in User Repo 
  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/839df7fa-fc76-40a2-a989-02a3746f7d9e)
  3b. Write GetAllUsers and GetUserById methods to return User information
  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/c138ce5f-f16a-44ee-ab19-7c2e3cc21295)
  3c. Write the AddUsers method to add User information to the user.db table.
  ![image](https://github.com/Dbrown127/basic_login_register_api/assets/114959173/dc0cd98e-7316-4293-a6c4-010371a5dd19)



   
