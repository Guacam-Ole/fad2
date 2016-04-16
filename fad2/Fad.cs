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

        string _flashAirVersion="2.0.0";
       // private string _newIssueUrl = $"https://github.com/OleAlbers/GooglePlusOptimizer/issues/new?body=%60Program-Version%3A%20{Application.ProductVersion}%60%0A%60FlashAir-Version%3A%20{_flashAirVersion}1.0.0.0%60";
        

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
        private void ShowIssues()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new GitHub { Dock = DockStyle.Fill });
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

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateIssue.Visible = true;
            ShowIssues();
        }

        private void CreateIssue_Click(object sender, EventArgs e)
        {

            string _newIssueUrl = $"https://github.com/OleAlbers/GooglePlusOptimizer/issues/new?body=%60Program-Version%3A%20{Application.ProductVersion}%60%0A%60FlashAir-Version%3A%20{_flashAirVersion}%60%0A%0A";


        System.Diagnostics.Process.Start(_newIssueUrl);
        }

        private void FadMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CreateIssue.Visible = false;
        }

      
    }
}
