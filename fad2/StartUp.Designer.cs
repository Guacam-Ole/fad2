namespace fad2.UI
{
    partial class StartUp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ConnectionPanel = new MetroFramework.Controls.MetroPanel();
            this.FileExplorer = new MetroFramework.Controls.MetroTile();
            this.AutoDownload = new MetroFramework.Controls.MetroTile();
            this.ConnectionHelp = new MetroFramework.Controls.MetroLabel();
            this.ConnectionTile = new MetroFramework.Controls.MetroTile();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.BackPicture = new System.Windows.Forms.PictureBox();
            this.ConnectionPanel.SuspendLayout();
            this.ConnectionTile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // ConnectionPanel
            // 
            this.ConnectionPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectionPanel.Controls.Add(this.FileExplorer);
            this.ConnectionPanel.Controls.Add(this.AutoDownload);
            this.ConnectionPanel.Controls.Add(this.ConnectionHelp);
            this.ConnectionPanel.Controls.Add(this.ConnectionTile);
            this.ConnectionPanel.HorizontalScrollbarBarColor = true;
            this.ConnectionPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ConnectionPanel.HorizontalScrollbarSize = 10;
            this.ConnectionPanel.Location = new System.Drawing.Point(57, 28);
            this.ConnectionPanel.Name = "ConnectionPanel";
            this.ConnectionPanel.Size = new System.Drawing.Size(333, 274);
            this.ConnectionPanel.TabIndex = 5;
            this.ConnectionPanel.VerticalScrollbarBarColor = true;
            this.ConnectionPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ConnectionPanel.VerticalScrollbarSize = 10;
            // 
            // FileExplorer
            // 
            this.FileExplorer.ActiveControl = null;
            this.FileExplorer.Location = new System.Drawing.Point(184, 127);
            this.FileExplorer.Name = "FileExplorer";
            this.FileExplorer.Size = new System.Drawing.Size(143, 144);
            this.FileExplorer.TabIndex = 7;
            this.FileExplorer.Text = "File Explorer";
            this.FileExplorer.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.FileExplorer.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.FileExplorer.UseSelectable = true;
            this.FileExplorer.Visible = false;
            this.FileExplorer.Click += new System.EventHandler(this.FileExplorer_Click);
            // 
            // AutoDownload
            // 
            this.AutoDownload.ActiveControl = null;
            this.AutoDownload.Location = new System.Drawing.Point(3, 127);
            this.AutoDownload.Name = "AutoDownload";
            this.AutoDownload.Size = new System.Drawing.Size(143, 144);
            this.AutoDownload.TabIndex = 6;
            this.AutoDownload.Text = "Auto Mode";
            this.AutoDownload.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.AutoDownload.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.AutoDownload.UseSelectable = true;
            this.AutoDownload.Visible = false;
            this.AutoDownload.Click += new System.EventHandler(this.AutoDownload_Click);
            // 
            // ConnectionHelp
            // 
            this.ConnectionHelp.AutoSize = true;
            this.ConnectionHelp.Location = new System.Drawing.Point(3, 91);
            this.ConnectionHelp.Name = "ConnectionHelp";
            this.ConnectionHelp.Size = new System.Drawing.Size(324, 19);
            this.ConnectionHelp.TabIndex = 5;
            this.ConnectionHelp.Text = "Check the Help if you cannot Connect to your FlashAir";
            this.ConnectionHelp.Visible = false;
            // 
            // ConnectionTile
            // 
            this.ConnectionTile.ActiveControl = null;
            this.ConnectionTile.Controls.Add(this.metroProgressSpinner1);
            this.ConnectionTile.Location = new System.Drawing.Point(3, 3);
            this.ConnectionTile.Name = "ConnectionTile";
            this.ConnectionTile.Size = new System.Drawing.Size(324, 73);
            this.ConnectionTile.TabIndex = 4;
            this.ConnectionTile.Text = "Connecting...";
            this.ConnectionTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            this.ConnectionTile.UseSelectable = true;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(138, 17);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(56, 30);
            this.metroProgressSpinner1.TabIndex = 6;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // BackPicture
            // 
            this.BackPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BackPicture.BackColor = System.Drawing.Color.Transparent;
            this.BackPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackPicture.Location = new System.Drawing.Point(3, 3);
            this.BackPicture.Name = "BackPicture";
            this.BackPicture.Size = new System.Drawing.Size(434, 325);
            this.BackPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BackPicture.TabIndex = 4;
            this.BackPicture.TabStop = false;
            // 
            // StartUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ConnectionPanel);
            this.Controls.Add(this.BackPicture);
            this.Name = "StartUp";
            this.Size = new System.Drawing.Size(440, 331);
            this.Load += new System.EventHandler(this.StartUp_Load);
            this.Resize += new System.EventHandler(this.StartUp_Resize);
            this.ConnectionPanel.ResumeLayout(false);
            this.ConnectionPanel.PerformLayout();
            this.ConnectionTile.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel ConnectionPanel;
        private MetroFramework.Controls.MetroLabel ConnectionHelp;
        private MetroFramework.Controls.MetroTile ConnectionTile;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.PictureBox BackPicture;
        private MetroFramework.Controls.MetroTile FileExplorer;
        private MetroFramework.Controls.MetroTile AutoDownload;
    }
}
