using System;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    public partial class SettingsCombo : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;

        private string _warning;

        public SettingsCombo()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
            SettingValue.SelectedIndexChanged += Combo_Changed;
        }

        public object DataSource
        {
            get { return SettingValue.DataSource; }
            set { SettingValue.DataSource = value; }
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

        public int? Value
        {
            get { return (int?) SettingValue?.SelectedValue; }
            set
            {
                SettingValue.SelectedValue = value ?? 0;
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

        public event EventHandler ComboChanged;

        private void Combo_Changed(object sender, EventArgs e)
        {
            ComboChanged?.Invoke(this, e);
        }

        private void SettingsString_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control crtl in Controls)
            {
                crtl.Enabled = Enabled;
            }
        }


        private void SettingValue_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ValueChanged = true;
        }
    }
}