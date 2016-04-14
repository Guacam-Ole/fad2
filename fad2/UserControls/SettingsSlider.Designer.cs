namespace fad2.UI.UserControls
{
    partial class SettingsSlider
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
            this.SettingVersion = new MetroFramework.Controls.MetroLabel();
            this.WarningLabel = new System.Windows.Forms.Label();
            this.MetroToolTip = new MetroFramework.Components.MetroToolTip();
            this.SettingValue = new MetroFramework.Controls.MetroTrackBar();
            this.SuspendLayout();
            // 
            // SettingKey
            // 
            this.SettingKey.Location = new System.Drawing.Point(4, 5);
            this.SettingKey.Name = "SettingKey";
            this.SettingKey.Size = new System.Drawing.Size(223, 23);
            this.SettingKey.TabIndex = 0;
            // 
            // SettingVersion
            // 
            this.SettingVersion.Location = new System.Drawing.Point(681, 9);
            this.SettingVersion.Name = "SettingVersion";
            this.SettingVersion.Size = new System.Drawing.Size(81, 19);
            this.SettingVersion.TabIndex = 2;
            this.SettingVersion.Text = "0.0.0.0";
            // 
            // WarningLabel
            // 
            this.WarningLabel.AutoSize = true;
            this.WarningLabel.BackColor = System.Drawing.Color.Transparent;
            this.WarningLabel.Font = new System.Drawing.Font("Webdings", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.WarningLabel.Location = new System.Drawing.Point(622, 6);
            this.WarningLabel.Name = "WarningLabel";
            this.WarningLabel.Size = new System.Drawing.Size(36, 26);
            this.WarningLabel.TabIndex = 4;
            this.WarningLabel.Text = "i";
            this.MetroToolTip.SetToolTip(this.WarningLabel, "\r\n");
            // 
            // SettingValue
            // 
            this.SettingValue.BackColor = System.Drawing.Color.Transparent;
            this.SettingValue.Location = new System.Drawing.Point(234, 4);
            this.SettingValue.Name = "SettingValue";
            this.SettingValue.Size = new System.Drawing.Size(382, 23);
            this.SettingValue.TabIndex = 5;
            this.SettingValue.ValueChanged += new System.EventHandler(this.SettingValue_ValueChanged);
            // 
            // SettingsSlider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SettingValue);
            this.Controls.Add(this.WarningLabel);
            this.Controls.Add(this.SettingVersion);
            this.Controls.Add(this.SettingKey);
            this.Name = "SettingsSlider";
            this.Size = new System.Drawing.Size(765, 37);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public MetroFramework.Controls.MetroLabel SettingKey;
        private MetroFramework.Controls.MetroLabel SettingVersion;
        private System.Windows.Forms.Label WarningLabel;
        protected MetroFramework.Components.MetroToolTip MetroToolTip;
        protected MetroFramework.Controls.MetroTrackBar SettingValue;
    }
}
