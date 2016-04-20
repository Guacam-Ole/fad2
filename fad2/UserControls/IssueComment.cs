using System;
using System.Windows.Forms;
using fad2.Backend;
using fad2.Backend.Github;

namespace fad2.UI.UserControls
{
    public partial class IssueComment : UserControl
    {
        private DateTime _date;

        private readonly int _minHeight = 40;

        public IssueComment()
        {
            InitializeComponent();
        }

        public GitHubComment Container
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
                //CommentGroup.Text=$"{_date:yyyy-MM-dd}";
                //  Avatar.Text = value.Author;
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
                var size = g.MeasureString(Comment.Text, Comment.Font, Comment.Width);
                Comment.Height = (int) Math.Ceiling(size.Height) + 20;
                if (Comment.Height < _minHeight)
                {
                    Comment.Height = _minHeight;
                }
            }

            //   CommentGroup.Height = Comment.Height + 10;
//            this.Height = CommentGroup.Height + 20;
        }
    }
}