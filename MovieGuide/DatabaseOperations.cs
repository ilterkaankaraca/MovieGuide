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
    class DatabaseOperations
    {
        public static OleDbCommand command;
        public static OleDbDataReader reader;
        public static OleDbDataAdapter adapter;
        public static DataTable table;
        public static string API = "2bef03fb";
        
        //Kullanıcı bilgilerini kontrol eden metot.
        
        //Login Formu çağırıldığında hatırlanması istenen kullanıcı adının veri tabanından çekilmesine yarayan metot.
        public string Remember()
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
            command = new OleDbCommand("SELECT * FROM Users WHERE REMEMBERME= 'yes'",Program.databaseConnection);
            reader = command.ExecuteReader();
            if (reader.Read() == true)
            {
                return reader["ID"].ToString();
            }
            else
                return null;

        }
        //Beni hatırla kutusu işaretlendiğinde bu metot çalışır ilgili kullanıcının "REMEMBERME" alanını yes diğerlerini no yapar.
        public void Remember(string id)
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
            command = new OleDbCommand("UPDATE Users SET REMEMBERME='no' WHERE REMEMBERME='yes'", Program.databaseConnection);
            command.ExecuteNonQuery();
            command = new OleDbCommand("UPDATE Users SET REMEMBERME='yes' WHERE ID ='" + id + "'", Program.databaseConnection);
            command.ExecuteNonQuery();
            Program.databaseConnection.Close();
        }
        //veri tabanına ekleme yapan metot.
        public void Add(Movie movie)
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
            command = new OleDbCommand("SELECT * FROM Movies WHERE IMDBID='"+movie.imdbID+"'",Program.databaseConnection);
            reader = command.ExecuteReader();
            if (reader.Read()==false)
            {
                command = new OleDbCommand("INSERT INTO Movies([TITLE], [YEAR], [RATED], [RELEASED], [RUNTIME], [GENRE], [ACTORS], [PLOT], [DIRECTOR], [WRITER], [LANGUAGE], [COUNTRY], [AWARDS], [IMDBRATING], [IMDBVOTES], [IMDBID]) VALUES (@Title, @Year, @Rated, @Released, @Runtime, @Genre, @Actors, @Plot, @Director, @Writer, @Language, @Country, @Awards, @imdbRating, @imdbVotes, @imdbID)", Program.databaseConnection);
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
            Program.databaseConnection.Close();
                
        }
        //Bulunamayan filmlerin dosya yolunu ve adını bir tabloya kaydeden program
        public void Add(string path)
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
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
            Program.databaseConnection.Close();
        }
        //Kullanıcı Ekleyen metot.
        public bool Add(string id, string password, string api,string type)
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
            command = new OleDbCommand("SELECT * FROM Users WHERE ID='"+id+"'",Program.databaseConnection);
            reader = command.ExecuteReader();
            if (reader.Read() == false)
            {

                command = new OleDbCommand("INSERT INTO Users([ID],[PASSWORD],[API],[TYPE],[REMEMBERME]) VALUES(@ID,@PASSWORD,@API,@REMEMBERME,@TYPE)", Program.databaseConnection);
                command.Parameters.AddWithValue("@ID", id);
                command.Parameters.AddWithValue("@PASSWORD", password);
                command.Parameters.AddWithValue("@API", api);
                command.Parameters.AddWithValue("@REMEMEBERME","no");
                command.Parameters.AddWithValue("@TYPE", type);
                command.ExecuteNonQuery();
                return true;
            }
            else
            {
                Program.databaseConnection.Close();
                return false;
            }     
        }
        //Tablodaki tüm verileri siler.
        public void DeleteAll(string table_name)
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
            command = new OleDbCommand("DELETE * FROM " + table_name + "" , Program.databaseConnection);
            command.ExecuteNonQuery();
            Program.databaseConnection.Close();
        }
        //Listeler.       
        public void List(string table_name)
        {
            table = new DataTable();
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
            adapter = new OleDbDataAdapter("Select * From " + table_name, Program.databaseConnection);
            adapter.Fill(table);
        }
        //Arama yapar.
        public void Search(string table_name, string search_text,string column)
        {
            table = new DataTable();
            if (ConnectionState.Closed == Program.databaseConnection.State)
            {
                Program.databaseConnection.Open();
            }
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from " + table_name + " where " + column + " Like '" + search_text + "%'", Program.databaseConnection);
            //OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from " + table_name + " Like '" + search_text + "%'", Program.con);
            adapter.Fill(table);
        }
        public void Delete(string table, string pkey)
        {
            if (ConnectionState.Closed == Program.databaseConnection.State)
                Program.databaseConnection.Open();
            if (table == "Movies")
            {
                DatabaseOperations.command = new OleDbCommand("Delete from " + table + " where IMDBID='" + pkey + "'", Program.databaseConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                DatabaseOperations.command = new OleDbCommand("Delete from " + table + " where TITLE='" + pkey + "'", Program.databaseConnection);
                command.ExecuteNonQuery();
            }
        }

        public string id { get; set; }
    }
}
