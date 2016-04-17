using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace fad2.Backend
{
    public class FileLoader
    {
        private ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private List<SingleFileSetting> _allLines;

        public Settings LoadFromFile(string fileName)
        {
            Settings setting = new Settings();
            _allLines = new List<SingleFileSetting>();
            string[] lines = File.ReadAllLines(fileName);
            int i = 0;
            foreach (string line in lines)
            {   try
                {
                    i++;
                    var singleSetting = new SingleFileSetting(i, line) { Setting = setting };
                    singleSetting.CheckLine();

                    _allLines.Add(singleSetting);
                } catch (Exception ex)
                {
                    _log.Error(ex);
                }
            }
            
            return setting;
        }

        public void SaveToFile(string version, string fileName, Settings settings)
        {
            List<string> configFileContent = new List<string>();
            Dictionary<string, string> vendorValues;
            Dictionary<string, string> sdWlanValues;

            GetCategorizedValues(settings, out vendorValues, out sdWlanValues);
            configFileContent.Add("[FlashAirDownloader]");
            configFileContent.Add($"FAD_Version={version}");
            configFileContent.Add($"FAD_Url=http://dotnet.work/fad2");
            configFileContent.Add(string.Empty);
            if (vendorValues.Count>0)
            {
                configFileContent.Add("[Vendor]");
                foreach (KeyValuePair<string,string> pair in vendorValues)
                {
                    configFileContent.Add($"{pair.Key}={pair.Value}");
                }
                configFileContent.Add(string.Empty);
            }
            if (sdWlanValues.Count > 0)
            {
                configFileContent.Add("[WLANSD]");
                foreach (KeyValuePair<string, string> pair in sdWlanValues)
                {
                    configFileContent.Add($"{pair.Key}={pair.Value}");
                }
                configFileContent.Add(string.Empty);
            }
            File.WriteAllLines(fileName, configFileContent);

        }

        private void  GetCategorizedValues(Settings settings, out Dictionary<string,string> vendorValues, out Dictionary<string,string>sdWlanValues)
        {
            vendorValues = new Dictionary<string, string>();
            sdWlanValues = new Dictionary<string, string>();

            foreach (var property in settings.GetType().GetProperties())
            {
                var customAttribute = (SettingAttribute)property.GetCustomAttributes(typeof(SettingAttribute), true).FirstOrDefault();
                if (customAttribute!=null)
                {
                    var value = property.GetValue(settings, null);
                    string strValue = null;
                    if (value==null)
                    {
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(customAttribute.TrueValue))
                    {
                        strValue = (bool)value ? customAttribute.TrueValue : customAttribute.FalseValue;
                   
                    } else
                    {
                        strValue = value.ToString();
                    }

                    if (strValue == customAttribute.Default)
                    {
                        continue;   // system default. No need to save that
                    }

                    if (customAttribute.Parent=="Vendor")
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
