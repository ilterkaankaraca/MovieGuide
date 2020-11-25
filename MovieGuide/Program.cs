using System;
using System.Windows.Forms;

namespace MovieGuide
{
    static class Program
    {
        //Veritabanı bağlantısı kuruluyor.

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
