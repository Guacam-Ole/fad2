using System;
using System.Diagnostics;
using fad2.UI.Properties;
using MetroFramework.Forms;

namespace fad2.UI
{
    /// <summary>
    /// About Window
    /// </summary>
    public partial class About : MetroForm
    {
        /// <summary>
        /// About Window
        /// </summary>
        public About()
        {
            InitializeComponent();
            AboutMeText.Text = Resources.AboutMe;
        }

        private void CloseWin_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Donate_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=38M5R54WMYWN4");
        }
    }
}