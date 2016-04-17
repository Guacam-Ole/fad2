using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace fad2.Backend
{
    public class FileLoader
    {

        private List<SingleFileSetting> _allLines;

        public Settings LoadFromFile(string fileName)
        {
            _allLines = new List<SingleFileSetting>();
            string[] lines = File.ReadAllLines(fileName);
            int i = 0;
            foreach (string line in lines)
            {
                i++;
                _allLines.Add(new SingleFileSetting(i,line));
            }       


        }
    }
}
