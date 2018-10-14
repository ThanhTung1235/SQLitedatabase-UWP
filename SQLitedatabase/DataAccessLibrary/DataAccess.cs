using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace SQLitedatabase.DataAccessLibrary
{
    class DataAccess
    {
        public static string SQL_CONNECTION = "Filename=MySong.db";
        public static void InitializeDatabase()
        {
            using (SqliteConnection db =
                new SqliteConnection(SQL_CONNECTION))
            {
                db.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                                      "EXISTS Songs (Id INTEGER PRIMARY KEY, " +
                                      "name NVARCHAR(250), thumbnail NVARCHAR(250))";

                SqliteCommand createTable = new SqliteCommand(tableCommand, db);

                createTable.ExecuteReader();
            }
        }
    }
}
