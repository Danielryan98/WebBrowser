
namespace WebBrowser
{
    partial class HistoryForm
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
            this.historyListView = new System.Windows.Forms.ListView();
            this.columnURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEraseSelected = new System.Windows.Forms.Button();
            this.btnEraseAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // historyListView
            // 
            this.historyListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnURL,
            this.columnName});
            this.historyListView.FullRowSelect = true;
            this.historyListView.HideSelection = false;
            this.historyListView.Location = new System.Drawing.Point(12, 63);
            this.historyListView.MultiSelect = false;
            this.historyListView.Name = "historyListView";
            this.historyListView.Size = new System.Drawing.Size(776, 375);
            this.historyListView.TabIndex = 1;
            this.historyListView.UseCompatibleStateImageBehavior = false;
            this.historyListView.View = System.Windows.Forms.View.Details;
            this.historyListView.DoubleClick += new System.EventHandler(this.LoadFromHistory);
            // 
            // columnURL
            // 
            this.columnURL.Text = "URL";
            this.columnURL.Width = 387;
            // 
            // columnName
            // 
            this.columnName.Text = "DESCRIPTION";
            this.columnName.Width = 384;
            // 
            // btnEraseSelected
            // 
            this.btnEraseSelected.Location = new System.Drawing.Point(12, 12);
            this.btnEraseSelected.Name = "btnEraseSelected";
            this.btnEraseSelected.Size = new System.Drawing.Size(121, 45);
            this.btnEraseSelected.TabIndex = 4;
            this.btnEraseSelected.Text = "ERASE SELECTED";
            this.btnEraseSelected.UseVisualStyleBackColor = true;
            this.btnEraseSelected.Click += new System.EventHandler(this.DeleteHistoryEntry);
            // 
            // btnEraseAll
            // 
            this.btnEraseAll.Location = new System.Drawing.Point(139, 12);
            this.btnEraseAll.Name = "btnEraseAll";
            this.btnEraseAll.Size = new System.Drawing.Size(121, 45);
            this.btnEraseAll.TabIndex = 5;
            this.btnEraseAll.Text = "ERASE ALL";
            this.btnEraseAll.UseVisualStyleBackColor = true;
            this.btnEraseAll.Click += new System.EventHandler(this.DeleteAllHistory);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEraseAll);
            this.Controls.Add(this.btnEraseSelected);
            this.Controls.Add(this.historyListView);
            this.Name = "HistoryForm";
            this.Text = "HistoryForm";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView historyListView;
        private System.Windows.Forms.ColumnHeader columnURL;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.Button btnEraseSelected;
        private System.Windows.Forms.Button btnEraseAll;
    }
}