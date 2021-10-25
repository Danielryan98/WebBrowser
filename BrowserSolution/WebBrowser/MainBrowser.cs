using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http; //needed for searching URL
using System.Text.RegularExpressions; //needed for page title
using System.IO; //needed for read write of files
using System.Linq;
using System.Diagnostics;

namespace WebBrowser
{
    
    public partial class MainBrowser : Form
    {
        List<BulkObject> bulkList = new List<BulkObject>(); //List of type BulkObject, a bulk object has: URL, response code for that URL, and the number of bytes for that URL response.
        static Stack<String> backStack = new Stack<String>(); //Stack to hold previous web pages.
        static Stack<String> forwardStack = new Stack<String>(); //Stack to hold web page that was active before back button press.
        static String currentPageAddress = "";
        static String backwardSearchAddress = "";
        static String forwardSearchAddress = "";
        static String homePage = "";

        /*Booleans for Search(), signifies what type of search will be carried out.*/
        bool isBulkDownload = false;
        bool isForwardSearch = false;
        bool isBackwardSearch = false;
        bool isFormLoad = false;
        bool isRefresh = false;

        public MainBrowser()
        {
            InitializeComponent();
        }

        /*Load in the home page, if one isn't set then make it heriot-watt website. Booleans needed so that there isn't an attempt to push to back stack.*/
        private async void Form1_Load(object sender, EventArgs e)
        {
            /*ReadFavourites();*/ //Could read favourites & history on load as stated in the cw spec, but that isn't necessary for this implementation.
            /*ReadHistory();*/
            Database db = new Database();
            homePage = db.ReadHomePage();
            if(homePage == "")
            {
                db.UpdateHomePage("http://hw.ac.uk");
                homePage = "http://hw.ac.uk";
            }
            menuSetHomePage.Text = homePage;
            isFormLoad = true;
            await Search(homePage);
            isFormLoad = false;
        }

        /*If there is text in the search bar then try to carry out a http request.*/
        private async void btnSearchPressed(object sender, EventArgs e)
        {
            String address = searchBar.Text;
            if(address != "")
            {
               await AttemptSearch(address);             
            } 
            
        }

        /*Refresh the page, booleans let Search() know that it is just to refresh the page.*/
        private async void Refresh(object sender, EventArgs e)
        {
            isRefresh = true;
            await AttemptSearch(currentPageAddress);
            isRefresh = false;
        }

        /*Checks for empty stack, if one presses back multiple times fast enough or uses the shortcut keys to go back then they will get an error message. Booleans signify which method of search() to use.*/
        private async void Back(object sender, EventArgs e)
        {
            if (backStack.Count != 0)
            {
                isBackwardSearch = true;                
                backwardSearchAddress = backStack.Pop(); //Get the URL from the back stack to search for.
                await AttemptSearch(backwardSearchAddress);
                isBackwardSearch = false;
            } else
            {
                isBackwardSearch = false;
                MessageBox.Show("No pages to go backwards to.");
            } //Was going to use a try catch but then theres no way to be sure of poppable backstack, so would would current page address an then fail at pop of empty back stack.

        }

        /*Checks for empty stack, if one presses forward multiple times fast enough or uses the shortcut keys to go forward then they will get an error message. Booleans signify which method of search() to use.*/
        private async void Forward(object sender, EventArgs e)
        {
            if (forwardStack.Count != 0)
            {
                isForwardSearch = true;
                forwardSearchAddress = forwardStack.Pop(); //Get the URL from the forward stack.
                await AttemptSearch(forwardSearchAddress);
                isForwardSearch = false;
            }
            else
            {
                isForwardSearch = false;
                MessageBox.Show("No pages to go forward to.");
            }

        }

        /*Check for empty stacks to disable the use of the back and forward buttons. Does not disable use of keyboard shortcuts though. Called when neccessary.*/
        private void CheckStacks()
        {
            if (forwardStack.Count == 0)
            {
                btnForward.Enabled = false;
            } else
            {
                btnForward.Enabled = true;
            }

            if(backStack.Count == 0)
            {
                btnBack.Enabled = false;
            } else
            {
                btnBack.Enabled = true;
            }
        }

        
        static readonly HttpClient client = new HttpClient(); //HttpClient class instantiation that allows for sending HTTP request messages, and also receiving HTTP response messages.

