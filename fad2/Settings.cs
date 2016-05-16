using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using fad2.Backend;
using fad2.UI.Properties;
using fad2.UI.UserControls;
using log4net;
using MetroFramework;
using MetroFramework.Controls;

namespace fad2.UI
{
    /// <summary>
    /// Settings-Control
    /// </summary>
    public partial class Settings : UserControl
    {
        private const int TileSize = 300;
        private const int TileMargin = 20;

        private readonly string[] _ignoreProperties =
        {
            "DNSMODE", "BRGNETWORKKEY", "BRGSSID", "APPNETWORKKEY", "APPSSID"
        };

        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly string _programSettingsFile = Application.StartupPath + "\\fad2.json";
        private readonly Random _random = new Random();

        private string _formatString;
        private string _previewString;

        private ProgramSettings _programSettings;

        private Backend.Settings _settings;

        /// <summary>
        /// Settings
        /// </summary>
        public Settings()
        {
            InitializeComponent();
            SetCombos();

            LoadProgramSettings();
            var backImageTimer = new Timer {Interval = _programSettings.BackgroundInterval*1000};
            backImageTimer.Tick += _backImageTimer_Tick;
            if (_programSettings.ShowTiles)
            {
                backImageTimer.Start();
            }

            DisableControls();
        }


        private void LoadProgramSettings()
        {
            _programSettings = new FileLoader().LoadProgramSettings(_programSettingsFile);
            ApplicationUrl.Value = _programSettings.FlashAirUrl;
            LocalPath.Value = _programSettings.LocalPath;
            FilesExist.Value = _programSettings.ExistingFiles;
            DeleteFiles.Value = _programSettings.DeleteFiles;
            MultiCards.Value = _programSettings.MultiCardsFolder;
            DateCreation.Value = _programSettings.CreateByDate;
            CustomFolderCreation.Value = _programSettings.FolderFomat;
            ServiceInterval.Value = _programSettings.FileCheckInterval;
            LoadThumbs.Value = _programSettings.LoadThumbs;
            FiletypesToCopy.Value = _programSettings.FileTypesToCopy;
            StartupPath.Value = _programSettings.CardStartupPath;
            BackgroundInterval.Value = _programSettings.BackgroundInterval;
            Backgroundlocation.Value = _programSettings.ImageBackgroundFolder;
            ShowBackimages.Value = _programSettings.ShowBackgroundImage;
            ShowTiles.Value = _programSettings.ShowTiles;
            CheckForUpdates.Value = _programSettings.CheckForUpdates;
        }


