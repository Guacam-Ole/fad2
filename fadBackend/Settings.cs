using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fad.Backend
{
    public class Settings
    {
        public string Url { get; set; }

        public Settings()
        {
            Url = "http://flashair";
        }
    }
}
