
namespace WebBrowser
{
    partial class FavouritesForm
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
            this.favouritesListView = new System.Windows.Forms.ListView();
            this.columnURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDeleteFav = new System.Windows.Forms.Button();
            this.btnNewFav = new System.Windows.Forms.Button();
            this.btnEditFav = new System.Windows.Forms.Button();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxURL = new System.Windows.Forms.TextBox();
            this.lblFavName = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.txtBoxUpdateURL = new System.Windows.Forms.TextBox();
            this.txtBoxUpdateName = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lblUpdateName = new System.Windows.Forms.Label();
            this.lblUpdateURL = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // favouritesListView
            // 
            this.favouritesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnURL,
            this.columnName});
            this.favouritesListView.FullRowSelect = true;
            this.favouritesListView.HideSelection = false;
            this.favouritesListView.Location = new System.Drawing.Point(13, 12);
            this.favouritesListView.MultiSelect = false;
            this.favouritesListView.Name = "favouritesListView";
            this.favouritesListView.Size = new System.Drawing.Size(353, 426);
            this.favouritesListView.TabIndex = 0;
            this.favouritesListView.UseCompatibleStateImageBehavior = false;
            this.favouritesListView.View = System.Windows.Forms.View.Details;
            this.favouritesListView.DoubleClick += new System.EventHandler(this.GetFavourite);
            // 
            // columnURL
            // 
            this.columnURL.Text = "URL";
            this.columnURL.Width = 170;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 178;
            // 
            // btnDeleteFav
            // 
            this.btnDeleteFav.Location = new System.Drawing.Point(372, 393);
            this.btnDeleteFav.Name = "btnDeleteFav";
            this.btnDeleteFav.Size = new System.Drawing.Size(121, 45);
            this.btnDeleteFav.TabIndex = 1;
            this.btnDeleteFav.Text = "DELETE SELECTED";
            this.btnDeleteFav.UseVisualStyleBackColor = true;
            this.btnDeleteFav.Click += new System.EventHandler(this.DeleteFavourite);
            // 
            // btnNewFav
            // 
            this.btnNewFav.Location = new System.Drawing.Point(523, 75);
            this.btnNewFav.Name = "btnNewFav";
            this.btnNewFav.Size = new System.Drawing.Size(121, 45);
            this.btnNewFav.TabIndex = 2;
            this.btnNewFav.Text = "ADD";
            this.btnNewFav.UseVisualStyleBackColor = true;
            this.btnNewFav.Click += new System.EventHandler(this.AddFavourite);
            // 
            // btnEditFav
            // 
            this.btnEditFav.Location = new System.Drawing.Point(372, 342);
            this.btnEditFav.Name = "btnEditFav";
            this.btnEditFav.Size = new System.Drawing.Size(121, 45);
            this.btnEditFav.TabIndex = 3;
            this.btnEditFav.Text = "EDIT SELECTED";
            this.btnEditFav.UseVisualStyleBackColor = true;
            this.btnEditFav.Click += new System.EventHandler(this.EditFavouriteName);
            // 
            // txtBoxName
            // 
            this.txtBoxName.Location = new System.Drawing.Point(384, 37);
            this.txtBoxName.Multiline = true;
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(199, 32);
            this.txtBoxName.TabIndex = 5;
            // 
            // txtBoxURL
            // 
            this.txtBoxURL.Location = new System.Drawing.Point(589, 37);
            this.txtBoxURL.Multiline = true;
            this.txtBoxURL.Name = "txtBoxURL";
            this.txtBoxURL.Size = new System.Drawing.Size(199, 32);
            this.txtBoxURL.TabIndex = 6;
            // 
            // lblFavName
            // 
            this.lblFavName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavName.Location = new System.Drawing.Point(384, 12);
            this.lblFavName.Name = "lblFavName";
            this.lblFavName.Size = new System.Drawing.Size(199, 25);
            this.lblFavName.TabIndex = 7;
            this.lblFavName.Text = "NAME";
            this.lblFavName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblURL
            // 
            this.lblURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL.Location = new System.Drawing.Point(589, 12);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(199, 25);
            this.lblURL.TabIndex = 8;
            this.lblURL.Text = "URL";
            this.lblURL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtBoxUpdateURL
            // 
            this.txtBoxUpdateURL.Location = new System.Drawing.Point(589, 247);
            this.txtBoxUpdateURL.Multiline = true;
            this.txtBoxUpdateURL.Name = "txtBoxUpdateURL";
            this.txtBoxUpdateURL.Size = new System.Drawing.Size(199, 32);
            this.txtBoxUpdateURL.TabIndex = 10;
            // 
            // txtBoxUpdateName
            // 
            this.txtBoxUpdateName.Location = new System.Drawing.Point(384, 247);
            this.txtBoxUpdateName.Multiline = true;
            this.txtBoxUpdateName.Name = "txtBoxUpdateName";
            this.txtBoxUpdateName.Size = new System.Drawing.Size(199, 32);
            this.txtBoxUpdateName.TabIndex = 11;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(523, 285);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(121, 45);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.UpdateFavourite);
            // 
            // lblUpdateName
            // 
            this.lblUpdateName.AutoEllipsis = true;
            this.lblUpdateName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateName.Location = new System.Drawing.Point(384, 194);
            this.lblUpdateName.Name = "lblUpdateName";
            this.lblUpdateName.Size = new System.Drawing.Size(199, 25);
            this.lblUpdateName.TabIndex = 13;
            this.lblUpdateName.Text = "NAME";
            this.lblUpdateName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblUpdateURL
            // 
            this.lblUpdateURL.AutoEllipsis = true;
            this.lblUpdateURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateURL.Location = new System.Drawing.Point(589, 194);
            this.lblUpdateURL.Name = "lblUpdateURL";
            this.lblUpdateURL.Size = new System.Drawing.Size(199, 25);
            this.lblUpdateURL.TabIndex = 14;
            this.lblUpdateURL.Text = "URL";
            this.lblUpdateURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(384, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 15;
            this.label1.Text = "UPDATING";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(384, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "TO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(589, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 25);
            this.label3.TabIndex = 17;
            this.label3.Text = "UPDATING";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(589, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(199, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "TO";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // FavouritesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUpdateURL);
            this.Controls.Add(this.lblUpdateName);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtBoxUpdateName);
            this.Controls.Add(this.txtBoxUpdateURL);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblFavName);
            this.Controls.Add(this.txtBoxURL);
            this.Controls.Add(this.txtBoxName);
            this.Controls.Add(this.btnEditFav);
            this.Controls.Add(this.btnNewFav);
            this.Controls.Add(this.btnDeleteFav);
            this.Controls.Add(this.favouritesListView);
            this.Name = "FavouritesForm";
            this.Text = "FavouritesForm";
            this.Load += new System.EventHandler(this.FavouritesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView favouritesListView;
        private System.Windows.Forms.Button btnDeleteFav;
        private System.Windows.Forms.Button btnNewFav;
        private System.Windows.Forms.Button btnEditFav;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxURL;
        private System.Windows.Forms.Label lblFavName;
        private System.Windows.Forms.Label lblURL;
        private System.Windows.Forms.ColumnHeader columnURL;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.TextBox txtBoxUpdateURL;
        private System.Windows.Forms.TextBox txtBoxUpdateName;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblUpdateName;
        private System.Windows.Forms.Label lblUpdateURL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}