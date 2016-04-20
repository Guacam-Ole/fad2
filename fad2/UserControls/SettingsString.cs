using System;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    public partial class SettingsString : MetroUserControl
    {
        private string _internalName;
        protected bool _isValid = true;

        private string _toolTip;

        protected bool _valueChanged;

        private string _warning;

        public SettingsString()
        {
            InitializeComponent();
            AddFont();
            EnabledChanged += SettingsString_EnabledChanged;
        }

        public string Regex { get; set; }

        public string InternalName
        {
            get { return _internalName; }
            set
            {
                _internalName = value;
                MetroToolTip.SetToolTip(SettingKey, value);
            }
        }

        public char PasswordChar
        {
            get { return SettingValue.PasswordChar; }
            set { SettingValue.PasswordChar = value; }
        }

        public int MaxCharacters
        {
            get { return SettingValue.MaxLength; }
            set { SettingValue.MaxLength = value; }
        }

        public string Key
        {
            get { return SettingKey.Text; }
            set { SettingKey.Text = value; }
        }

        public string Value
        {
            get { return SettingValue.Text; }
            set
            {
                SettingValue.Text = value;
                Enabled = UiSettings.HasFeature(SettingVersion.Text);
            }
        }

        public string RequiredVersion
        {
            get { return SettingVersion.Text; }
            set { SettingVersion.Text = value; }
        }

        public string Warning
        {
            get { return _warning; }
            set
            {
                _warning = value;
                WarningLabel.Visible = !string.IsNullOrWhiteSpace(_warning);
                MetroToolTip.SetToolTip(WarningLabel, _warning);
            }
        }

        public string ToolTip
        {
            get { return _toolTip; }

            set
            {
                _toolTip = value;
                MetroToolTip.SetToolTip(SettingValue, _toolTip);
            }
        }

        public bool IsValid
        {
            get { return _isValid; }
        }

        public bool ValueChanged
        {
            get { return _valueChanged; }
        }

        private void SettingsString_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control crtl in Controls)
            {
                crtl.Enabled = Enabled;
            }
        }

        private void AddFont()
        {
            var pfc = new PrivateFontCollection();
        }

        private void SettingValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (Regex != null)
            {
                _isValid = new Regex(Regex).IsMatch(SettingValue.Text);
                //SettingValue.CustomBackground = !_isValid;
            }
            _valueChanged = true;
        }
    }
}