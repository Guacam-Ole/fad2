using System;
using System.Windows.Forms;
using fad2.Backend.Github;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Single Comment from GitHub-Issue
    /// </summary>
    public partial class IssueComment : UserControl
    {
        private const int MinHeight = 40;
        private DateTime _date;

        /// <summary>
        /// Create a new Comment
        /// </summary>
        public IssueComment()
        {
            InitializeComponent();
        }

        /// <summary>
        /// GithubContainer for a Github-comment
        /// </summary>
        public GitHubComment GithubContainer
        {
            get
            {
                return new GitHubComment
                {
                    Date = _date,
                    Author = Avatar.Text,
                    Comment = Comment.Text
                };
            }
            set
            {
                _date = value.Date;
                Avatar.Tag = value.Picture;
                AvatarName.SetToolTip(Avatar, value.Author);
                Comment.Text = value.Comment;
                ReloadAvatar();
                RepaintComment();
            }
        }


        private void ReloadAvatar()
        {
            var tag = (string) Avatar.Tag;
            if (tag == null || !Uri.IsWellFormedUriString(tag, UriKind.Absolute)) return;
            var image = UiSettings.ResizedImage(new Uri(tag), 255, Avatar.Width, Avatar.Height);
            if (image == null) return;
            Avatar.TileImage = image;
            Avatar.UseTileImage = true;
        }

        private void RepaintComment()
        {
            using (var g = CreateGraphics())
            {
                var size = g.MeasureString(Comment.Text, Comment.Font, Comment.Width);
                Comment.Height = (int) Math.Ceiling(size.Height) + 20;
                if (Comment.Height < MinHeight)
                {
                    Comment.Height = MinHeight;
                }
            }
        }
    }
}