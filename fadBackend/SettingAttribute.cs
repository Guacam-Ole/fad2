using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fad2.Backend
{
    public class SettingAttribute:Attribute
    {
        public string Name { get; set; }
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }
        public bool CanSetThroughAir { get; set; }
        public string Default { get; set; }

        public SettingAttribute(string name)
        {
            Name = name;
        }
    }
}
