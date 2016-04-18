using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using fad2.Backend;
using MetroFramework;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    public partial class IssueStarter : UserControl
    {
        private List<GitHubComment> _comments;

        private DateTime _date;


        private string _pipeline;

        public IssueStarter()
        {
            InitializeComponent();
        }

        public GitHubComment IssueComment
        {
            get
            {
                return new GitHubComment
                {
                    Title = Title.Text,
                    Comment = Content.Text,
                    Date = _date,
                    Picture = (string) Avatar.Tag,
                    Url = (string) WatchOnGitHub.Tag
                };
            }
            set
            {
                Title.Text = value.Title;
                Content.Text = value.Comment;
                _date = value.Date;
                Date.Text = $"{_date:yyyy-MM-dd}";
                WatchOnGitHub.Tag = value.Url;
                Avatar.Tag = value.Picture;
                AvatarName.SetToolTip(Avatar, value.Author);
                ReloadAvatar();
                RepaintComment();
            }
        }

        public bool IsBug
        {
            get { return BugTag.Visible; }
            set { BugTag.Visible = value; }
        }

        public bool IsFeatureRequest
        {
            get { return WishTag.Visible; }
            set { WishTag.Visible = value; }
        }

        public string Pipeline
        {
            get { return _pipeline; }
            set
            {
                _pipeline = value;
                SetMileStone();
            }
        }

        public List<GitHubComment> Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
                LoadComments();
            }
        }

        private void LoadComments()
        {
            CommentPanel.Controls.Clear();
            CommentPanel.Height = 10;
            if (_comments == null)
            {
                return;
            }
            foreach (var comment in _comments.OrderByDescending(cm => cm.Date))
            {
                var issueComment = new IssueComment();
                issueComment.Dock = DockStyle.Top;
                //    issueComment.Margin.Top = 20;
                issueComment.Container = comment;
                issueComment.AutoSize = true;
                issueComment.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                CommentPanel.Controls.Add(issueComment);
                //      CommentPanel.AutoSize = true;
                //   CommentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
        }

        private void SetMileStone()
        {
            MileStoneClosed.Style = MetroColorStyle.Silver;
            MileStoneDone.Style = MetroColorStyle.Silver;
            MileStoneInProgress.Style = MetroColorStyle.Silver;
            MileStoneNew.Style = MetroColorStyle.Silver;
            MileStoneToDo.Style = MetroColorStyle.Silver;

            switch (_pipeline)
            {
                case "Closed":
                    MileStoneClosed.Style = MetroColorStyle.Green;
                    break;
                case "Done":
                    MileStoneDone.Style = MetroColorStyle.Green;
                    break;
                case "In Progress":
                    MileStoneInProgress.Style = MetroColorStyle.Green;
                    break;
                case "New":
                    MileStoneNew.Style = MetroColorStyle.Green;
                    break;
                case "ToDo":
                    MileStoneToDo.Style = MetroColorStyle.Green;
                    break;
            }
        }


        private void ReloadAvatar()
        {
            var tag = (string) Avatar.Tag;
            if (tag != null && Uri.IsWellFormedUriString(tag, UriKind.Absolute))
            {
                var image = UiSettings.ResizedImage(new Uri(tag), 255, Avatar.Width, Avatar.Height);
                if (image != null)
                {
                    Avatar.TileImage = image;
                    Avatar.UseTileImage = true;
                }
            }
        }

        private void RepaintComment()
        {
            using (var g = CreateGraphics())
            {
                var size = g.MeasureString(Content.Text, Content.Font, Content.Width);
                Content.Height = (int) Math.Ceiling(size.Height) + 20;
            }
            WatchOnGitHub.Top = Content.Height + Content.Top + 10;
            ShowComments.Top = WatchOnGitHub.Top;
            CommentPanel.Top = WatchOnGitHub.Height + WatchOnGitHub.Top + 10;
        }

        private void WatchOnGitHub_Click(object sender, EventArgs e)
        {
            var button = (MetroLink) sender;
            Process.Start((string) button.Tag);
        }
    }
}