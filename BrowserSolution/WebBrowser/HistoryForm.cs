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

            for (int i = 0; i < historyDict.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.Text = historyDict.ElementAt(i).Key;
                item.SubItems.Add(historyDict.ElementAt(i).Value);

                historyListView.Items.Add(item);
            }
        }
    }
}
