using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.DirectoryServices;

namespace Proje
{
    class Database
    {
        public static OleDbCommand command;
        public static OleDbDataReader reader;
        public static OleDbDataAdapter adapter;
        public static DataTable table;
        public static string API = "";
  
        //veri tabanına ekleme yapan metot.
        public void Add(Movie movie)
        {
            if (ConnectionState.Closed == Program.con.State)
            {
                Program.con.Open();
            }
            command = new OleDbCommand("SELECT * FROM Movies WHERE IMDBID='"+movie.imdbID+"'",Program.con);
            reader = command.ExecuteReader();
            if (reader.Read()==false)
            {
                command = new OleDbCommand("INSERT INTO Movies([TITLE], [YEAR], [RATED], [RELEASED], [RUNTIME], [GENRE], [ACTORS], [PLOT], [DIRECTOR], [WRITER], [LANGUAGE], [COUNTRY], [AWARDS], [IMDBRATING], [IMDBVOTES], [IMDBID]) VALUES (@Title, @Year, @Rated, @Released, @Runtime, @Genre, @Actors, @Plot, @Director, @Writer, @Language, @Country, @Awards, @imdbRating, @imdbVotes, @imdbID)", Program.con);
                command.Parameters.AddWithValue("@Title", movie.Title);
                command.Parameters.AddWithValue("@Year", movie.Year);
                command.Parameters.AddWithValue("@Rated", movie.Rated);
                command.Parameters.AddWithValue("@Released", movie.Released);
                command.Parameters.AddWithValue("@Runtime", movie.Runtime);
                command.Parameters.AddWithValue("@Genre", movie.Genre);
                command.Parameters.AddWithValue("@Actors", movie.Actors);
                command.Parameters.AddWithValue("@Plot", movie.Plot);
                command.Parameters.AddWithValue("@Director", movie.Director);
                command.Parameters.AddWithValue("@Writer", movie.Writer);
                command.Parameters.AddWithValue("@Language", movie.Language);
                command.Parameters.AddWithValue("@Country", movie.Country);
                command.Parameters.AddWithValue("@Awards", movie.Awards);
                command.Parameters.AddWithValue("@imdbRating", movie.imdbRating);
                command.Parameters.AddWithValue("@imdbVotes", movie.imdbVotes);
                command.Parameters.AddWithValue("@imdbID", movie.imdbID);
                command.ExecuteNonQuery();
            }
            Program.con.Close();
                
        }
        //Bulunamayan filmlerin dosya yolunu ve adını bir tabloya kaydeden program
        public void Add(string path)
        {
            if (ConnectionState.Closed == Program.con.State)
            {
                Program.con.Open();
            }
            string title = path.Remove(0, path.LastIndexOf("\\") + 1);
            title = title.Replace("'", "");
            command = new OleDbCommand("SELECT * FROM NotFound WHERE TITLE='"+title+"'",Program.con);
            reader = command.ExecuteReader();
            if (reader.Read()==false)
            {
                command = new OleDbCommand("INSERT INTO NotFound([TITLE]) VALUES(@TITLE)", Program.con);
                command.Parameters.AddWithValue("@TITLE", title);
                command.ExecuteNonQuery();
            }
            Program.con.Close();
        }
        //Tablodaki tüm verileri siler.
        public void DeleteAll(string table_name)
        {
            if (ConnectionState.Closed == Program.con.State)
            {
                Program.con.Open();
            }
            command = new OleDbCommand("DELETE * FROM " + table_name + "" , Program.con);
            command.ExecuteNonQuery();
            Program.con.Close();
        }
        //Listeler.       
        public void List(string table_name)
        {
            table = new DataTable();
            if (ConnectionState.Closed == Program.con.State)
            {
                Program.con.Open();
            }
            adapter = new OleDbDataAdapter("Select * From " + table_name, Program.con);
            adapter.Fill(table);
        }
        //Arama yapar.
        public void Search(string table_name, string search_text,string column)
        {
            table = new DataTable();
            if (ConnectionState.Closed == Program.con.State)
            {
                Program.con.Open();
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from " + table_name + " where " + column + " Like '" + search_text + "%'", Program.con);
            //OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from " + table_name + " Like '" + search_text + "%'", Program.con);
            adapter.Fill(table);
        }
        public void Delete(string table, string pkey)
        {
            if (ConnectionState.Closed == Program.con.State)
                Program.con.Open();
            if (table == "Movies")
            {
                Database.command = new OleDbCommand("Delete from " + table + " where IMDBID='" + pkey + "'", Program.con);
                command.ExecuteNonQuery();
            }
            else
            {
                Database.command = new OleDbCommand("Delete from " + table + " where TITLE='" + pkey + "'", Program.con);
                command.ExecuteNonQuery();
            }
        }

        public string id { get; set; }
    }
}
