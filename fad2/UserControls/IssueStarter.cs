using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fad2.Backend;

namespace fad2.UI.UserControls
{
    public partial class IssueStarter : UserControl
    {
        public IssueStarter()
        {
            InitializeComponent();
        }

        private DateTime _date;

        public GitHubComment IssueComment
        {
            get
            {
                return new GitHubComment
                {
                    Title = Title.Text,
                    Comment = Content.Text,
                    Date = _date,
                    Picture = (string)Avatar.Tag,
                    Url = (string)WatchOnGitHub.Tag
                };
            }
            set
            {
                Title.Text = value.Title;
                Content.Text = value.Comment;
                _date = value.Date;
                Date.Text = $"{_date:yyyy-MM-dd}";
                WatchOnGitHub.Tag = value.Url;
                Avatar.Text = value.Author;
                Avatar.Tag = value.Picture;
                AvatarName.SetToolTip(Avatar, value.Author);
                ReloadAvatar();
                RepaintComment();
            }
        }

        public bool IsBug
        {
            get
            {
                return BugTag.Visible;
            }
            set
            {
                BugTag.Visible = value;
            }

        }

        public bool IsFeatureRequest
        {
            get
            {
                return WishTag.Visible;
            }
            set
            {
                WishTag.Visible = value;
            }
        }


        private string _pipeline;
        public string Pipeline
        {
            get
            {
                return _pipeline;
            }
            set
            {
                _pipeline = value;
                SetMileStone();

            }
        }

        private List<GitHubComment> _comments;
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
            if (_comments == null)
            {
                return;
            }
            foreach (GitHubComment comment in _comments.OrderByDescending(cm => cm.Date))
            {
                var issueComment = new UserControls.IssueComment();
                issueComment.Dock = DockStyle.Top;
                //    issueComment.Margin.Top = 20;
                issueComment.Container = comment;
                issueComment.AutoSize = true;
                issueComment.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                CommentPanel.Controls.Add(issueComment);
                //     CommentPanel.AutoSize = true;
                // CommentPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
        }

        private void SetMileStone()
        {
            MileStoneClosed.Style = MetroFramework.MetroColorStyle.Silver;
            MileStoneDone.Style = MetroFramework.MetroColorStyle.Silver;
            MileStoneInProgress.Style = MetroFramework.MetroColorStyle.Silver;
            MileStoneNew.Style = MetroFramework.MetroColorStyle.Silver;
            MileStoneToDo.Style = MetroFramework.MetroColorStyle.Silver;

            switch (_pipeline)
            {
                case "Closed":
                    MileStoneClosed.Style = MetroFramework.MetroColorStyle.Green;
                    break;
                case "Done":
                    MileStoneDone.Style = MetroFramework.MetroColorStyle.Green;
                    break;
                case "In Progress":
                    MileStoneInProgress.Style = MetroFramework.MetroColorStyle.Green;
                    break;
                case "New":
                    MileStoneNew.Style = MetroFramework.MetroColorStyle.Green;
                    break;
                case "ToDo":
                    MileStoneToDo.Style = MetroFramework.MetroColorStyle.Green;
                    break;
            }
        }


        private void ReloadAvatar()
        {
            string tag = (string)Avatar.Tag;
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
            using (Graphics g = CreateGraphics())
            {
                SizeF size = g.MeasureString(Content.Text, Content.Font, Content.Width);
                Content.Height = (int)Math.Ceiling(size.Height) + 20;
            }
            WatchOnGitHub.Top= Content.Height + Content.Top + 10;
            ShowComments.Top = WatchOnGitHub.Top;
            CommentPanel.Top = WatchOnGitHub.Height + WatchOnGitHub.Top + 10;

        }
    }
}
