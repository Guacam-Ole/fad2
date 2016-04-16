namespace fad2.UI.UserControls
{
    partial class IssueStarter
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Avatar = new MetroFramework.Controls.MetroTile();
            this.BugTag = new MetroFramework.Controls.MetroTile();
            this.WishTag = new MetroFramework.Controls.MetroTile();
            this.Title = new MetroFramework.Controls.MetroLabel();
            this.WatchOnGitHub = new MetroFramework.Controls.MetroLink();
            this.MileStoneNew = new MetroFramework.Controls.MetroTile();
            this.MileStoneToDo = new MetroFramework.Controls.MetroTile();
            this.MileStoneInProgress = new MetroFramework.Controls.MetroTile();
            this.MileStoneDone = new MetroFramework.Controls.MetroTile();
            this.MileStoneClosed = new MetroFramework.Controls.MetroTile();
            this.ShowComments = new MetroFramework.Controls.MetroLink();
            this.Date = new MetroFramework.Controls.MetroLabel();
            this.CommentPanel = new MetroFramework.Controls.MetroPanel();
            this.AvatarName = new MetroFramework.Components.MetroToolTip();
            this.Content = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.Location = new System.Drawing.Point(65, 17);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(75, 73);
            this.Avatar.TabIndex = 0;
            // 
            // BugTag
            // 
            this.BugTag.Location = new System.Drawing.Point(3, 17);
            this.BugTag.Name = "BugTag";
            this.BugTag.Size = new System.Drawing.Size(56, 23);
            this.BugTag.Style = MetroFramework.MetroColorStyle.Red;
            this.BugTag.TabIndex = 1;
            this.BugTag.Text = "BUG";
            // 
            // WishTag
            // 
            this.WishTag.Location = new System.Drawing.Point(4, 47);
            this.WishTag.Name = "WishTag";
            this.WishTag.Size = new System.Drawing.Size(55, 23);
            this.WishTag.Style = MetroFramework.MetroColorStyle.Teal;
            this.WishTag.TabIndex = 2;
            this.WishTag.Text = "WISH";
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Title.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.Title.Location = new System.Drawing.Point(164, 20);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(636, 31);
            this.Title.TabIndex = 3;
            this.Title.Text = "Something is wrong in denmark!";
            // 
            // WatchOnGitHub
            // 
            this.WatchOnGitHub.Location = new System.Drawing.Point(164, 199);
            this.WatchOnGitHub.Name = "WatchOnGitHub";
            this.WatchOnGitHub.Size = new System.Drawing.Size(112, 23);
            this.WatchOnGitHub.TabIndex = 5;
            this.WatchOnGitHub.Text = "Watch on GitHub";
            this.WatchOnGitHub.Click += new System.EventHandler(this.WatchOnGitHub_Click);
            // 
            // MileStoneNew
            // 
            this.MileStoneNew.Location = new System.Drawing.Point(52, 125);
            this.MileStoneNew.Name = "MileStoneNew";
            this.MileStoneNew.Size = new System.Drawing.Size(88, 19);
            this.MileStoneNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.MileStoneNew.TabIndex = 6;
            this.MileStoneNew.Text = "New";
            // 
            // MileStoneToDo
            // 
            this.MileStoneToDo.Location = new System.Drawing.Point(52, 150);
            this.MileStoneToDo.Name = "MileStoneToDo";
            this.MileStoneToDo.Size = new System.Drawing.Size(88, 19);
            this.MileStoneToDo.Style = MetroFramework.MetroColorStyle.Green;
            this.MileStoneToDo.TabIndex = 7;
            this.MileStoneToDo.Text = "ToDo";
            // 
            // MileStoneInProgress
            // 
            this.MileStoneInProgress.Location = new System.Drawing.Point(52, 175);
            this.MileStoneInProgress.Name = "MileStoneInProgress";
            this.MileStoneInProgress.Size = new System.Drawing.Size(89, 19);
            this.MileStoneInProgress.Style = MetroFramework.MetroColorStyle.Silver;
            this.MileStoneInProgress.TabIndex = 8;
            this.MileStoneInProgress.Text = "In Progress";
            // 
            // MileStoneDone
            // 
            this.MileStoneDone.Location = new System.Drawing.Point(52, 200);
            this.MileStoneDone.Name = "MileStoneDone";
            this.MileStoneDone.Size = new System.Drawing.Size(89, 19);
            this.MileStoneDone.Style = MetroFramework.MetroColorStyle.Silver;
            this.MileStoneDone.TabIndex = 9;
            this.MileStoneDone.Text = "Done";
            // 
            // MileStoneClosed
            // 
            this.MileStoneClosed.Location = new System.Drawing.Point(52, 225);
            this.MileStoneClosed.Name = "MileStoneClosed";
            this.MileStoneClosed.Size = new System.Drawing.Size(89, 19);
            this.MileStoneClosed.Style = MetroFramework.MetroColorStyle.Silver;
            this.MileStoneClosed.TabIndex = 10;
            this.MileStoneClosed.Text = "Closed";
            // 
            // ShowComments
            // 
            this.ShowComments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowComments.Location = new System.Drawing.Point(664, 200);
            this.ShowComments.Name = "ShowComments";
            this.ShowComments.Size = new System.Drawing.Size(134, 23);
            this.ShowComments.TabIndex = 14;
            this.ShowComments.Text = "Show 45 Comments";
            this.ShowComments.Visible = false;
            // 
            // Date
            // 
            this.Date.Location = new System.Drawing.Point(52, 93);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(88, 23);
            this.Date.TabIndex = 15;
            this.Date.Text = "01.01.2022";
            this.Date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CommentPanel
            // 
            this.CommentPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentPanel.AutoSize = true;
            this.CommentPanel.BackColor = System.Drawing.Color.Gray;
            this.CommentPanel.HorizontalScrollbarBarColor = true;
            this.CommentPanel.HorizontalScrollbarHighlightOnWheel = false;
            this.CommentPanel.HorizontalScrollbarSize = 10;
            this.CommentPanel.Location = new System.Drawing.Point(184, 229);
            this.CommentPanel.Name = "CommentPanel";
            this.CommentPanel.Size = new System.Drawing.Size(614, 15);
            this.CommentPanel.TabIndex = 16;
            this.CommentPanel.VerticalScrollbarBarColor = true;
            this.CommentPanel.VerticalScrollbarHighlightOnWheel = false;
            this.CommentPanel.VerticalScrollbarSize = 10;
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Content.Location = new System.Drawing.Point(164, 54);
            this.Content.Multiline = true;
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(636, 139);
            this.Content.TabIndex = 19;
            this.Content.Text = "metroTextBox1";
            // 
            // IssueStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.Content);
            this.Controls.Add(this.CommentPanel);
            this.Controls.Add(this.Date);
            this.Controls.Add(this.ShowComments);
            this.Controls.Add(this.MileStoneClosed);
            this.Controls.Add(this.MileStoneDone);
            this.Controls.Add(this.MileStoneInProgress);
            this.Controls.Add(this.MileStoneToDo);
            this.Controls.Add(this.MileStoneNew);
            this.Controls.Add(this.WatchOnGitHub);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.WishTag);
            this.Controls.Add(this.BugTag);
            this.Controls.Add(this.Avatar);
            this.MinimumSize = new System.Drawing.Size(0, 300);
            this.Name = "IssueStarter";
            this.Size = new System.Drawing.Size(820, 435);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile Avatar;
        private MetroFramework.Controls.MetroTile BugTag;
        private MetroFramework.Controls.MetroTile WishTag;
        private MetroFramework.Controls.MetroLabel Title;
        private MetroFramework.Controls.MetroLink WatchOnGitHub;
        private MetroFramework.Controls.MetroTile MileStoneNew;
        private MetroFramework.Controls.MetroTile MileStoneToDo;
        private MetroFramework.Controls.MetroTile MileStoneInProgress;
        private MetroFramework.Controls.MetroTile MileStoneDone;
        private MetroFramework.Controls.MetroTile MileStoneClosed;
        private MetroFramework.Controls.MetroLink ShowComments;
        private MetroFramework.Controls.MetroLabel Date;
        private MetroFramework.Controls.MetroPanel CommentPanel;
        private MetroFramework.Components.MetroToolTip AvatarName;
        private MetroFramework.Controls.MetroTextBox Content;
    }
}
