using Dapper;
using Register_API.Data_Context;
using Register_API.Model.payload;

namespace Register_API.Model.Repository
{
    public class UserRepository
    {
        //Initialize database manaager.
        private readonly DatabaseManager _dbManager;

        public UserRepository(DatabaseManager dbManager)
        {
            _dbManager = dbManager;
        }

        public void RegisterUser(RegisterRequestModel newUser)
        {
            using var connection = _dbManager.GetConnection();
            try
            {
                // Specify the database file path
                string dbFilePath = "user.db";

                // Check if the database file exists
                if (File.Exists(dbFilePath))
                {
                    // If the file exists, proceed with adding user information
                    connection.Open();
                    string query = @"INSERT INTO Users (FirstName, LastName, Email, Username, Password) VALUES " +
                        "(@FirstName, @LastName, @Email, @Username, @Password)";
                    connection.Execute(sql: query, newUser);
                }
                else
                {
                    Console.WriteLine("The user database file does not exist. Now creating " + dbFilePath);
                    CreateUsersTable();
                }                             
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public bool AuthenticateUser(LoginRequestModel userToAuthenticate)
        {
            using var connection = _dbManager.GetConnection();
            var sqlSelect = @"
            SELECT COUNT(*)
            FROM Users
            WHERE Email = @Email AND Password = @Password";

            int userCount = connection.ExecuteScalar<int>(sqlSelect, userToAuthenticate);
            return userCount > 0;
        }

        public void CreateUsersTable()
        {
            using var connection = _dbManager.GetConnection();
            connection.Open();

            string createTableSql = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL
                )";

            connection.Execute(createTableSql);
        }
        public IEnumerable<User> GetAllUsers()
        {
            using var connection = _dbManager.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Users";
            return connection.Query<User>(sql: query);
        }

        public User GetUserById(int id)
        {
            using var connection = _dbManager.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Users WHERE Id = @Id";
#pragma warning disable CS8603 // Possible null reference return.
            return connection.QueryFirstOrDefault<User>(sql: query, new { Id = id });
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}

