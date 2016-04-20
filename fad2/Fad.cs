using System;
using System.Diagnostics;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace fad2.UI
{
    public partial class Fad : MetroForm
    {
       

        public Fad()
        {
            InitializeComponent();
            ShowLoader();
        }

        public void ShowLoader()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new StartUp {Dock = DockStyle.Fill});
        }

        private void ShowSettings()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new Settings {Dock = DockStyle.Fill});
        }

        private void ShowIssues()
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(new GitHub {Dock = DockStyle.Fill});
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Fad_Resize(object sender, EventArgs e)
        {
            //   this.Text = $"{Width}x{Height}";
        }

        private void supportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateIssue.Visible = true;
            ShowIssues();
        }

        private void CreateIssue_Click(object sender, EventArgs e)
        {
           
        }

        private void FadMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            CreateIssue.Visible = false;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoader();
        }
    }
}