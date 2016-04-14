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
            this.SettingsPanel = new MetroFramework.Controls.MetroPanel();
            this.SaveSettings = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.CardSettingsTab = new MetroFramework.Controls.MetroTabControl();
            this.CardSettingsVendor = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.DontDoAnythingStupid = new MetroFramework.Controls.MetroLabel();
            this.CardSettingsNetwork = new MetroFramework.Controls.MetroTabPage();
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
            this.settingsString1 = new fad2.UI.UserControls.SettingsString();
            this.RightPanel = new MetroFramework.Controls.MetroPanel();
            this.SettingsPanel.SuspendLayout();
            this.CardSettingsTab.SuspendLayout();
            this.CardSettingsVendor.SuspendLayout();
            this.CardSettingsNetwork.SuspendLayout();
            this.SuspendLayout();
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsPanel.Controls.Add(this.RightPanel);
            this.SettingsPanel.Controls.Add(this.SaveSettings);
            this.SettingsPanel.Controls.Add(this.metroLabel1);
            this.SettingsPanel.Controls.Add(this.metroButton2);
            this.SettingsPanel.Controls.Add(this.metroButton1);
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
            // SaveSettings
            // 
            this.SaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveSettings.Location = new System.Drawing.Point(17, 578);
            this.SaveSettings.Name = "SaveSettings";
            this.SaveSettings.Size = new System.Drawing.Size(119, 23);
            this.SaveSettings.TabIndex = 13;
            this.SaveSettings.Text = "Save";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(17, 72);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(110, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Settings Location:";
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(17, 126);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(119, 23);
            this.metroButton2.TabIndex = 4;
            this.metroButton2.Text = "Use Network";
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(17, 97);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(119, 23);
            this.metroButton1.TabIndex = 3;
            this.metroButton1.Text = "Use Local SDCard";
            // 
            // CardSettingsTab
            // 
            this.CardSettingsTab.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CardSettingsTab.Controls.Add(this.CardSettingsVendor);
            this.CardSettingsTab.Controls.Add(this.CardSettingsNetwork);
            this.CardSettingsTab.Location = new System.Drawing.Point(172, 3);
            this.CardSettingsTab.Name = "CardSettingsTab";
            this.CardSettingsTab.SelectedIndex = 0;
            this.CardSettingsTab.Size = new System.Drawing.Size(834, 598);
            this.CardSettingsTab.TabIndex = 2;
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
            this.CardSettingsVendor.Location = new System.Drawing.Point(4, 35);
            this.CardSettingsVendor.Name = "CardSettingsVendor";
            this.CardSettingsVendor.Size = new System.Drawing.Size(826, 559);
            this.CardSettingsVendor.TabIndex = 0;
            this.CardSettingsVendor.Text = "Vendor";
            this.CardSettingsVendor.VerticalScrollbar = true;
            this.CardSettingsVendor.VerticalScrollbarBarColor = true;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(7, 97);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(510, 19);
            this.metroLabel2.TabIndex = 32;
            this.metroLabel2.Text = "Better check the documentation BEFORE you change a setting you do not understand." +
    "";
            // 
            // DontDoAnythingStupid
            // 
            this.DontDoAnythingStupid.AutoSize = true;
            this.DontDoAnythingStupid.Location = new System.Drawing.Point(7, 78);
            this.DontDoAnythingStupid.Name = "DontDoAnythingStupid";
            this.DontDoAnythingStupid.Size = new System.Drawing.Size(459, 19);
            this.DontDoAnythingStupid.TabIndex = 31;
            this.DontDoAnythingStupid.Text = "Please be aware that you can really screw up here if you enter wrong values.. ";
            // 
            // CardSettingsNetwork
            // 
            this.CardSettingsNetwork.Controls.Add(this.settingsString1);
            this.CardSettingsNetwork.HorizontalScrollbarBarColor = true;
            this.CardSettingsNetwork.Location = new System.Drawing.Point(4, 35);
            this.CardSettingsNetwork.Name = "CardSettingsNetwork";
            this.CardSettingsNetwork.Size = new System.Drawing.Size(826, 559);
            this.CardSettingsNetwork.TabIndex = 1;
            this.CardSettingsNetwork.Text = "WLANSD";
            this.CardSettingsNetwork.VerticalScrollbarBarColor = true;
            // 
            // VendorWebDav
            // 
            this.VendorWebDav.DataSource = null;
            this.VendorWebDav.InternalName = "WEBDAV";
            this.VendorWebDav.Key = "WebDav";
            this.VendorWebDav.Location = new System.Drawing.Point(3, 1067);
            this.VendorWebDav.Name = "VendorWebDav";
            this.VendorWebDav.RequiredVersion = "3.00.00";
            this.VendorWebDav.Size = new System.Drawing.Size(765, 37);
            this.VendorWebDav.TabIndex = 30;
            this.VendorWebDav.ToolTip = null;
            this.VendorWebDav.Value = null;
            this.VendorWebDav.Warning = "Upload must be enabled, too to allow writing";
            // 
            // VendorFirmware
            // 
            this.VendorFirmware.InternalName = "VERSION";
            this.VendorFirmware.Key = "Firmware version";
            this.VendorFirmware.Location = new System.Drawing.Point(3, 1024);
            this.VendorFirmware.MaxCharacters = 32;
            this.VendorFirmware.Name = "VendorFirmware";
            this.VendorFirmware.PasswordChar = '\0';
            this.VendorFirmware.RequiredVersion = "1.00.00";
            this.VendorFirmware.Size = new System.Drawing.Size(765, 37);
            this.VendorFirmware.TabIndex = 29;
            this.VendorFirmware.ToolTip = "";
            this.VendorFirmware.Value = "";
            this.VendorFirmware.Warning = "";
            // 
            // VendorCode
            // 
            this.VendorCode.InternalName = "VENDOR";
            this.VendorCode.Key = "Vendor code";
            this.VendorCode.Location = new System.Drawing.Point(3, 981);
            this.VendorCode.MaxCharacters = 32;
            this.VendorCode.Name = "VendorCode";
            this.VendorCode.PasswordChar = '\0';
            this.VendorCode.RequiredVersion = "1.00.00";
            this.VendorCode.Size = new System.Drawing.Size(765, 37);
            this.VendorCode.TabIndex = 28;
            this.VendorCode.ToolTip = "";
            this.VendorCode.Value = "";
            this.VendorCode.Warning = "";
            // 
            // VendorUploadEnabled
            // 
            this.VendorUploadEnabled.InternalName = "UPLOAD";
            this.VendorUploadEnabled.Key = "Upload Enabled";
            this.VendorUploadEnabled.Location = new System.Drawing.Point(3, 938);
            this.VendorUploadEnabled.Name = "VendorUploadEnabled";
            this.VendorUploadEnabled.RequiredVersion = "1.00.00";
            this.VendorUploadEnabled.Size = new System.Drawing.Size(765, 37);
            this.VendorUploadEnabled.TabIndex = 27;
            this.VendorUploadEnabled.ToolTip = "";
            this.VendorUploadEnabled.Value = false;
            this.VendorUploadEnabled.Warning = "MUST be enabled to allow writing of data or configuration";
            // 
            // VendorUploadDir
            // 
            this.VendorUploadDir.InternalName = "UPDIR";
            this.VendorUploadDir.Key = "Upload Directory";
            this.VendorUploadDir.Location = new System.Drawing.Point(3, 895);
            this.VendorUploadDir.MaxCharacters = 32;
            this.VendorUploadDir.Name = "VendorUploadDir";
            this.VendorUploadDir.PasswordChar = '\0';
            this.VendorUploadDir.RequiredVersion = "2.00.03";
            this.VendorUploadDir.Size = new System.Drawing.Size(765, 37);
            this.VendorUploadDir.TabIndex = 26;
            this.VendorUploadDir.ToolTip = "";
            this.VendorUploadDir.Value = "";
            this.VendorUploadDir.Warning = "";
            // 
            // VendorTimezone
            // 
            this.VendorTimezone.InternalName = "TIMEZONE";
            this.VendorTimezone.Key = "Time Zone";
            this.VendorTimezone.Location = new System.Drawing.Point(3, 859);
            this.VendorTimezone.Maximum = 54;
            this.VendorTimezone.Minimum = -48;
            this.VendorTimezone.Name = "VendorTimezone";
            this.VendorTimezone.RequiredVersion = "3.00.00";
            this.VendorTimezone.Size = new System.Drawing.Size(765, 37);
            this.VendorTimezone.TabIndex = 25;
            this.VendorTimezone.ToolTip = "UTC = 0";
            this.VendorTimezone.Value = 10;
            this.VendorTimezone.Warning = null;
            // 
            // VendorStaRetry
            // 
            this.VendorStaRetry.InternalName = "STA_RETRY_CT";
            this.VendorStaRetry.Key = "STA connection retries";
            this.VendorStaRetry.Location = new System.Drawing.Point(3, 816);
            this.VendorStaRetry.Maximum = 10;
            this.VendorStaRetry.Minimum = 0;
            this.VendorStaRetry.Name = "VendorStaRetry";
            this.VendorStaRetry.RequiredVersion = "3.00.00";
            this.VendorStaRetry.Size = new System.Drawing.Size(765, 37);
            this.VendorStaRetry.TabIndex = 24;
            this.VendorStaRetry.ToolTip = null;
            this.VendorStaRetry.Value = 10;
            this.VendorStaRetry.Warning = null;
            // 
            // VendorProductCode
            // 
            this.VendorProductCode.InternalName = "PRODUCT";
            this.VendorProductCode.Key = "Product Code";
            this.VendorProductCode.Location = new System.Drawing.Point(3, 773);
            this.VendorProductCode.MaxCharacters = 32;
            this.VendorProductCode.Name = "VendorProductCode";
            this.VendorProductCode.PasswordChar = '\0';
            this.VendorProductCode.RequiredVersion = "1.00.00";
            this.VendorProductCode.Size = new System.Drawing.Size(765, 37);
            this.VendorProductCode.TabIndex = 23;
            this.VendorProductCode.ToolTip = "Product name of the FlashAir";
            this.VendorProductCode.Value = "";
            this.VendorProductCode.Warning = "";
            // 
            // VendorNoiseCancel
            // 
            this.VendorNoiseCancel.InternalName = "NOISE_CANCEL";
            this.VendorNoiseCancel.Key = "Noise Cancel";
            this.VendorNoiseCancel.Location = new System.Drawing.Point(3, 730);
            this.VendorNoiseCancel.Name = "VendorNoiseCancel";
            this.VendorNoiseCancel.RequiredVersion = "2.00.03";
            this.VendorNoiseCancel.Size = new System.Drawing.Size(765, 37);
            this.VendorNoiseCancel.TabIndex = 22;
            this.VendorNoiseCancel.ToolTip = "Improve connection at the cost of range and signal";
            this.VendorNoiseCancel.Value = false;
            this.VendorNoiseCancel.Warning = "";
            // 
            // VendorMasterCode
            // 
            this.VendorMasterCode.InternalName = "MASTERCODE";
            this.VendorMasterCode.Key = "Master Code";
            this.VendorMasterCode.Location = new System.Drawing.Point(3, 687);
            this.VendorMasterCode.MaxCharacters = 32;
            this.VendorMasterCode.Name = "VendorMasterCode";
            this.VendorMasterCode.PasswordChar = '\0';
            this.VendorMasterCode.RequiredVersion = "1.00.00";
            this.VendorMasterCode.Size = new System.Drawing.Size(765, 37);
            this.VendorMasterCode.TabIndex = 21;
            this.VendorMasterCode.ToolTip = "Used as a password to set the SSID and Network key";
            this.VendorMasterCode.Value = "";
            this.VendorMasterCode.Warning = "Must be a HEX value with 12 characters";
            // 
            // VendorLuaWrite
            // 
            this.VendorLuaWrite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.VendorLuaWrite.InternalName = "LUA_SD_EVENT";
            this.VendorLuaWrite.Key = "LUA Write Script";
            this.VendorLuaWrite.Location = new System.Drawing.Point(3, 644);
            this.VendorLuaWrite.MaxCharacters = 32;
            this.VendorLuaWrite.Name = "VendorLuaWrite";
            this.VendorLuaWrite.PasswordChar = '\0';
            this.VendorLuaWrite.RequiredVersion = "3.00.00";
            this.VendorLuaWrite.Size = new System.Drawing.Size(765, 37);
            this.VendorLuaWrite.TabIndex = 20;
            this.VendorLuaWrite.ToolTip = "";
            this.VendorLuaWrite.Value = "";
            this.VendorLuaWrite.Warning = "";
            // 
            // VendorLuaPathBoot
            // 
            this.VendorLuaPathBoot.InternalName = "LUA_RUN_SCRIPT";
            this.VendorLuaPathBoot.Key = "LUA Boot Script";
            this.VendorLuaPathBoot.Location = new System.Drawing.Point(3, 601);
            this.VendorLuaPathBoot.MaxCharacters = 32;
            this.VendorLuaPathBoot.Name = "VendorLuaPathBoot";
            this.VendorLuaPathBoot.PasswordChar = '\0';
            this.VendorLuaPathBoot.RequiredVersion = "3.00.00";
            this.VendorLuaPathBoot.Size = new System.Drawing.Size(765, 37);
            this.VendorLuaPathBoot.TabIndex = 19;
            this.VendorLuaPathBoot.ToolTip = "";
            this.VendorLuaPathBoot.Value = "";
            this.VendorLuaPathBoot.Warning = "";
            // 
            // VendorLock
            // 
            this.VendorLock.InternalName = "LOCK";
            this.VendorLock.Key = "Default Configured";
            this.VendorLock.Location = new System.Drawing.Point(3, 558);
            this.VendorLock.Name = "VendorLock";
            this.VendorLock.RequiredVersion = "0.0.0.0";
            this.VendorLock.Size = new System.Drawing.Size(765, 37);
            this.VendorLock.TabIndex = 18;
            this.VendorLock.ToolTip = "If set to true, Network settings will be reconfigured on browser";
            this.VendorLock.Value = false;
            this.VendorLock.Warning = "";
            // 
            // VendorIfMode
            // 
            this.VendorIfMode.InternalName = "IFMODE";
            this.VendorIfMode.Key = "SD Interface Enabled";
            this.VendorIfMode.Location = new System.Drawing.Point(3, 512);
            this.VendorIfMode.Name = "VendorIfMode";
            this.VendorIfMode.RequiredVersion = "2.00.03";
            this.VendorIfMode.Size = new System.Drawing.Size(765, 37);
            this.VendorIfMode.TabIndex = 17;
            this.VendorIfMode.ToolTip = "Enable the usage of the SD Interface User I/O";
            this.VendorIfMode.Value = false;
            this.VendorIfMode.Warning = "Check the API for more information";
            // 
            // VendorDns
            // 
            this.VendorDns.DataSource = null;
            this.VendorDns.InternalName = "DNSMODE";
            this.VendorDns.Key = "DNS operation mode";
            this.VendorDns.Location = new System.Drawing.Point(3, 469);
            this.VendorDns.Name = "VendorDns";
            this.VendorDns.RequiredVersion = "2.00.02";
            this.VendorDns.Size = new System.Drawing.Size(765, 37);
            this.VendorDns.TabIndex = 16;
            this.VendorDns.ToolTip = null;
            this.VendorDns.Value = null;
            this.VendorDns.Warning = "";
            // 
            // VendorBootScreenPath
            // 
            this.VendorBootScreenPath.InternalName = "CIPATH";
            this.VendorBootScreenPath.Key = "Bootscreen path";
            this.VendorBootScreenPath.Location = new System.Drawing.Point(3, 426);
            this.VendorBootScreenPath.MaxCharacters = 32;
            this.VendorBootScreenPath.Name = "VendorBootScreenPath";
            this.VendorBootScreenPath.PasswordChar = '\0';
            this.VendorBootScreenPath.RequiredVersion = "1.00.00";
            this.VendorBootScreenPath.Size = new System.Drawing.Size(765, 37);
            this.VendorBootScreenPath.TabIndex = 15;
            this.VendorBootScreenPath.ToolTip = "";
            this.VendorBootScreenPath.Value = "";
            this.VendorBootScreenPath.Warning = "";
            // 
            // VendorAppMode
            // 
            this.VendorAppMode.DataSource = null;
            this.VendorAppMode.InternalName = "APPMODE";
            this.VendorAppMode.Key = "Wireless LAN Mode";
            this.VendorAppMode.Location = new System.Drawing.Point(3, 211);
            this.VendorAppMode.Name = "VendorAppMode";
            this.VendorAppMode.RequiredVersion = "1.0.0.0";
            this.VendorAppMode.Size = new System.Drawing.Size(765, 37);
            this.VendorAppMode.TabIndex = 14;
            this.VendorAppMode.ToolTip = null;
            this.VendorAppMode.Value = null;
            this.VendorAppMode.Warning = "Pass-Thru-Mode requires V2.00.02 or higher";
            // 
            // VendorAppAutoTime
            // 
            this.VendorAppAutoTime.InternalName = "APPAUTOTIME";
            this.VendorAppAutoTime.Key = "Connection time-out";
            this.VendorAppAutoTime.Location = new System.Drawing.Point(3, 125);
            this.VendorAppAutoTime.Maximum = 120;
            this.VendorAppAutoTime.Minimum = 0;
            this.VendorAppAutoTime.Name = "VendorAppAutoTime";
            this.VendorAppAutoTime.RequiredVersion = "1.0.0.0";
            this.VendorAppAutoTime.Size = new System.Drawing.Size(765, 37);
            this.VendorAppAutoTime.TabIndex = 13;
            this.VendorAppAutoTime.ToolTip = null;
            this.VendorAppAutoTime.Value = 50;
            this.VendorAppAutoTime.ValueType = fad2.UI.UserControls.SettingsTimeSlider.ValueTypes.Second;
            this.VendorAppAutoTime.Warning = null;
            // 
            // VendorCid
            // 
            this.VendorCid.InternalName = "CID";
            this.VendorCid.Key = "Card ID";
            this.VendorCid.Location = new System.Drawing.Point(3, 383);
            this.VendorCid.MaxCharacters = 32;
            this.VendorCid.Name = "VendorCid";
            this.VendorCid.PasswordChar = '\0';
            this.VendorCid.RequiredVersion = "1.00.00";
            this.VendorCid.Size = new System.Drawing.Size(765, 37);
            this.VendorCid.TabIndex = 12;
            this.VendorCid.ToolTip = "Card Identifier specified by the SD standard";
            this.VendorCid.Value = "";
            this.VendorCid.Warning = "Must be a HEX value with exactly 32 characters";
            // 
            // VendorSSID
            // 
            this.VendorSSID.InternalName = "APPSSID";
            this.VendorSSID.Key = "SSID";
            this.VendorSSID.Location = new System.Drawing.Point(3, 340);
            this.VendorSSID.MaxCharacters = 32;
            this.VendorSSID.Name = "VendorSSID";
            this.VendorSSID.PasswordChar = '\0';
            this.VendorSSID.RequiredVersion = "1.00.00";
            this.VendorSSID.Size = new System.Drawing.Size(765, 37);
            this.VendorSSID.TabIndex = 11;
            this.VendorSSID.ToolTip = "";
            this.VendorSSID.Value = "";
            this.VendorSSID.Warning = "";
            // 
            // VendorNetworkKey
            // 
            this.VendorNetworkKey.InternalName = "APPNETWORKKEY";
            this.VendorNetworkKey.Key = "Network security key";
            this.VendorNetworkKey.Location = new System.Drawing.Point(3, 297);
            this.VendorNetworkKey.MaxCharacters = 63;
            this.VendorNetworkKey.Name = "VendorNetworkKey";
            this.VendorNetworkKey.PasswordChar = '*';
            this.VendorNetworkKey.RequiredVersion = "1.00.00";
            this.VendorNetworkKey.Size = new System.Drawing.Size(765, 37);
            this.VendorNetworkKey.TabIndex = 10;
            this.VendorNetworkKey.ToolTip = "";
            this.VendorNetworkKey.Value = "";
            this.VendorNetworkKey.Warning = "Enter at least 8 Characters";
            // 
            // VendorAppname
            // 
            this.VendorAppname.InternalName = "APPNAME";
            this.VendorAppname.Key = "NETBIOS / Bonjour - Name";
            this.VendorAppname.Location = new System.Drawing.Point(3, 254);
            this.VendorAppname.MaxCharacters = 15;
            this.VendorAppname.Name = "VendorAppname";
            this.VendorAppname.PasswordChar = '\0';
            this.VendorAppname.RequiredVersion = "1.00.00";
            this.VendorAppname.Size = new System.Drawing.Size(765, 37);
            this.VendorAppname.TabIndex = 9;
            this.VendorAppname.ToolTip = "";
            this.VendorAppname.Value = "";
            this.VendorAppname.Warning = "";
            // 
            // VendorAppInfo
            // 
            this.VendorAppInfo.InternalName = "APPINFO";
            this.VendorAppInfo.Key = "App-Info";
            this.VendorAppInfo.Location = new System.Drawing.Point(3, 168);
            this.VendorAppInfo.MaxCharacters = 16;
            this.VendorAppInfo.Name = "VendorAppInfo";
            this.VendorAppInfo.PasswordChar = '\0';
            this.VendorAppInfo.RequiredVersion = "1.00.00";
            this.VendorAppInfo.Size = new System.Drawing.Size(765, 37);
            this.VendorAppInfo.TabIndex = 6;
            this.VendorAppInfo.ToolTip = "Application\'s unique information";
            this.VendorAppInfo.Value = "";
            this.VendorAppInfo.Warning = "Must be 1-16 characters ";
            // 
            // settingsString1
            // 
            this.settingsString1.InternalName = null;
            this.settingsString1.Key = "App-Info";
            this.settingsString1.Location = new System.Drawing.Point(3, 16);
            this.settingsString1.MaxCharacters = 32767;
            this.settingsString1.Name = "settingsString1";
            this.settingsString1.PasswordChar = '\0';
            this.settingsString1.RequiredVersion = "1.00.00";
            this.settingsString1.Size = new System.Drawing.Size(765, 37);
            this.settingsString1.TabIndex = 8;
            this.settingsString1.ToolTip = "Applications Unique Information";
            this.settingsString1.Value = "";
            this.settingsString1.Warning = null;
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
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingsPanel);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(1200, 636);
            this.SettingsPanel.ResumeLayout(false);
            this.SettingsPanel.PerformLayout();
            this.CardSettingsTab.ResumeLayout(false);
            this.CardSettingsVendor.ResumeLayout(false);
            this.CardSettingsVendor.PerformLayout();
            this.CardSettingsNetwork.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel SettingsPanel;
        private MetroFramework.Controls.MetroButton SaveSettings;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private MetroFramework.Controls.MetroButton metroButton1;
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
        private SettingsString settingsString1;
        private MetroFramework.Controls.MetroPanel RightPanel;
    }
}