        /*Universal method for getting response from http request based off the Microsoft Documentation for HttpClient Class.*/
        public async Task GetResponse(String address)
        {
          
            try
            {
                HttpResponseMessage response = await client.GetAsync(address); //Gets the response from the HttpClient instance.
                statusBox.Text = (int)response.StatusCode + " " + response.StatusCode.ToString(); //displays the status code.
                byte[] responseBodyBytes = await response.Content.ReadAsByteArrayAsync();
                string responseBody = Encoding.UTF8.GetString(responseBodyBytes); //Have to encode to UTF8 because some websites dont work otherwise.
                htmlTextBox.Text = responseBody; //Displays the html.
                currentPageAddress = address; //Update current address.
                searchBar.Text = address; //Put the url in the searchbar.
                textBoxPageTitle.Text = Regex.Match(responseBody, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value; //Get the title from the html body
                if (isRefresh == false) //Don't want to add the same page to the history on refesh.
                {
                    Database db = new Database();
                    db.AddHistory(address, textBoxPageTitle.Text);
                }
            } catch (HttpRequestException e)
            {
                MessageBox.Show(e.Message);
            }
            
            
        }

        public async Task Search(String address)
        {
            if (isBulkDownload == true) //Case: Bulk Download. We don't want to display html.
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(address);
                    byte[] responseBodyBytes = await response.Content.ReadAsByteArrayAsync();
                    string responseBody = Encoding.UTF8.GetString(responseBodyBytes);
                    
                    byte[] txt = new UTF8Encoding(true).GetBytes(responseBody); //Get the response body as bytes.
                    bulkList.Add(new BulkObject() { accessResponseCode = (int)response.StatusCode + " " + response.StatusCode.ToString(), accessUrl = address, accessUrlBytes = txt }); //Add the relevant details to a BulkObject
                    textBoxPageTitle.Text = ""; //Clear all html related tools, as we arent displaying a web page.
                    searchBar.Text = "";
                    statusBox.Text = "";
                    backStack.Push(currentPageAddress); //We come away from the web page we were on so need to add it to the backstack to get back to.
                    CheckStacks();
                } catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            else if(isBackwardSearch == true) //Case: Backwards One Page. We want to push the current page to the forward stack here before we go to the previous page.
            {
                
                forwardStack.Push(currentPageAddress);
                await GetResponse(address); //We need to wait for GetResponse() to finish before going further or errors will occur.
                CheckStacks(); //Could be no pages to go back to now so check the stacks, and if there isn't any to go back to the back button will be disabled.
                
            } else if(isForwardSearch == true) //Case: Forwards One Page. We want to push the current page to the back stack here before we go to the page ahead.
            {
                backStack.Push(currentPageAddress);
                await GetResponse(address);
                CheckStacks(); //Could be no pages to go forward now.
                
            } else if (isFormLoad == true) //Case: On Browser Start Up. Don't want to push to any stacks. Just get the home page.
            {
                
                await GetResponse(address);
                CheckStacks(); //Disables both forward and back buttons because there is no pages to go forward or back to.
                
            } else if (isRefresh == true) //Case: Page Refresh. Don't want to push to any stacks. Just refresh the page.
            {      
                await GetResponse(address);
                CheckStacks();
                
            } else //A normal search via the search bar, a favourite clicked in the favourites page, or a history url clicked in the history page.
            {
                
                forwardStack.Clear(); //Clear the forward stack because there are no pages to go forward to after a new search.
                backStack.Push(currentPageAddress); //The current page should be pushed to the back stack to go back to.
                await GetResponse(address);
                CheckStacks(); //Theres no forward pages - thats a guarantee - so disable the forward button.
                
            }
        }

