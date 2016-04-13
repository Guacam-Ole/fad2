namespace fad2.UI
{
    partial class Fad
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cardSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fADSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apiDocumentationforDevelopersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BackPicture = new System.Windows.Forms.PictureBox();
            this.ConnectionPanel = new MetroFramework.Controls.MetroPanel();
            this.ConnectionHelp = new MetroFramework.Controls.MetroLabel();
            this.ConnectionTile = new MetroFramework.Controls.MetroTile();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.CardSettingsGeneral = new MetroFramework.Controls.MetroTabPage();
            this.CardSettingsNetwork = new MetroFramework.Controls.MetroTabPage();
            this.CardSettingsFeatures = new MetroFramework.Controls.MetroTabPage();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.SaveSettings = new MetroFramework.Controls.MetroButton();
            this.SetVersion = new fad2.UI.SettingsString();
            this.SetVendor = new fad2.UI.SettingsString();
            this.SetUpDir = new fad2.UI.SettingsString();
            this.SetTimeZone = new fad2.UI.SettingsString();
            this.SetProdcutCode = new fad2.UI.SettingsString();
            this.SetAppInfo = new fad2.UI.SettingsString();
            this.SetCardId = new fad2.UI.SettingsString();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).BeginInit();
            this.ConnectionPanel.SuspendLayout();
            this.ConnectionTile.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.metroTabControl1.SuspendLayout();
            this.CardSettingsGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolStripMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1148, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cardSettingsToolStripMenuItem,
            this.fADSettingsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // cardSettingsToolStripMenuItem
            // 
            this.cardSettingsToolStripMenuItem.Name = "cardSettingsToolStripMenuItem";
            this.cardSettingsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cardSettingsToolStripMenuItem.Text = "Card Settings";
            // 
            // fADSettingsToolStripMenuItem
            // 
            this.fADSettingsToolStripMenuItem.Name = "fADSettingsToolStripMenuItem";
            this.fADSettingsToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.fADSettingsToolStripMenuItem.Text = "FAD Settings";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(113, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.apiDocumentationforDevelopersToolStripMenuItem,
            this.toolStripMenuItem3,
            this.aboutToolStripMenuItem,
            this.licenseToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem2.Text = "Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // apiDocumentationforDevelopersToolStripMenuItem
            // 
            this.apiDocumentationforDevelopersToolStripMenuItem.Name = "apiDocumentationforDevelopersToolStripMenuItem";
            this.apiDocumentationforDevelopersToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.apiDocumentationforDevelopersToolStripMenuItem.Text = "Api Documentation (for Developers)";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(262, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Size = new System.Drawing.Size(265, 22);
            this.licenseToolStripMenuItem.Text = "License";
            // 
            // BackPicture
            // 
            this.BackPicture.BackColor = System.Drawing.Color.Transparent;
            this.BackPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BackPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackPicture.Location = new System.Drawing.Point(20, 84);
            this.BackPicture.Name = "BackPicture";
            this.BackPicture.Size = new System.Drawing.Size(1148, 512);
            this.BackPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BackPicture.TabIndex = 1;
            this.BackPicture.TabStop = false;
            // 
            // ConnectionPanel
            // 
            this.ConnectionPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectionPanel.Controls.Add(this.ConnectionHelp);
            this.ConnectionPanel.Controls.Add(this.ConnectionTile);
            this.ConnectionPanel.HorizontalScrollbarBarColor = true;
            this.ConnectionPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.ConnectionPanel.HorizontalScrollbarSize = 10;
            this.ConnectionPanel.Location = new System.Drawing.Point(421, 261);
            this.ConnectionPanel.Name = "ConnectionPanel";
            this.ConnectionPanel.Size = new System.Drawing.Size(333, 131);
            this.ConnectionPanel.TabIndex = 3;
            this.ConnectionPanel.VerticalScrollbarBarColor = true;
            this.ConnectionPanel.VerticalScrollbarHighlightOnWheel = false;
            this.ConnectionPanel.VerticalScrollbarSize = 10;
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
            this.ConnectionTile.Controls.Add(this.metroProgressSpinner1);
            this.ConnectionTile.Location = new System.Drawing.Point(3, 3);
            this.ConnectionTile.Name = "ConnectionTile";
            this.ConnectionTile.Size = new System.Drawing.Size(324, 73);
            this.ConnectionTile.TabIndex = 4;
            this.ConnectionTile.Text = "Connecting...";
            this.ConnectionTile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(138, 17);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(56, 30);
            this.metroProgressSpinner1.TabIndex = 6;
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.Controls.Add(this.SaveSettings);
            this.metroPanel1.Controls.Add(this.metroLabel1);
            this.metroPanel1.Controls.Add(this.metroButton2);
            this.metroPanel1.Controls.Add(this.metroButton1);
            this.metroPanel1.Controls.Add(this.metroTabControl1);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(23, 87);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(1142, 506);
            this.metroPanel1.TabIndex = 4;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(4, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(110, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Settings Location:";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(3, 126);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(119, 23);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Use Network";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(3, 97);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(119, 23);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Use Local SDCard";
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.CardSettingsGeneral);
            this.metroTabControl1.Controls.Add(this.CardSettingsNetwork);
            this.metroTabControl1.Controls.Add(this.CardSettingsFeatures);
            this.metroTabControl1.Location = new System.Drawing.Point(172, 3);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 0;
            this.metroTabControl1.Size = new System.Drawing.Size(868, 500);
            this.metroTabControl1.TabIndex = 2;
            // 
            // CardSettingsGeneral
            // 
            this.CardSettingsGeneral.Controls.Add(this.SetVersion);
            this.CardSettingsGeneral.Controls.Add(this.SetVendor);
            this.CardSettingsGeneral.Controls.Add(this.SetUpDir);
            this.CardSettingsGeneral.Controls.Add(this.SetTimeZone);
            this.CardSettingsGeneral.Controls.Add(this.SetProdcutCode);
            this.CardSettingsGeneral.Controls.Add(this.SetAppInfo);
            this.CardSettingsGeneral.Controls.Add(this.SetCardId);
            this.CardSettingsGeneral.HorizontalScrollbarBarColor = true;
            this.CardSettingsGeneral.Location = new System.Drawing.Point(4, 35);
            this.CardSettingsGeneral.Name = "CardSettingsGeneral";
            this.CardSettingsGeneral.Size = new System.Drawing.Size(860, 461);
            this.CardSettingsGeneral.TabIndex = 0;
            this.CardSettingsGeneral.Text = "General Settings";
            this.CardSettingsGeneral.VerticalScrollbarBarColor = true;
            // 
            // CardSettingsNetwork
            // 
            this.CardSettingsNetwork.HorizontalScrollbarBarColor = true;
            this.CardSettingsNetwork.Location = new System.Drawing.Point(4, 35);
            this.CardSettingsNetwork.Name = "CardSettingsNetwork";
            this.CardSettingsNetwork.Size = new System.Drawing.Size(962, 461);
            this.CardSettingsNetwork.TabIndex = 1;
            this.CardSettingsNetwork.Text = "Network Settings";
            this.CardSettingsNetwork.VerticalScrollbarBarColor = true;
            // 
            // CardSettingsFeatures
            // 
            this.CardSettingsFeatures.HorizontalScrollbarBarColor = true;
            this.CardSettingsFeatures.Location = new System.Drawing.Point(4, 35);
            this.CardSettingsFeatures.Name = "CardSettingsFeatures";
            this.CardSettingsFeatures.Size = new System.Drawing.Size(962, 461);
            this.CardSettingsFeatures.TabIndex = 2;
            this.CardSettingsFeatures.Text = "Card Features";
            this.CardSettingsFeatures.VerticalScrollbarBarColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // SaveSettings
            // 
            this.SaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveSettings.Location = new System.Drawing.Point(1046, 54);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(75, 23);
            this.SaveSettings.TabIndex = 13;
            this.SaveSettings.Text = "Save";
            // 
            // SetVersion
            // 
            this.SetVersion.Enabled = false;
            this.SetVersion.Key = "Firmware Version";
            this.SetVersion.Location = new System.Drawing.Point(-4, 274);
            this.SetVersion.Name = "SetVersion";
            this.SetVersion.RequiredVersion = "1.00.00";
            this.SetVersion.Size = new System.Drawing.Size(765, 37);
            this.SetVersion.TabIndex = 12;
            this.SetVersion.ToolTip = "";
            this.SetVersion.Value = "";
            this.SetVersion.Warning = "";
            // 
            // SetVendor
            // 
            this.SetVendor.Key = "Vendor";
            this.SetVendor.Location = new System.Drawing.Point(-4, 231);
            this.SetVendor.Name = "SetVendor";
            this.SetVendor.RequiredVersion = "1.00.00";
            this.SetVendor.Size = new System.Drawing.Size(765, 37);
            this.SetVendor.TabIndex = 11;
            this.SetVendor.ToolTip = "";
            this.SetVendor.Value = "";
            this.SetVendor.Warning = "";
            // 
            // SetUpDir
            // 
            this.SetUpDir.Key = "Upload Directory";
            this.SetUpDir.Location = new System.Drawing.Point(-4, 188);
            this.SetUpDir.Name = "SetUpDir";
            this.SetUpDir.RequiredVersion = "2.00.03";
            this.SetUpDir.Size = new System.Drawing.Size(765, 37);
            this.SetUpDir.TabIndex = 10;
            this.SetUpDir.ToolTip = "e.g. \"/DCIM\"";
            this.SetUpDir.Value = "";
            this.SetUpDir.Warning = "";
            // 
            // SetTimeZone
            // 
            this.SetTimeZone.Key = "Timezone";
            this.SetTimeZone.Location = new System.Drawing.Point(-4, 145);
            this.SetTimeZone.Name = "SetTimeZone";
            this.SetTimeZone.RequiredVersion = "3.00.00";
            this.SetTimeZone.Size = new System.Drawing.Size(765, 37);
            this.SetTimeZone.TabIndex = 9;
            this.SetTimeZone.ToolTip = "0=UTC";
            this.SetTimeZone.Value = "";
            this.SetTimeZone.Warning = "Check the help how to calculate the correct timezone";
            // 
            // SetProdcutCode
            // 
            this.SetProdcutCode.Key = "Product Code";
            this.SetProdcutCode.Location = new System.Drawing.Point(-4, 102);
            this.SetProdcutCode.Name = "SetProdcutCode";
            this.SetProdcutCode.RequiredVersion = "1.00.00";
            this.SetProdcutCode.Size = new System.Drawing.Size(765, 37);
            this.SetProdcutCode.TabIndex = 8;
            this.SetProdcutCode.ToolTip = "Product Code";
            this.SetProdcutCode.Value = "";
            this.SetProdcutCode.Warning = null;
            // 
            // SetAppInfo
            // 
            this.SetAppInfo.Key = "App-Info";
            this.SetAppInfo.Location = new System.Drawing.Point(-4, 16);
            this.SetAppInfo.Name = "SetAppInfo";
            this.SetAppInfo.RequiredVersion = "1.00.00";
            this.SetAppInfo.Size = new System.Drawing.Size(765, 37);
            this.SetAppInfo.TabIndex = 7;
            this.SetAppInfo.ToolTip = "Applications Unique Information";
            this.SetAppInfo.Value = "";
            this.SetAppInfo.Warning = null;
            // 
            // SetCardId
            // 
            this.SetCardId.Key = "Card Id";
            this.SetCardId.Location = new System.Drawing.Point(-4, 59);
            this.SetCardId.Name = "SetCardId";
            this.SetCardId.RequiredVersion = "1.00.00";
            this.SetCardId.Size = new System.Drawing.Size(765, 37);
            this.SetCardId.TabIndex = 6;
            this.SetCardId.ToolTip = "Card Id";
            this.SetCardId.Value = "";
            this.SetCardId.Warning = "Must be a hexadecimal Number  with 32 characters";
            // 
            // Fad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 616);
            this.Controls.Add(this.metroPanel1);
            this.Controls.Add(this.ConnectionPanel);
            this.Controls.Add(this.BackPicture);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(500, 350);
            this.Name = "Fad";
            this.Text = "FlashAirDownloader 2";
            this.Resize += new System.EventHandler(this.Fad_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BackPicture)).EndInit();
            this.ConnectionPanel.ResumeLayout(false);
            this.ConnectionPanel.PerformLayout();
            this.ConnectionTile.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroTabControl1.ResumeLayout(false);
            this.CardSettingsGeneral.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cardSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fADSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apiDocumentationforDevelopersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licenseToolStripMenuItem;
        private System.Windows.Forms.PictureBox BackPicture;
        private MetroFramework.Controls.MetroPanel ConnectionPanel;
        private MetroFramework.Controls.MetroTile ConnectionTile;
        private MetroFramework.Controls.MetroLabel ConnectionHelp;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroTabPage CardSettingsGeneral;
        private MetroFramework.Controls.MetroTabPage CardSettingsNetwork;
        private MetroFramework.Controls.MetroTabPage CardSettingsFeatures;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private SettingsString SetAppInfo;
        private SettingsString SetCardId;
        private SettingsString SetProdcutCode;
        private SettingsString SetVersion;
        private SettingsString SetVendor;
        private SettingsString SetUpDir;
        private SettingsString SetTimeZone;
        private MetroFramework.Controls.MetroButton SaveSettings;
    }
}

