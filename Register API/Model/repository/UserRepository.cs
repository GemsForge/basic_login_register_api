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
            var connection = _dbManager.GetConnection();
            try
            {
                string query = @"INSERT INTO Users (FirstName, LastName, Email, Username, Password) VALUES " +
                        "(@FirstName, @LastName, @Email, @Username, @Password)";
                connection.Execute(sql: query, newUser);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public bool AuthenticateUser(LoginRequestModel userToAuthenticate)
        {
            var connection = _dbManager.GetConnection();
            var sqlSelect = @"
            SELECT COUNT(*)
            FROM Users
            WHERE Username = @Username AND Password = @Password";

            int userCount = connection.ExecuteScalar<int>(sqlSelect, userToAuthenticate);
            connection.Close();
            return userCount > 0;
        }

        public void CreateUsersTable()
        {
            using var connection = _dbManager.GetConnection();


            string createTableSql = @"CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    FirstName TEXT NOT NULL,
                    LastName TEXT NOT NULL,
                    Email TEXT NOT NULL,
                    Username TEXT NOT NULL,
                    Password TEXT NOT NULL
                )";

            connection.Execute(createTableSql);
            connection.Close();
        }
        public IEnumerable<User> GetAllUsers()
        {
            using var connection = _dbManager.GetConnection();
            connection.Open();
            string query = "SELECT * FROM Users";
            connection.Close();
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