        private void _backImageTimer_Tick(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void SetCombos()
        {
            var appModes = new Dictionary<int, string>
            {
                {(int) ProgramSettings.AppModes.AccessPoint, "AP (Access Point) mode "},
                {(int) ProgramSettings.AppModes.Station, "STA (Station) mode "},
                {(int) ProgramSettings.AppModes.PassThru, "Pass-Thru mode"},
                {(int) ProgramSettings.AppModes.AccessPointNo, "AP (Access Point) mode (Keep Write-Protect)"},
                {(int) ProgramSettings.AppModes.StationNo, "STA (Station) mode (Keep Write-Protect)"},
                {(int) ProgramSettings.AppModes.PassThruNo, "Pass-Thru mode (Keep Write-Protect)"}
            };
            VendorAppMode.DataSource = appModes.ToList();

            var dnsModes = new Dictionary<int, string>
            {
                {(int) ProgramSettings.DnsModes.OnlyAppName, "Return IP Only if request is done with APPNAME"},
                {(int) ProgramSettings.DnsModes.Always, "Always return IP to DNS requests (default)"}
            };
            VendorDns.DataSource = dnsModes.ToList();

            var webdavModes = new Dictionary<int, string>
            {
                {(int) ProgramSettings.WebDavModes.Disable, "Disable FlashAir Drive"},
                {(int) ProgramSettings.WebDavModes.ReadOnly, "Read only - mode"},
                {(int) ProgramSettings.WebDavModes.ReadWrite, "Read/write - mode"}
            };
            VendorWebDav.DataSource = webdavModes.ToList();

            var perCardDirectory = new Dictionary<int, string>
            {
                {(int) ProgramSettings.CardDirModes.NoDirectory, "No Subdirectory per Card"},
                {(int) ProgramSettings.CardDirModes.CardId, "Use Card Id"},
                {(int) ProgramSettings.CardDirModes.ApplicationName, "Use Application Name"}
            };
            MultiCards.DataSource = perCardDirectory.ToList();

            var dateCreation = new Dictionary<int, string>
            {
                {(int) ProgramSettings.DateModes.NoDirectory, "Don't create Subfolder"},
                {(int) ProgramSettings.DateModes.Year, "Year"},
                {(int) ProgramSettings.DateModes.Month, "Year-Month"},
                {(int) ProgramSettings.DateModes.Day, "Year-Month-Day"},
                {(int) ProgramSettings.DateModes.Custom, "Custom"}
            };
            DateCreation.DataSource = dateCreation.ToList();

            var existingFiles = new Dictionary<int, string>
            {
                {(int) ProgramSettings.OverwriteModes.Never, "Never Overwrite"},
                {(int) ProgramSettings.OverwriteModes.Newer, "Overwrite if newer"},
                {(int) ProgramSettings.OverwriteModes.Always, "Always overwrite"},
                {(int) ProgramSettings.OverwriteModes.Copy, "Create copy"}
            };
            FilesExist.DataSource = existingFiles.ToList();

            var serviceOptions = new Dictionary<int, string>
            {
                {(int) ProgramSettings.ServiceOption.Install, "Install Service"},
                {(int) ProgramSettings.ServiceOption.Uninstall, "Uninstall Service"},
                {(int) ProgramSettings.ServiceOption.Start, "Start Service"},
                {(int) ProgramSettings.ServiceOption.Stop, "Stop Service"}
            };
            ServiceActions.DataSource = serviceOptions.ToList();


            var fileTypes = new Dictionary<int, string>
            {
                {(int) ProgramSettings.FileTypes.Images, "Images"},
                {(int) ProgramSettings.FileTypes.Videos, "Images and Videos"},
                {(int) ProgramSettings.FileTypes.AllFiles, "All Files"}
            };
            FiletypesToCopy.DataSource = fileTypes.ToList();
          
        }


        private void AddTiles()
        {
            RightPanel.Controls.Clear();
            var xTileCount = 1 + RightPanel.Width/TileSize;
            var yTileCount = 1 + RightPanel.Height/TileSize;

            for (var x = 0; x < xTileCount; x++)
            {
                for (var y = 0; y < yTileCount; y++)
                {
                    var tile = new MetroTile
                    {
                        Left = (TileSize + TileMargin)*x - TileMargin/2,
                        Top = (TileSize + TileMargin)*y - TileMargin/2,
                        Anchor = AnchorStyles.Top | AnchorStyles.Left,
                        Width = TileSize,
                        Height = TileSize,
                        Style = GetRandomStyle(),
                        TileImageAlign = ContentAlignment.MiddleCenter,
                        UseTileImage = true
                    };
                    RightPanel.Controls.Add(tile);
                    Application.DoEvents();
                }
            }
        }

        private MetroColorStyle GetRandomStyle()
        {
            var styles = Enum.GetNames(typeof(MetroColorStyle));
            return (MetroColorStyle) Enum.Parse(typeof(MetroColorStyle), styles[_random.Next(styles.Length)]);
        }

        private void SettingsPanel_Resize(object sender, EventArgs e)
        {
            if (_programSettings == null)
            {
                return; // Settings not loaded yet
            }

            if (!_programSettings.ShowTiles)
            {
                return;
            }
            AddTiles();
            ChangeImages();
        }

        private void ChangeImages()
        {
            if (RightPanel.Controls.Count > 0)
            {
                foreach (MetroTile tile in RightPanel.Controls)
                {
                    tile.TileImage = UiSettings.ResizedImage(TileSize, TileSize);
                    Application.DoEvents();
                }
            }
            RightPanel.Refresh();
        }

        private void ChangeImage()
        {
            if (RightPanel.Controls.Count <= 0) return;
            var currentImage = _random.Next(RightPanel.Controls.Count);
            var imageControl = RightPanel.Controls[currentImage];
            if (imageControl is MetroTile)
            {
                var tile = (MetroTile) RightPanel.Controls[currentImage];
                tile.TileImage = UiSettings.ResizedImage(TileSize, TileSize);
                tile.Refresh();
            }
        }

        private void DisableControls()
        {
            SaveSettings.Enabled = false;
            if (CardSettingsTab.TabPages.Count <= 1) return;
            CardSettingsTab.TabPages.Remove(CardSettingsVendor);
            CardSettingsTab.TabPages.Remove(CardSettingsNetwork);
            CardSettingsTab.TabPages.Remove(CardSettingsDisable);
        }

        private void EnableControls()
        {
            SaveSettings.Enabled = true;
            if (CardSettingsTab.TabPages.Count != 1) return;
            CardSettingsTab.TabPages.Add(CardSettingsVendor);
            CardSettingsTab.TabPages.Add(CardSettingsNetwork);
            CardSettingsTab.TabPages.Add(CardSettingsDisable);
        }

        private void LoadFlashairSettingsFromFile(string filename)
        {
            var fl = new FileLoader();
            _settings = fl.LoadFromFile(filename);
            DisplayFlashairSettings();
        }


        private void ReadFlashairSettings()
        {
            if (_settings == null)
            {
                DisableControls();
                return;
            }
            foreach (var property in _settings.GetType().GetProperties())
            {
                try
                {
                    var customAttribute =
                        (SettingAttribute) property.GetCustomAttributes(typeof(SettingAttribute), true).FirstOrDefault();
                    if (customAttribute == null) continue;
                    var internalName = customAttribute.Name;
                    if (_ignoreProperties.Contains(internalName))
                    {
                        continue;
                    }
                    var newSetting = GetControlValue(internalName);
                    if (newSetting == null)
                    {
                        continue; // No changes made
                    }
                    property.SetValue(_settings, newSetting, null);
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }

            _settings.DnsAlways = VendorDns.Value == 1;
            if (_settings.AppMode == 3 || _settings.AppMode == 6)
            {
                _settings.BrgNetworkKey = VendorNetworkKey.Value;
                _settings.BrgSsid = VendorSSID.Value;
            }
            else
            {
                _settings.AppNetworkKey = VendorNetworkKey.Value;
                _settings.AppSsid = VendorSSID.Value;
            }

            _settings.DisableCgi = string.Empty;
            if (DisableDownload.Value)
            {
                _settings.DisableCgi += ",/";
            }
            if (DisableCommand.Value)
            {
                _settings.DisableCgi += ",/command.cgi";
            }
            if (DisableThumbnails.Value)
            {
                _settings.DisableCgi += ",/thumbnail.cgi";
            }
            if (DisableUploads.Value)
            {
                _settings.DisableCgi += ",/upload.cgi";
            }
            if (!string.IsNullOrWhiteSpace(_settings.DisableCgi))
            {
                _settings.DisableCgi = _settings.DisableCgi.Substring(1);
            }
        }

        private void DisplayFlashairSettings()
        {
            if (_settings == null)
            {
                DisableControls();
                return;
            }

            UiSettings.CardVersion = _settings.Version;
            Application.DoEvents();
            foreach (var property in _settings.GetType().GetProperties())
            {
                try
                {
                    var customAttribute =
                        (SettingAttribute) property.GetCustomAttributes(typeof(SettingAttribute), true).FirstOrDefault();
                    if (customAttribute == null) continue;
                    var internalName = customAttribute.Name;
                    if (_ignoreProperties.Contains(internalName))
                    {
                        continue;
                    }
                    var value = property.GetValue(_settings, null);
                    SetControlValue(internalName, value);
                }
                catch (Exception ex)
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


            var disableDownload = false;
            var disableCommand = false;
            var disableUpload = false;
            var disableThumbnails = false;

            if (!string.IsNullOrWhiteSpace(_settings.DisableCgi))
            {
                var disabledCgis = _settings.DisableCgi.Split(',');
                foreach (var disabledCgi in disabledCgis)
                {
                    disableDownload |= disabledCgi == "/";
                    disableCommand |= disabledCgi == "/command.cgi";
                    disableUpload |= disabledCgi == "/upload.cgi";
                    disableThumbnails |= disabledCgi == "/thumbnail.cgi";
                }
            }
            DisableDownload.Value = disableDownload;
            DisableCommand.Value = disableCommand;
            DisableUploads.Value = disableUpload;
            DisableThumbnails.Value = disableThumbnails;

            EnableControls();
        }


        private string GetFlashairSettingsFile()
        {
            LoadTile.Visible = true;
            LoadSpinner.Visible = true;
            LoadTile.Style = MetroColorStyle.Default;
            LoadTile.Text = Resources.SearchForFile;
            Application.DoEvents();
            for (var drive = 'D'; drive <= 'Z'; drive++)
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
                                return settingsFile;
                            }
                        }
                    }
                }
                catch
                {
                    // ignore non-existing drive
                }
            }
            return null;
        }

        private void SaveFlashairSettingsToFile(string fileName)
        {
            ReadFlashairSettings();
            var fl = new FileLoader();
            if (fl.SaveToFile(Application.ProductVersion, fileName, _settings))
            {
                MetroMessageBox.Show(this, "Settings saved", "Flashair-Settings");
            }
            else
            {
                MetroMessageBox.Show(this, "Saving Settings FAILED. Please check if the file/card is write protected.", "Flashair-Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFlashairSettingsToFile()
        {
            var settingsFile = GetFlashairSettingsFile();
            if (settingsFile != null)
            {
                LoadTile.Text = Resources.SavingSettings;
                Application.DoEvents();
                SaveFlashairSettingsToFile(settingsFile);
                LoadTile.Visible = false;
                return;
            }
            LoadTile.Style = MetroColorStyle.Orange;
            LoadSpinner.Visible = false;
            LoadTile.Text = Resources.FileNotFound;
        }

        private void LoadFlashairSettingsFromFile()
        {
            var settingsFile = GetFlashairSettingsFile();
            if (settingsFile != null)
            {
                LoadTile.Text = Resources.LoadingSettings;
                Application.DoEvents();
                LoadFlashairSettingsFromFile(settingsFile);
                var settingsFileInfo = new FileInfo(settingsFile);
                if (!settingsFileInfo.IsReadOnly)
                {
                    SaveSettings.Enabled = true;
                }

                LoadTile.Visible = false;
            }

            LoadTile.Style = MetroColorStyle.Orange;
            LoadSpinner.Visible = false;
            LoadTile.Text = Resources.FileNotFound;
        }

        private void LoadFromFile_Click(object sender, EventArgs e)
        {
            LoadFlashairSettingsFromFile();
        }

        private void SaveSettings_Click(object sender, EventArgs e)
        {
            SaveFlashairSettingsToFile();
        }

        private object GetControlValue(string internalName)
        {
            var targetControl = FindControlByInternalName(internalName);
            if (targetControl == null)
            {
                return null;
            }

            var valueChangedProperty = targetControl.GetType().GetProperty("ValueChanged");
            var valueProperty = targetControl.GetType().GetProperty("Value");

            if (valueChangedProperty == null || valueProperty == null)
            {
                return null;
            }

            var hasChanged = (bool) valueChangedProperty.GetValue(targetControl, null);
            return !hasChanged ? null : valueProperty.GetValue(targetControl, null);
        }

        private void SetControlValue(string internalName, object value)
        {
            var targetControl = FindControlByInternalName(internalName);
            if (targetControl == null)
            {
                return;
            }
            if (targetControl is SettingsBoolean)
            {
                ((SettingsBoolean) targetControl).Value = (bool) value;
            }
            else if (targetControl is SettingsCombo)
            {
                ((SettingsCombo) targetControl).Value = (int) value;
            }
            else if (targetControl is SettingsString)
            {
                ((SettingsString) targetControl).Value = value as string;
            }
            else if (targetControl is SettingsSlider)
            {
                ((SettingsSlider) targetControl).Value = (int) value;
            }
        }

        private Control FindControlByInternalName(string internalName)
        {
            foreach (Control setting in CardSettingsVendor.Controls)
            {
                var nameProperty = setting.GetType().GetProperty("InternalName");
                if (nameProperty == null) continue;
                var namePropertyValue = (string) nameProperty.GetValue(setting, null);
                if (namePropertyValue == internalName)
                {
                    return setting;
                }
            }
            foreach (Control setting in CardSettingsNetwork.Controls)
            {
                var nameProperty = setting.GetType().GetProperty("InternalName");
                if (nameProperty == null) continue;
                var namePropertyValue = (string) nameProperty.GetValue(setting, null);
                if (namePropertyValue == internalName)
                {
                    return setting;
                }
            }
            return null;
        }

        private void DateCreation_ComboChanged(object sender, EventArgs e)
        {
            ShowFolderSetting();
        }

        private void ShowFolderSetting()
        {
            CustomFolderCreation.Enabled = DateCreation.Value == 4;
            switch (MultiCards.Value)
            {
                case 1:
                    _formatString = "{0}\\";
                    break;
                case 2:
                    _formatString = "{1}\\";
                    break;
                default:
                    _formatString = string.Empty;
                    break;
            }
            switch (DateCreation.Value)
            {
                case 0:
                    // No Subfolder
                    break;
                case 1:
                    // year
                    _formatString += "{2:yyyy}";
                    break;
                case 2:
                    // month:
                    _formatString += "{2:yyyy-MM}";
                    break;
                case 3:
                case 4:
                    // day
                    _formatString += "{2:yyyy-MM-dd}";
                    break;
            }
            _previewString = string.Format(LocalPath.Value + _formatString, "CARDID", "APPID", DateTime.Now);
            CustomFolderCreation.Value = _formatString;
            PathPreview.Value = _previewString;
        }

        private void MultiCards_ComboChanged(object sender, EventArgs e)
        {
            ShowFolderSetting();
        }


        private void SaveProgramSettings()
        {
            _programSettings.LocalPath = LocalPath.Value;
            _programSettings.CreateByDate = DateCreation.Value ?? 0;
            _programSettings.DeleteFiles = DeleteFiles.Value;
            _programSettings.ExistingFiles = FilesExist.Value ?? 0;
            _programSettings.FileCheckInterval = ServiceInterval.Value;
            _programSettings.FlashAirUrl = ApplicationUrl.Value;
            _programSettings.FolderFomat = CustomFolderCreation.Value;
            _programSettings.MultiCardsFolder = MultiCards.Value ?? 0;
            _programSettings.FileTypesToCopy = FiletypesToCopy.Value ?? 1;
            _programSettings.LoadThumbs = LoadThumbs.Value;
            _programSettings.CardStartupPath = StartupPath.Value;
            _programSettings.BackgroundInterval = BackgroundInterval.Value;
            _programSettings.ImageBackgroundFolder = Backgroundlocation.Value;
            _programSettings.ShowBackgroundImage = ShowBackimages.Value;
            _programSettings.ShowTiles = ShowTiles.Value;
            _programSettings.CheckForUpdates = CheckForUpdates.Value;

            new FileLoader().SaveProgramSettings(_programSettings, _programSettingsFile);
        }

        private void SaveProgSettings_Click(object sender, EventArgs e)
        {
            SaveProgramSettings();
            LoadProgramSettings();
        }
    }
}