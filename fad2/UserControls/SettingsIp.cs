using System.Drawing;
using System.Net;
using System.Windows.Forms;
using fad2.UI.Properties;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Ip-Textbox
    /// </summary>
    public class SettingsIp : SettingsString
    {
        private void InitializeComponent()
        {
            SuspendLayout();
            SettingValue.BackColor = Color.Tomato;
            SettingValue.KeyDown += SettingValue_KeyDown;
            AutoScaleDimensions = new SizeF(6F, 13F);
            Name = "SettingsIp";
            ResumeLayout(false);
            PerformLayout();
        }

        private void SettingValue_KeyDown(object sender, KeyEventArgs e)
        {
            ValueChanged = true;
            IPAddress ipAddress;
            if (string.IsNullOrWhiteSpace(SettingValue.Text) || IPAddress.TryParse(SettingValue.Text, out ipAddress))
            {
                Warning = null;
                IsValid = true;
            }
            else
            {
                Warning = Resources.EnterIpWarning;
                IsValid = false;
            }
        }
    }
}