using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fad2.Backend
{
    public class ProgramSettings
    {
        public string FlashAirUrl { get; set; }
        public string LocalPath { get; set; }
        public int ExistingFiles { get; set; }
        public bool DeleteFiles { get; set; }
        public int MultiCardsFolder { get; set; }
        public int CreateByDate { get; set; }
        public string FolderFomat { get; set; }
        public int FileCheckInterval { get; set; }

        public int LastTimeout { get; set; } = 300000;

        public enum AppModes
        {
            AccessPoint=4,
            Station=5,
            PassThru=6
        }

        public enum DnsModes
        {
            OnlyAppName=0,
            Always=1
        }

        public enum CardDirModes
        {
            NoDirectory=0,
            CardId=1,
            ApplicationName=2
        }


        public enum WebDavModes
        {
            Disable=0,
            ReadOnly=1,
            ReadWrite=2
        }


        public enum DateModes
        {
            NoDirectory=0,
            Year=1,
            Month=2,
            Day=3,
            Custom=4
        }

        public enum OverwriteModes
        {
            Never=0,
            Newer=1,
            Always=2,
            Copy=3
        }

        public enum ServiceOption
        {
            Install=0,
            Uninstall=1,
            Start=2,
            Stop=3
        }
    }
}
