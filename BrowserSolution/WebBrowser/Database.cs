using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace WebBrowser
{
    class Database
    {
        public void NewFavourite(string url, string title)
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1NEW\\BrowserSolution\\WebBrowser\\bin\\Favourites.db; version = 3;"))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();
                writeSQL.CommandText = "INSERT INTO Favourites(URL, TITLE) VALUES (@url, @title)";
                writeSQL.Parameters.AddWithValue("@url", url);
                writeSQL.Parameters.AddWithValue("@title", title);
                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        public List<Favourite> ReadFavourites()
        {
           

            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1NEW\\BrowserSolution\\WebBrowser\\bin\\Favourites.db; version = 3;"))
            {

                connection.Open();


                List<Favourite> favList = new List<Favourite>();
                SQLiteDataReader readSQL;
                SQLiteCommand getSQLData;
                getSQLData = connection.CreateCommand();
                getSQLData.CommandText = "SELECT * FROM Favourites";
                readSQL = getSQLData.ExecuteReader();
                while (readSQL.Read())
                {
                    favList.Add(new Favourite() { URL = readSQL["URL"].ToString(), TITLE = readSQL["TITLE"].ToString() });

                }
                

                connection.Close();
                return favList;
            }

        }
    }
}
