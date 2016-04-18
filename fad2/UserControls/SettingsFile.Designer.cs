namespace fad2.UI.UserControls
{
    partial class SettingsFile
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
            this.SettingKey = new MetroFramework.Controls.MetroLabel();
            this.SettingValue = new MetroFramework.Controls.MetroTextBox();
            this.MetroToolTip = new MetroFramework.Components.MetroToolTip();
            this.SelectFile = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // SettingKey
            // 
            this.SettingKey.Location = new System.Drawing.Point(4, 5);
            this.SettingKey.Name = "SettingKey";
            this.SettingKey.Size = new System.Drawing.Size(223, 23);
            this.SettingKey.TabIndex = 0;
            // 
            // SettingValue
            // 
            this.SettingValue.BackColor = System.Drawing.Color.Tomato;
            this.SettingValue.Location = new System.Drawing.Point(233, 4);
            this.SettingValue.Name = "SettingValue";
            this.SettingValue.Size = new System.Drawing.Size(383, 28);
            this.SettingValue.TabIndex = 1;
            this.SettingValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingValue_KeyDown);
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(668, 5);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(94, 27);
            this.SelectFile.TabIndex = 2;
            this.SelectFile.Text = "Select";
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // SettingsFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.SettingValue);
            this.Controls.Add(this.SettingKey);
            this.Name = "SettingsFile";
            this.Size = new System.Drawing.Size(765, 37);
            this.ResumeLayout(false);

        }

        #endregion

        public MetroFramework.Controls.MetroLabel SettingKey;
        protected MetroFramework.Controls.MetroTextBox SettingValue;
        protected MetroFramework.Components.MetroToolTip MetroToolTip;
        private MetroFramework.Controls.MetroButton SelectFile;
    }
}
