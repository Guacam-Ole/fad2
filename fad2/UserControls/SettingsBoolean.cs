using System;
using System.Drawing.Text;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Switch
    /// </summary>
    public partial class SettingsBoolean : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;
        private string _warning;

        /// <summary>
        /// Switch
        /// </summary>
        public SettingsBoolean()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
        }

        /// <summary>
        /// Value changed?
        /// </summary>
        public bool ValueChanged { get; private set; }

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
        public bool Value
        {
            get { return SettingValue.Checked; }
            set
            {
                SettingValue.Checked = value;
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
        /// Warning-Tooltip
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
        /// Tooltip
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

        private void SettingsString_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control crtl in Controls)
            {
                crtl.Enabled = Enabled;
            }
        }

        private void SettingValue_Click(object sender, EventArgs e)
        {
            ValueChanged = true;
        }
    }
}