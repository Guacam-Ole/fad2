using System;

namespace fad2.Backend
{
    /// <summary>
    ///     Program setings
    /// </summary>
    public class ProgramSettings
    {
        /// <summary>
        ///     Available AppModes
        /// </summary>
        public enum AppModes
        {
            AccessPoint = 4,
            Station = 5,
            PassThru = 6
        }

        /// <summary>
        ///     Card Directory Modes
        /// </summary>
        public enum CardDirModes
        {
            NoDirectory = 0,
            CardId = 1,
            ApplicationName = 2
        }


        /// <summary>
        ///     Date Modes
        /// </summary>
        public enum DateModes
        {
            NoDirectory = 0,
            Year = 1,
            Month = 2,
            Day = 3,
            Custom = 4
        }

        /// <summary>
        ///     Dns Modes
        /// </summary>
        public enum DnsModes
        {
            OnlyAppName = 0,
            Always = 1
        }

        /// <summary>
        ///     File Types
        /// </summary>
        public enum FileTypes
        {
            Images = 0,
            Videos = 1,
            AllFiles = 2
        }

        /// <summary>
        ///     Overwrite Modes
        /// </summary>
        public enum OverwriteModes
        {
            Never = 0,
            Newer = 1,
            Always = 2,
            Copy = 3
        }

        public enum ServiceOption
        {
            Install = 0,
            Uninstall = 1,
            Start = 2,
            Stop = 3
        }

        public enum Themes
        {
            Light = 0,
            Dark = 1
        }

        /// <summary>
        ///     Webdav Modes
        /// </summary>
        public enum WebDavModes
        {
            Disable = 0,
            ReadOnly = 1,
            ReadWrite = 2
        }

        /// <summary>
        ///     Flashair-Address
        /// </summary>
        public string FlashAirUrl { get; set; }

        /// <summary>
        ///     Local Path
        /// </summary>
        public string LocalPath { get; set; }

        /// <summary>
        ///     How to deal with existing files?
        /// </summary>
        public int ExistingFiles { get; set; }

        /// <summary>
        ///     Delete files after copying?
        /// </summary>
        public bool DeleteFiles { get; set; }

        /// <summary>
        ///     Folder creation when using multiple Cards
        /// </summary>
        public int MultiCardsFolder { get; set; }

        /// <summary>
        ///     Create a folder by date?
        /// </summary>
        public int CreateByDate { get; set; }

        /// <summary>
        ///     Folder format
        /// </summary>
        public string FolderFomat { get; set; }

        /// <summary>
        ///     Interval to check for files when using service
        /// </summary>
        public int FileCheckInterval { get; set; }

        /// <summary>
        ///     What files to copy?
        /// </summary>
        public int FileTypesToCopy { get; set; } = 1;

        /// <summary>
        ///     What Images to use for background
        /// </summary>
        public string ImageBackgroundFolder { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "examplepix";

        /// <summary>
        ///     Where to start looking for files?
        /// </summary>
        public string CardStartupPath { get; set; } = "/";

        /// <summary>
        ///     Load Thumbnails?
        /// </summary>
        public bool LoadThumbs { get; set; } = true;

        public string Theme { get; set; } = "Light";

        public int BackgroundInterval { get; set; } = 10;

        public bool ShowBackgroundImage { get; set; } = true;
        public bool ShowTiles { get; set; } = true;
    }
}