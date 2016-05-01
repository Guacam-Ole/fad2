using System;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Settimg with simgle label
    /// </summary>
    public partial class SettingsLabel : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;
        private string _warning;

        /// <summary>
        /// Setting with single Label
        /// </summary>
        public SettingsLabel()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
        }
         
        /// <summary>
        /// Regex
        /// </summary>
        public string Regex { get; set; }

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
        public string Value
        {
            get { return SettingValue.Text; }
            set
            {
                SettingValue.Text = value;
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

        /// <summary>
        /// Is valid?
        /// </summary>
        public bool IsValid { get; set; } = true;

        /// <summary>
        /// Value changed?
        /// </summary>
        public bool ValueChanged { get; set; }

        private void SettingsString_EnabledChanged(object sender, EventArgs e)
        {
            foreach (Control crtl in Controls)
            {
                crtl.Enabled = Enabled;
            }
        }
    }
}