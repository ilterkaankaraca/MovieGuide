using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.DirectoryServices;
using System.Security.Authentication;

namespace Proje
{
    class DatabaseOperations
    {
        public static OleDbCommand command;
        public static OleDbDataReader reader;
        public static OleDbDataAdapter adapter;
        public static DataTable table;
        
    	public void Connect()
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
        }
        
        public void Disconnect()
        {
            if (ConnectionState.Open == Program.databaseConnection.State)
            {
                Program.databaseConnection.Close();
            }
        }
        //veri tabanına ekleme yapan metot.
        public void Add(Movie movie)
        {
            Connect();
            command = new OleDbCommand("SELECT * FROM Movies WHERE IMDBID='"+movie.imdbId+"'",Program.databaseConnection);
            reader = command.ExecuteReader();
            if (reader.Read()==false)
            {
                command = new OleDbCommand("INSERT INTO Movies([TITLE], [YEAR], [RATED], [RUNTIME], [GENRE], [ACTORS], [PLOT], [DIRECTOR], [WRITER], [LANGUAGE], [COUNTRY], [AWARDS], [IMDBRATING], [IMDBVOTES], [IMDBID]) VALUES (@Title, @Year, @Rated, @Runtime, @Genre, @Actors, @Plot, @Director, @Writer, @Language, @Country, @Awards, @imdbRating, @imdbVotes, @imdbID)", Program.databaseConnection);
                command.Parameters.AddWithValue("@Title", movie.title);
                command.Parameters.AddWithValue("@Year", movie.year);
                command.Parameters.AddWithValue("@Rated", movie.rated);
                command.Parameters.AddWithValue("@Runtime", movie.runtime);
                command.Parameters.AddWithValue("@Genre", movie.genre);
                command.Parameters.AddWithValue("@Actors", movie.actors);
                command.Parameters.AddWithValue("@Plot", movie.plot);
                command.Parameters.AddWithValue("@Director", movie.director);
                command.Parameters.AddWithValue("@Writer", movie.writer);
                command.Parameters.AddWithValue("@Language", movie.language);
                command.Parameters.AddWithValue("@Country", movie.country);
                command.Parameters.AddWithValue("@Awards", movie.awards);
                command.Parameters.AddWithValue("@imdbRating", movie.imdbRating);
                command.Parameters.AddWithValue("@imdbVotes", movie.imdbVotes);
                command.Parameters.AddWithValue("@imdbID", movie.imdbId);
                command.ExecuteNonQuery();
            }
            Disconnect();
                
        }
        //Bulunamayan filmlerin dosya yolunu ve adını bir tabloya kaydeden program
        public void Add(string path)
        {
            Connect();
            string title = path.Remove(0, path.LastIndexOf("\\") + 1);
            title = title.Replace("'", "");
            command = new OleDbCommand("SELECT * FROM NotFound WHERE TITLE='"+title+"'",Program.databaseConnection);
            reader = command.ExecuteReader();
            if (reader.Read()==false)
            {
                command = new OleDbCommand("INSERT INTO NotFound([TITLE]) VALUES(@TITLE)", Program.databaseConnection);
                command.Parameters.AddWithValue("@TITLE", title);
                command.ExecuteNonQuery();
            }
            Disconnect();
        }
        //Tablodaki tüm verileri siler.
        public void DeleteAll(string table_name)
        {
            Connect();
            command = new OleDbCommand("DELETE * FROM " + table_name + "" , Program.databaseConnection);
            command.ExecuteNonQuery();
            Disconnect();
        }
        //Listeler.       
        public void List(string table_name)
        {
            table = new DataTable();
            Connect();
            adapter = new OleDbDataAdapter("Select * From " + table_name, Program.databaseConnection);
            adapter.Fill(table);
            Disconnect();
        }
        //Arama yapar.
        public void Search(string table_name, string search_text,string column)
        {
            table = new DataTable();
            Connect();
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from " + table_name + " where " + column + " Like '" + search_text + "%'", Program.databaseConnection);
            //OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from " + table_name + " Like '" + search_text + "%'", Program.con);
            adapter.Fill(table);
            Disconnect();
        }
        public void Delete(string table, string pkey)
        {
            Connect();
            if (table == "Movies")
            {
                command = new OleDbCommand("Delete from " + table + " where IMDBID='" + pkey + "'", Program.databaseConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                command = new OleDbCommand("Delete from " + table + " where TITLE='" + pkey + "'", Program.databaseConnection);
                command.ExecuteNonQuery();
            }
            Disconnect();
        }
    }
}
