using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fad2.UI.UserControls;

namespace fad2.UI
{
    public partial class GitHub : UserControl
    {
        public GitHub()
        {
            InitializeComponent();
            LoadGitHubValues();
        }

        private void LoadGitHubValues()
        {

            this.Controls.Clear();
            var allIssues=Backend.GitHub.GetIssues($"{Application.StartupPath}\\github.cache","OleAlbers", "GooglePlusOptimizer");
            if (allIssues != null)
            {
                foreach (var issue in allIssues)
                {
                    var starter = new IssueStarter();
                    //starter.Comments = issue.Comments;
                    starter.IsBug = issue.IsBug;
                    starter.IsFeatureRequest = issue.IsWish;
                    starter.IssueComment = issue.Comment;
                    starter.Pipeline = issue.Pipeline;
                    starter.Comments = issue.Comments?.Select(cm => cm.Comment).ToList();
                    starter.Dock = DockStyle.Top;
                    this.Controls.Add(starter);
                }
            }


            //var comments = new List<GitHubComment>();
            //comments.Add(new GitHubComment
            //{
            //    Comment = "Erster!",
            //    Author = "Lustiger Typ",
            //    Date = new DateTime(2016, 5, 2),
            //    Picture = "https://avatars.githubusercontent.com/u/4692497?v=3"
            //});
            //comments.Add(new GitHubComment
            //{
            //    Comment = "Das ist so albern",
            //    Author = "Ernster Typ",
            //    Date = new DateTime(2016, 5, 22)
            //});
            //comments.Add(new GitHubComment
            //{
            //    Comment = "Das ist so albern",
            //    Author = "Ernster Typ",
            //    Date = new DateTime(2016, 5, 22)
            //});
            //comments.Add(new GitHubComment
            //{
            //    Comment = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.",
            //    Author = "Ernster Typ",
            //    Date = new DateTime(2016, 5, 22)
            //});
            //comments.Add(new GitHubComment
            //{
            //    Comment = "Das ist so albern",
            //    Author = "Ernster Typ",
            //    Date = new DateTime(2016, 5, 22)
            //});
            //comments.Add(new GitHubComment
            //{
            //    Comment = "Das ist so albern",
            //    Author = "Ernster Typ",
            //    Date = new DateTime(2016, 5, 22)
            //});
            //issueStarter1.IssueComment = new GitHubComment
            //{
            //    Comment = "JLorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est Lorem ipsum dolor sit amet.!",
            //    Author = "Ole Albers",
            //    Date = new DateTime(2015, 1, 1),
            //    Picture = "https://avatars1.githubusercontent.com/u/neeeee.png",
            //    Title = "Da ist was faul!"
            //};
            //issueStarter1.Comments = comments;
           
        }
    }
}
