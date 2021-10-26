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
    /*This class is for the functionality of the favourites screen that is activated through Settings -> Favourites OR ctrl + shift + f when on the browser main page.*/
    public partial class FavouritesForm : Form
    {
        public FavouritesForm()
        {
            InitializeComponent();
        }

        private void FavouritesForm_Load(object sender, EventArgs e)
        {
            PopulateFavouriteList(); //Display favourites on form load.

        }

        /*Method for displaying the favourites.*/
        private void PopulateFavouriteList()
        {
            favouritesListView.Items.Clear(); //Clear the list to avoid duplication.

            Database db = new Database();
            Dictionary<string, string> favDict = db.ReadFavourites(); //Set a new dictionary equal to the dictionary returned by ReadFavourites in the database class.

            for (int i = 0; i < favDict.Count; i++) //For each favourite, append it to the list view.
            {
                ListViewItem item = new ListViewItem();
                item.Text = favDict.ElementAt(i).Key;
                item.SubItems.Add(favDict.ElementAt(i).Value);
                
                favouritesListView.Items.Add(item);
            }
        }

        /*Property for MainBrowser class to use to search for a selected favourite.*/
        public string ReturnURL { get; set; }

        /*Method called on list view item DOUBLE-CLICK. Sets ReturnURL to the favourite url which is then searched for on close of the favourites form by the Main Browser class.*/
        private void GetFavourite(object sender, EventArgs e)
        {
            
            string favURL = favouritesListView.SelectedItems[0].Text;
            ReturnURL = favURL;
            this.Close();
        }

        /*Method for enabling the modification of a favourite. Activated on 'EDIT SELECTED' press.*/
        private void EditFavouriteName(object sender, EventArgs e)
        {
            try
            {
                ListViewItem favourite = favouritesListView.SelectedItems[0]; //User must select from the favourite list a favourite that they want to modify.

                string originalURL = favourite.SubItems[0].Text;
                string originalName = favourite.SubItems[1].Text;

                lblUpdateName.Text = originalName; //Label updates to favourite that is being edited so that the user knows what they're changing.
                lblUpdateURL.Text = originalURL;
                txtBoxUpdateName.Text = originalName;
                txtBoxUpdateURL.Text = originalURL;
            } catch
            {
                MessageBox.Show("Please select a favourite to edit first."); //Triggered on press without a selected favourite.
            }
        }

        /*Method for adding a favourite to the favourites list via the interface shown on the favourites form.*/
        private void AddFavourite(object sender, EventArgs e)
        {     
            string url = txtBoxURL.Text;
            string name = txtBoxName.Text;


            Database db = new Database();
            db.NewFavourite(url, name); //Add the favourite to the database.

            txtBoxURL.Text = ""; //Reset the fields.
            txtBoxName.Text = "";

            PopulateFavouriteList(); //Update the favourites list to show the new favourite.
        }

        /*Method for modifying a favourite.*/
        private void UpdateFavourite(object sender, EventArgs e)
        {
            string originalURL = lblUpdateURL.Text;
            string originalName = lblUpdateName.Text;

            string newURL = txtBoxUpdateURL.Text; //Get the URL and Name from the text inputs.
            string newName = txtBoxUpdateName.Text; 

            Database db = new Database();
            db.UpdateFavourite(originalURL, originalName, newURL, newName); //Update the favourite in the database.

            txtBoxUpdateName.Text = ""; //Reset the fields.
            txtBoxUpdateURL.Text = "";
            lblUpdateName.Text = "NAME";
            lblUpdateURL.Text = "URL"; 

            PopulateFavouriteList(); //Update the favourites list to show the changes.
        }

        /*Method for removing a favourite, activated on 'DELETE SELECTED'*/
        private void DeleteFavourite(object sender, EventArgs e)
        {
            try
            {
                ListViewItem favourite = favouritesListView.SelectedItems[0];

                string favURL = favourite.SubItems[0].Text; //Get the favourite to delete from the selected items text.

                Database db = new Database();
                db.DeleteFavourite(favURL); //Delete the favourite with corresponding URL from the database.

                PopulateFavouriteList(); //Update the favourite list.
            } catch
            {
                MessageBox.Show("Please select a favourite to delete first.");
            }
        }

       
    }
}
