﻿using System;
using System.Drawing.Text;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    public partial class SettingsSlider : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;


        private string _warning;

        public SettingsSlider()
        {
            InitializeComponent();
            AddFont();
            EnabledChanged += SettingsString_EnabledChanged;
        }

        public string InternalName
        {
            get { return _internalName; }
            set
            {
                _internalName = value;
                MetroToolTip.SetToolTip(SettingKey, value);
            }
        }

        public string Key
        {
            get { return SettingKey.Text; }
            set { SettingKey.Text = value; }
        }

        public int Minimum
        {
            get { return SettingValue.Minimum; }
            set { SettingValue.Minimum = value; }
        }

        public int Maximum
        {
            get { return SettingValue.Maximum; }
            set { SettingValue.Maximum = value; }
        }


        public int Value
        {
            get { return SettingValue.Value; }
            set
            {
                SettingValue.Value = value;
                Enabled = UiSettings.HasFeature(SettingVersion.Text);
            }
        }

        public string RequiredVersion
        {
            get { return SettingVersion.Text; }
            set { SettingVersion.Text = value; }
        }

        public bool ValueChanged { get; private set; }


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

        protected virtual void SettingValue_Scroll(object sender, ScrollEventArgs e)
        {
            //Application.DoEvents();
        }

        protected virtual void SettingValue_ValueChanged(object sender, EventArgs e)
        {
            MetroToolTip.SetToolTip(SettingValue, SettingValue.Value.ToString());
        }

        private void SettingsSlider_Click(object sender, EventArgs e)
        {
            ValueChanged = true;
        }
    }
}