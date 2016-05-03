using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace fad2.UI
{
    public partial class FileViewer : MetroForm
    {
        public FileViewer(string title="Text viewer", string filename=null)
        {
            InitializeComponent();
            Text = title;
            if (filename != null)
            {
                    LoadTextFile(filename);
            }
        }

        private void LoadTextFile(string filename)
        {
            using (StreamReader sr = File.OpenText(filename))
            {
                TextFileContent.Text = string.Empty;
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    TextFileContent.Text += s + "\r\n";
                }
            }
        }
    }
}
