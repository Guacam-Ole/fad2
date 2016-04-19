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
            this.PipelineNew = new MetroFramework.Controls.MetroTile();
            this.PipelineTodo = new MetroFramework.Controls.MetroTile();
            this.PipelineInProgress = new MetroFramework.Controls.MetroTile();
            this.PipelineDone = new MetroFramework.Controls.MetroTile();
            this.PipelineReleased = new MetroFramework.Controls.MetroTile();
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
            // PipelineNew
            // 
            this.PipelineNew.Location = new System.Drawing.Point(52, 125);
            this.PipelineNew.Name = "PipelineNew";
            this.PipelineNew.Size = new System.Drawing.Size(88, 19);
            this.PipelineNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineNew.TabIndex = 6;
            this.PipelineNew.Text = "New";
            // 
            // PipelineTodo
            // 
            this.PipelineTodo.Location = new System.Drawing.Point(52, 150);
            this.PipelineTodo.Name = "PipelineTodo";
            this.PipelineTodo.Size = new System.Drawing.Size(88, 19);
            this.PipelineTodo.Style = MetroFramework.MetroColorStyle.Green;
            this.PipelineTodo.TabIndex = 7;
            this.PipelineTodo.Text = "ToDo";
            // 
            // PipelineInProgress
            // 
            this.PipelineInProgress.Location = new System.Drawing.Point(52, 175);
            this.PipelineInProgress.Name = "PipelineInProgress";
            this.PipelineInProgress.Size = new System.Drawing.Size(89, 19);
            this.PipelineInProgress.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineInProgress.TabIndex = 8;
            this.PipelineInProgress.Text = "In Progress";
            // 
            // PipelineDone
            // 
            this.PipelineDone.Location = new System.Drawing.Point(52, 200);
            this.PipelineDone.Name = "PipelineDone";
            this.PipelineDone.Size = new System.Drawing.Size(89, 19);
            this.PipelineDone.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineDone.TabIndex = 9;
            this.PipelineDone.Text = "Done";
            // 
            // PipelineReleased
            // 
            this.PipelineReleased.Location = new System.Drawing.Point(52, 225);
            this.PipelineReleased.Name = "PipelineReleased";
            this.PipelineReleased.Size = new System.Drawing.Size(89, 19);
            this.PipelineReleased.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineReleased.TabIndex = 10;
            this.PipelineReleased.Text = "Released";
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
            this.Controls.Add(this.PipelineReleased);
            this.Controls.Add(this.PipelineDone);
            this.Controls.Add(this.PipelineInProgress);
            this.Controls.Add(this.PipelineTodo);
            this.Controls.Add(this.PipelineNew);
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
        private MetroFramework.Controls.MetroTile PipelineNew;
        private MetroFramework.Controls.MetroTile PipelineTodo;
        private MetroFramework.Controls.MetroTile PipelineInProgress;
        private MetroFramework.Controls.MetroTile PipelineDone;
        private MetroFramework.Controls.MetroTile PipelineReleased;
        private MetroFramework.Controls.MetroLabel Date;
        private MetroFramework.Controls.MetroPanel CommentPanel;
        private MetroFramework.Components.MetroToolTip AvatarName;
        private MetroFramework.Controls.MetroTextBox Content;
    }
}
