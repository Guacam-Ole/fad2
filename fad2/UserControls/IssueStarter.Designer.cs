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
            this.Date = new MetroFramework.Controls.MetroLabel();
            this.BugTag = new MetroFramework.Controls.MetroTile();
            this.WishTag = new MetroFramework.Controls.MetroTile();
            this.Title = new MetroFramework.Controls.MetroLabel();
            this.WatchOnGitHub = new MetroFramework.Controls.MetroLink();
            this.PipelineNew = new MetroFramework.Controls.MetroTile();
            this.PipelineTodo = new MetroFramework.Controls.MetroTile();
            this.PipelineInProgress = new MetroFramework.Controls.MetroTile();
            this.PipelineDone = new MetroFramework.Controls.MetroTile();
            this.PipelineReleased = new MetroFramework.Controls.MetroTile();
            this.CommentPanel = new MetroFramework.Controls.MetroPanel();
            this.AvatarName = new MetroFramework.Components.MetroToolTip();
            this.Content = new MetroFramework.Controls.MetroTextBox();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // Avatar
            // 
            this.Avatar.ActiveControl = null;
            this.Avatar.Location = new System.Drawing.Point(65, 17);
            this.Avatar.Name = "Avatar";
            this.Avatar.Size = new System.Drawing.Size(93, 92);
            this.Avatar.TabIndex = 0;
            this.Avatar.UseSelectable = true;
            // 
            // Date
            // 
            this.Date.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Date.Location = new System.Drawing.Point(164, 20);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(95, 31);
            this.Date.TabIndex = 15;
            this.Date.Text = "01.01.2022";
            // 
            // BugTag
            // 
            this.BugTag.ActiveControl = null;
            this.BugTag.Location = new System.Drawing.Point(3, 17);
            this.BugTag.Name = "BugTag";
            this.BugTag.Size = new System.Drawing.Size(55, 43);
            this.BugTag.Style = MetroFramework.MetroColorStyle.Red;
            this.BugTag.TabIndex = 1;
            this.BugTag.Text = "BUG";
            this.BugTag.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BugTag.UseSelectable = true;
            // 
            // WishTag
            // 
            this.WishTag.ActiveControl = null;
            this.WishTag.Location = new System.Drawing.Point(4, 66);
            this.WishTag.Name = "WishTag";
            this.WishTag.Size = new System.Drawing.Size(55, 43);
            this.WishTag.Style = MetroFramework.MetroColorStyle.Teal;
            this.WishTag.TabIndex = 2;
            this.WishTag.Text = "WISH";
            this.WishTag.UseSelectable = true;
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.Title.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.Title.Location = new System.Drawing.Point(268, 20);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(532, 31);
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
            this.WatchOnGitHub.UseSelectable = true;
            this.WatchOnGitHub.Click += new System.EventHandler(this.WatchOnGitHub_Click);
            // 
            // PipelineNew
            // 
            this.PipelineNew.ActiveControl = null;
            this.PipelineNew.Location = new System.Drawing.Point(65, 112);
            this.PipelineNew.Margin = new System.Windows.Forms.Padding(0);
            this.PipelineNew.Name = "PipelineNew";
            this.PipelineNew.Size = new System.Drawing.Size(93, 38);
            this.PipelineNew.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineNew.TabIndex = 6;
            this.PipelineNew.Text = "New";
            this.PipelineNew.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.PipelineNew.UseSelectable = true;
            // 
            // PipelineTodo
            // 
            this.PipelineTodo.ActiveControl = null;
            this.PipelineTodo.Location = new System.Drawing.Point(65, 153);
            this.PipelineTodo.Name = "PipelineTodo";
            this.PipelineTodo.Size = new System.Drawing.Size(93, 37);
            this.PipelineTodo.Style = MetroFramework.MetroColorStyle.Green;
            this.PipelineTodo.TabIndex = 7;
            this.PipelineTodo.Text = "ToDo";
            this.PipelineTodo.UseSelectable = true;
            // 
            // PipelineInProgress
            // 
            this.PipelineInProgress.ActiveControl = null;
            this.PipelineInProgress.Location = new System.Drawing.Point(65, 196);
            this.PipelineInProgress.Name = "PipelineInProgress";
            this.PipelineInProgress.Size = new System.Drawing.Size(94, 37);
            this.PipelineInProgress.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineInProgress.TabIndex = 8;
            this.PipelineInProgress.Text = "In Progress";
            this.PipelineInProgress.UseSelectable = true;
            // 
            // PipelineDone
            // 
            this.PipelineDone.ActiveControl = null;
            this.PipelineDone.Location = new System.Drawing.Point(65, 239);
            this.PipelineDone.Name = "PipelineDone";
            this.PipelineDone.Size = new System.Drawing.Size(94, 37);
            this.PipelineDone.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineDone.TabIndex = 9;
            this.PipelineDone.Text = "Done";
            this.PipelineDone.UseSelectable = true;
            // 
            // PipelineReleased
            // 
            this.PipelineReleased.ActiveControl = null;
            this.PipelineReleased.Location = new System.Drawing.Point(65, 282);
            this.PipelineReleased.Name = "PipelineReleased";
            this.PipelineReleased.Size = new System.Drawing.Size(94, 37);
            this.PipelineReleased.Style = MetroFramework.MetroColorStyle.Silver;
            this.PipelineReleased.TabIndex = 10;
            this.PipelineReleased.Text = "Released";
            this.PipelineReleased.UseSelectable = true;
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
            // AvatarName
            // 
            this.AvatarName.Style = MetroFramework.MetroColorStyle.Blue;
            this.AvatarName.StyleManager = null;
            this.AvatarName.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // Content
            // 
            this.Content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.Content.CustomButton.Image = null;
            this.Content.CustomButton.Location = new System.Drawing.Point(498, 1);
            this.Content.CustomButton.Name = "";
            this.Content.CustomButton.Size = new System.Drawing.Size(137, 137);
            this.Content.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.Content.CustomButton.TabIndex = 1;
            this.Content.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.Content.CustomButton.UseSelectable = true;
            this.Content.CustomButton.Visible = false;
            this.Content.Lines = new string[] {
        "metroTextBox1"};
            this.Content.Location = new System.Drawing.Point(164, 54);
            this.Content.MaxLength = 32767;
            this.Content.Multiline = true;
            this.Content.Name = "Content";
            this.Content.PasswordChar = '\0';
            this.Content.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Content.SelectedText = "";
            this.Content.SelectionLength = 0;
            this.Content.SelectionStart = 0;
            this.Content.ShortcutsEnabled = true;
            this.Content.Size = new System.Drawing.Size(636, 139);
            this.Content.TabIndex = 19;
            this.Content.Text = "metroTextBox1";
            this.Content.UseSelectable = true;
            this.Content.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.Content.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(52, 225);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(89, 19);
            this.metroTile1.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile1.TabIndex = 10;
            this.metroTile1.Text = "Released";
            this.metroTile1.UseSelectable = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Location = new System.Drawing.Point(52, 225);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(89, 19);
            this.metroTile2.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile2.TabIndex = 10;
            this.metroTile2.Text = "Released";
            this.metroTile2.UseSelectable = true;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Location = new System.Drawing.Point(52, 225);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(89, 19);
            this.metroTile3.Style = MetroFramework.MetroColorStyle.Silver;
            this.metroTile3.TabIndex = 10;
            this.metroTile3.Text = "Released";
            this.metroTile3.UseSelectable = true;
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Location = new System.Drawing.Point(0, 0);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(75, 23);
            this.metroTile4.TabIndex = 0;
            this.metroTile4.UseSelectable = true;
            // 
            // IssueStarter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.Date);
            this.Controls.Add(this.Content);
            this.Controls.Add(this.CommentPanel);
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
            this.Size = new System.Drawing.Size(820, 360);
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
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile metroTile4;
    }
}
