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
    public partial class FavouritesForm : Form
    {
        public FavouritesForm()
        {
            InitializeComponent();
        }

        private void FavouritesForm_Load(object sender, EventArgs e)
        {
            PopulateFavouriteList();

        }

        private void PopulateFavouriteList()
        {
            favouritesListView.Items.Clear();

            Database db = new Database();
            Dictionary<string, string> favDict = db.ReadFavourites();

            for (int i = 0; i < favDict.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = favDict.ElementAt(i).Key;
                item.SubItems.Add(favDict.ElementAt(i).Value);
                
                favouritesListView.Items.Add(item);
            }
        }

        public string ReturnURL { get; set; }

        private void GetFavourite(object sender, EventArgs e)
        {
            
            string favURL = favouritesListView.SelectedItems[0].Text;
            ReturnURL = favURL;
            this.Close();
        }

        private void EditFavouriteName(object sender, EventArgs e)
        {
            try
            {
                ListViewItem favourite = favouritesListView.SelectedItems[0];

                string originalURL = favourite.SubItems[0].Text;
                string originalName = favourite.SubItems[1].Text;

                lblUpdateName.Text = originalName;
                lblUpdateURL.Text = originalURL;
                txtBoxUpdateName.Text = originalName;
                txtBoxUpdateURL.Text = originalURL;
            } catch
            {
                Console.WriteLine("Need to write exception for no favourite selected to edit");
            }
        }

        private void AddFavourite(object sender, EventArgs e)
        {     
            string url = txtBoxURL.Text;
            string name = txtBoxName.Text;


            Database db = new Database();
            db.NewFavourite(url, name);

            txtBoxURL.Text = "";
            txtBoxName.Text = "";

            PopulateFavouriteList();
        }

        private void UpdateFavourite(object sender, EventArgs e)
        {
            string originalURL = lblUpdateURL.Text;
            string originalName = lblUpdateName.Text;

            string newURL = txtBoxUpdateURL.Text;
            string newName = txtBoxUpdateName.Text;

            Database db = new Database();
            db.UpdateFavourite(originalURL, originalName, newURL, newName);

            txtBoxUpdateName.Text = "";
            txtBoxUpdateURL.Text = "";
            lblUpdateName.Text = "NAME";
            lblUpdateURL.Text = "URL";

            PopulateFavouriteList();
        }

        private void DeleteFavourite(object sender, EventArgs e)
        {
            try
            {
                ListViewItem favourite = favouritesListView.SelectedItems[0];

                string favURL = favourite.SubItems[0].Text;

                Database db = new Database();
                db.DeleteFavourite(favURL);

                PopulateFavouriteList();
            } catch
            {
                Console.WriteLine("Need to write exception for no favourite selected to delete");
            }
        }

       
    }
}
