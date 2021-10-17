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
    public partial class HistoryForm : Form
    {
        public string ReturnURL { get; set; }
        public HistoryForm()
        {
            InitializeComponent();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            PopulateHistoryList();

        }


        private void PopulateHistoryList()
        {
            historyListView.Items.Clear();

            Database db = new Database();
            Dictionary<string, string> historyDict = db.ReadHistory();

            for (int i = historyDict.Count - 1; i != -1; i--)
            {
                ListViewItem item = new ListViewItem();
                item.Text = historyDict.ElementAt(i).Key;
                item.SubItems.Add(historyDict.ElementAt(i).Value);

                historyListView.Items.Add(item);
            }
        }

        private void LoadFromHistory(object sender, EventArgs e)
        {

            string historyURL = historyListView.SelectedItems[0].Text;
            ReturnURL = historyURL;
            this.Close();
        }

        private void DeleteHistoryEntry(object sender, EventArgs e)
        {
            try
            {
                ListViewItem history = historyListView.SelectedItems[0];

                string historyUrl = history.SubItems[0].Text;
                string historyName = history.SubItems[1].Text;

                Database db = new Database();
                db.DeleteHistoryEntry(historyUrl);

                PopulateHistoryList();
            } catch
            {
                Console.WriteLine("Need to write exception for no history to erase");
            }
        }

        private void DeleteAllHistory(object sender, EventArgs e)
        {
            Database db = new Database();
            db.DeleteAllHistory();

            PopulateHistoryList();
        }
    }
}
