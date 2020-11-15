using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MovieGuide
{
    static class Program
    {
        //Veritabanı bağlantısı kuruluyor.
        public static OleDbConnection databaseConnection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=MovieGuideDb.accdb"); 
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
