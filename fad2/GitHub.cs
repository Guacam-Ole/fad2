using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using fad2.Backend.Github;
using fad2.UI.UserControls;
using log4net;

namespace fad2.UI
{
    public partial class GitHub : UserControl
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public GitHub()
        {
            InitializeComponent();
            Application.DoEvents();
            LoadGitHubValues();
        }

        private string GetPipeLineForIssue(ZenHubBoard board, int issueNumber)
        {
            if (board == null)
            {
                return null;
            }
            return (from pipeline in board.Pipelines where pipeline.Issues.Any(issue => issue.Number == issueNumber) select pipeline.Name).FirstOrDefault();
        }

 

        private void LoadGitHubValues()
        {
            var gitHubTop = new GithubTop { Dock = DockStyle.Top };
            Controls.Add(gitHubTop);
            Application.DoEvents();
            
            var allIssues = Backend.GitHub.GetIssues($"{Application.StartupPath}\\github.cache", Properties.Settings.Default.GIthubAuthor,Properties.Settings.Default.GithubRepo);
            if (allIssues == null) return;
            var board=Backend.GitHub.GetBoard($"{Application.StartupPath}\\zenhub.cache", Properties.Settings.Default.GIthubAuthor, Properties.Settings.Default.GithubRepo);
            var counter = 0;
            Controls.Clear();
            
            foreach (var issue in allIssues)
            {
                counter++;
                var starter = new IssueStarter
                {
                    Tag = counter,
                    IsBug = issue.IsBug,
                    IsFeatureRequest = issue.IsWish,
                    IssueComment = issue.Comment, 

                    Pipeline = GetPipeLineForIssue(board, issue.Number),
                    Comments = issue.Comments?.Select(cm => cm.Comment).ToList(),
                    Dock = DockStyle.Top
                };
                Controls.Add(starter);
                Application.DoEvents();
            }
            Controls.Add(gitHubTop);
            gitHubTop.Controls[0].Visible = false;
            gitHubTop.Controls[1].Visible = false;


            //  Controls = container.Controls;
        }
    }
}