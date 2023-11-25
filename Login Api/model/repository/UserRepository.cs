using Dapper;
using Login_Api.data_context;

namespace Login_Api.model.repository
{
    internal class UserRepository
    {
        //Initialize database manaager.
        private DatabaseManager dbManager;

        public UserRepository()
        {
            dbManager = new DatabaseManager();
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (var connection = dbManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Users";
                return connection.Query<User>(sql: query);
            }
        }

        public User GetUserById(int id)
        {
            using (var connection = dbManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE Id = @Id";
                return connection.QueryFirstOrDefault<User>(sql: query, new { Id = id });
            }
        }

        public void AddUser(User user)
        {
            using (var connection = dbManager.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Users (FirstName, LastName, Email, Username, Password) VALUES " +
                    "(@FirstName, @LastName, @Email, @Username, @Password)";
                connection.Execute(sql: query, user);
            }
        }

        public void CreateUsersTable()
        {
            using (var connection = dbManager.GetConnection())
            {
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
        }
    }
}

