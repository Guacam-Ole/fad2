namespace fad2.UI
{
    partial class GitHub
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
            fad2.UI.GitHubComment gitHubComment1 = new fad2.UI.GitHubComment();
            this.issueStarter1 = new fad2.UI.UserControls.IssueStarter();
            this.SuspendLayout();
            // 
            // issueStarter1
            // 
            this.issueStarter1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.issueStarter1.AutoScroll = true;
            this.issueStarter1.Comments = null;
            this.issueStarter1.IsBug = true;
            this.issueStarter1.IsFeatureRequest = false;
            gitHubComment1.Author = null;
            gitHubComment1.Comment = "metroLabel1\r\nzwo drei vier\r\n";
            gitHubComment1.Date = new System.DateTime(((long)(0)));
            gitHubComment1.Picture = null;
            gitHubComment1.Title = "Something is wrong in denmark!";
            gitHubComment1.Url = null;
            this.issueStarter1.IssueComment = gitHubComment1;
            this.issueStarter1.Location = new System.Drawing.Point(4, 4);
            this.issueStarter1.MileStone = "Done";
            this.issueStarter1.Name = "issueStarter1";
            this.issueStarter1.Size = new System.Drawing.Size(801, 429);
            this.issueStarter1.TabIndex = 0;
            // 
            // GitHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.issueStarter1);
            this.Name = "GitHub";
            this.Size = new System.Drawing.Size(822, 452);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.IssueStarter issueStarter1;
    }
}
