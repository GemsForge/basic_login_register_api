using System.Data.SQLite;

namespace Register_API.Data_Context
{
    public class DatabaseManager
    {
        //TODO: Move connection string to appsettings.json
        private readonly string _connectionString = @"Data Source=users.db; Version=3;";

        public SQLiteConnection? GetConnection()
        {

            try
            {
                SQLiteConnection connection = new(_connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }
    }
}
