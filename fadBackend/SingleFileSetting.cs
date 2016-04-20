using System.Linq;

namespace fad2.Backend
{
    /// <summary>
    /// Single Setting from Settings-File
    /// </summary>
    public class SingleFileSetting
    {
        /// <summary>
        /// New single Setting
        /// </summary>
        /// <param name="pos">Line pos in File</param>
        /// <param name="line">Content from line</param>
        public SingleFileSetting(int pos, string line)
        {
            Line = pos;
            Original = line;
        }

        /// <summary>
        /// Line in File
        /// </summary>
        public int Line { get; set; }
        /// <summary>
        /// Original string
        /// </summary>
        public string Original { get; set; }
        /// <summary>
        /// Is this a category title?
        /// </summary>
        public bool IsTitle { get; set; }
        /// <summary>
        /// Is this a setting?
        /// </summary>
        public bool IsSetting { get; set; }
        /// <summary>
        /// Do I know this setting?
        /// </summary>
        public bool IsKnown { get; set; }
        /// <summary>
        /// Key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Is this just an empty line?
        /// </summary>
        public bool IsEmpty { get; set; }
        /// <summary>
        /// Is this modified?
        /// </summary>
        public bool IsModified { get; set; }
        /// <summary>
        /// Single Setting
        /// </summary>
        public Settings Setting { get; set; }

        /// <summary>
        /// Check Line Contents
        /// </summary>
        public void CheckLine()
        {
            if (string.IsNullOrWhiteSpace(Original))
            {
                IsEmpty = true;
            }
            else if (Original.Contains('[') && Original.Contains(']'))
            {
                GetTitle();
            }
            else if (Original.Contains('='))
            {
                GetSetting();
            }
        }

        private void GetSetting()
        {
            IsSetting = true;
            var divider = Original.IndexOf('=');
            Key = Original.Substring(0, divider);
            Value = Original.Substring(divider + 1);

            var settingProperties = typeof(Settings).GetProperties();
            foreach (var property in settingProperties)
            {
                var settingsAttributes = property.GetCustomAttributes(typeof(SettingAttribute), true);
                var settingsAttribute = settingsAttributes.FirstOrDefault();
                if (settingsAttribute == null) continue;
                var attr = (SettingAttribute) settingsAttribute;
                if (attr.Name != Key) continue;
                if (property.PropertyType == typeof(int))
                {
                    property.SetValue(Setting, int.Parse(Value), null);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    property.SetValue(Setting, Value == attr.TrueValue, null);
                }
                else
                {
                    property.SetValue(Setting, Value, null);
                }

                IsKnown = true;
                break;
            }
        }

        private void GetTitle()
        {
            IsTitle = true;
            var titleStart = Original.IndexOf('[') + 1;
            var titleEnd = Original.IndexOf(']') - 1;

            Value = Original.Substring(titleStart, titleEnd - titleStart + 1);
            switch (Value)
            {
                case "Vendor":
                case "WLANSD":
                    IsKnown = true;
                    break;
            }
        }
    }
}