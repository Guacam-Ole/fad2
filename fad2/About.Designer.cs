namespace fad2.UI
{
    partial class About
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.AboutMeText = new MetroFramework.Controls.MetroTextBox();
            this.CloseWin = new MetroFramework.Controls.MetroButton();
            this.Donate = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // AboutMeText
            // 
            this.AboutMeText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.AboutMeText.CustomButton.Image = null;
            this.AboutMeText.CustomButton.Location = new System.Drawing.Point(386, 1);
            this.AboutMeText.CustomButton.Name = "";
            this.AboutMeText.CustomButton.Size = new System.Drawing.Size(147, 147);
            this.AboutMeText.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.AboutMeText.CustomButton.TabIndex = 1;
            this.AboutMeText.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.AboutMeText.CustomButton.UseSelectable = true;
            this.AboutMeText.CustomButton.Visible = false;
            this.AboutMeText.Enabled = false;
            this.AboutMeText.Lines = new string[0];
            this.AboutMeText.Location = new System.Drawing.Point(23, 63);
            this.AboutMeText.MaxLength = 32767;
            this.AboutMeText.Multiline = true;
            this.AboutMeText.Name = "AboutMeText";
            this.AboutMeText.PasswordChar = '\0';
            this.AboutMeText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.AboutMeText.SelectedText = "";
            this.AboutMeText.SelectionLength = 0;
            this.AboutMeText.SelectionStart = 0;
            this.AboutMeText.Size = new System.Drawing.Size(534, 149);
            this.AboutMeText.TabIndex = 1;
            this.AboutMeText.UseSelectable = true;
            this.AboutMeText.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.AboutMeText.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CloseWin
            // 
            this.CloseWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseWin.Location = new System.Drawing.Point(430, 236);
            this.CloseWin.Name = "CloseWin";
            this.CloseWin.Size = new System.Drawing.Size(127, 23);
            this.CloseWin.TabIndex = 9;
            this.CloseWin.Text = "Just ran out of coins";
            this.CloseWin.UseSelectable = true;
            this.CloseWin.Click += new System.EventHandler(this.CloseWin_Click);
            // 
            // Donate
            // 
            this.Donate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Donate.Location = new System.Drawing.Point(23, 236);
            this.Donate.Name = "Donate";
            this.Donate.Size = new System.Drawing.Size(127, 23);
            this.Donate.TabIndex = 10;
            this.Donate.Text = "Donate some money";
            this.Donate.UseSelectable = true;
            this.Donate.Click += new System.EventHandler(this.Donate_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 269);
            this.Controls.Add(this.Donate);
            this.Controls.Add(this.CloseWin);
            this.Controls.Add(this.AboutMeText);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.Resizable = false;
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox AboutMeText;
        private MetroFramework.Controls.MetroButton CloseWin;
        private MetroFramework.Controls.MetroButton Donate;
    }
}