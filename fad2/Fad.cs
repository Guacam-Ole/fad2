using System;
using System.Diagnostics;
using System.IO;
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
            ShowIssues();
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoader();
        }

        private void apiDocumentationforDevelopersToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Application.StartupPath, "LICENSE.TXT"));
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void apiDocumentationforDevelopers9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://flashair-developers.com/en/documents/api/");
        }

        private void setupHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/OleAlbers/fad2/wiki");
        }
    }
}