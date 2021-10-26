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
        /*Paths for the databases defined.*/
        string favDir = string.Format("Data Source={0}", Path.Combine(Path.GetDirectoryName(Application.StartupPath), "NewFavourites.db"));
        string historyDir = string.Format("Data Source={0}", Path.Combine(Path.GetDirectoryName(Application.StartupPath), "NewHistory.db"));
        string homePageDir = string.Format("Data Source={0}", Path.Combine(Path.GetDirectoryName(Application.StartupPath), "HomePage.db"));

        /*Have to check if table exists, because one has to be created to begin with.*/
        public void CheckIfTableExists(String name, string directory) //Takes in the name of the table to be checked for and the path to look in.
        {
            var connection = new SQLiteConnection(directory); 
            connection.Open(); //Open a new SQL DB connection in the chosen directory.
            SQLiteCommand getSQLData = connection.CreateCommand();
            getSQLData.CommandText = "SELECT name FROM sqlite_master WHERE type = 'table' AND name = '@name'"; //Define the SQL command, checking for occurences of TABLE_NAME.
            getSQLData.Parameters.AddWithValue("@name", name);
 
            int numberOfRows = getSQLData.ExecuteNonQuery(); //Returns the number of rows in the database that match the table name, if it exists, there will be 1 row.
            
            if(numberOfRows < 1)
            {
                CreateNewTable(name); //We need to create a new table because one doesnt yet exist.
            }
            connection.Close();
        }

        /*Method for creating a new database table*/
        public void CreateNewTable(string name) //Takes string equal to Favourites or History or HomePage.
        {
            if(name == "Favourites") //Case: Creating Favourites Table.
            {
                SQLiteConnection connection = new SQLiteConnection(favDir); //Create it in the favourite db directory.
                connection.Open();

                string sql = "create table Favourites (URL varchar(60) not null primary key, TITLE varchar(60) not null)"; //Define the table, we want unique entries, with URL as primary key, and a name associated to the url.

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                try
                {
                    command.ExecuteNonQuery();
                }catch
                {
                    
                }
                

                connection.Close();

            } else if(name == "History") //Case: Creating History Table.
            {
                SQLiteConnection connection = new SQLiteConnection(historyDir); //Create it in the history db directory.
                connection.Open();

                string sql = "create table History (URL varchar(60) not null primary key, TITLE varchar(60) not null)"; //Define the table, we want unique entries, with URL as primary key, and a name associated to the url.

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {
                    
                }

                connection.Close();
            }
            else if (name == "HomePage") //Case: Creating HomePage Table.
            {
                SQLiteConnection connection = new SQLiteConnection(homePageDir); //Create it in the homePage db directory.
                connection.Open();

                string sql = "create table HomePage (URL varchar(60) not null primary key)"; //Define the table, doesn't need to be unique because there can only be one entry.

                SQLiteCommand command = new SQLiteCommand(sql, connection);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch
                {

                }

                connection.Close();
            }

        }

        /*Method for adding a new favourite to the database.*/
        public void NewFavourite(string url, string title) //Takes a url and a name associated with it.
        {
            CheckIfTableExists("Favourites", favDir); //Check that the favourites table exists.
            using (var connection = new SQLiteConnection(favDir))
            {
                try
                {
                    connection.Open();
                    SQLiteCommand writeSQL;
                    writeSQL = connection.CreateCommand();
                    writeSQL.CommandText = "INSERT INTO Favourites(URL, TITLE) VALUES (@url, @title)"; //Define the command, we want to insert a favourite with URL and NAME.
                    writeSQL.Parameters.AddWithValue("@url", url);
                    writeSQL.Parameters.AddWithValue("@title", title);                      
                        try
                        {
                            writeSQL.ExecuteNonQuery(); //Insert the new favourite.
                        }
                        catch
                        {
                            MessageBox.Show("Favourite URL already exists.");
                        }                      
                                    
                } catch
                {
                    MessageBox.Show("Can't connect to database.");
                }                             
                connection.Close();
            }
        }

        /*Method for writing favourites into a dictionary for use on the favourites page.*/
        public Dictionary<string, string> ReadFavourites()
        {

            CheckIfTableExists("Favourites", favDir);
            using (var connection = new SQLiteConnection(favDir))
            {

                connection.Open();

                Dictionary<string, string> favDict = new Dictionary<string, string>(); //Dictionary of type string, string. Key = URL : Value = Name.

                SQLiteDataReader readSQL;
                SQLiteCommand getSQLData;
                getSQLData = connection.CreateCommand();
                getSQLData.CommandText = "SELECT * FROM Favourites"; //Select all entries in favourites table.
                readSQL = getSQLData.ExecuteReader();
                while (readSQL.Read())
                {
                    favDict.Add(readSQL["URL"].ToString(), readSQL["TITLE"].ToString()); //Add the favourite to the dictionary.

                }
                

                connection.Close();
                return favDict; //Return the dictionary for use on the favourites page.
            }

        }

        /*Method for updating a modified favourite.*/
        public void UpdateFavourite(string originalURL, string originalName, string newURL, string newName) //Takes in the favourite being modified's values, and the values to update it to.
        {
            CheckIfTableExists("Favourites", favDir);
            using (var connection = new SQLiteConnection(favDir))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "UPDATE Favourites SET URL = @newURL, TITLE = @newTitle Where URL = @originalURL and TITLE = @originalTitle"; //Search the db table for the appropriate entry and modify the values to the new values. 

                writeSQL.Parameters.AddWithValue("@newURL", newURL); //Add all values in appropriate places.
                writeSQL.Parameters.AddWithValue("@newTitle", newName);
                writeSQL.Parameters.AddWithValue("@originalURL", originalURL);
                writeSQL.Parameters.AddWithValue("@originalTitle", originalName);

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        /*Method for removing a favourite from the database.*/
        public void DeleteFavourite(string url) //Takes in a url to be deleted
        {
            CheckIfTableExists("Favourites", favDir);
            using (var connection = new SQLiteConnection(favDir))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "DELETE FROM Favourites WHERE URL = @url"; //Delete entry from the database table that matches the url passed through.

                writeSQL.Parameters.AddWithValue("@url", url);

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        /*Read in the history from the database and store it in a dictionary.*/
        public Dictionary<string, string> ReadHistory()
        {

            CheckIfTableExists("History", historyDir);
            using (var connection = new SQLiteConnection(historyDir))
            {

                connection.Open();

                Dictionary<string, string> historyDict = new Dictionary<string, string>(); //Dictionary of type string, string. Key = URL : Value = Name.

                SQLiteDataReader readSQL;
                SQLiteCommand getSQLData;
                getSQLData = connection.CreateCommand();
                getSQLData.CommandText = "SELECT * FROM History"; //Select all entries in the history table.
                readSQL = getSQLData.ExecuteReader();
                while (readSQL.Read())
                {
                    historyDict.Add(readSQL["URL"].ToString(), readSQL["TITLE"].ToString()); //Add the entry to the dictionary.

                }


                connection.Close();
                return historyDict; //Return the dictionary for use in the history page.
            }

        }

        /*Method for adding page to the history database table.*/
        public void AddHistory(string url, string title) //Add a url and the title of the url page.
        {
            CheckIfTableExists("History", historyDir);
            using (var connection = new SQLiteConnection(historyDir))
            {

                connection.Open();
                try
                {
                    SQLiteCommand writeSQL;
                    writeSQL = connection.CreateCommand();
                    writeSQL.CommandText = "INSERT INTO History(URL, TITLE) VALUES (@url, @title)"; //Add the history entry to the database table with this command.
                    writeSQL.Parameters.AddWithValue("@url", url);
                    writeSQL.Parameters.AddWithValue("@title", title);
                    writeSQL.ExecuteNonQuery(); //Add the history entry to the database table.
                }
                catch
                {
                    
                }

                connection.Close();
            }
        }

        /*Method for deleting a history entry from the history database table.*/
        public void DeleteHistoryEntry(string url) //Takes in url of history entry to be deleted.
        {
            CheckIfTableExists("History", historyDir);
            using (var connection = new SQLiteConnection(historyDir))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "DELETE FROM History WHERE URL = @url"; //Command deletes the matching entry from the database.

                writeSQL.Parameters.AddWithValue("@url", url);

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        /*Method for deleting all the history from the database, activated through the method triggered on 'ERASE ALL' press on the history form.*/
        public void DeleteAllHistory()
        {
            CheckIfTableExists("History", historyDir);
            using (var connection = new SQLiteConnection(historyDir))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();

                writeSQL.CommandText = "DELETE FROM History"; //This command deletes all rows in the table.

                writeSQL.ExecuteNonQuery();

                connection.Close();
            }
        }

        /*Method for changing the homepage entry in the homepage database table.*/
        public void UpdateHomePage(string newURL) //Takes in the new homepage url.
        {
            CheckIfTableExists("HomePage", homePageDir);
            using (var connection = new SQLiteConnection(homePageDir))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();
                writeSQL.CommandText = "DELETE FROM HomePage"; //Clear the entire table command.
                writeSQL.ExecuteNonQuery(); //Execute the wipe.

                SQLiteCommand writeHomeSQL;
                writeHomeSQL = connection.CreateCommand();
                writeHomeSQL.CommandText = "INSERT INTO HomePage(URL) VALUES (@url)"; //Insert new  homepage command.
                writeHomeSQL.Parameters.AddWithValue("@url", newURL);
                writeHomeSQL.ExecuteNonQuery(); //Add the new homepage to the database.

                connection.Close();
            }
        }

        /*Method for getting the home page url from the database.*/
        public String ReadHomePage()
        {

            CheckIfTableExists("HomePage", homePageDir);
            using (var connection = new SQLiteConnection(homePageDir))
            {

                connection.Open();

                string homePage = "";

                SQLiteDataReader readSQL;
                SQLiteCommand getSQLData;
                getSQLData = connection.CreateCommand();
                getSQLData.CommandText = "SELECT * FROM HomePage"; //Command to get the homepage url.
                readSQL = getSQLData.ExecuteReader();
                while (readSQL.Read())
                {
                    homePage = readSQL["URL"].ToString(); //Update the homePage varibale to be the homepage in the database.

                }


                connection.Close();
                return homePage; //Return the homepage to the method that called for it.
            }

        }
    }
}
