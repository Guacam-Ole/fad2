using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace fad2.UI.UserControls
{
    public class SettingsIp : SettingsString
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // SettingValue
            // 
            this.SettingValue.BackColor = System.Drawing.Color.Tomato;
            this.SettingValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SettingValue_KeyDown);
            // 
            // SettingsIp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "SettingsIp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void SettingValue_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            IPAddress ipAddress;
            if (string.IsNullOrWhiteSpace(SettingValue.Text) || IPAddress.TryParse(SettingValue.Text, out ipAddress))
            {
                Warning = null;
                SettingValue.CustomBackground = false;
                _isValid = true;
            }
            else
            {
                Warning = "Please enter a valid IP-Address";
                SettingValue.CustomBackground = true;
                _isValid = false;
            }
        }
    }
}
