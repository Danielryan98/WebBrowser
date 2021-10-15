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
            Database db = new Database();
            List<Favourite> favList = db.ReadFavourites();

            for (int i = 0; i < favList.Count; i++)
            {
                favouritesListView.Items.Add(favList[i].TITLE + " " + favList[i].URL);
            }
        }

    }
}