        /*Method provides a try catch for searching, and displays the appropriate error message when unsuccessful.*/
        private async Task AttemptSearch(string address)
        {
            try
            {
                await Search(address);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /*Method for setting a new home page, calls method from database class where the background is handled.*/
        private void SetHomePage(object sender, EventArgs e)
        {
            Database db = new Database();
            db.UpdateHomePage(menuSetHomePage.Text);
            homePage = menuSetHomePage.Text;

        }

        /*Searches for the home page*/
        private async void Home(object sender, EventArgs e)
        {
            await AttemptSearch(homePage);

        }

        /*Method for opening the favourites form, which can be accessed via the settings in the browser or by CTRL + SHIFT + F.*/
        private async void ActivateFavouritesPage(object sender, EventArgs e)
        {
            FavouritesForm favPage = new FavouritesForm();
            DialogResult dialogresult = favPage.ShowDialog();
            if(favPage.ReturnURL != null) //ReturnURL is a property in the class FavouritesForm, that is set to the selected favourite url.
            {
                searchBar.Text = favPage.ReturnURL;
                await AttemptSearch(favPage.ReturnURL); //Search for the favourite URL.
                favPage.ReturnURL = null; //Reset the favourite url to null.
            }    
        }

        /*New favourite method - communicates with database through an instantiation of the Database class*/
        private void NewFavourite(object sender, EventArgs e)
        {
            Database db = new Database();
            db.NewFavourite(currentPageAddress, textBoxPageTitle.Text); //NewFavourite() in Database class takes a URL and a Name for the new favourite.
        }

        /*Method for opening the History form, which can be accessed via the settings in the browser or by CTRL + SHIFT + H. Same functionality as Favourites.*/
        private async void ActivateHistoryPage(object sender, EventArgs e)
        {
            HistoryForm historyPage = new HistoryForm();
            DialogResult dialogresult = historyPage.ShowDialog();
            if(historyPage.ReturnURL != null)
            {
                searchBar.Text = historyPage.ReturnURL;
                await AttemptSearch(historyPage.ReturnURL);
                historyPage.ReturnURL = null;
            }
            


        }

        /*Method for activating the file prompt, based off the boiler plate code in the Microsoft Documentation for OpenFileDialog Class.*/
        private async void OpenFilePrompt(object sender, EventArgs e)
        {
            isBulkDownload = true; //When search() for the strings inside the .txt file it will follow Case: Bulk Download.

            bulkList.Clear(); //Clear the bulklist of previous read.

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; //Open file prompt in C drive
                openFileDialog.Filter = "txt files (*.txt)|*.txt"; //Only allow for txt files
                openFileDialog.RestoreDirectory = true; //If previosuly opened a file, will open in the same directory.

                if (openFileDialog.ShowDialog() == DialogResult.OK) //If a file has been selected
                {
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile(); //Open the file to read from it

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while(!reader.EndOfStream)
                        {

                            await AttemptSearch(reader.ReadLine()); //Search for each line (url) in the file
                            
                            
                        }
                    }              
                    PopulateBulk(); //Show the results
                }
               
            }
            isBulkDownload = false;
        } 

        /*Method for displaying the results of Bulk Download*/
        private void PopulateBulk()
        {
            currentPageAddress = null; //Dont want refresh of the page to display the page we were on when bulk download was initiated
            htmlTextBox.Text = ""; //Clear the html
            foreach (BulkObject b in bulkList) //Append to the htmlTextBox each bulk object: Response code, bytes, url.
            {
                htmlTextBox.Text += "< " + b.accessResponseCode + " > ";
                htmlTextBox.Text += "< " + b.accessUrlBytes.Length + " bytes > ";
                htmlTextBox.Text += "< " + b.accessUrl + " >";             
                htmlTextBox.Text += Environment.NewLine;
            }
        }

        /*Shortcut keys for the program.*/
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Left))
            {
                Back(sender, new EventArgs());
            } 
            else if (e.KeyData == (Keys.Control | Keys.Right))
            {
                Forward(sender, new EventArgs());
            }
            else if (e.KeyData == (Keys.Control | Keys.H))
            {
                Home(sender, new EventArgs());
            }
            else if (e.KeyData == Keys.Enter)
            {
                btnSearchPressed(sender, new EventArgs());
            }
            else if (e.KeyData == (Keys.Control | Keys.F))
            {
                NewFavourite(sender, new EventArgs());
            }
            else if (e.KeyData == (Keys.Control | Keys.R))
            {
                Refresh(sender, new EventArgs());
            }
            else if (e.KeyData == (Keys.Control | Keys.B))
            {
                OpenFilePrompt(sender, new EventArgs());
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.H))
            {
                ActivateHistoryPage(sender, new EventArgs());
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.F))
            {
                ActivateFavouritesPage(sender, new EventArgs());
            }
            else if (e.KeyData == (Keys.Control | Keys.Alt | Keys.H)) //Sets home page to the current page.
            {
                Database db = new Database();
                db.UpdateHomePage(currentPageAddress);
                homePage = currentPageAddress;
                menuSetHomePage.Text = homePage; //Updates the homepage in the settings.
            }
        }

        
    }

  


    }
