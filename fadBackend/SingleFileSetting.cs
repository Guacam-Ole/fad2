using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fad2.Backend
{
    public class SingleFileSetting
    {
        public int Line { get; set; }
        public string Original { get; set; }
        public bool IsTitle { get; set; }
        public bool IsSetting { get; set; }
        public bool IsKnown { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public bool IsEmpty { get; set; }

        public SingleFileSetting() { }
        public SingleFileSetting(int pos, string line)
        {
            Line = pos;
            Original = line;
            CheckLine();
        }

        private string[] _allowedValues= new [] {"ID","DHCP_Enabled"}

        private void CheckLine()
        {
            if (string.IsNullOrWhiteSpace(Original))
            {
                IsEmpty = true;
            } else if (Original.Contains('[') && Original.Contains(']'))
            {
                GetTitle();
            } else if (Original.Contains('='))
            {
                GetSetting();
            } 
        }

        private void GetSetting()
        {
            IsSetting = true;
            int divider = Original.IndexOf('=');
            Key = Original.Substring(0, divider);
            Value = Original.Substring(divider + 1);
        }

        private void GetTitle()
        {
            IsTitle = true;
            int titleStart = Original.IndexOf('[')+1;
            int titleEnd = Original.IndexOf(']')-1;

            Value = Original.Substring(titleStart, titleEnd - titleStart);
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
