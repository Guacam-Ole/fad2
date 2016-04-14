using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fad2.UI.UserControls;
using MetroFramework.Controls;

namespace fad2.UI
{
    public partial class Settings : UserControl
    {

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
            int xTileCount =1+ RightPanel.Width / 110;
            int yTileCount =1+ RightPanel.Height / 110;

            for (int x=0; x<xTileCount; x++)
            {
                for (int y=0; y<yTileCount; y++)
                {
                    MetroTile tile = new MetroTile();
                    tile.Left = 110 * x -5;
                    tile.Top = 110 * y - 5;
                    tile.Anchor = AnchorStyles.Top | AnchorStyles.Left;
                    tile.Width = 100;
                    tile.Height = 100;
                    tile.Style = GetRandomStyle();
                    tile.TileImageAlign = ContentAlignment.MiddleCenter;
                    tile.UseTileImage = true;
                    
               //     tile.Text = $"{x},{y}";
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
                    tile.TileImage = UiSettings.ResizedImage(100, 100);
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
                tile.TileImage = UiSettings.ResizedImage(100, 100);
                tile.Refresh();
            }
        }
    }
}
