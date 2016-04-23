using fad2.UI.UserControls;

namespace fad2.UI
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        ///     Clean up any resources being used.
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
            this.SettingsPanel = new MetroFramework.Controls.MetroPanel();
            this.SaveProgSettings = new MetroFramework.Controls.MetroButton();
            this.ProgSettingsLabel = new MetroFramework.Controls.MetroLabel();
            this.LoadTile = new MetroFramework.Controls.MetroTile();
            this.LoadSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.RightPanel = new MetroFramework.Controls.MetroPanel();
            this.SaveSettings = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.LoadFromFile = new MetroFramework.Controls.MetroButton();
            this.CardSettingsTab = new MetroFramework.Controls.MetroTabControl();
            this.ApplicationSettings = new MetroFramework.Controls.MetroTabPage();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.CustomDirHelp = new MetroFramework.Controls.MetroLink();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.CardSettingsDisable = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.CardSettingsVendor = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.DontDoAnythingStupid = new MetroFramework.Controls.MetroLabel();
            this.CardSettingsNetwork = new MetroFramework.Controls.MetroTabPage();
            this.Backgroundlocation = new fad2.UI.UserControls.SettingsFile();
            this.ShowTiles = new fad2.UI.UserControls.SettingsBoolean();
            this.ShowBackimages = new fad2.UI.UserControls.SettingsBoolean();
            this.BackgroundInterval = new fad2.UI.UserControls.SettingsTimeSlider();
            this.LoadThumbs = new fad2.UI.UserControls.SettingsBoolean();
            this.StartupPath = new fad2.UI.UserControls.SettingsString();
            this.FiletypesToCopy = new fad2.UI.UserControls.SettingsCombo();
            this.DeleteFiles = new fad2.UI.UserControls.SettingsBoolean();
            this.ServiceInterval = new fad2.UI.UserControls.SettingsTimeSlider();
            this.ServiceActions = new fad2.UI.UserControls.SettingsComboButton();
            this.CurrentServiceStatus = new fad2.UI.UserControls.SettingsLabel();
            this.FilesExist = new fad2.UI.UserControls.SettingsCombo();
            this.PathPreview = new fad2.UI.UserControls.SettingsLabel();
            this.CustomFolderCreation = new fad2.UI.UserControls.SettingsString();
            this.DateCreation = new fad2.UI.UserControls.SettingsCombo();
            this.MultiCards = new fad2.UI.UserControls.SettingsCombo();
            this.LocalPath = new fad2.UI.UserControls.SettingsFile();
            this.ApplicationUrl = new fad2.UI.UserControls.SettingsString();
            this.DisableUploads = new fad2.UI.UserControls.SettingsBoolean();
            this.DisableThumbnails = new fad2.UI.UserControls.SettingsBoolean();
            this.DisableCommand = new fad2.UI.UserControls.SettingsBoolean();
            this.DisableDownload = new fad2.UI.UserControls.SettingsBoolean();
            this.VendorWebDav = new fad2.UI.UserControls.SettingsCombo();
            this.VendorFirmware = new fad2.UI.UserControls.SettingsString();
            this.VendorCode = new fad2.UI.UserControls.SettingsString();
            this.VendorUploadEnabled = new fad2.UI.UserControls.SettingsBoolean();
            this.VendorUploadDir = new fad2.UI.UserControls.SettingsString();
            this.VendorTimezone = new fad2.UI.UserControls.SettingsSlider();
            this.VendorStaRetry = new fad2.UI.UserControls.SettingsSlider();
            this.VendorProductCode = new fad2.UI.UserControls.SettingsString();
            this.VendorNoiseCancel = new fad2.UI.UserControls.SettingsBoolean();
            this.VendorMasterCode = new fad2.UI.UserControls.SettingsString();
            this.VendorLuaWrite = new fad2.UI.UserControls.SettingsString();
            this.VendorLuaPathBoot = new fad2.UI.UserControls.SettingsString();
            this.VendorLock = new fad2.UI.UserControls.SettingsBoolean();
            this.VendorIfMode = new fad2.UI.UserControls.SettingsBoolean();
            this.VendorDns = new fad2.UI.UserControls.SettingsCombo();
            this.VendorBootScreenPath = new fad2.UI.UserControls.SettingsString();
            this.VendorAppMode = new fad2.UI.UserControls.SettingsCombo();
            this.VendorAppAutoTime = new fad2.UI.UserControls.SettingsTimeSlider();
            this.VendorCid = new fad2.UI.UserControls.SettingsString();
            this.VendorSSID = new fad2.UI.UserControls.SettingsString();
            this.VendorNetworkKey = new fad2.UI.UserControls.SettingsString();
            this.VendorAppname = new fad2.UI.UserControls.SettingsString();
            this.VendorAppInfo = new fad2.UI.UserControls.SettingsString();
            this.WlansdProxyPort = new fad2.UI.UserControls.SettingsString();
            this.Wlansd_ProxyServer = new fad2.UI.UserControls.SettingsString();
            this.WlansdUseProxy = new fad2.UI.UserControls.SettingsBoolean();
            this.WlansdDnsAlternate = new fad2.UI.UserControls.SettingsIp();
            this.WlansdDns = new fad2.UI.UserControls.SettingsIp();
            this.WlansdGateway = new fad2.UI.UserControls.SettingsIp();
            this.WlansdSubnet = new fad2.UI.UserControls.SettingsIp();
            this.WlansdIpAddress = new fad2.UI.UserControls.SettingsIp();
            this.WlansdDhcp = new fad2.UI.UserControls.SettingsBoolean();
            this.WlansdId = new fad2.UI.UserControls.SettingsString();
            this.SettingsPanel.SuspendLayout();
            this.LoadTile.SuspendLayout();
            this.CardSettingsTab.SuspendLayout();
            this.ApplicationSettings.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            this.CardSettingsDisable.SuspendLayout();
            this.CardSettingsVendor.SuspendLayout();
            this.CardSettingsNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsPanel.Controls.Add(this.SaveProgSettings);
            this.SettingsPanel.Controls.Add(this.ProgSettingsLabel);
            this.SettingsPanel.Controls.Add(this.LoadTile);
            this.SettingsPanel.Controls.Add(this.RightPanel);
            this.SettingsPanel.Controls.Add(this.SaveSettings);
            this.SettingsPanel.Controls.Add(this.metroLabel1);
            this.SettingsPanel.Controls.Add(this.LoadFromFile);
            this.SettingsPanel.Controls.Add(this.CardSettingsTab);
            this.SettingsPanel.HorizontalScrollbarBarColor = true;
            this.SettingsPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.SettingsPanel.HorizontalScrollbarSize = 10;
            this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(1200, 636);
            this.SettingsPanel.TabIndex = 5;
            this.SettingsPanel.VerticalScrollbarBarColor = true;
            this.SettingsPanel.VerticalScrollbarHighlightOnWheel = false;
            this.SettingsPanel.VerticalScrollbarSize = 10;
            this.SettingsPanel.Resize += new System.EventHandler(this.SettingsPanel_Resize);
            // 
            // SaveProgSettings
            // 
            this.SaveProgSettings.Location = new System.Drawing.Point(20, 369);
            this.SaveProgSettings.Name = "SaveProgSettings";
            this.SaveProgSettings.Size = new System.Drawing.Size(119, 23);
            this.SaveProgSettings.TabIndex = 17;
            this.SaveProgSettings.Text = "Save";
            this.SaveProgSettings.UseSelectable = true;
            this.SaveProgSettings.Click += new System.EventHandler(this.SaveProgSettings_Click);
            // 
            // ProgSettingsLabel
            // 
            this.ProgSettingsLabel.AutoSize = true;
            this.ProgSettingsLabel.Location = new System.Drawing.Point(36, 347);
            this.ProgSettingsLabel.Name = "ProgSettingsLabel";
            this.ProgSettingsLabel.Size = new System.Drawing.Size(90, 19);
            this.ProgSettingsLabel.TabIndex = 16;
            this.ProgSettingsLabel.Text = "Card Settings:";
            // 
            // LoadTile
            // 
            this.LoadTile.ActiveControl = null;
            this.LoadTile.Controls.Add(this.LoadSpinner);
            this.LoadTile.Location = new System.Drawing.Point(17, 155);
            this.LoadTile.Name = "LoadTile";
            this.LoadTile.Size = new System.Drawing.Size(119, 110);
            this.LoadTile.TabIndex = 15;
            this.LoadTile.Text = "Loading....";
            this.LoadTile.UseSelectable = true;
            this.LoadTile.Visible = false;
            // 
            // LoadSpinner
            // 
            this.LoadSpinner.Location = new System.Drawing.Point(3, 3);
            this.LoadSpinner.Maximum = 100;
            this.LoadSpinner.Name = "LoadSpinner";
            this.LoadSpinner.Size = new System.Drawing.Size(116, 88);
            this.LoadSpinner.TabIndex = 0;
            this.LoadSpinner.UseSelectable = true;
            // 
            // RightPanel
            // 
            this.RightPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RightPanel.HorizontalScrollbarBarColor = true;
            this.RightPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.RightPanel.HorizontalScrollbarSize = 10;
            this.RightPanel.Location = new System.Drawing.Point(1013, 38);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(184, 563);
            this.RightPanel.TabIndex = 14;
            this.RightPanel.VerticalScrollbarBarColor = true;
            this.RightPanel.VerticalScrollbarHighlightOnWheel = false;
            this.RightPanel.VerticalScrollbarSize = 10;
            // 
            // SaveSettings
            // 
            this.SaveSettings.Enabled = false;
            this.SaveSettings.Location = new System.Drawing.Point(17, 126);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(119, 23);
            this.SaveSettings.TabIndex = 13;
            this.SaveSettings.Text = "Save";
            this.SaveSettings.UseSelectable = true;
            this.SaveSettings.Click += new System.EventHandler(this.SaveSettings_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(33, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(90, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Card Settings:";
            // 
            // LoadFromFile
            // 
            this.LoadFromFile.Location = new System.Drawing.Point(17, 97);
            this.LoadFromFile.Name = "LoadFromFile";
            this.LoadFromFile.Size = new System.Drawing.Size(119, 23);
            this.LoadFromFile.TabIndex = 3;
            this.LoadFromFile.Text = "Load";
            this.LoadFromFile.UseSelectable = true;
            this.LoadFromFile.Click += new System.EventHandler(this.LoadFromFile_Click);
            // 
            // CardSettingsTab
            // 
            this.CardSettingsTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CardSettingsTab.Controls.Add(this.ApplicationSettings);
            this.CardSettingsTab.Controls.Add(this.CardSettingsDisable);
            this.CardSettingsTab.Controls.Add(this.CardSettingsVendor);
            this.CardSettingsTab.Controls.Add(this.CardSettingsNetwork);
            this.CardSettingsTab.Location = new System.Drawing.Point(173, 3);
            this.CardSettingsTab.Name = "CardSettingsTab";
            this.CardSettingsTab.SelectedIndex = 0;
            this.CardSettingsTab.Size = new System.Drawing.Size(834, 598);
            this.CardSettingsTab.TabIndex = 2;
            this.CardSettingsTab.UseSelectable = true;
            // 
            // ApplicationSettings
            // 
            this.ApplicationSettings.AutoScroll = true;
            this.ApplicationSettings.Controls.Add(this.metroPanel3);
            this.ApplicationSettings.Controls.Add(this.LoadThumbs);
            this.ApplicationSettings.Controls.Add(this.StartupPath);
            this.ApplicationSettings.Controls.Add(this.FiletypesToCopy);
            this.ApplicationSettings.Controls.Add(this.DeleteFiles);
            this.ApplicationSettings.Controls.Add(this.metroPanel2);
            this.ApplicationSettings.Controls.Add(this.FilesExist);
            this.ApplicationSettings.Controls.Add(this.metroPanel1);
            this.ApplicationSettings.Controls.Add(this.LocalPath);
            this.ApplicationSettings.Controls.Add(this.ApplicationUrl);
            this.ApplicationSettings.HorizontalScrollbar = true;
            this.ApplicationSettings.HorizontalScrollbarBarColor = true;
            this.ApplicationSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.ApplicationSettings.HorizontalScrollbarSize = 10;
            this.ApplicationSettings.Location = new System.Drawing.Point(4, 38);
            this.ApplicationSettings.Name = "ApplicationSettings";
            this.ApplicationSettings.Size = new System.Drawing.Size(826, 556);
            this.ApplicationSettings.TabIndex = 2;
            this.ApplicationSettings.Text = "Application Settings";
            this.ApplicationSettings.VerticalScrollbar = true;
            this.ApplicationSettings.VerticalScrollbarBarColor = true;
            this.ApplicationSettings.VerticalScrollbarHighlightOnWheel = false;
            this.ApplicationSettings.VerticalScrollbarSize = 10;
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.Backgroundlocation);
            this.metroPanel3.Controls.Add(this.ShowTiles);
            this.metroPanel3.Controls.Add(this.ShowBackimages);
            this.metroPanel3.Controls.Add(this.BackgroundInterval);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(4, 542);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(792, 203);
            this.metroPanel3.TabIndex = 26;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(7, -5);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(47, 19);
            this.metroLabel4.TabIndex = 14;
            this.metroLabel4.Text = "Styling";
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.ServiceInterval);
            this.metroPanel2.Controls.Add(this.ServiceActions);
            this.metroPanel2.Controls.Add(this.CurrentServiceStatus);
            this.metroPanel2.Controls.Add(this.metroLabel5);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(3, 765);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(793, 192);
            this.metroPanel2.TabIndex = 21;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(8, 0);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(86, 19);
            this.metroLabel5.TabIndex = 14;
            this.metroLabel5.Text = "Fad2 Service:";
            // 
            // metroPanel1
            // 
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.PathPreview);
            this.metroPanel1.Controls.Add(this.CustomDirHelp);
            this.metroPanel1.Controls.Add(this.CustomFolderCreation);
            this.metroPanel1.Controls.Add(this.DateCreation);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.MultiCards);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 311);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(793, 213);
            this.metroPanel1.TabIndex = 12;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // CustomDirHelp
            // 
            this.CustomDirHelp.Location = new System.Drawing.Point(632, 137);
            this.CustomDirHelp.Name = "CustomDirHelp";
            this.CustomDirHelp.Size = new System.Drawing.Size(75, 23);
            this.CustomDirHelp.TabIndex = 19;
            this.CustomDirHelp.Text = "Help";
            this.CustomDirHelp.UseSelectable = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(8, -3);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(162, 19);
            this.metroLabel3.TabIndex = 13;
            this.metroLabel3.Text = "Automatic folder creation:";
            // 
            // CardSettingsDisable
            // 
            this.CardSettingsDisable.Controls.Add(this.metroLabel6);
            this.CardSettingsDisable.Controls.Add(this.DisableUploads);
            this.CardSettingsDisable.Controls.Add(this.DisableThumbnails);
            this.CardSettingsDisable.Controls.Add(this.DisableCommand);
            this.CardSettingsDisable.Controls.Add(this.DisableDownload);
            this.CardSettingsDisable.HorizontalScrollbarBarColor = true;
            this.CardSettingsDisable.HorizontalScrollbarHighlightOnWheel = false;
            this.CardSettingsDisable.HorizontalScrollbarSize = 10;
            this.CardSettingsDisable.Location = new System.Drawing.Point(4, 38);
            this.CardSettingsDisable.Name = "CardSettingsDisable";
            this.CardSettingsDisable.Size = new System.Drawing.Size(826, 556);
            this.CardSettingsDisable.TabIndex = 3;
            this.CardSettingsDisable.Text = "Disable Functions";
            this.CardSettingsDisable.VerticalScrollbarBarColor = true;
            this.CardSettingsDisable.VerticalScrollbarHighlightOnWheel = false;
            this.CardSettingsDisable.VerticalScrollbarSize = 10;
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(3, 16);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(464, 19);
            this.metroLabel6.TabIndex = 33;
            this.metroLabel6.Text = "For security reasons you can disable single functions over WiFi for the FlashAir." +
    "";
            // 
            // CardSettingsVendor
            // 
            this.CardSettingsVendor.AutoScroll = true;
            this.CardSettingsVendor.Controls.Add(this.metroLabel2);
            this.CardSettingsVendor.Controls.Add(this.DontDoAnythingStupid);
            this.CardSettingsVendor.Controls.Add(this.VendorWebDav);
            this.CardSettingsVendor.Controls.Add(this.VendorFirmware);
            this.CardSettingsVendor.Controls.Add(this.VendorCode);
            this.CardSettingsVendor.Controls.Add(this.VendorUploadEnabled);
            this.CardSettingsVendor.Controls.Add(this.VendorUploadDir);
            this.CardSettingsVendor.Controls.Add(this.VendorTimezone);
            this.CardSettingsVendor.Controls.Add(this.VendorStaRetry);
            this.CardSettingsVendor.Controls.Add(this.VendorProductCode);
            this.CardSettingsVendor.Controls.Add(this.VendorNoiseCancel);
            this.CardSettingsVendor.Controls.Add(this.VendorMasterCode);
            this.CardSettingsVendor.Controls.Add(this.VendorLuaWrite);
            this.CardSettingsVendor.Controls.Add(this.VendorLuaPathBoot);
            this.CardSettingsVendor.Controls.Add(this.VendorLock);
            this.CardSettingsVendor.Controls.Add(this.VendorIfMode);
            this.CardSettingsVendor.Controls.Add(this.VendorDns);
            this.CardSettingsVendor.Controls.Add(this.VendorBootScreenPath);
            this.CardSettingsVendor.Controls.Add(this.VendorAppMode);
            this.CardSettingsVendor.Controls.Add(this.VendorAppAutoTime);
            this.CardSettingsVendor.Controls.Add(this.VendorCid);
            this.CardSettingsVendor.Controls.Add(this.VendorSSID);
            this.CardSettingsVendor.Controls.Add(this.VendorNetworkKey);
            this.CardSettingsVendor.Controls.Add(this.VendorAppname);
            this.CardSettingsVendor.Controls.Add(this.VendorAppInfo);
            this.CardSettingsVendor.HorizontalScrollbar = true;
            this.CardSettingsVendor.HorizontalScrollbarBarColor = true;
            this.CardSettingsVendor.HorizontalScrollbarHighlightOnWheel = false;
            this.CardSettingsVendor.HorizontalScrollbarSize = 10;
            this.CardSettingsVendor.Location = new System.Drawing.Point(4, 38);
            this.CardSettingsVendor.Name = "CardSettingsVendor";
            this.CardSettingsVendor.Size = new System.Drawing.Size(826, 556);
            this.CardSettingsVendor.TabIndex = 0;
            this.CardSettingsVendor.Text = "Vendor";
            this.CardSettingsVendor.VerticalScrollbar = true;
            this.CardSettingsVendor.VerticalScrollbarBarColor = true;
            this.CardSettingsVendor.VerticalScrollbarHighlightOnWheel = false;
            this.CardSettingsVendor.VerticalScrollbarSize = 10;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(7, 30);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(510, 19);
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "Better check the documentation BEFORE you change a setting you do not understand." +
    "";
            // 
            // DontDoAnythingStupid
            // 
            this.DontDoAnythingStupid.AutoSize = true;
            this.DontDoAnythingStupid.Location = new System.Drawing.Point(7, 11);
            this.DontDoAnythingStupid.Name = "DontDoAnythingStupid";
            this.DontDoAnythingStupid.Size = new System.Drawing.Size(459, 19);
            this.DontDoAnythingStupid.TabIndex = 31;
            this.DontDoAnythingStupid.Text = "Please be aware that you can really screw up here if you enter wrong values.. ";
            // 
            // CardSettingsNetwork
            // 
            this.CardSettingsNetwork.Controls.Add(this.WlansdProxyPort);
            this.CardSettingsNetwork.Controls.Add(this.Wlansd_ProxyServer);
            this.CardSettingsNetwork.Controls.Add(this.WlansdUseProxy);
            this.CardSettingsNetwork.Controls.Add(this.WlansdDnsAlternate);
            this.CardSettingsNetwork.Controls.Add(this.WlansdDns);
            this.CardSettingsNetwork.Controls.Add(this.WlansdGateway);
            this.CardSettingsNetwork.Controls.Add(this.WlansdSubnet);
            this.CardSettingsNetwork.Controls.Add(this.WlansdIpAddress);
            this.CardSettingsNetwork.Controls.Add(this.WlansdDhcp);
            this.CardSettingsNetwork.Controls.Add(this.WlansdId);
            this.CardSettingsNetwork.HorizontalScrollbarBarColor = true;
            this.CardSettingsNetwork.HorizontalScrollbarHighlightOnWheel = false;
            this.CardSettingsNetwork.HorizontalScrollbarSize = 10;
            this.CardSettingsNetwork.Location = new System.Drawing.Point(4, 38);
            this.CardSettingsNetwork.Name = "CardSettingsNetwork";
            this.CardSettingsNetwork.Size = new System.Drawing.Size(826, 556);
            this.CardSettingsNetwork.TabIndex = 1;
            this.CardSettingsNetwork.Text = "WLANSD";
            this.CardSettingsNetwork.VerticalScrollbarBarColor = true;
            this.CardSettingsNetwork.VerticalScrollbarHighlightOnWheel = false;
            this.CardSettingsNetwork.VerticalScrollbarSize = 10;
            // 
            // Backgroundlocation
            // 
            this.Backgroundlocation.DirectoryOnly = true;
            this.Backgroundlocation.Filter = null;
            this.Backgroundlocation.InternalName = null;
            this.Backgroundlocation.Key = "Background images location";
            this.Backgroundlocation.Location = new System.Drawing.Point(7, 153);
            this.Backgroundlocation.MaxCharacters = 32767;
            this.Backgroundlocation.Name = "Backgroundlocation";
            this.Backgroundlocation.PasswordChar = '\0';
            this.Backgroundlocation.Regex = null;
            this.Backgroundlocation.Size = new System.Drawing.Size(765, 37);
            this.Backgroundlocation.TabIndex = 19;
            this.Backgroundlocation.ToolTip = null;
            this.Backgroundlocation.UseSelectable = true;
            this.Backgroundlocation.Value = "";
            // 
            // ShowTiles
            // 
            this.ShowTiles.InternalName = null;
            this.ShowTiles.Key = "Show Imagetiles (Settings)";
            this.ShowTiles.Location = new System.Drawing.Point(7, 67);
            this.ShowTiles.Name = "ShowTiles";
            this.ShowTiles.RequiredVersion = "";
            this.ShowTiles.Size = new System.Drawing.Size(765, 37);
            this.ShowTiles.TabIndex = 18;
            this.ShowTiles.ToolTip = null;
            this.ShowTiles.UseSelectable = true;
            this.ShowTiles.Value = false;
            this.ShowTiles.Warning = null;
            // 
            // ShowBackimages
            // 
            this.ShowBackimages.InternalName = null;
            this.ShowBackimages.Key = "Show background Images";
            this.ShowBackimages.Location = new System.Drawing.Point(7, 24);
            this.ShowBackimages.Name = "ShowBackimages";
            this.ShowBackimages.RequiredVersion = "";
            this.ShowBackimages.Size = new System.Drawing.Size(765, 37);
            this.ShowBackimages.TabIndex = 17;
            this.ShowBackimages.ToolTip = null;
            this.ShowBackimages.UseSelectable = true;
            this.ShowBackimages.Value = false;
            this.ShowBackimages.Warning = null;
            // 
            // BackgroundInterval
            // 
            this.BackgroundInterval.InternalName = null;
            this.BackgroundInterval.Key = "Image change interval";
            this.BackgroundInterval.Location = new System.Drawing.Point(7, 110);
            this.BackgroundInterval.Maximum = 60;
            this.BackgroundInterval.Minimum = 2;
            this.BackgroundInterval.Name = "BackgroundInterval";
            this.BackgroundInterval.RequiredVersion = "";
            this.BackgroundInterval.Size = new System.Drawing.Size(765, 37);
            this.BackgroundInterval.TabIndex = 16;
            this.BackgroundInterval.ToolTip = null;
            this.BackgroundInterval.UseSelectable = true;
            this.BackgroundInterval.Value = 50;
            this.BackgroundInterval.ValueType = fad2.UI.UserControls.SettingsTimeSlider.ValueTypes.Second;
            this.BackgroundInterval.Warning = null;
            // 
            // LoadThumbs
            // 
            this.LoadThumbs.InternalName = null;
            this.LoadThumbs.Key = "Load Thumbnails";
            this.LoadThumbs.Location = new System.Drawing.Point(3, 268);
            this.LoadThumbs.Name = "LoadThumbs";
            this.LoadThumbs.RequiredVersion = "";
            this.LoadThumbs.Size = new System.Drawing.Size(765, 37);
            this.LoadThumbs.TabIndex = 25;
            this.LoadThumbs.ToolTip = null;
            this.LoadThumbs.UseSelectable = true;
            this.LoadThumbs.Value = false;
            this.LoadThumbs.Warning = null;
            // 
            // StartupPath
            // 
            this.StartupPath.InternalName = null;
            this.StartupPath.Key = "Flashair Imagepath";
            this.StartupPath.Location = new System.Drawing.Point(3, 182);
            this.StartupPath.MaxCharacters = 32767;
            this.StartupPath.Name = "StartupPath";
            this.StartupPath.PasswordChar = '\0';
            this.StartupPath.Regex = null;
            this.StartupPath.RequiredVersion = "";
            this.StartupPath.Size = new System.Drawing.Size(765, 37);
            this.StartupPath.TabIndex = 24;
            this.StartupPath.ToolTip = null;
            this.StartupPath.UseSelectable = true;
            this.StartupPath.Value = "";
            this.StartupPath.Warning = null;
            // 
            // FiletypesToCopy
            // 
            this.FiletypesToCopy.DataSource = null;
            this.FiletypesToCopy.InternalName = null;
            this.FiletypesToCopy.Key = "Filetypes to copy:";
            this.FiletypesToCopy.Location = new System.Drawing.Point(3, 225);
            this.FiletypesToCopy.Name = "FiletypesToCopy";
            this.FiletypesToCopy.RequiredVersion = "";
            this.FiletypesToCopy.Size = new System.Drawing.Size(765, 37);
            this.FiletypesToCopy.TabIndex = 23;
            this.FiletypesToCopy.ToolTip = null;
            this.FiletypesToCopy.UseSelectable = true;
            this.FiletypesToCopy.Value = null;
            this.FiletypesToCopy.Warning = null;
            // 
            // DeleteFiles
            // 
            this.DeleteFiles.InternalName = null;
            this.DeleteFiles.Key = "Delete files after downloading:";
            this.DeleteFiles.Location = new System.Drawing.Point(3, 139);
            this.DeleteFiles.Name = "DeleteFiles";
            this.DeleteFiles.RequiredVersion = "";
            this.DeleteFiles.Size = new System.Drawing.Size(765, 37);
            this.DeleteFiles.TabIndex = 22;
            this.DeleteFiles.ToolTip = null;
            this.DeleteFiles.UseSelectable = true;
            this.DeleteFiles.Value = false;
            this.DeleteFiles.Warning = null;
            // 
            // ServiceInterval
            // 
            this.ServiceInterval.InternalName = null;
            this.ServiceInterval.Key = "Filecheck interval:";
            this.ServiceInterval.Location = new System.Drawing.Point(8, 108);
            this.ServiceInterval.Maximum = 300;
            this.ServiceInterval.Minimum = 10;
            this.ServiceInterval.Name = "ServiceInterval";
            this.ServiceInterval.RequiredVersion = "";
            this.ServiceInterval.Size = new System.Drawing.Size(765, 37);
            this.ServiceInterval.TabIndex = 17;
            this.ServiceInterval.ToolTip = null;
            this.ServiceInterval.UseSelectable = true;
            this.ServiceInterval.Value = 50;
            this.ServiceInterval.ValueType = fad2.UI.UserControls.SettingsTimeSlider.ValueTypes.Second;
            this.ServiceInterval.Warning = null;
            // 
            // ServiceActions
            // 
            this.ServiceActions.ButtonText = "GO";
            this.ServiceActions.DataSource = null;
            this.ServiceActions.InternalName = null;
            this.ServiceActions.Key = "Change Service:";
            this.ServiceActions.Location = new System.Drawing.Point(8, 65);
            this.ServiceActions.Name = "ServiceActions";
            this.ServiceActions.Size = new System.Drawing.Size(765, 37);
            this.ServiceActions.TabIndex = 16;
            this.ServiceActions.ToolTip = null;
            this.ServiceActions.UseSelectable = true;
            this.ServiceActions.Value = null;
            this.ServiceActions.Warning = null;
            // 
            // CurrentServiceStatus
            // 
            this.CurrentServiceStatus.InternalName = null;
            this.CurrentServiceStatus.Key = "Current Status:";
            this.CurrentServiceStatus.Location = new System.Drawing.Point(8, 22);
            this.CurrentServiceStatus.Name = "CurrentServiceStatus";
            this.CurrentServiceStatus.Regex = null;
            this.CurrentServiceStatus.RequiredVersion = "";
            this.CurrentServiceStatus.Size = new System.Drawing.Size(765, 37);
            this.CurrentServiceStatus.TabIndex = 15;
            this.CurrentServiceStatus.ToolTip = null;
            this.CurrentServiceStatus.UseSelectable = true;
            this.CurrentServiceStatus.Value = "Not Installed";
            this.CurrentServiceStatus.Warning = null;
            // 
            // FilesExist
            // 
            this.FilesExist.DataSource = null;
            this.FilesExist.InternalName = null;
            this.FilesExist.Key = "Existing Files:";
            this.FilesExist.Location = new System.Drawing.Point(3, 99);
            this.FilesExist.Name = "FilesExist";
            this.FilesExist.RequiredVersion = "";
            this.FilesExist.Size = new System.Drawing.Size(765, 37);
            this.FilesExist.TabIndex = 20;
            this.FilesExist.ToolTip = null;
            this.FilesExist.UseSelectable = true;
            this.FilesExist.Value = null;
            this.FilesExist.Warning = null;
            // 
            // PathPreview
            // 
            this.PathPreview.InternalName = null;
            this.PathPreview.Key = "Preview:";
            this.PathPreview.Location = new System.Drawing.Point(8, 173);
            this.PathPreview.Name = "PathPreview";
            this.PathPreview.Regex = null;
            this.PathPreview.RequiredVersion = "";
            this.PathPreview.Size = new System.Drawing.Size(765, 37);
            this.PathPreview.TabIndex = 20;
            this.PathPreview.ToolTip = null;
            this.PathPreview.UseSelectable = true;
            this.PathPreview.Value = "D:\\Images\\APPID\\2016-12-31\\Image.png";
            this.PathPreview.Warning = null;
            // 
            // CustomFolderCreation
            // 
            this.CustomFolderCreation.Enabled = false;
            this.CustomFolderCreation.InternalName = "ID";
            this.CustomFolderCreation.Key = "Custom:";
            this.CustomFolderCreation.Location = new System.Drawing.Point(3, 130);
            this.CustomFolderCreation.MaxCharacters = 16;
            this.CustomFolderCreation.Name = "CustomFolderCreation";
            this.CustomFolderCreation.PasswordChar = '\0';
            this.CustomFolderCreation.Regex = null;
            this.CustomFolderCreation.RequiredVersion = "";
            this.CustomFolderCreation.Size = new System.Drawing.Size(765, 37);
            this.CustomFolderCreation.TabIndex = 16;
            this.CustomFolderCreation.ToolTip = "";
            this.CustomFolderCreation.UseSelectable = true;
            this.CustomFolderCreation.Value = "";
            this.CustomFolderCreation.Warning = null;
            // 
            // DateCreation
            // 
            this.DateCreation.DataSource = null;
            this.DateCreation.InternalName = null;
            this.DateCreation.Key = "Create by date:";
            this.DateCreation.Location = new System.Drawing.Point(3, 87);
            this.DateCreation.Name = "DateCreation";
            this.DateCreation.RequiredVersion = "";
            this.DateCreation.Size = new System.Drawing.Size(765, 37);
            this.DateCreation.TabIndex = 15;
            this.DateCreation.ToolTip = null;
            this.DateCreation.UseSelectable = true;
            this.DateCreation.Value = null;
            this.DateCreation.Warning = null;
            this.DateCreation.ComboChanged += new System.EventHandler(this.DateCreation_ComboChanged);
            // 
            // MultiCards
            // 
            this.MultiCards.DataSource = null;
            this.MultiCards.InternalName = null;
            this.MultiCards.Key = "Multiple Cards:";
            this.MultiCards.Location = new System.Drawing.Point(3, 44);
            this.MultiCards.Name = "MultiCards";
            this.MultiCards.RequiredVersion = "";
            this.MultiCards.Size = new System.Drawing.Size(765, 37);
            this.MultiCards.TabIndex = 12;
            this.MultiCards.ToolTip = null;
            this.MultiCards.UseSelectable = true;
            this.MultiCards.Value = null;
            this.MultiCards.Warning = null;
            this.MultiCards.ComboChanged += new System.EventHandler(this.MultiCards_ComboChanged);
            // 
            // LocalPath
            // 
            this.LocalPath.DirectoryOnly = true;
            this.LocalPath.Filter = null;
            this.LocalPath.InternalName = null;
            this.LocalPath.Key = "Local path";
            this.LocalPath.Location = new System.Drawing.Point(3, 56);
            this.LocalPath.MaxCharacters = 32767;
            this.LocalPath.Name = "LocalPath";
            this.LocalPath.PasswordChar = '\0';
            this.LocalPath.Regex = null;
            this.LocalPath.Size = new System.Drawing.Size(765, 37);
            this.LocalPath.TabIndex = 10;
            this.LocalPath.ToolTip = null;
            this.LocalPath.UseSelectable = true;
            this.LocalPath.Value = "";
            // 
            // ApplicationUrl
            // 
            this.ApplicationUrl.InternalName = "ID";
            this.ApplicationUrl.Key = "FlashAir Url";
            this.ApplicationUrl.Location = new System.Drawing.Point(3, 13);
            this.ApplicationUrl.MaxCharacters = 16;
            this.ApplicationUrl.Name = "ApplicationUrl";
            this.ApplicationUrl.PasswordChar = '\0';
            this.ApplicationUrl.Regex = null;
            this.ApplicationUrl.RequiredVersion = "";
            this.ApplicationUrl.Size = new System.Drawing.Size(765, 37);
            this.ApplicationUrl.TabIndex = 9;
            this.ApplicationUrl.ToolTip = "";
            this.ApplicationUrl.UseSelectable = true;
            this.ApplicationUrl.Value = "http://flashair";
            this.ApplicationUrl.Warning = null;
            // 
            // DisableUploads
            // 
            this.DisableUploads.InternalName = null;
            this.DisableUploads.Key = "Disable Uploads";
            this.DisableUploads.Location = new System.Drawing.Point(3, 185);
            this.DisableUploads.Name = "DisableUploads";
            this.DisableUploads.RequiredVersion = "2.00.02";
            this.DisableUploads.Size = new System.Drawing.Size(765, 37);
            this.DisableUploads.TabIndex = 37;
            this.DisableUploads.ToolTip = null;
            this.DisableUploads.UseSelectable = true;
            this.DisableUploads.Value = false;
            this.DisableUploads.Warning = "Also disables Delete-Functioniality";
            // 
            // DisableThumbnails
            // 
            this.DisableThumbnails.InternalName = null;
            this.DisableThumbnails.Key = "Disable Thumbnails";
            this.DisableThumbnails.Location = new System.Drawing.Point(3, 142);
            this.DisableThumbnails.Name = "DisableThumbnails";
            this.DisableThumbnails.RequiredVersion = "2.00.02";
            this.DisableThumbnails.Size = new System.Drawing.Size(765, 37);
            this.DisableThumbnails.TabIndex = 36;
            this.DisableThumbnails.ToolTip = null;
            this.DisableThumbnails.UseSelectable = true;
            this.DisableThumbnails.Value = false;
            this.DisableThumbnails.Warning = "Makes this application a bit ugly...";
            // 
            // DisableCommand
            // 
            this.DisableCommand.InternalName = null;
            this.DisableCommand.Key = "Disable Commands";
            this.DisableCommand.Location = new System.Drawing.Point(3, 91);
            this.DisableCommand.Name = "DisableCommand";
            this.DisableCommand.RequiredVersion = "2.00.02";
            this.DisableCommand.Size = new System.Drawing.Size(765, 37);
            this.DisableCommand.TabIndex = 35;
            this.DisableCommand.Tag = "";
            this.DisableCommand.ToolTip = "These allow configurations without physical access to the card";
            this.DisableCommand.UseSelectable = true;
            this.DisableCommand.Value = false;
            this.DisableCommand.Warning = "";
            // 
            // DisableDownload
            // 
            this.DisableDownload.InternalName = null;
            this.DisableDownload.Key = "Disable Downloads";
            this.DisableDownload.Location = new System.Drawing.Point(3, 45);
            this.DisableDownload.Name = "DisableDownload";
            this.DisableDownload.RequiredVersion = "2.00.02";
            this.DisableDownload.Size = new System.Drawing.Size(765, 37);
            this.DisableDownload.TabIndex = 34;
            this.DisableDownload.ToolTip = null;
            this.DisableDownload.UseSelectable = true;
            this.DisableDownload.Value = false;
            this.DisableDownload.Warning = "Makes this program pretty useless (obviously)";
            // 
            // VendorWebDav
            // 
            this.VendorWebDav.DataSource = null;
            this.VendorWebDav.InternalName = "WEBDAV";
            this.VendorWebDav.Key = "WebDav";
            this.VendorWebDav.Location = new System.Drawing.Point(3, 1004);
            this.VendorWebDav.Name = "VendorWebDav";
            this.VendorWebDav.RequiredVersion = "3.00.00";
            this.VendorWebDav.Size = new System.Drawing.Size(765, 37);
            this.VendorWebDav.TabIndex = 30;
            this.VendorWebDav.ToolTip = null;
            this.VendorWebDav.UseSelectable = true;
            this.VendorWebDav.Value = null;
            this.VendorWebDav.Warning = "Upload must be enabled, too to allow writing";
            // 
            // VendorFirmware
            // 
            this.VendorFirmware.InternalName = "VERSION";
            this.VendorFirmware.Key = "Firmware version";
            this.VendorFirmware.Location = new System.Drawing.Point(3, 961);
            this.VendorFirmware.MaxCharacters = 32;
            this.VendorFirmware.Name = "VendorFirmware";
            this.VendorFirmware.PasswordChar = '\0';
            this.VendorFirmware.Regex = null;
            this.VendorFirmware.RequiredVersion = "1.00.00";
            this.VendorFirmware.Size = new System.Drawing.Size(765, 37);
            this.VendorFirmware.TabIndex = 29;
            this.VendorFirmware.ToolTip = "";
            this.VendorFirmware.UseSelectable = true;
            this.VendorFirmware.Value = "";
            this.VendorFirmware.Warning = "";
            // 
            // VendorCode
            // 
            this.VendorCode.InternalName = "VENDOR";
            this.VendorCode.Key = "Vendor code";
            this.VendorCode.Location = new System.Drawing.Point(3, 918);
            this.VendorCode.MaxCharacters = 32;
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.PasswordChar = '\0';
            this.VendorCode.Regex = null;
            this.VendorCode.RequiredVersion = "1.00.00";
            this.VendorCode.Size = new System.Drawing.Size(765, 37);
            this.VendorCode.TabIndex = 28;
            this.VendorCode.ToolTip = "";
            this.VendorCode.UseSelectable = true;
            this.VendorCode.Value = "";
            this.VendorCode.Warning = "";
            // 
            // VendorUploadEnabled
            // 
            this.VendorUploadEnabled.InternalName = "UPLOAD";
            this.VendorUploadEnabled.Key = "Upload Enabled";
            this.VendorUploadEnabled.Location = new System.Drawing.Point(3, 875);
            this.VendorUploadEnabled.Name = "VendorUploadEnabled";
            this.VendorUploadEnabled.RequiredVersion = "1.00.00";
            this.VendorUploadEnabled.Size = new System.Drawing.Size(765, 37);
            this.VendorUploadEnabled.TabIndex = 27;
            this.VendorUploadEnabled.ToolTip = "";
            this.VendorUploadEnabled.UseSelectable = true;
            this.VendorUploadEnabled.Value = false;
            this.VendorUploadEnabled.Warning = "MUST be enabled to allow writing of data or configuration";
            // 
            // VendorUploadDir
            // 
            this.VendorUploadDir.InternalName = "UPDIR";
            this.VendorUploadDir.Key = "Upload Directory";
            this.VendorUploadDir.Location = new System.Drawing.Point(3, 832);
            this.VendorUploadDir.MaxCharacters = 32;
            this.VendorUploadDir.Name = "VendorUploadDir";
            this.VendorUploadDir.PasswordChar = '\0';
            this.VendorUploadDir.Regex = null;
            this.VendorUploadDir.RequiredVersion = "2.00.03";
            this.VendorUploadDir.Size = new System.Drawing.Size(765, 37);
            this.VendorUploadDir.TabIndex = 26;
            this.VendorUploadDir.ToolTip = "";
            this.VendorUploadDir.UseSelectable = true;
            this.VendorUploadDir.Value = "";
            this.VendorUploadDir.Warning = "";
            // 
            // VendorTimezone
            // 
            this.VendorTimezone.InternalName = "TIMEZONE";
            this.VendorTimezone.Key = "Time Zone";
            this.VendorTimezone.Location = new System.Drawing.Point(3, 789);
            this.VendorTimezone.Maximum = 54;
            this.VendorTimezone.Minimum = -48;
            this.VendorTimezone.Name = "VendorTimezone";
            this.VendorTimezone.RequiredVersion = "3.00.00";
            this.VendorTimezone.Size = new System.Drawing.Size(765, 37);
            this.VendorTimezone.TabIndex = 25;
            this.VendorTimezone.ToolTip = "UTC = 0";
            this.VendorTimezone.UseSelectable = true;
            this.VendorTimezone.Value = 10;
            this.VendorTimezone.Warning = null;
            // 
            // VendorStaRetry
            // 
            this.VendorStaRetry.InternalName = "STA_RETRY_CT";
            this.VendorStaRetry.Key = "STA connection retries";
            this.VendorStaRetry.Location = new System.Drawing.Point(3, 746);
            this.VendorStaRetry.Maximum = 10;
            this.VendorStaRetry.Minimum = 0;
            this.VendorStaRetry.Name = "VendorStaRetry";
            this.VendorStaRetry.RequiredVersion = "3.00.00";
            this.VendorStaRetry.Size = new System.Drawing.Size(765, 37);
            this.VendorStaRetry.TabIndex = 24;
            this.VendorStaRetry.ToolTip = null;
            this.VendorStaRetry.UseSelectable = true;
            this.VendorStaRetry.Value = 10;
            this.VendorStaRetry.Warning = null;
            // 
            // VendorProductCode
            // 
            this.VendorProductCode.InternalName = "PRODUCT";
            this.VendorProductCode.Key = "Product Code";
            this.VendorProductCode.Location = new System.Drawing.Point(0, 703);
            this.VendorProductCode.MaxCharacters = 32;
            this.VendorProductCode.Name = "VendorProductCode";
            this.VendorProductCode.PasswordChar = '\0';
            this.VendorProductCode.Regex = null;
            this.VendorProductCode.RequiredVersion = "1.00.00";
            this.VendorProductCode.Size = new System.Drawing.Size(765, 37);
            this.VendorProductCode.TabIndex = 23;
            this.VendorProductCode.ToolTip = "Product name of the FlashAir";
            this.VendorProductCode.UseSelectable = true;
            this.VendorProductCode.Value = "";
            this.VendorProductCode.Warning = "";
            // 
            // VendorNoiseCancel
            // 
            this.VendorNoiseCancel.InternalName = "NOISE_CANCEL";
            this.VendorNoiseCancel.Key = "Noise Cancel";
            this.VendorNoiseCancel.Location = new System.Drawing.Point(3, 660);
            this.VendorNoiseCancel.Name = "VendorNoiseCancel";
            this.VendorNoiseCancel.RequiredVersion = "2.00.03";
            this.VendorNoiseCancel.Size = new System.Drawing.Size(765, 37);
            this.VendorNoiseCancel.TabIndex = 22;
            this.VendorNoiseCancel.ToolTip = "Improve connection at the cost of range and signal";
            this.VendorNoiseCancel.UseSelectable = true;
            this.VendorNoiseCancel.Value = false;
            this.VendorNoiseCancel.Warning = "";
            // 
            // VendorMasterCode
            // 
            this.VendorMasterCode.InternalName = "MASTERCODE";
            this.VendorMasterCode.Key = "Master Code";
            this.VendorMasterCode.Location = new System.Drawing.Point(3, 617);
            this.VendorMasterCode.MaxCharacters = 32;
            this.VendorMasterCode.Name = "VendorMasterCode";
            this.VendorMasterCode.PasswordChar = '\0';
            this.VendorMasterCode.Regex = null;
            this.VendorMasterCode.RequiredVersion = "1.00.00";
            this.VendorMasterCode.Size = new System.Drawing.Size(765, 37);
            this.VendorMasterCode.TabIndex = 21;
            this.VendorMasterCode.ToolTip = "Used as a password to set the SSID and Network key";
            this.VendorMasterCode.UseSelectable = true;
            this.VendorMasterCode.Value = "";
            this.VendorMasterCode.Warning = "Must be a HEX value with 12 characters";
            // 
            // VendorLuaWrite
            // 
            this.VendorLuaWrite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VendorLuaWrite.InternalName = "LUA_SD_EVENT";
            this.VendorLuaWrite.Key = "LUA Write Script";
            this.VendorLuaWrite.Location = new System.Drawing.Point(3, 574);
            this.VendorLuaWrite.MaxCharacters = 32;
            this.VendorLuaWrite.Name = "VendorLuaWrite";
            this.VendorLuaWrite.PasswordChar = '\0';
            this.VendorLuaWrite.Regex = null;
            this.VendorLuaWrite.RequiredVersion = "3.00.00";
            this.VendorLuaWrite.Size = new System.Drawing.Size(765, 37);
            this.VendorLuaWrite.TabIndex = 20;
            this.VendorLuaWrite.ToolTip = "";
            this.VendorLuaWrite.UseSelectable = true;
            this.VendorLuaWrite.Value = "";
            this.VendorLuaWrite.Warning = "";
            // 
            // VendorLuaPathBoot
            // 
            this.VendorLuaPathBoot.InternalName = "LUA_RUN_SCRIPT";
            this.VendorLuaPathBoot.Key = "LUA Boot Script";
            this.VendorLuaPathBoot.Location = new System.Drawing.Point(3, 531);
            this.VendorLuaPathBoot.MaxCharacters = 32;
            this.VendorLuaPathBoot.Name = "VendorLuaPathBoot";
            this.VendorLuaPathBoot.PasswordChar = '\0';
            this.VendorLuaPathBoot.Regex = null;
            this.VendorLuaPathBoot.RequiredVersion = "3.00.00";
            this.VendorLuaPathBoot.Size = new System.Drawing.Size(765, 37);
            this.VendorLuaPathBoot.TabIndex = 19;
            this.VendorLuaPathBoot.ToolTip = "";
            this.VendorLuaPathBoot.UseSelectable = true;
            this.VendorLuaPathBoot.Value = "";
            this.VendorLuaPathBoot.Warning = "";
            // 
            // VendorLock
            // 
            this.VendorLock.InternalName = "LOCK";
            this.VendorLock.Key = "Default Configured";
            this.VendorLock.Location = new System.Drawing.Point(3, 488);
            this.VendorLock.Name = "VendorLock";
            this.VendorLock.RequiredVersion = "1.00.00";
            this.VendorLock.Size = new System.Drawing.Size(765, 37);
            this.VendorLock.TabIndex = 18;
            this.VendorLock.ToolTip = "If set to true, Network settings will be reconfigured on browser";
            this.VendorLock.UseSelectable = true;
            this.VendorLock.Value = false;
            this.VendorLock.Warning = "";
            // 
            // VendorIfMode
            // 
            this.VendorIfMode.InternalName = "IFMODE";
            this.VendorIfMode.Key = "SD Interface Enabled";
            this.VendorIfMode.Location = new System.Drawing.Point(3, 445);
            this.VendorIfMode.Name = "VendorIfMode";
            this.VendorIfMode.RequiredVersion = "2.00.03";
            this.VendorIfMode.Size = new System.Drawing.Size(765, 37);
            this.VendorIfMode.TabIndex = 17;
            this.VendorIfMode.ToolTip = "Enable the usage of the SD Interface User I/O";
            this.VendorIfMode.UseSelectable = true;
            this.VendorIfMode.Value = false;
            this.VendorIfMode.Warning = "Check the API for more information";
            // 
            // VendorDns
            // 
            this.VendorDns.DataSource = null;
            this.VendorDns.InternalName = "DNSMODE";
            this.VendorDns.Key = "DNS operation mode";
            this.VendorDns.Location = new System.Drawing.Point(3, 402);
            this.VendorDns.Name = "VendorDns";
            this.VendorDns.RequiredVersion = "2.00.02";
            this.VendorDns.Size = new System.Drawing.Size(765, 37);
            this.VendorDns.TabIndex = 16;
            this.VendorDns.ToolTip = null;
            this.VendorDns.UseSelectable = true;
            this.VendorDns.Value = null;
            this.VendorDns.Warning = "";
            // 
            // VendorBootScreenPath
            // 
            this.VendorBootScreenPath.InternalName = "CIPATH";
            this.VendorBootScreenPath.Key = "Bootscreen path";
            this.VendorBootScreenPath.Location = new System.Drawing.Point(3, 359);
            this.VendorBootScreenPath.MaxCharacters = 32;
            this.VendorBootScreenPath.Name = "VendorBootScreenPath";
            this.VendorBootScreenPath.PasswordChar = '\0';
            this.VendorBootScreenPath.Regex = null;
            this.VendorBootScreenPath.RequiredVersion = "1.00.00";
            this.VendorBootScreenPath.Size = new System.Drawing.Size(765, 37);
            this.VendorBootScreenPath.TabIndex = 15;
            this.VendorBootScreenPath.ToolTip = "";
            this.VendorBootScreenPath.UseSelectable = true;
            this.VendorBootScreenPath.Value = "";
            this.VendorBootScreenPath.Warning = "";
            // 
            // VendorAppMode
            // 
            this.VendorAppMode.DataSource = null;
            this.VendorAppMode.InternalName = "APPMODE";
            this.VendorAppMode.Key = "Wireless LAN Mode";
            this.VendorAppMode.Location = new System.Drawing.Point(3, 144);
            this.VendorAppMode.Name = "VendorAppMode";
            this.VendorAppMode.RequiredVersion = "1.00.00";
            this.VendorAppMode.Size = new System.Drawing.Size(765, 37);
            this.VendorAppMode.TabIndex = 14;
            this.VendorAppMode.ToolTip = null;
            this.VendorAppMode.UseSelectable = true;
            this.VendorAppMode.Value = null;
            this.VendorAppMode.Warning = "Pass-Thru-Mode requires V2.00.02 or higher";
            // 
            // VendorAppAutoTime
            // 
            this.VendorAppAutoTime.InternalName = "APPAUTOTIME";
            this.VendorAppAutoTime.Key = "Connection time-out";
            this.VendorAppAutoTime.Location = new System.Drawing.Point(3, 58);
            this.VendorAppAutoTime.Maximum = 600000;
            this.VendorAppAutoTime.Minimum = 0;
            this.VendorAppAutoTime.Name = "VendorAppAutoTime";
            this.VendorAppAutoTime.RequiredVersion = "1.0.0.0";
            this.VendorAppAutoTime.Size = new System.Drawing.Size(765, 37);
            this.VendorAppAutoTime.TabIndex = 13;
            this.VendorAppAutoTime.ToolTip = null;
            this.VendorAppAutoTime.UseSelectable = true;
            this.VendorAppAutoTime.Value = 60000;
            this.VendorAppAutoTime.ValueType = fad2.UI.UserControls.SettingsTimeSlider.ValueTypes.Millisecond;
            this.VendorAppAutoTime.Warning = "Use at least 1 Minute or \"0\" to disable Timeout";
            // 
            // VendorCid
            // 
            this.VendorCid.InternalName = "CID";
            this.VendorCid.Key = "Card ID";
            this.VendorCid.Location = new System.Drawing.Point(3, 316);
            this.VendorCid.MaxCharacters = 32;
            this.VendorCid.Name = "VendorCid";
            this.VendorCid.PasswordChar = '\0';
            this.VendorCid.Regex = null;
            this.VendorCid.RequiredVersion = "1.00.00";
            this.VendorCid.Size = new System.Drawing.Size(765, 37);
            this.VendorCid.TabIndex = 12;
            this.VendorCid.ToolTip = "Card Identifier specified by the SD standard";
            this.VendorCid.UseSelectable = true;
            this.VendorCid.Value = "";
            this.VendorCid.Warning = "Must be a HEX value with exactly 32 characters";
            // 
            // VendorSSID
            // 
            this.VendorSSID.InternalName = "APPSSID";
            this.VendorSSID.Key = "SSID";
            this.VendorSSID.Location = new System.Drawing.Point(3, 273);
            this.VendorSSID.MaxCharacters = 32;
            this.VendorSSID.Name = "VendorSSID";
            this.VendorSSID.PasswordChar = '\0';
            this.VendorSSID.Regex = null;
            this.VendorSSID.RequiredVersion = "1.00.00";
            this.VendorSSID.Size = new System.Drawing.Size(765, 37);
            this.VendorSSID.TabIndex = 11;
            this.VendorSSID.ToolTip = "";
            this.VendorSSID.UseSelectable = true;
            this.VendorSSID.Value = "";
            this.VendorSSID.Warning = "";
            // 
            // VendorNetworkKey
            // 
            this.VendorNetworkKey.InternalName = "APPNETWORKKEY";
            this.VendorNetworkKey.Key = "Network security key";
            this.VendorNetworkKey.Location = new System.Drawing.Point(3, 230);
            this.VendorNetworkKey.MaxCharacters = 63;
            this.VendorNetworkKey.Name = "VendorNetworkKey";
            this.VendorNetworkKey.PasswordChar = '*';
            this.VendorNetworkKey.Regex = null;
            this.VendorNetworkKey.RequiredVersion = "1.00.00";
            this.VendorNetworkKey.Size = new System.Drawing.Size(765, 37);
            this.VendorNetworkKey.TabIndex = 10;
            this.VendorNetworkKey.ToolTip = "";
            this.VendorNetworkKey.UseSelectable = true;
            this.VendorNetworkKey.Value = "";
            this.VendorNetworkKey.Warning = "Enter at least 8 Characters";
            // 
            // VendorAppname
            // 
            this.VendorAppname.InternalName = "APPNAME";
            this.VendorAppname.Key = "NETBIOS / Bonjour - Name";
            this.VendorAppname.Location = new System.Drawing.Point(3, 187);
            this.VendorAppname.MaxCharacters = 15;
            this.VendorAppname.Name = "VendorAppname";
            this.VendorAppname.PasswordChar = '\0';
            this.VendorAppname.Regex = null;
            this.VendorAppname.RequiredVersion = "1.00.00";
            this.VendorAppname.Size = new System.Drawing.Size(765, 37);
            this.VendorAppname.TabIndex = 9;
            this.VendorAppname.ToolTip = "";
            this.VendorAppname.UseSelectable = true;
            this.VendorAppname.Value = "";
            this.VendorAppname.Warning = "";
            // 
            // VendorAppInfo
            // 
            this.VendorAppInfo.InternalName = "APPINFO";
            this.VendorAppInfo.Key = "App-Info";
            this.VendorAppInfo.Location = new System.Drawing.Point(3, 101);
            this.VendorAppInfo.MaxCharacters = 16;
            this.VendorAppInfo.Name = "VendorAppInfo";
            this.VendorAppInfo.PasswordChar = '\0';
            this.VendorAppInfo.Regex = null;
            this.VendorAppInfo.RequiredVersion = "1.00.00";
            this.VendorAppInfo.Size = new System.Drawing.Size(765, 37);
            this.VendorAppInfo.TabIndex = 6;
            this.VendorAppInfo.ToolTip = "Application\'s unique information";
            this.VendorAppInfo.UseSelectable = true;
            this.VendorAppInfo.Value = "";
            this.VendorAppInfo.Warning = "Must be 1-16 characters ";
            // 
            // WlansdProxyPort
            // 
            this.WlansdProxyPort.InternalName = "Port_Number";
            this.WlansdProxyPort.Key = "Proxy Port";
            this.WlansdProxyPort.Location = new System.Drawing.Point(3, 403);
            this.WlansdProxyPort.MaxCharacters = 16;
            this.WlansdProxyPort.Name = "WlansdProxyPort";
            this.WlansdProxyPort.PasswordChar = '\0';
            this.WlansdProxyPort.Regex = "^\\d*$";
            this.WlansdProxyPort.RequiredVersion = "1.00.00";
            this.WlansdProxyPort.Size = new System.Drawing.Size(765, 37);
            this.WlansdProxyPort.TabIndex = 27;
            this.WlansdProxyPort.ToolTip = "";
            this.WlansdProxyPort.UseSelectable = true;
            this.WlansdProxyPort.Value = "";
            this.WlansdProxyPort.Warning = null;
            // 
            // Wlansd_ProxyServer
            // 
            this.Wlansd_ProxyServer.InternalName = "Proxy_Server_Name";
            this.Wlansd_ProxyServer.Key = "Proxy Server";
            this.Wlansd_ProxyServer.Location = new System.Drawing.Point(3, 360);
            this.Wlansd_ProxyServer.MaxCharacters = 16;
            this.Wlansd_ProxyServer.Name = "Wlansd_ProxyServer";
            this.Wlansd_ProxyServer.PasswordChar = '\0';
            this.Wlansd_ProxyServer.Regex = "^([a-zA-Z0-9]|[a-zA-Z0-9][a-zA-Z0-9\\-]{0,61}[a-zA-Z0-9])(\\.([a-zA-Z0-9]|[a-zA-Z0-" +
    "9][a-zA-Z0-9\\-]{0,61}[a-zA-Z0-9]))*$";
            this.Wlansd_ProxyServer.RequiredVersion = "1.00.00";
            this.Wlansd_ProxyServer.Size = new System.Drawing.Size(765, 37);
            this.Wlansd_ProxyServer.TabIndex = 26;
            this.Wlansd_ProxyServer.ToolTip = "Ip or Hostname";
            this.Wlansd_ProxyServer.UseSelectable = true;
            this.Wlansd_ProxyServer.Value = "";
            this.Wlansd_ProxyServer.Warning = null;
            // 
            // WlansdUseProxy
            // 
            this.WlansdUseProxy.InternalName = "Proxy_Server_Enabled";
            this.WlansdUseProxy.Key = "Enable Proxy";
            this.WlansdUseProxy.Location = new System.Drawing.Point(3, 317);
            this.WlansdUseProxy.Name = "WlansdUseProxy";
            this.WlansdUseProxy.RequiredVersion = "1.00.00";
            this.WlansdUseProxy.Size = new System.Drawing.Size(765, 37);
            this.WlansdUseProxy.TabIndex = 24;
            this.WlansdUseProxy.ToolTip = "";
            this.WlansdUseProxy.UseSelectable = true;
            this.WlansdUseProxy.Value = false;
            this.WlansdUseProxy.Warning = "";
            // 
            // WlansdDnsAlternate
            // 
            this.WlansdDnsAlternate.InternalName = "Alternate_DNS_Server";
            this.WlansdDnsAlternate.Key = "Alternate DNS Server";
            this.WlansdDnsAlternate.Location = new System.Drawing.Point(3, 274);
            this.WlansdDnsAlternate.MaxCharacters = 32767;
            this.WlansdDnsAlternate.Name = "WlansdDnsAlternate";
            this.WlansdDnsAlternate.PasswordChar = '\0';
            this.WlansdDnsAlternate.Regex = null;
            this.WlansdDnsAlternate.RequiredVersion = "1.00.00";
            this.WlansdDnsAlternate.Size = new System.Drawing.Size(765, 37);
            this.WlansdDnsAlternate.TabIndex = 23;
            this.WlansdDnsAlternate.ToolTip = null;
            this.WlansdDnsAlternate.UseSelectable = true;
            this.WlansdDnsAlternate.Value = "";
            this.WlansdDnsAlternate.Warning = null;
            // 
            // WlansdDns
            // 
            this.WlansdDns.InternalName = "Preferred_DNS_Server";
            this.WlansdDns.Key = "DNS Server";
            this.WlansdDns.Location = new System.Drawing.Point(3, 231);
            this.WlansdDns.MaxCharacters = 32767;
            this.WlansdDns.Name = "WlansdDns";
            this.WlansdDns.PasswordChar = '\0';
            this.WlansdDns.Regex = null;
            this.WlansdDns.RequiredVersion = "1.00.00";
            this.WlansdDns.Size = new System.Drawing.Size(765, 37);
            this.WlansdDns.TabIndex = 22;
            this.WlansdDns.ToolTip = null;
            this.WlansdDns.UseSelectable = true;
            this.WlansdDns.Value = "";
            this.WlansdDns.Warning = null;
            // 
            // WlansdGateway
            // 
            this.WlansdGateway.InternalName = "Default_Gateway";
            this.WlansdGateway.Key = "Gateway";
            this.WlansdGateway.Location = new System.Drawing.Point(3, 188);
            this.WlansdGateway.MaxCharacters = 32767;
            this.WlansdGateway.Name = "WlansdGateway";
            this.WlansdGateway.PasswordChar = '\0';
            this.WlansdGateway.Regex = null;
            this.WlansdGateway.RequiredVersion = "1.00.00";
            this.WlansdGateway.Size = new System.Drawing.Size(765, 37);
            this.WlansdGateway.TabIndex = 21;
            this.WlansdGateway.ToolTip = null;
            this.WlansdGateway.UseSelectable = true;
            this.WlansdGateway.Value = "";
            this.WlansdGateway.Warning = null;
            // 
            // WlansdSubnet
            // 
            this.WlansdSubnet.InternalName = "Subnet_Mask";
            this.WlansdSubnet.Key = "Subnet Mask";
            this.WlansdSubnet.Location = new System.Drawing.Point(3, 145);
            this.WlansdSubnet.MaxCharacters = 32767;
            this.WlansdSubnet.Name = "WlansdSubnet";
            this.WlansdSubnet.PasswordChar = '\0';
            this.WlansdSubnet.Regex = null;
            this.WlansdSubnet.RequiredVersion = "1.00.00";
            this.WlansdSubnet.Size = new System.Drawing.Size(765, 37);
            this.WlansdSubnet.TabIndex = 20;
            this.WlansdSubnet.ToolTip = null;
            this.WlansdSubnet.UseSelectable = true;
            this.WlansdSubnet.Value = "";
            this.WlansdSubnet.Warning = null;
            // 
            // WlansdIpAddress
            // 
            this.WlansdIpAddress.InternalName = "IP_Address";
            this.WlansdIpAddress.Key = "IP Address";
            this.WlansdIpAddress.Location = new System.Drawing.Point(3, 102);
            this.WlansdIpAddress.MaxCharacters = 32767;
            this.WlansdIpAddress.Name = "WlansdIpAddress";
            this.WlansdIpAddress.PasswordChar = '\0';
            this.WlansdIpAddress.Regex = null;
            this.WlansdIpAddress.RequiredVersion = "1.00.00";
            this.WlansdIpAddress.Size = new System.Drawing.Size(765, 37);
            this.WlansdIpAddress.TabIndex = 19;
            this.WlansdIpAddress.ToolTip = null;
            this.WlansdIpAddress.UseSelectable = true;
            this.WlansdIpAddress.Value = "";
            this.WlansdIpAddress.Warning = null;
            // 
            // WlansdDhcp
            // 
            this.WlansdDhcp.InternalName = "DHCP_Enabled";
            this.WlansdDhcp.Key = "DHCP";
            this.WlansdDhcp.Location = new System.Drawing.Point(3, 59);
            this.WlansdDhcp.Name = "WlansdDhcp";
            this.WlansdDhcp.RequiredVersion = "1.00.00";
            this.WlansdDhcp.Size = new System.Drawing.Size(765, 37);
            this.WlansdDhcp.TabIndex = 18;
            this.WlansdDhcp.ToolTip = "";
            this.WlansdDhcp.UseSelectable = true;
            this.WlansdDhcp.Value = false;
            this.WlansdDhcp.Warning = "";
            // 
            // WlansdId
            // 
            this.WlansdId.InternalName = "ID";
            this.WlansdId.Key = "Card ID";
            this.WlansdId.Location = new System.Drawing.Point(3, 16);
            this.WlansdId.MaxCharacters = 16;
            this.WlansdId.Name = "WlansdId";
            this.WlansdId.PasswordChar = '\0';
            this.WlansdId.Regex = null;
            this.WlansdId.RequiredVersion = "1.00.00";
            this.WlansdId.Size = new System.Drawing.Size(765, 37);
            this.WlansdId.TabIndex = 8;
            this.WlansdId.ToolTip = "Card ID using up to 16 characters";
            this.WlansdId.UseSelectable = true;
            this.WlansdId.Value = "";
            this.WlansdId.Warning = null;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingsPanel);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1200, 636);
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            this.LoadTile.ResumeLayout(false);
            this.CardSettingsTab.ResumeLayout(false);
            this.ApplicationSettings.ResumeLayout(false);
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.CardSettingsDisable.ResumeLayout(false);
            this.CardSettingsDisable.PerformLayout();
            this.CardSettingsVendor.ResumeLayout(false);
            this.CardSettingsVendor.PerformLayout();
            this.CardSettingsNetwork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel SettingsPanel;
        private MetroFramework.Controls.MetroButton SaveSettings;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton LoadFromFile;
        private MetroFramework.Controls.MetroTabControl CardSettingsTab;
        private MetroFramework.Controls.MetroTabPage CardSettingsVendor;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel DontDoAnythingStupid;
        private SettingsCombo VendorWebDav;
        private SettingsString VendorFirmware;
        private SettingsString VendorCode;
        private SettingsBoolean VendorUploadEnabled;
        private SettingsString VendorUploadDir;
        private SettingsSlider VendorTimezone;
        private SettingsSlider VendorStaRetry;
        private SettingsString VendorProductCode;
        private SettingsBoolean VendorNoiseCancel;
        private SettingsString VendorMasterCode;
        private SettingsString VendorLuaWrite;
        private SettingsString VendorLuaPathBoot;
        private SettingsBoolean VendorLock;
        private SettingsBoolean VendorIfMode;
        private SettingsCombo VendorDns;
        private SettingsString VendorBootScreenPath;
        private SettingsCombo VendorAppMode;
        private SettingsTimeSlider VendorAppAutoTime;
        private SettingsString VendorCid;
        private SettingsString VendorSSID;
        private SettingsString VendorNetworkKey;
        private SettingsString VendorAppname;
        private SettingsString VendorAppInfo;
        private MetroFramework.Controls.MetroTabPage CardSettingsNetwork;
        private SettingsString WlansdId;
        private MetroFramework.Controls.MetroPanel RightPanel;
        private SettingsBoolean WlansdDhcp;
        private SettingsString Wlansd_ProxyServer;
        private SettingsBoolean WlansdUseProxy;
        private SettingsIp WlansdDnsAlternate;
        private SettingsIp WlansdDns;
        private SettingsIp WlansdGateway;
        private SettingsIp WlansdSubnet;
        private SettingsIp WlansdIpAddress;
        private SettingsString WlansdProxyPort;
        private MetroFramework.Controls.MetroTile LoadTile;
        private MetroFramework.Controls.MetroProgressSpinner LoadSpinner;
        private MetroFramework.Controls.MetroTabPage ApplicationSettings;
        private SettingsFile LocalPath;
        private SettingsString ApplicationUrl;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private SettingsCombo DateCreation;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private SettingsCombo MultiCards;
        private SettingsCombo FilesExist;
        private MetroFramework.Controls.MetroLink CustomDirHelp;
        private SettingsString CustomFolderCreation;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private SettingsLabel CurrentServiceStatus;
        private SettingsComboButton ServiceActions;
        private SettingsBoolean DeleteFiles;
        private SettingsTimeSlider ServiceInterval;
        private SettingsLabel PathPreview;
        private MetroFramework.Controls.MetroTabPage CardSettingsDisable;
        private SettingsBoolean DisableUploads;
        private SettingsBoolean DisableThumbnails;
        private SettingsBoolean DisableCommand;
        private SettingsBoolean DisableDownload;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroButton SaveProgSettings;
        private MetroFramework.Controls.MetroLabel ProgSettingsLabel;
        private SettingsString StartupPath;
        private SettingsCombo FiletypesToCopy;
        private SettingsBoolean LoadThumbs;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private SettingsFile Backgroundlocation;
        private SettingsBoolean ShowTiles;
        private SettingsBoolean ShowBackimages;
        private SettingsTimeSlider BackgroundInterval;
        private MetroFramework.Controls.MetroLabel metroLabel4;
    }
}
