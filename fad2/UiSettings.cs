using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fad2.UI
{
    public static class UiSettings
    {
        public static string CardVersion { get; set; }
        public static bool HasFeature(string versionToCompare)
        {
            return versionToCompare.CompareTo(CardVersion) >= 0;
        }
    }
}
