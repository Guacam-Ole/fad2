using System;
using System.Windows.Forms;

namespace fad2.UI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Fad());
            UiSettings.CardVersion = "9.0.0.0";
        }
    }
}