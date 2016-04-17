using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text.RegularExpressions;

namespace fad2.UI.UserControls
{
    public partial class SettingsString : MetroFramework.Controls.MetroUserControl
    {
        public SettingsString()
        {
            InitializeComponent();
            AddFont();
            this.EnabledChanged += SettingsString_EnabledChanged;
        }

        private void SettingsString_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control crtl in this.Controls)
            {
                crtl.Enabled = this.Enabled;
            }
        }

        public string Regex { get; set; }

        private string _internalName;
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
            get
            {
                return SettingValue.MaxLength;
            }
            set
            {
                SettingValue.MaxLength = value;
            }
        }

        private string _warning;
        public string Key
        {
            get
            {
                return SettingKey.Text;
            }
            set
            {
                SettingKey.Text = value;
            }
        }
        public string Value
        {
            get
            {
                return SettingValue.Text;
            }
            set
            {
                SettingValue.Text = value;
                Enabled = UiSettings.HasFeature(SettingVersion.Text);
            }
        }
        public string RequiredVersion
        {
            get
            {
                return SettingVersion.Text;
            }
            set
            {
                SettingVersion.Text = value;
           

            }
        }

        public string Warning
        {
            get
            {
                return _warning;
            }
            set
            {
                _warning = value;
                WarningLabel.Visible = !string.IsNullOrWhiteSpace(_warning);
                MetroToolTip.SetToolTip(WarningLabel, _warning);
            }
        }

        private string _toolTip;
        public string ToolTip
        {
            get
            {
                return _toolTip;
            }

            set
            {
                _toolTip = value;
                MetroToolTip.SetToolTip(SettingValue, _toolTip);
            }
        }

        private void AddFont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();
        }
        protected bool _isValid = true;
        public bool IsValid
        {
            get
            {
                return _isValid;
            }
        }

        protected bool _valueChanged;
        public bool ValueChanged
        {
            get
            {
                return _valueChanged;
            }
        }

        private void SettingValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (Regex != null)
            {
                _isValid = new Regex(Regex).IsMatch(SettingValue.Text);
                SettingValue.CustomBackground = !_isValid;
            }
        }
    }
}
