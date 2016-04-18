using System.Linq;
using System.Windows.Forms;
using fad2.UI.UserControls;

namespace fad2.UI
{
    public partial class GitHub : UserControl
    {
        public GitHub()
        {
            InitializeComponent();
            Application.DoEvents();
            LoadGitHubValues();
        }

        private void LoadGitHubValues()
        {
            Controls.Clear();
            var allIssues = Backend.GitHub.GetIssues($"{Application.StartupPath}\\github.cache", "OleAlbers",
                "GooglePlusOptimizer");
            if (allIssues == null) return;
            var counter = 0;
            ProgressLoad.Value = 0;
            ProgressLoad.Maximum = allIssues.Count;
            foreach (var issue in allIssues)
            {
                counter++;
                var starter = new IssueStarter
                {
                    IsBug = issue.IsBug,
                    IsFeatureRequest = issue.IsWish,
                    IssueComment = issue.Comment,
                    Pipeline = issue.Pipeline,
                    Comments = issue.Comments?.Select(cm => cm.Comment).ToList(),
                    Dock = DockStyle.Top
                };
                Controls.Add(starter);
                ProgressLoad.Value = counter;
                Application.DoEvents();
            }
        }
    }
}