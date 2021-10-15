using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http; //needed for searching URL
using System.Text.RegularExpressions; //needed for page title
using System.IO; //needed for read write of files
using System.Data.SQLite;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        static Stack<String> backStack = new Stack<String>();
        static Stack<String> forwardStack = new Stack<String>();
        static String currentPageAddress = "";
        static String homePage = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFavourites();
            StreamReader sr = new StreamReader("HomePage.txt");
            homePage = sr.ReadLine();
            sr.Close();
            menuSetHomePage.Text = homePage;
            Search(homePage);
            
        }

        private void btnSearchPressed(object sender, EventArgs e)
        {
            backStack.Push(currentPageAddress);
            String address = searchBar.Text;
            Search(address);
        }

        private void Refresh(object sender, EventArgs e)
        {
            Search(currentPageAddress);
        }

        private void Back(object sender, EventArgs e)
        {
            if (backStack.Count != 0)
            {
                forwardStack.Push(currentPageAddress);
                currentPageAddress = backStack.Pop();
                Search(currentPageAddress);
            } else
            {
                Console.WriteLine("No pages to go backwards to");
            } //Was going to use a try catch but then theres no way to be sure of poppable backstack, so would would current page address an then fail at pop of empty back stack
            
        }

        private void Forward(object sender, EventArgs e)
        {
            if (forwardStack.Count != 0)
            {
                backStack.Push(currentPageAddress);
                currentPageAddress = forwardStack.Pop();
                Search(currentPageAddress);
            }
            else
            {
                Console.WriteLine("No pages to go forward to");
            }        
          
        }

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        async Task Search(String address)
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync(address);
                statusBox.Text = (int)response.StatusCode + " " + response.StatusCode.ToString();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);
                htmlTextBox.Text = responseBody;
                currentPageAddress = address;
                textBoxPageTitle.Text = Regex.Match(responseBody, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        private void SetHomePage(object sender, EventArgs e)
        {
            File.WriteAllText("HomePage.txt", String.Empty);
            StreamWriter sw = new StreamWriter("HomePage.txt");
            sw.WriteLine(menuSetHomePage.Text);
            sw.Close();
            homePage = menuSetHomePage.Text;

        }

        private void Home(object sender, EventArgs e)
        {
            Search(homePage);

        }

    


        private void NewFavourite(object sender, EventArgs e)
        {
            using (var connection = new SQLiteConnection("Data Source=C:\\Users\\ryand\\Source\\Repos\\f21sc-2021-22-cw1NEW\\BrowserSolution\\WebBrowser\\bin\\Favourites.db; version = 3;"))
            {

                connection.Open();

                SQLiteCommand writeSQL;
                writeSQL = connection.CreateCommand();
                writeSQL.CommandText = "INSERT INTO Favourites(URL, TITLE) VALUES ('http://test123.com', 'TEST123')";
                writeSQL.ExecuteNonQuery();

                connection.Close();
            }

             ReadFavourites();
        }

        private void ReadFavourites()
        {
            favouritesListBox.Text = "";

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
                    favList.Add(new Favourite() {URL = readSQL["URL"].ToString(), TITLE = readSQL["TITLE"].ToString()});
                    
                }
                for (int i = 0; i < favList.Count; i++)
                {
                    favouritesListBox.Text += favList[i].URL;
                    favouritesListBox.Text += favList[i].TITLE;
                }

                connection.Close();
            }
            
        }

    }

  


    }
