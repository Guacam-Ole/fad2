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
    }
}
