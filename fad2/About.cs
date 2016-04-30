using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace fad2.UI
{
    public partial class About : MetroForm
    {
        public About()
        {
            InitializeComponent();
            AboutMeText.Text = Properties.Resources.AboutMe;
        }



        private void CloseWin_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void Donate_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=38M5R54WMYWN4");
        }
    }
}
