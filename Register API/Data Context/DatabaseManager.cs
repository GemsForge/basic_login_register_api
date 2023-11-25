using System.Data.SQLite;

namespace Register_API.Data_Context
{
    internal class DatabaseManager
    {

        private string connectionString = "Data Source=user.db;Version=3;";

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
