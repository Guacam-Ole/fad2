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

namespace fad2.UI
{
    public partial class SettingsCombo : MetroFramework.Controls.MetroUserControl
    {
        public SettingsCombo()
        {
            InitializeComponent();
            this.EnabledChanged += SettingsString_EnabledChanged;
        }

        private void SettingsString_EnabledChanged(object sender, EventArgs e)
        {
           foreach (Control crtl in this.Controls)
            {
                crtl.Enabled = this.Enabled;
            }
        }

       public object DataSource { get
            {
                return SettingValue.DataSource;

            }
        set
            {
                SettingValue.DataSource = value;
            }
        }

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
        public object Value
        {
            get
            {
                return SettingValue.SelectedItem;
            }
            set
            {
                SettingValue.SelectedItem = value;
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
                Enabled &= UiSettings.HasFeature(value);
               
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

      

    }
}
