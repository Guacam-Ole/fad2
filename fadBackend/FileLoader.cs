using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;

namespace fad2.Backend
{
    public class FileLoader
    {
        private List<SingleFileSetting> _allLines;
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Settings LoadFromFile(string fileName)
        {
            var setting = new Settings();
            _allLines = new List<SingleFileSetting>();
            var lines = File.ReadAllLines(fileName);
            var i = 0;
            foreach (var line in lines)
            {
                try
                {
                    i++;
                    var singleSetting = new SingleFileSetting(i, line) {Setting = setting};
                    singleSetting.CheckLine();

                    _allLines.Add(singleSetting);
                }
                catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }

            return setting;
        }

        public void SaveToFile(string version, string fileName, Settings settings)
        {
            var configFileContent = new List<string>();
            Dictionary<string, string> vendorValues;
            Dictionary<string, string> sdWlanValues;

            GetCategorizedValues(settings, out vendorValues, out sdWlanValues);
            configFileContent.Add("[FlashAirDownloader]");
            configFileContent.Add($"FAD_Version={version}");
            configFileContent.Add($"FAD_Url=http://dotnet.work/fad2");
            configFileContent.Add(string.Empty);
            if (vendorValues.Count > 0)
            {
                configFileContent.Add("[Vendor]");
                foreach (var pair in vendorValues)
                {
                    configFileContent.Add($"{pair.Key}={pair.Value}");
                }
                configFileContent.Add(string.Empty);
            }
            if (sdWlanValues.Count > 0)
            {
                configFileContent.Add("[WLANSD]");
                foreach (var pair in sdWlanValues)
                {
                    configFileContent.Add($"{pair.Key}={pair.Value}");
                }
                configFileContent.Add(string.Empty);
            }
            File.WriteAllLines(fileName, configFileContent);
        }

        private void GetCategorizedValues(Settings settings, out Dictionary<string, string> vendorValues,
            out Dictionary<string, string> sdWlanValues)
        {
            vendorValues = new Dictionary<string, string>();
            sdWlanValues = new Dictionary<string, string>();

            foreach (var property in settings.GetType().GetProperties())
            {
                var customAttribute =
                    (SettingAttribute) property.GetCustomAttributes(typeof(SettingAttribute), true).FirstOrDefault();
                if (customAttribute != null)
                {
                    var value = property.GetValue(settings, null);
                    string strValue = null;
                    if (value == null)
                    {
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(customAttribute.TrueValue))
                    {
                        strValue = (bool) value ? customAttribute.TrueValue : customAttribute.FalseValue;
                    }
                    else
                    {
                        strValue = value.ToString();
                    }

                    if (strValue == customAttribute.Default)
                    {
                        continue; // system default. No need to save that
                    }

                    if (customAttribute.Parent == "Vendor")
                    {
                        vendorValues.Add(customAttribute.Name, strValue);
                    }
                    else
                    {
                        sdWlanValues.Add(customAttribute.Name, strValue);
                    }
                }
            }
        }
    }
}