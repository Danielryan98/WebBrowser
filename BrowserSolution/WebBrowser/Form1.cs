using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Collections;

namespace WebBrowser
{
    public partial class Form1 : Form
    {
        static Stack<String> backStack = new Stack<String>();
        static Stack<String> forwardStack = new Stack<String>();
        static String currentPageAddress = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Search("http://google.com");
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
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

        bool isCollapsed = true;
        private void Settings(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                settingsPanel.Size = settingsPanel.MaximumSize;
                isCollapsed = false;
            } else
            {
                settingsPanel.Size = settingsPanel.MinimumSize;
                isCollapsed = true;
            }
        }

        public Dictionary<string, string> favouritesDict = new Dictionary<string, string>();
        public string favouriteName { get; set; }
        public string favouriteURL { get; set; }

        

        private void NewFavourite(object sender, EventArgs e)
        {
            Favourite newFav = new Favourite();
            favouriteName = "Fav 1";
            favouriteURL = currentPageAddress;

            favouritesDict.Add(favouriteName, favouriteURL);

        }


    }

    public class Favourite
    {
        

        

    }

    }
