
namespace WebBrowser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchBar = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.htmlTextBox = new System.Windows.Forms.TextBox();
            this.btnFavourite = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.textBoxPageTitle = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHomePage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetHomePage = new System.Windows.Forms.ToolStripTextBox();
            this.btnSetHomePage = new System.Windows.Forms.ToolStripMenuItem();
            this.favouritesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHome = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // searchBar
            // 
            this.searchBar.Location = new System.Drawing.Point(214, 9);
            this.searchBar.Name = "searchBar";
            this.searchBar.Size = new System.Drawing.Size(400, 20);
            this.searchBar.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 7);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.Back);
            // 
            // btnForward
            // 
            this.btnForward.Location = new System.Drawing.Point(93, 7);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(75, 23);
            this.btnForward.TabIndex = 3;
            this.btnForward.Text = ">";
            this.btnForward.UseVisualStyleBackColor = true;
            this.btnForward.Click += new System.EventHandler(this.Forward);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(174, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(34, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "R";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.Refresh);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(620, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(52, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "GO";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearchPressed);
            // 
            // htmlTextBox
            // 
            this.htmlTextBox.Location = new System.Drawing.Point(0, 63);
            this.htmlTextBox.Multiline = true;
            this.htmlTextBox.Name = "htmlTextBox";
            this.htmlTextBox.Size = new System.Drawing.Size(984, 468);
            this.htmlTextBox.TabIndex = 6;
            // 
            // btnFavourite
            // 
            this.btnFavourite.Location = new System.Drawing.Point(678, 7);
            this.btnFavourite.Name = "btnFavourite";
            this.btnFavourite.Size = new System.Drawing.Size(41, 23);
            this.btnFavourite.TabIndex = 8;
            this.btnFavourite.Text = "FAV";
            this.btnFavourite.UseVisualStyleBackColor = true;
            this.btnFavourite.Click += new System.EventHandler(this.NewFavourite);
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 537);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(156, 20);
            this.statusBox.TabIndex = 10;
            // 
            // textBoxPageTitle
            // 
            this.textBoxPageTitle.Location = new System.Drawing.Point(12, 37);
            this.textBoxPageTitle.Name = "textBoxPageTitle";
            this.textBoxPageTitle.Size = new System.Drawing.Size(100, 20);
            this.textBoxPageTitle.TabIndex = 11;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSettings});
            this.menuStrip1.Location = new System.Drawing.Point(763, 9);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(212, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuSettings
            // 
            this.menuSettings.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHistory,
            this.menuHomePage,
            this.favouritesToolStripMenuItem});
            this.menuSettings.Name = "menuSettings";
            this.menuSettings.Size = new System.Drawing.Size(69, 20);
            this.menuSettings.Text = "SETTINGS";
            // 
            // menuHistory
            // 
            this.menuHistory.Name = "menuHistory";
            this.menuHistory.Size = new System.Drawing.Size(155, 22);
            this.menuHistory.Text = "History";
            // 
            // menuHomePage
            // 
            this.menuHomePage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSetHomePage,
            this.btnSetHomePage});
            this.menuHomePage.Name = "menuHomePage";
            this.menuHomePage.Size = new System.Drawing.Size(155, 22);
            this.menuHomePage.Text = "Set Home Page";
            // 
            // menuSetHomePage
            // 
            this.menuSetHomePage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuSetHomePage.Name = "menuSetHomePage";
            this.menuSetHomePage.Size = new System.Drawing.Size(100, 23);
            // 
            // btnSetHomePage
            // 
            this.btnSetHomePage.Name = "btnSetHomePage";
            this.btnSetHomePage.Size = new System.Drawing.Size(160, 22);
            this.btnSetHomePage.Text = "Set Home Page";
            this.btnSetHomePage.Click += new System.EventHandler(this.SetHomePage);
            // 
            // favouritesToolStripMenuItem
            // 
            this.favouritesToolStripMenuItem.Name = "favouritesToolStripMenuItem";
            this.favouritesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.favouritesToolStripMenuItem.Text = "Favourites";
            this.favouritesToolStripMenuItem.Click += new System.EventHandler(this.ActivateFavouritesPage);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(726, 7);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(34, 23);
            this.btnHome.TabIndex = 13;
            this.btnHome.Text = "H";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.Home);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.textBoxPageTitle);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.btnFavourite);
            this.Controls.Add(this.htmlTextBox);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnForward);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.searchBar);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox searchBar;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox htmlTextBox;
        private System.Windows.Forms.Button btnFavourite;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.TextBox textBoxPageTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuSettings;
        private System.Windows.Forms.ToolStripMenuItem menuHistory;
        private System.Windows.Forms.ToolStripMenuItem menuHomePage;
        private System.Windows.Forms.ToolStripTextBox menuSetHomePage;
        private System.Windows.Forms.ToolStripMenuItem btnSetHomePage;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.ToolStripMenuItem favouritesToolStripMenuItem;
    }
}

