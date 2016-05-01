using System;
using System.IO;
using System.Reflection;
using log4net;

namespace fad2.Backend
{
    /// <summary>
    ///     Informations for a single File on Flashair-card
    /// </summary>
    public class FlashAirFileInformation
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// New FileInformation
        /// </summary>
        public FlashAirFileInformation() { }

        /// <summary>
        ///     Create new Information-Object from returnstring
        /// </summary>
        /// <param name="originalData">String returned by api</param>
        public FlashAirFileInformation(string originalData)
        {
            var singleElements = originalData.Split(',');
            if (singleElements.Length != 6)
            {
                // There are some lines that are no File Information and therefore should be ignored
                return;
            }
            Directory = singleElements[0];
            Filename = singleElements[1];
            Size = int.Parse(singleElements[2]);
            Attributes = int.Parse(singleElements[3]);
            DateAttributes = int.Parse(singleElements[4]);
            TimeAttributes = int.Parse(singleElements[5]);
            CalcAttributes();
            CalcDate();
        }

        /// <summary>
        /// Extension
        /// </summary>
        public string Extension
        {
            get
            {
                return Filename == null ? string.Empty : Path.GetExtension(Filename);
            }
        }

        /// <summary>
        ///     Absolute Directory
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        ///     Filename
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        ///     Filesize
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        ///     File Attributes
        /// </summary>
        public int Attributes { get; set; }

        /// <summary>
        ///     Date Attributes
        /// </summary>
        public int DateAttributes { get; set; }

        /// <summary>
        ///     Time Attributes
        /// </summary>
        public int TimeAttributes { get; set; }

        /// <summary>
        ///     File is Archived?
        /// </summary>
        public bool Archive { get; set; }

        /// <summary>
        ///     File is Volume?
        /// </summary>
        public bool IsVolume { get; set; }

        /// <summary>
        ///     File is Directory?
        /// </summary>
        public bool IsDirectory { get; set; }

        /// <summary>
        ///     FIle is Systemfile?
        /// </summary>
        public bool SystemFile { get; set; }

        /// <summary>
        ///     File is Hidden?
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        ///     File is Readonly?
        /// </summary>
        public bool ReadOnly { get; set; }

        /// <summary>
        ///     Date the Picture is taken
        /// </summary>
        public DateTime PictureTaken { get; set; }

        private void CalcAttributes()
        {
            ReadOnly = GetBit(Attributes, 0);
            Hidden = GetBit(Attributes, 1);
            SystemFile = GetBit(Attributes, 2);
            IsDirectory = GetBit(Attributes, 3); // Documentation calls this "Directly", but I am quite shure this is just one of those many translation errors in the api documentation.
            IsVolume = GetBit(Attributes, 4);
            Archive = GetBit(Attributes, 5);
        }

        private void CalcDate()
        {
            PictureTaken = GetDateFromBits(DateAttributes, TimeAttributes);
        }

        private static bool GetBit(int i, int bitNumber)
        {
            return (i & (1 << bitNumber)) != 0;
        }

        private static int GetBitRange(int bit, int bitNumberStart, int bitNumberEnd)
        {
            var value = 0;
            var counter = 0;
            for (var i = bitNumberStart; i <= bitNumberEnd; i++)
            {
                if (GetBit(bit, i))
                {
                    value += (int) Math.Pow(2, counter);
                }
                counter++;
            }
            return value;
        }

        private DateTime GetDateFromBits(int dateBits, int timeBits)
        {
            try
            {
                var day = GetBitRange(dateBits, 0, 4);
                var month = GetBitRange(dateBits, 5, 8);
                var year = 1980 + GetBitRange(dateBits, 9, 15);

                var second = GetBitRange(timeBits, 0, 4)*2;
                var minute = GetBitRange(timeBits, 5, 10);
                var hour = GetBitRange(timeBits, 11, 15);

                var fileDate = new DateTime(year, month, day, hour, minute, second);
                return fileDate;
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                return new DateTime(1980, 1, 1);
            }
        }
    }
}