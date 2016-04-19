namespace fad2.UI.UserControls
{
    partial class GithubTop 
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
            this.LoadingIssuesLabel = new MetroFramework.Controls.MetroLabel();
            this.LoadingIssuesSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.MetroNewIssue = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.GithubLink = new MetroFramework.Controls.MetroLink();
            this.SuspendLayout();
            // 
            // LoadingIssuesLabel
            // 
            this.LoadingIssuesLabel.AutoSize = true;
            this.LoadingIssuesLabel.Location = new System.Drawing.Point(0, 0);
            this.LoadingIssuesLabel.Name = "LoadingIssuesLabel";
            this.LoadingIssuesLabel.Size = new System.Drawing.Size(104, 19);
            this.LoadingIssuesLabel.TabIndex = 0;
            this.LoadingIssuesLabel.Text = "Loading Issues....";
            // 
            // LoadingIssuesSpinner
            // 
            this.LoadingIssuesSpinner.Location = new System.Drawing.Point(114, 4);
            this.LoadingIssuesSpinner.Maximum = 100;
            this.LoadingIssuesSpinner.Name = "LoadingIssuesSpinner";
            this.LoadingIssuesSpinner.Size = new System.Drawing.Size(26, 19);
            this.LoadingIssuesSpinner.TabIndex = 1;
            // 
            // MetroNewIssue
            // 
            this.MetroNewIssue.Location = new System.Drawing.Point(371, 4);
            this.MetroNewIssue.Name = "MetroNewIssue";
            this.MetroNewIssue.Size = new System.Drawing.Size(146, 23);
            this.MetroNewIssue.TabIndex = 2;
            this.MetroNewIssue.Text = "Create a new Issue";
            this.MetroNewIssue.Click += new System.EventHandler(this.MetroNewIssue_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(4, 46);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(389, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Closed Issues will not be displayed here. But you can see them at ";
            // 
            // GithubLink
            // 
            this.GithubLink.Location = new System.Drawing.Point(388, 45);
            this.GithubLink.Name = "GithubLink";
            this.GithubLink.Size = new System.Drawing.Size(50, 23);
            this.GithubLink.TabIndex = 4;
            this.GithubLink.Text = "GitHub";
            this.GithubLink.Click += new System.EventHandler(this.GithubLink_Click);
            // 
            // GithubTop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LoadingIssuesSpinner);
            this.Controls.Add(this.LoadingIssuesLabel);
            this.Controls.Add(this.GithubLink);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.MetroNewIssue);
            this.Name = "GithubTop";
            this.Size = new System.Drawing.Size(891, 81);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel LoadingIssuesLabel;
        private MetroFramework.Controls.MetroProgressSpinner LoadingIssuesSpinner;
        private MetroFramework.Controls.MetroButton MetroNewIssue;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLink GithubLink;
    }
}
