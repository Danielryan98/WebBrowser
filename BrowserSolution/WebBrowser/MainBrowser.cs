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
        static Stack<String> backStack = new Stack<String>();
        static Stack<String> forwardStack = new Stack<String>();
        static String currentPageAddress = "";
        static String backwardSearchAddress = "";
        static String forwardSearchAddress = "";
        static String homePage = "";
        bool isBulkDownload = false;
        bool isForwardSearch = false;
        bool isBackwardSearch = false;
        bool isFormLoad = false;
        bool isRefresh = false;

        public MainBrowser()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            /*ReadFavourites();*/
            StreamReader sr = new StreamReader("HomePage.txt");
            homePage = sr.ReadLine();
            sr.Close();
            menuSetHomePage.Text = homePage;
            isFormLoad = true;
            await Search(homePage);
            isFormLoad = false;
        }

        private async void btnSearchPressed(object sender, EventArgs e)
        {
            String address = searchBar.Text;
            if(address != "")
            {
               await AttemptSearch(address);             
            } 
            
        }

        private async void Refresh(object sender, EventArgs e)
        {
            isRefresh = true;
            await AttemptSearch(currentPageAddress);
            isRefresh = false;
        }

        private async void Back(object sender, EventArgs e)
        {
            if (backStack.Count != 0)
            {
                isBackwardSearch = true;                
                backwardSearchAddress = backStack.Pop();
                await AttemptSearch(backwardSearchAddress);
                isBackwardSearch = false;
            } else
            {
                isBackwardSearch = false;
                MessageBox.Show("No pages to go backwards to.");
            } //Was going to use a try catch but then theres no way to be sure of poppable backstack, so would would current page address an then fail at pop of empty back stack

        }

        private async void Forward(object sender, EventArgs e)
        {
            if (forwardStack.Count != 0)
            {
                isForwardSearch = true;
                forwardSearchAddress = forwardStack.Pop();
                await AttemptSearch(forwardSearchAddress);
                isForwardSearch = false;
            }
            else
            {
                isForwardSearch = false;
                MessageBox.Show("No pages to go forward to."); //if you click forward fast enough you can activate this message
            }

        }


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

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        List<BulkObject> bulkList = new List<BulkObject>();

        public async Task GetResponse(String address)
        {
          
            try
            {
                HttpResponseMessage response = await client.GetAsync(address);
                statusBox.Text = (int)response.StatusCode + " " + response.StatusCode.ToString();
                byte[] responseBodyBytes = await response.Content.ReadAsByteArrayAsync();
                string responseBody = Encoding.UTF8.GetString(responseBodyBytes);
                htmlTextBox.Text = responseBody;
                currentPageAddress = address;
                searchBar.Text = address;
                textBoxPageTitle.Text = Regex.Match(responseBody, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
                if (isRefresh == false)
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
            if (isBulkDownload == true)
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(address);
                    byte[] responseBodyBytes = await response.Content.ReadAsByteArrayAsync();
                    string responseBody = Encoding.UTF8.GetString(responseBodyBytes);
                    
                    Byte[] txt = new UTF8Encoding(true).GetBytes(responseBody);
                    bulkList.Add(new BulkObject() { accessResponseCode = (int)response.StatusCode + " " + response.StatusCode.ToString(), accessUrl = address, accessUrlBytes = txt });
                    textBoxPageTitle.Text = "";
                    searchBar.Text = "";
                    statusBox.Text = "";
                    backStack.Push(currentPageAddress);
                    CheckStacks();
                } catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            else if(isBackwardSearch == true)
            {
                try
                {
                    forwardStack.Push(currentPageAddress);
                    await GetResponse(address);
                    CheckStacks();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                }
            } else if(isForwardSearch == true)
            {
                try
                {
                    backStack.Push(currentPageAddress);
                    await GetResponse(address);
                    CheckStacks();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                }
            } else if (isFormLoad == true)
            {
                try
                {
                    await GetResponse(address);
                    CheckStacks();

                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                }
            } else if (isRefresh == true)
            {
                try
                {

                    await GetResponse(address);
                    CheckStacks();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                }
            } else
            {
                try
                {
                    forwardStack.Clear();
                    backStack.Push(currentPageAddress);
                    await GetResponse(address);
                    CheckStacks();
                }
                catch (HttpRequestException e)
                {
                    MessageBox.Show(e.Message);
                }
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

        private async void Home(object sender, EventArgs e)
        {
            await AttemptSearch(homePage);

        }


        private async void ActivateFavouritesPage(object sender, EventArgs e)
        {
            FavouritesForm favPage = new FavouritesForm();
            DialogResult dialogresult = favPage.ShowDialog();
            if(favPage.ReturnURL != null)
            {
                searchBar.Text = favPage.ReturnURL;
                await AttemptSearch(favPage.ReturnURL);
                favPage.ReturnURL = null;
            }    
        }

        private void NewFavourite(object sender, EventArgs e)
        {
            Database db = new Database();
            db.NewFavourite(currentPageAddress, textBoxPageTitle.Text);
        }

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

        private async void OpenFilePrompt(object sender, EventArgs e)
        {
            isBulkDownload = true;

            bulkList.Clear();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        while(!reader.EndOfStream)
                        {

                            await AttemptSearch(reader.ReadLine());
                            
                            
                        }
                    }              
                    PopulateBulk();
                }
               
            }                                
            isBulkDownload = false;
        } 

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

        private void PopulateBulk()
        {
            htmlTextBox.Text = "";
            foreach (BulkObject b in bulkList)
            {
                htmlTextBox.Text += "< " + b.accessResponseCode + " > ";
                htmlTextBox.Text += "< " + b.accessUrlBytes.Length + " bytes > ";
                htmlTextBox.Text += "< " + b.accessUrl + " >";             
                htmlTextBox.Text += Environment.NewLine;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Right))
            {
                Back(sender, new EventArgs());
            } 
            else if (e.KeyData == (Keys.Control | Keys.Left))
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
            else if (e.KeyData == (Keys.Control | Keys.S))
            {
                
            }
        }

        
    }

  


    }
