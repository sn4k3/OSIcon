using System;
using System.Windows.Forms;

namespace OSIcon.Explorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public const string AppTitle = "OSIcon Explorer";

        public static Main mainFrm;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mainFrm = new Main();
            Application.Run(mainFrm);
        }
    }
}
