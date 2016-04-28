using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using log4net;
using Newtonsoft.Json;

namespace fad2.Backend
{
    /// <summary>
    ///     Methods to load local files
    /// </summary>
    public class FileLoader
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private List<SingleFileSetting> _allLines;

        /// <summary>
        ///     Load a file
        /// </summary>
        /// <param name="fileName">filename</param>
        /// <returns>Settings</returns>
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

        /// <summary>
        ///     Save Program settings
        /// </summary>
        /// <param name="settings">Settings</param>
        /// <param name="filename">File to save to</param>
        public void SaveProgramSettings(ProgramSettings settings, string filename)
        {
            File.WriteAllText(filename, JsonConvert.SerializeObject(settings));
        }

        /// <summary>
        ///     Load program settings
        /// </summary>
        /// <param name="filename">Settingsfile</param>
        /// <returns>Settings</returns>
        public ProgramSettings LoadProgramSettings(string filename)
        {
            if (File.Exists(filename))
            {
                return JsonConvert.DeserializeObject<ProgramSettings>(File.ReadAllText(filename));
            }
            return new ProgramSettings
            {
                FlashAirUrl = "http://flashair",
                LocalPath = "C:\\",
                CreateByDate = (int) ProgramSettings.DateModes.Month,
                FileCheckInterval = 60,
                FolderFomat = "{2:yyyy-MM-dd}"
            };
        }

        /// <summary>
        ///     Save Flashair-Settingsfile
        /// </summary>
        /// <param name="version">FAD-Version</param>
        /// <param name="fileName">Filename</param>
        /// <param name="settings">Settings</param>
        public void SaveToFile(string version, string fileName, Settings settings)
        {
            var configFileContent = new List<string>();
            Dictionary<string, string> vendorValues;
            Dictionary<string, string> sdWlanValues;

            GetCategorizedValues(settings, out vendorValues, out sdWlanValues);
            configFileContent.Add("[FlashAirDownloader]");
            configFileContent.Add($"FAD_Version={version}");
            configFileContent.Add("FAD_Url=http://dotnet.work/fad2");
            configFileContent.Add(string.Empty);
            if (vendorValues.Count > 0)
            {
                configFileContent.Add("[Vendor]");
                configFileContent.AddRange(vendorValues.Select(pair => $"{pair.Key}={pair.Value}"));
                configFileContent.Add(string.Empty);
            }
            if (sdWlanValues.Count > 0)
            {
                configFileContent.Add("[WLANSD]");
                configFileContent.AddRange(sdWlanValues.Select(pair => $"{pair.Key}={pair.Value}"));
                configFileContent.Add(string.Empty);
            }
            File.WriteAllLines(fileName, configFileContent);
        }

        private void GetCategorizedValues(Settings settings, out Dictionary<string, string> vendorValues, out Dictionary<string, string> sdWlanValues)
        {
            vendorValues = new Dictionary<string, string>();
            sdWlanValues = new Dictionary<string, string>();

            foreach (var property in settings.GetType().GetProperties())
            {
                var customAttribute = (SettingAttribute) property.GetCustomAttributes(typeof(SettingAttribute), true).FirstOrDefault();
                if (customAttribute == null) continue;
                var value = property.GetValue(settings, null);
                string strValue;
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