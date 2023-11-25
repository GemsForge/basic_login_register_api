// See https://aka.ms/new-console-template for more information
using Login_Api.model;
using Login_Api.model.repository;

internal class Program
{
    private static void Main(string[] args)
    {
        //initialize new istance of user repo (CRUD operations)
        var userRepository = new UserRepository();

        // Create the Users table if it doesn't exist
        userRepository.CreateUsersTable();

        //Form to Add new User to console app
        Console.WriteLine("Enter First Name:");
        string firstName = Console.ReadLine();
        Console.WriteLine("Enter Last Name:");
        string lastName = Console.ReadLine();
        Console.WriteLine("Enter Username");
        string username = Console.ReadLine();
        Console.WriteLine("Enter Email:");
        string email = Console.ReadLine();
        Console.WriteLine("Enter Password:");
        string password = Console.ReadLine();

        // Create a new User object with the input values
        var NewUser = new User(firstName, lastName, username, email, password)
        {
            FirstName = lastName,
            LastName = lastName,
            Email = email,
            Username = username,
            Password = password
        };

        // Add the user to the database
        userRepository.AddUser(NewUser);

        Console.WriteLine("User added successfully.");
    }
}