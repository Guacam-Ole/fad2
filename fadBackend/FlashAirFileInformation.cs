using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fad2.Backend
{
    public class FlashAirFileInformation
    {
        public  string Directory { get; set; }
        public  string Filename { get; set; }
        public  int Size { get; set; }
        public  int Attributes { get; set; }
        public  int DateAttributes { get; set; }
        public  int TimeAttributes { get; set; }
        public  bool Archive { get; set; }
        public  bool IsVolume { get; set; }
        public  bool IsDirectory { get; set; }  
        public  bool SystemFile { get; set; }
        public  bool Hidden { get; set; }
        public  bool ReadOnly { get; set; }
        public  DateTime PictureTaken { get; set; }

        private void CalcAttributes()
        {
            ReadOnly = GetBit(Attributes, 0);
            Hidden = GetBit(Attributes, 1);
            SystemFile = GetBit(Attributes, 2);
            IsDirectory = GetBit(Attributes, 3);   // Documentation calls this "Directly", but I think this is just one of those many translation errors in the api documentation...
            IsVolume = GetBit(Attributes, 4);
            Archive = GetBit(Attributes, 5);
        }

        public FlashAirFileInformation(string originalData)
        {
            string[] singleElements = originalData.Split(',');
            if (singleElements.Length != 6)
            {
                // strange....
                return;
                //throw new ArgumentException($"Unexpected format for ImageData: {originalData}");
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

        private void CalcDate()
        {
            PictureTaken = GetDateFromBits(DateAttributes, TimeAttributes);
        }


        private bool GetBit(int i, int bitNumber)
        {
            return (i & (1 << bitNumber)) != 0;
        }

       
        private int GetBitRange(int bit, int bitNumberStart, int bitNumberEnd)
        {
            int value = 0;
            int counter = 0;
            for (int i = bitNumberStart; i <= bitNumberEnd; i++)
            {

                if (GetBit(bit, i))
                {
                    value += (int)Math.Pow(2, counter);
                }
                counter++;
            }
            return value;
        }

      
        private DateTime GetDateFromBits(int dateBits, int timeBits)
        {
            try
            {
                int day = GetBitRange(dateBits, 0, 4);
                int month = GetBitRange(dateBits, 5, 8);
                int year = 1980 + GetBitRange(dateBits, 9, 15);

                int second = GetBitRange(timeBits, 0, 4) * 2;
                int minute = GetBitRange(timeBits, 5, 10);
                int hour = GetBitRange(timeBits, 11, 15);

                DateTime fileDate = new DateTime(year, month, day, hour, minute, second);
                return fileDate;
            }
            catch (Exception ex)
            {               
                // TODO: Log
                return new DateTime(1980, 1, 1);
            }
        }

    }
}
