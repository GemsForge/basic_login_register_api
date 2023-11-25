using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Api.data_context
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
