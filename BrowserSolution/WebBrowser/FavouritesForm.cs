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

        private void favouritesListView_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            string origString = favouritesListView.SelectedItems.ToString();

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

    }
}
