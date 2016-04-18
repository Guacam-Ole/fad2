﻿using System;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    public partial class SettingsFile : MetroUserControl
    {
        private string _internalName;
        protected bool _isValid = true;


        private string _toolTip;

        protected bool _valueChanged;

        public SettingsFile()
        {
            InitializeComponent();
            AddFont();
            EnabledChanged += SettingsString_EnabledChanged;
        }

        public string Filter { get; set; }
        public bool DirectoryOnly { get; set; }

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
            set { SettingValue.Text = value; }
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
                SettingValue.CustomBackground = !_isValid;
            }
            _valueChanged = true;
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (DirectoryOnly)
            {
                var dlg = new FolderBrowserDialog();
                dlg.ShowDialog();
                SettingValue.Text = dlg.SelectedPath;
                if (!string.IsNullOrWhiteSpace(SettingValue.Text) && !SettingValue.Text.EndsWith("\\"))
                {
                    SettingValue.Text += @"\";
                }
            }
            else
            {
                var fld = new OpenFileDialog {Filter = Filter};
                fld.ShowDialog();
                SettingValue.Text = fld.FileName;
            }
        }
    }
}