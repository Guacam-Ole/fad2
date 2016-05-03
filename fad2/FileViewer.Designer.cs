namespace fad2.UI
{
    partial class FileViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileViewer));
            this.TextFileContent = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // TextFileContent
            // 
            this.TextFileContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.TextFileContent.CustomButton.Image = null;
            this.TextFileContent.CustomButton.Location = new System.Drawing.Point(374, 1);
            this.TextFileContent.CustomButton.Name = "";
            this.TextFileContent.CustomButton.Size = new System.Drawing.Size(351, 351);
            this.TextFileContent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TextFileContent.CustomButton.TabIndex = 1;
            this.TextFileContent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TextFileContent.CustomButton.UseSelectable = true;
            this.TextFileContent.CustomButton.Visible = false;
            this.TextFileContent.Lines = new string[] {
        "metroTextBox1"};
            this.TextFileContent.Location = new System.Drawing.Point(24, 64);
            this.TextFileContent.MaxLength = 32767;
            this.TextFileContent.Multiline = true;
            this.TextFileContent.Name = "TextFileContent";
            this.TextFileContent.PasswordChar = '\0';
            this.TextFileContent.ReadOnly = true;
            this.TextFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextFileContent.SelectedText = "";
            this.TextFileContent.SelectionLength = 0;
            this.TextFileContent.SelectionStart = 0;
            this.TextFileContent.ShortcutsEnabled = true;
            this.TextFileContent.Size = new System.Drawing.Size(726, 353);
            this.TextFileContent.TabIndex = 0;
            this.TextFileContent.Text = "metroTextBox1";
            this.TextFileContent.UseSelectable = true;
            this.TextFileContent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TextFileContent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // FileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 440);
            this.Controls.Add(this.TextFileContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 200);
            this.Name = "FileViewer";
            this.Text = "FileViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox TextFileContent;
    }
}