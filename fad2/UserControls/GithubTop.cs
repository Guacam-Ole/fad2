using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Interfaces;

namespace fad2.UI.UserControls
{
    public partial class GithubTop : MetroUserControl
    {
        
        public GithubTop()
        {
            InitializeComponent();
        }

        private void MetroNewIssue_Click(object sender, EventArgs e)
        {
            string newIssueUrl =$"https://github.com/{Properties.Settings.Default.GIthubAuthor}/{Properties.Settings.Default.GithubRepo}/issues/new?body=%60Program-Version%3A%20{Application.ProductVersion}%60%0A%0A";
            Process.Start(newIssueUrl);
        }

        private void GithubLink_Click(object sender, EventArgs e)
        {
            string githubUrl= $"https://github.com/{Properties.Settings.Default.GIthubAuthor}/{Properties.Settings.Default.GithubRepo}/issues";
            Process.Start(githubUrl);
        }
    }
}
