using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.IO;
using fad2.Backend;
using fad2.UI.UserControls;
using System.Linq;
using log4net;

namespace fad2.UI
{
    public partial class Settings : UserControl
    {
        private ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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

            string[] ignoreProperties = new string[] { "DNSMODE", "BRGNETWORKKEY", "BRGSSID", "APPNETWORKKEY", "APPSSID" };
            UiSettings.CardVersion = _settings.Version;
            foreach (var property in _settings.GetType().GetProperties())
            {    try
                {      
                    
                    var customAttribute = (SettingAttribute)property.GetCustomAttributes(typeof(SettingAttribute), true).FirstOrDefault();
                    if (customAttribute != null)
                    {
                        string internalName = customAttribute.Name;
                        if (ignoreProperties.Contains(internalName))
                        {
                            continue;
                        }
                        string trueValue = customAttribute.TrueValue;
                        var value = property.GetValue(_settings, null);
                        SetControlValue(internalName, value, trueValue);
                    }
                } catch(Exception ex)
                {
                    _log.Error(ex);
                }
            }

            VendorDns.Value = _settings.DnsAlways ? 1 : 0;
            if (_settings.AppMode == 3 || _settings.AppMode == 6)
            {
                VendorNetworkKey.Value = _settings.BrgNetworkKey;
                VendorSSID.Value = _settings.BrgSsid;
            }
            else
            {
                VendorNetworkKey.Value = _settings.AppNetworkKey;
                VendorSSID.Value = _settings.AppSsid;
            }

            EnableControls();
        }




        private void LoadSettingsFromFile()
        {
            LoadTile.Visible = true;
            LoadSpinner.Visible = true;
            LoadTile.Style = MetroFramework.MetroColorStyle.Default;
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
                                return;
                            }
                        }
                    }

                }
                catch     
                {
                    // ignore non-existing drive
                }
            }
            LoadTile.Style = MetroFramework.MetroColorStyle.Orange;
            LoadSpinner.Visible = false;
            LoadTile.Text = "File not found";
        }

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            LoadSettingsFromFile();
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
           
        }

        private void SetControlValue(string internalName, object value, string trueValue)
        {
            Control targetControl = FindControlByInternalName(internalName);
            if (targetControl==null)
            {
                return;
            }
            if (targetControl is SettingsBoolean)
            {
                ((SettingsBoolean)targetControl).Value = (bool)value ;
            } else if (targetControl is SettingsCombo)
            {
                ((SettingsCombo)targetControl).Value = (int)value;
            } else if (targetControl is SettingsIp || targetControl is SettingsString)
            {
                ((SettingsString)targetControl).Value = value as string;
            } else if (targetControl is SettingsSlider || targetControl is SettingsTimeSlider)
            {
                ((SettingsSlider)targetControl).Value = (int)value;
            }
        }

        private Control FindControlByInternalName(string internalName)
        {
            foreach (Control setting in CardSettingsVendor.Controls)
            {
                var nameProperty = setting.GetType().GetProperty("InternalName");
                if (nameProperty != null)
                {
                    string namePropertyValue = (string)nameProperty.GetValue(setting, null);
                    if (namePropertyValue == internalName)
                    {
                        return setting;
                    }
                }
            }
            foreach (Control setting in CardSettingsNetwork.Controls)
            {
                var nameProperty = setting.GetType().GetProperty("InternalName");
                if (nameProperty != null)
                {
                    string namePropertyValue = (string)nameProperty.GetValue(setting, null);
                    if (namePropertyValue == internalName)
                    {
                        return setting;
                    }
                }
            }
            return null;
        }
    }
}
