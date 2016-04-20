using System;

namespace fad2.Backend
{
    /// <summary>
    /// Single Setting Attribute (Matching Settings-File-Names to properties
    /// </summary>
    public class SettingAttribute : Attribute
    {
        /// <summary>
        /// New Setting Attribute
        /// </summary>
        /// <param name="name">Name in Settings-File</param>
        public SettingAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Name in Settings File
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Value that means "true"
        /// </summary>
        public string TrueValue { get; set; }
        /// <summary>
        /// Value that means "false"
        /// </summary>
        public string FalseValue { get; set; }
        /// <summary>
        /// Can be set through command.cgi?
        /// </summary>
        public bool CanSetThroughAir { get; set; }
        /// <summary>
        /// Default value
        /// </summary>
        public string Default { get; set; }
        /// <summary>
        /// Parent group
        /// </summary>
        public string Parent { get; set; }
    }
}