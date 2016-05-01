using System;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Combobox-Setting
    /// </summary>
    public partial class SettingsCombo : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;
        private string _warning;

        /// <summary>
        /// Combo-Setting
        /// </summary>
        public SettingsCombo()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
            SettingValue.SelectedIndexChanged += Combo_Changed;
        }

        /// <summary>
        /// Data-Source
        /// </summary>
        public object DataSource
        {
            get { return SettingValue.DataSource; }
            set { SettingValue.DataSource = value; }
        }

        /// <summary>
        /// Internal Name
        /// </summary>
        public string InternalName
        {
            get { return _internalName; }
            set
            {
                _internalName = value;
                MetroToolTip.SetToolTip(SettingKey, value);
            }
        }

        /// <summary>
        /// Key
        /// </summary>
        public string Key
        {
            get { return SettingKey.Text; }
            set { SettingKey.Text = value; }
        }

        /// <summary>
        /// Value
        /// </summary>
        public int? Value
        {
            get { return (int?) SettingValue?.SelectedValue; }
            set
            {
                SettingValue.SelectedValue = value ?? 0;
                Enabled = UiSettings.HasFeature(SettingVersion.Text);
            }
        }

        /// <summary>
        /// Required Version
        /// </summary>
        public string RequiredVersion
        {
            get { return SettingVersion.Text; }
            set { SettingVersion.Text = value; }
        }

        /// <summary>
        /// Value changed?
        /// </summary>
        public bool ValueChanged { get; private set; }

        /// <summary>
        /// Warning
        /// </summary>
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

        /// <summary>
        /// ToolTip
        /// </summary>
        public string ToolTip
        {
            get { return _toolTip; }

            set
            {
                _toolTip = value;
                MetroToolTip.SetToolTip(SettingValue, _toolTip);
            }
        }

        /// <summary>
        /// Combo Changed Event
        /// </summary>
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