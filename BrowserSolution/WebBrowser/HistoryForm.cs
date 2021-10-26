using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    /*The HistoryForm class contains all things regarding the history page.*/
    public partial class HistoryForm : Form
    {
        /*Property for MainBrowser class to use to search for a selected history entry.*/
        public string ReturnURL { get; set; } 
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            PopulateHistoryList(); //Show the history in a list on form load.

        }

        /*Method for displaying the favourites.*/
        private void PopulateHistoryList()
        {
            historyListView.Items.Clear(); //Clear the list to avoid duplication.

            Database db = new Database();
            Dictionary<string, string> historyDict = db.ReadHistory(); //Set a new dictionary equal to the dictionary returned by ReadFavourites in the database class.

            for (int i = historyDict.Count - 1; i != -1; i--) //For each favourite, append it to the list view but in order of most recently visited.
            {
                ListViewItem item = new ListViewItem();
                item.Text = historyDict.ElementAt(i).Key;
                item.SubItems.Add(historyDict.ElementAt(i).Value);

                historyListView.Items.Add(item);
            }
        }

        /*Method called on list view item DOUBLE-CLICK. Sets ReturnURL to the history url which is then searched for on close of the history form by the Main Browser class.*/
        private void LoadFromHistory(object sender, EventArgs e)
        {

            string historyURL = historyListView.SelectedItems[0].Text;
            ReturnURL = historyURL;
            Close(); //Automatically the form because the user has requested a page.
        }

        /*Method for removing a favourite, activated on 'DELETE SELECTED'*/
        private void DeleteHistoryEntry(object sender, EventArgs e)
        {
            try
            {
                ListViewItem history = historyListView.SelectedItems[0];

                string historyUrl = history.SubItems[0].Text; //Get the history entry to delete from the selected items text.
                string historyName = history.SubItems[1].Text;

                Database db = new Database();
                db.DeleteHistoryEntry(historyUrl); //Delete the history entry with corresponding URL from the database.

                PopulateHistoryList(); //Update the favourite list.
            } catch
            {
                Console.WriteLine("Need to write exception for no history to erase");
            }
        }

        /*Method for deleting all the history in the database on 'ERASE ALL' press.*/
        private void DeleteAllHistory(object sender, EventArgs e)
        {
            Database db = new Database();
            db.DeleteAllHistory(); //Delete all history from the database.

            PopulateHistoryList(); //Update the list to show no history.
        }
    }
}
