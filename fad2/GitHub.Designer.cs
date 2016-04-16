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
            this.ProgressLoad = new MetroFramework.Controls.MetroProgressBar();
            this.SuspendLayout();
            // 
            // ProgressLoad
            // 
            this.ProgressLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressLoad.Location = new System.Drawing.Point(126, 173);
            this.ProgressLoad.Name = "ProgressLoad";
            this.ProgressLoad.Size = new System.Drawing.Size(562, 23);
            this.ProgressLoad.TabIndex = 0;
            // 
            // GitHub
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.ProgressLoad);
            this.Name = "GitHub";
            this.Size = new System.Drawing.Size(822, 379);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar ProgressLoad;
    }
}
