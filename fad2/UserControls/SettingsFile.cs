using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace fad2.UI.UserControls
{
    /// <summary>
    /// Setting with FIle Selector
    /// </summary>
    public partial class SettingsFile : MetroUserControl
    {
        private string _internalName;
        private string _toolTip;

        /// <summary>
        /// Setting with File Selector
        /// </summary>
        public SettingsFile()
        {
            InitializeComponent();
            EnabledChanged += SettingsString_EnabledChanged;
        }

        /// <summary>
        /// Filter
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Directory Only?
        /// </summary>
        public bool DirectoryOnly { get; set; }

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
        /// Password Character
        /// </summary>
        public char PasswordChar
        {
            get { return SettingValue.PasswordChar; }
            set { SettingValue.PasswordChar = value; }
        }
        /// <summary>
        /// Maximum characters
        /// </summary>
        public int MaxCharacters
        {
            get { return SettingValue.MaxLength; }
            set { SettingValue.MaxLength = value; }
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
            set { SettingValue.Text = value; }
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
        /// Is this a valid setting?
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


        private void SettingValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (Regex != null)
            {
                IsValid = new Regex(Regex).IsMatch(SettingValue.Text);
            }
            ValueChanged = true;
        }

        private void SelectFile_Click(object sender, EventArgs e)
        {
            if (DirectoryOnly)
            {
                var dlg = new FolderBrowserDialog();
                if (!string.IsNullOrWhiteSpace(Value))
                {
                    dlg.SelectedPath = Value;
                }
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
                if (!string.IsNullOrWhiteSpace(Value))
                {
                    fld.FileName = Value;
                }
                fld.ShowDialog();
                SettingValue.Text = fld.FileName;
            }
        }
    }
}