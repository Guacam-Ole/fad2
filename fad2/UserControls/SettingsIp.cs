using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace fad2.UI.UserControls
{
    public class SettingsIp : SettingsString
    {
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // SettingValue
            // 
            SettingValue.BackColor = Color.Tomato;
            SettingValue.KeyDown += SettingValue_KeyDown;
            // 
            // SettingsIp
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            Name = "SettingsIp";
            ResumeLayout(false);
            PerformLayout();
        }


        private void SettingValue_KeyDown(object sender, KeyEventArgs e)
        {
            _valueChanged = true;
            IPAddress ipAddress;
            if (string.IsNullOrWhiteSpace(SettingValue.Text) || IPAddress.TryParse(SettingValue.Text, out ipAddress))
            {
                Warning = null;
                //   SettingValue.CustomBackground = false;
                _isValid = true;
            }
            else
            {
                Warning = "Please enter a valid IP-Address";
                // SettingValue.CustomBackground = true;
                _isValid = false;
            }
        }
    }
}