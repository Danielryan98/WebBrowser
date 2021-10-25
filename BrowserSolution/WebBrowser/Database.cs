using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WebBrowser
{
    class Database
    {

        string favDir = string.Format("Data Source={0}", Path.Combine(Path.GetDirectoryName(Application.StartupPath), "NewFavourites.db"));
        string historyDir = string.Format("Data Source={0}", Path.Combine(Path.GetDirectoryName(Application.StartupPath), "NewHistory.db"));

        public void NewFavourite(string url, string title)
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewFavourites.db; version=3;"))
            {
                try
                {
                    connection.Open();
                    try
                    {
                        SQLiteCommand writeSQL;
                        writeSQL = connection.CreateCommand();
                        writeSQL.CommandText = "INSERT INTO Favourites(URL, TITLE) VALUES (@url, @title)";
                        writeSQL.Parameters.AddWithValue("@url", url);
                        writeSQL.Parameters.AddWithValue("@title", title);
                            try
                            {
                                writeSQL.ExecuteNonQuery();
                            }
                            catch
                            {
                                MessageBox.Show("Favourite URL already exists");
                            }                      
                    }
                    catch
                    {
                        Console.WriteLine("Not sure");
                    }
                } catch
                {
                    MessageBox.Show("Can't connect to database");
                }
                
                

                connection.Close();
            }
        }

        public Dictionary<string, string> ReadFavourites()
        {
           

            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewFavourites.db; version=3;"))
            {

                connection.Open();

                Dictionary<string, string> favDict = new Dictionary<string, string>();

                SQLiteDataReader readSQL;
                SQLiteCommand getSQLData;
                getSQLData = connection.CreateCommand();
                getSQLData.CommandText = "SELECT * FROM Favourites";
                readSQL = getSQLData.ExecuteReader();
                while (readSQL.Read())
                {
                    favDict.Add(readSQL["URL"].ToString(), readSQL["TITLE"].ToString());

                }
                

                connection.Close();
                return favDict;
            }

        }

        public void UpdateFavourite(string originalURL, string originalName, string newURL, string newName)
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewFavourites.db; version=3;"))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "UPDATE Favourites SET URL = @newURL, TITLE = @newTitle Where URL = @originalURL and TITLE = @originalTitle";

                writeSQL.Parameters.AddWithValue("@newURL", newURL);
                writeSQL.Parameters.AddWithValue("@newTitle", newName);
                writeSQL.Parameters.AddWithValue("@originalURL", originalURL);
                writeSQL.Parameters.AddWithValue("@originalTitle", originalName);

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteFavourite(string url)
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewFavourites.db; version=3;"))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "DELETE FROM Favourites WHERE URL = @url";

                writeSQL.Parameters.AddWithValue("@url", url);

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        public Dictionary<string, string> ReadHistory()
        {


            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewHistory.db; version=3;"))
            {

                connection.Open();

                Dictionary<string, string> historyDict = new Dictionary<string, string>();

                SQLiteDataReader readSQL;
                SQLiteCommand getSQLData;
                getSQLData = connection.CreateCommand();
                getSQLData.CommandText = "SELECT * FROM History";
                readSQL = getSQLData.ExecuteReader();
                while (readSQL.Read())
                {
                    historyDict.Add(readSQL["URL"].ToString(), readSQL["TITLE"].ToString());

                }


                connection.Close();
                return historyDict;
            }

        }

        public void AddHistory(string url, string title)
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewHistory.db; version=3;"))
            {

                connection.Open();
                try
                {
                    SQLiteCommand writeSQL;
                    writeSQL = connection.CreateCommand();
                    writeSQL.CommandText = "INSERT INTO History(URL, TITLE) VALUES (@url, @title)";
                    writeSQL.Parameters.AddWithValue("@url", url);
                    writeSQL.Parameters.AddWithValue("@title", title);
                    writeSQL.ExecuteNonQuery();
                }
                catch
                {
                    Console.WriteLine("Need to add exception for duplicate value");
                }

                connection.Close();
            }
        }

        public void DeleteHistoryEntry(string url)
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewHistory.db; version=3;"))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "DELETE FROM History WHERE URL = @url";

                writeSQL.Parameters.AddWithValue("@url", url);

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        public void DeleteAllHistory()
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1Night\\BrowserSolution\\WebBrowser\\NewHistory.db; version=3;"))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "DELETE FROM History";

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}
