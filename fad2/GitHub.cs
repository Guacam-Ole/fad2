using System.Data;
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
            var allIssues=Backend.GitHub.GetIssues($"{Application.StartupPath}\\github.cache","OleAlbers", "GooglePlusOptimizer");
            if (allIssues != null)
            {
                int counter = 0;
                ProgressLoad.Value = 0;
                ProgressLoad.Maximum = allIssues.Count;
                foreach (var issue in allIssues)
                {
                    counter++;
                    var starter = new IssueStarter();
                    starter.IsBug = issue.IsBug;
                    starter.IsFeatureRequest = issue.IsWish;
                    starter.IssueComment = issue.Comment;
                    starter.Pipeline = issue.Pipeline;
                    starter.Comments = issue.Comments?.Select(cm => cm.Comment).ToList();
                    starter.Dock = DockStyle.Top;
                    Controls.Add(starter);
                    ProgressLoad.Value = counter;
                    Application.DoEvents();
                }
            }
        }
    }
}
