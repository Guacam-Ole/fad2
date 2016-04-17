using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.IO;
using fad2.Backend;
using fad2.UI.UserControls;

namespace fad2.UI
{
    public partial class Settings : UserControl
    {
        private const int _tileSize = 300;
        private const int _tileMargin = 20;

        Random _random = new Random();
        Timer _backImageTimer;

        public Settings()
        {
            InitializeComponent();
            SetCombos();
            _backImageTimer = new Timer();
            _backImageTimer.Interval = 5000;
            _backImageTimer.Tick += _backImageTimer_Tick;     _backImageTimer.Start();
        }

        private void _backImageTimer_Tick(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void SetCombos()
        {
            var appModes = new List<KeyValuePair<int, string>>();
            appModes.Add(new KeyValuePair<int, string>(4, "AP (Access Point) mode "));
            appModes.Add(new KeyValuePair<int, string>(5, "STA (Station) mode "));
            appModes.Add(new KeyValuePair<int, string>(6, "Pass-Thru mode"));
            VendorAppMode.DataSource = appModes;

            var dnsModes = new List<KeyValuePair<int, string>>();
            dnsModes.Add(new KeyValuePair<int, string>(0, "Return IP Only if request is done with APPNAME"));
            dnsModes.Add(new KeyValuePair<int, string>(1, "Always return IP to DNS requests (default)"));
            VendorDns.DataSource = dnsModes;

            var webdavModes = new List<KeyValuePair<int, string>>();
            webdavModes.Add(new KeyValuePair<int, string>(0, "Disable FlashAir Drive"));
            webdavModes.Add(new KeyValuePair<int, string>(1, "Read only - mode"));
            webdavModes.Add(new KeyValuePair<int, string>(2, "Read/write - mode"));
            VendorWebDav.DataSource = webdavModes;
        }

        private void AddTiles()
        {
            RightPanel.Controls.Clear();
            int xTileCount =1+ RightPanel.Width / _tileSize;
            int yTileCount =1+ RightPanel.Height / _tileSize;

            for (int x=0; x<xTileCount; x++)
            {
                for (int y=0; y<yTileCount; y++)
                {
                    MetroTile tile = new MetroTile();
                    tile.Left = (_tileSize + _tileMargin) * x - _tileMargin / 2;
                    tile.Top = (_tileSize + _tileMargin) * y - _tileMargin / 2;
                    tile.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    tile.Width = _tileSize;
                    tile.Height = _tileSize;
                    tile.Style = GetRandomStyle();
                    tile.TileImageAlign = ContentAlignment.MiddleCenter;
                    tile.UseTileImage = true;
                    RightPanel.Controls.Add(tile);
                    Application.DoEvents();
                }
            }
        }

        private MetroFramework.MetroColorStyle GetRandomStyle()
        {
            string[] styles = Enum.GetNames(typeof(MetroFramework.MetroColorStyle));
            return (MetroFramework.MetroColorStyle) Enum.Parse(typeof(MetroFramework.MetroColorStyle), styles[_random.Next(styles.Length)]);

        }

        private void SettingsPanel_Resize(object sender, EventArgs e)
        {
            AddTiles();
            ChangeImages();
        }

        private void ChangeImages()
        {

            if (RightPanel.Controls.Count > 0)
            {
                foreach (MetroTile tile in RightPanel.Controls)
                {
                    tile.TileImage = UiSettings.ResizedImage(_tileSize, _tileSize);
                    Application.DoEvents();
                }
            }
            RightPanel.Refresh();
        }

        private void ChangeImage()
        {
            if (RightPanel.Controls.Count > 0)
            {
                int currentImage = _random.Next(RightPanel.Controls.Count);
                var tile = ((MetroTile)RightPanel.Controls[currentImage]);
                tile.TileImage = UiSettings.ResizedImage(_tileSize, _tileSize);
                tile.Refresh();
            }
        }

        private void DisableControls()
        {
            SaveSettings.Enabled = false;
            CardSettingsTab.Enabled = false;
        }

        private void EnableControls()
        {
            SaveSettings.Enabled = true;
            CardSettingsTab.Enabled = true;
        }

        private void LoadSettingsFromFile(string filename)
        {
            FileLoader fl = new FileLoader();
            _settings = fl.LoadFromFile(filename);
            DisplaySettings();
        }

        Backend.Settings _settings;

        private void DisplaySettings()
        {
            if (_settings==null)
            {
                DisableControls();
                return;
            }

            UiSettings.CardVersion = _settings.Version;
            VendorAppAutoTime.Value = _settings.AppAutoTime;
            VendorAppInfo.Value = _settings.AppInfo;
            VendorAppMode.Value = _settings.AppMode;
            VendorAppname.Value = _settings.AppName;
            VendorBootScreenPath.Value = _settings.CiPath;
            VendorCid.Value = _settings.Cid;
            VendorCode.Value = _settings.ProductCode;
            VendorDns.Value = _settings.DnsAlways ? 1 : 0;
            VendorFirmware.Value = _settings.FirmwareVersion;
            VendorIfMode.Value = _settings.InterfaceEnabled;
            VendorLock.Value = _settings.Locked;
            VendorLuaPathBoot.Value = _settings.LuaRunScript;
            VendorLuaWrite.Value = _settings.LuaSdEvent;
            VendorMasterCode.Value = _settings.Mastercode;
            if (_settings.AppMode==3 || _settings.AppMode==6)
            {
                VendorNetworkKey.Value = _settings.BrgNetworkKey;
                VendorSSID.Value = _settings.BrgSsid;
            } else
            {
                VendorNetworkKey.Value = _settings.AppNetworkKey;
                VendorSSID.Value = _settings.AppSsid;
            }
            VendorNoiseCancel.Value = _settings.NoiseCancel;
            VendorProductCode.Value = _settings.ProductCode;
            VendorStaRetry.Value = _settings.StaRetries;
            VendorTimezone.Value = _settings.TimeZone;
            VendorUploadDir.Value = _settings.UploadDir;
            VendorUploadEnabled.Value = _settings.UploadEnabled;
            VendorWebDav.Value = _settings.WebDavMode;

            WlansdDhcp.Value = _settings.WlanSdDhcpEnabled;
            WlansdDns.Value = _settings.WlanSdPreferredDns;
            WlansdDnsAlternate.Value = _settings.WlanSdAlternateDns;
            WlansdGateway.Value = _settings.WlanSdDefaultGateway;
            WlansdId.Value = _settings.WlanSdCardId;
            WlansdIpAddress.Value = _settings.WlanSdIpAddress;
            WlansdProxyPort.Value = _settings.WlanSdProxyAddress;
            WlansdSubnet.Value = _settings.WlanSdSubnetMask;
            WlansdUseProxy.Value = _settings.WlanSdProxyEnabled;
            Wlansd_ProxyServer.Value = _settings.WlanSdProxyAddress;
            
            EnableControls();
        }




        private void LoadSettingsFromFile()
        {
            LoadTile.Text = "Search for File...";
            Application.DoEvents();
            for (char drive = 'D'; drive <= 'Z'; drive++)
            {
                string drivePath = $"{drive}:";
                string settingsPath = $"{drivePath}\\SD_WLAN";
                string settingsFile = $"{settingsPath}\\CONFIG";
                try
                {
                    LoadTile.Text = $"Search for File on {drivePath}";
                    Application.DoEvents();
                    if (Directory.Exists($"{drivePath}\\"))
                    {
                        if (Directory.Exists(settingsPath))
                        {
                            if (File.Exists(settingsFile))
                            {
                                LoadTile.Text = "Loading Settings";
                                Application.DoEvents();
                                LoadSettingsFromFile(settingsFile);
                                var settingsFileInfo = new FileInfo(settingsFile);
                                if (!settingsFileInfo.IsReadOnly)
                                {
                                    SaveSettings.Enabled = true;
                                }

                                LoadTile.Visible = false;
                            }
                        }




                    }

                }
                catch     
                {
                    // ignore non-existing drive
                }
            }
        }

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            LoadSettingsFromFile();
        }
    }
}
