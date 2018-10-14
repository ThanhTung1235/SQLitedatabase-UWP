using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using SQLitedatabase.DataAccessLibrary;
using SQLitedatabase.Entity;

namespace SQLitedatabase.Model
{
    class SongModel
    {
        public static void AddData(Song song)
        {
            using (SqliteConnection db =
                new SqliteConnection(DataAccess.SQL_CONNECTION))
            {
                db.Open();

                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;

                // Use parameterized query to prevent SQL injection attacks
                insertCommand.CommandText = "INSERT INTO Songs(name, thumbnail) VALUES (@name, @thumbnail)";
                insertCommand.Parameters.AddWithValue("@name", song.Name);
                insertCommand.Parameters.AddWithValue("@thumbnail", song.Thumbnail);
                insertCommand.ExecuteReader();

                db.Close();
            }

        }
        public static List<Song> GetSongList()
        {
            List<Song> list = new List<Song>();

            using (SqliteConnection db =
                new SqliteConnection(DataAccess.SQL_CONNECTION))
            {
                db.Open();

                SqliteCommand selectCommand = new SqliteCommand
                    ("SELECT * from Songs", db);

                SqliteDataReader query = selectCommand.ExecuteReader();
                Song song = null;
                while (query.Read())
                {
                    song = new Song()
                    {
                        Id = query.GetString(0),
                        Name = query.GetString(1),
                        Thumbnail = query.GetString(2)
                    };
                    list.Add(song);
                    
                }

                db.Close();
            }

            return list;
        }

    }
}
