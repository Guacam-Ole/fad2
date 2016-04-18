using System;

namespace fad2.Backend
{
    public class SettingAttribute : Attribute
    {
        public SettingAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }
        public bool CanSetThroughAir { get; set; }
        public string Default { get; set; }
        public string Parent { get; set; }
    }
}