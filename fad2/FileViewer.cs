using System.IO;
using MetroFramework.Forms;

namespace fad2.UI
{
    /// <summary>
    /// Generic File Viewer
    /// </summary>
    public partial class FileViewer : MetroForm
    {
        /// <summary>
        /// File Viewer
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="filename">Filename</param>
        public FileViewer(string title = "Text viewer", string filename = null)
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
            using (var sr = File.OpenText(filename))
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