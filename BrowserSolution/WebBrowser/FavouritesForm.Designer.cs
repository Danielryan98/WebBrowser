
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
            this.btnDeleteFav = new System.Windows.Forms.Button();
            this.btnNewFav = new System.Windows.Forms.Button();
            this.btnEditFav = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblFavName = new System.Windows.Forms.Label();
            this.lblURL = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // favouritesListView
            // 
            this.favouritesListView.HideSelection = false;
            this.favouritesListView.Location = new System.Drawing.Point(13, 12);
            this.favouritesListView.Name = "favouritesListView";
            this.favouritesListView.Size = new System.Drawing.Size(353, 426);
            this.favouritesListView.TabIndex = 0;
            this.favouritesListView.UseCompatibleStateImageBehavior = false;
            this.favouritesListView.View = System.Windows.Forms.View.List;
            // 
            // btnDeleteFav
            // 
            this.btnDeleteFav.Location = new System.Drawing.Point(372, 393);
            this.btnDeleteFav.Name = "btnDeleteFav";
            this.btnDeleteFav.Size = new System.Drawing.Size(121, 45);
            this.btnDeleteFav.TabIndex = 1;
            this.btnDeleteFav.Text = "DELETE SELECTED";
            this.btnDeleteFav.UseVisualStyleBackColor = true;
            // 
            // btnNewFav
            // 
            this.btnNewFav.Location = new System.Drawing.Point(523, 75);
            this.btnNewFav.Name = "btnNewFav";
            this.btnNewFav.Size = new System.Drawing.Size(121, 45);
            this.btnNewFav.TabIndex = 2;
            this.btnNewFav.Text = "ADD";
            this.btnNewFav.UseVisualStyleBackColor = true;
            // 
            // btnEditFav
            // 
            this.btnEditFav.Location = new System.Drawing.Point(372, 342);
            this.btnEditFav.Name = "btnEditFav";
            this.btnEditFav.Size = new System.Drawing.Size(121, 45);
            this.btnEditFav.TabIndex = 3;
            this.btnEditFav.Text = "EDIT SELECTED";
            this.btnEditFav.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(384, 37);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(199, 32);
            this.textBox2.TabIndex = 5;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(589, 37);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(199, 32);
            this.textBox1.TabIndex = 6;
            // 
            // lblFavName
            // 
            this.lblFavName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFavName.Location = new System.Drawing.Point(447, 12);
            this.lblFavName.Name = "lblFavName";
            this.lblFavName.Size = new System.Drawing.Size(74, 25);
            this.lblFavName.TabIndex = 7;
            this.lblFavName.Text = "NAME";
            // 
            // lblURL
            // 
            this.lblURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblURL.Location = new System.Drawing.Point(667, 12);
            this.lblURL.Name = "lblURL";
            this.lblURL.Size = new System.Drawing.Size(54, 25);
            this.lblURL.TabIndex = 8;
            this.lblURL.Text = "URL";
            // 
            // FavouritesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblURL);
            this.Controls.Add(this.lblFavName);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
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
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblFavName;
        private System.Windows.Forms.Label lblURL;
    }
}