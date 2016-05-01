using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using fad2.Backend.Github;
using log4net;
using MetroFramework;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Issue Starter Panel
    /// </summary>
    public partial class IssueStarter : UserControl
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private List<GitHubComment> _comments;
        private DateTime _date;
        private string _pipeline;

        /// <summary>
        /// New Issue Starter Panel
        /// </summary>
        public IssueStarter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Single Comment
        /// </summary>
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
                try
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
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
        }

        /// <summary>
        /// Is this a bug?
        /// </summary>
        public bool IsBug
        {
            get { return BugTag.Visible; }
            set { BugTag.Visible = value; }
        }

        /// <summary>
        /// is this a feature?
        /// </summary>
        public bool IsFeatureRequest
        {
            get { return WishTag.Visible; }
            set { WishTag.Visible = value; }
        }

        /// <summary>
        /// Current Pipeline (Zenhub(
        /// </summary>
        public string Pipeline
        {
            get { return _pipeline; }
            set
            {
                _pipeline = value;
                SetPipeline();
            }
        }

        /// <summary>
        /// Comments to this issue
        /// </summary>
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
            try
            {
                CommentPanel.Controls.Clear();
                CommentPanel.Height = 10;
                if (_comments == null)
                {
                    return;
                }
                foreach (var comment in _comments.OrderByDescending(cm => cm.Date))
                {
                    var issueComment = new IssueComment
                    {
                        Dock = DockStyle.Top,
                        GithubContainer = comment,
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowAndShrink
                    };
                    CommentPanel.Controls.Add(issueComment);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex);
            }
        }

        private void SetPipeline()
        {
            PipelineReleased.Style = MetroColorStyle.Silver;
            PipelineDone.Style = MetroColorStyle.Silver;
            PipelineInProgress.Style = MetroColorStyle.Silver;
            PipelineNew.Style = MetroColorStyle.Silver;
            PipelineTodo.Style = MetroColorStyle.Silver;

            switch (_pipeline)
            {
                case "Released":
                    PipelineReleased.Style = MetroColorStyle.Green;
                    break;
                case "Done":
                    PipelineDone.Style = MetroColorStyle.Green;
                    break;
                case "In Progress":
                    PipelineInProgress.Style = MetroColorStyle.Green;
                    break;
                case "New Issues":
                    PipelineNew.Style = MetroColorStyle.Green;
                    break;
                case "To Do":
                    PipelineTodo.Style = MetroColorStyle.Green;
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
            CommentPanel.Top = WatchOnGitHub.Height + WatchOnGitHub.Top + 10;
        }

        private void WatchOnGitHub_Click(object sender, EventArgs e)
        {
            var button = (MetroLink) sender;
            Process.Start((string) button.Tag);
        }
    }
}