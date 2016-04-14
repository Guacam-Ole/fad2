using fad2.Backend;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fad2.UI
{
    public partial class Fad : MetroFramework.Forms.MetroForm
    {
        
        

        public Fad()
        {
           
            InitializeComponent();
           ShowLoader();
          
         
        }

        private void ShowLoader()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new StartUp { Dock = DockStyle.Fill });
        }

        private void ShowSettings()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new Settings { Dock = DockStyle.Fill });
        }


        private void cardSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Fad_Resize(object sender, EventArgs e)
        {
            this.Text = $"{Width}x{Height}";
        }
    }
}
