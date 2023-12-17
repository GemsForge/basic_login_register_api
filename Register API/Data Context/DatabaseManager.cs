using System.Data.SQLite;

namespace Register_API.Data_Context
{
    public class DatabaseManager
    {

        private readonly string connectionString = "Data Source=user.db;Version=3;";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
