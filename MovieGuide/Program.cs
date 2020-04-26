using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace Proje
{
    static class Program
    {
        //Veritabanı bağlantısı kuruluyor.
        public static MySqlConnection con = new MySqlConnection("SERVER=localhost; DATABASE=movie_guide;UID=movie_guide;PASSWORD=password;"); 
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Program.con.Open();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Main());
        }
    }
}
