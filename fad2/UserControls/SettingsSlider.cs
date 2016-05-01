using System;
using System.Drawing.Text;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Slider
    /// </summary>
    public partial class SettingsSlider : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;
        private string _warning;

        /// <summary>
        /// New Slider
        /// </summary>
        public SettingsSlider()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
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
        /// Minimum-Value
        /// </summary>
        public int Minimum
        {
            get { return SettingValue.Minimum; }
            set { SettingValue.Minimum = value; }
        }

        /// <summary>
        /// Maximum-Value
        /// </summary>
        public int Maximum
        {
            get { return SettingValue.Maximum; }
            set { SettingValue.Maximum = value; }
        }

        /// <summary>
        /// Value
        /// </summary>
        public int Value
        {
            get { return SettingValue.Value; }
            set
            {
                SettingValue.Value = value;
                Enabled = UiSettings.HasFeature(SettingVersion.Text);
            }
        }

        /// <summary>
        /// Ruquired Version
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

       
        /// <summary>
        /// Value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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