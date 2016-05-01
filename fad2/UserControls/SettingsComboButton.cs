using System;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Click-Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void ClickEventHandler(object sender, EventArgs e);

    /// <summary>
    /// Combobox with button
    /// </summary>
    public partial class SettingsComboButton : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;
        private string _warning;

        /// <summary>
        /// Combobox with button
        /// </summary>
        public SettingsComboButton()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
            Action.Click += Action_Click;
        }

        /// <summary>
        /// Buttontext
        /// </summary>
        public string ButtonText
        {
            get { return Action.Text; }
            set { Action.Text = value; }
        }

        /// <summary>
        /// Datasource
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
            set { SettingValue.SelectedItem = value; }
        }

        /// <summary>
        /// Value changed
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
        /// Button clicked
        /// </summary>
        public event ClickEventHandler ButtonClicked;

        private void Action_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
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