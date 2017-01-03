using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace fad2.Backend
{
    public class ServiceSettings
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string _filename= Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),"fad.service.json");
        public void Save(ProgramSettings settings)
        {
            FileLoader loader = new FileLoader();
            loader.SaveProgramSettings(settings, _filename);
        }
        public ProgramSettings Load() {
            try
            {
                FileLoader loader = new FileLoader();
                return loader.LoadProgramSettings(_filename);
            } catch (Exception ex)
            {
                _log.Error(ex);
                return null;
            }
        }
    }
}
