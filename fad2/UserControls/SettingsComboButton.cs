using System;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    public delegate void ClickEventHandler(object sender, EventArgs e);

    public partial class SettingsComboButton : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;


        private string _warning;

        public SettingsComboButton()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
            Action.Click += Action_Click;
        }


        public string ButtonText
        {
            get { return Action.Text; }
            set { Action.Text = value; }
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
            set { SettingValue.SelectedItem = value; }
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