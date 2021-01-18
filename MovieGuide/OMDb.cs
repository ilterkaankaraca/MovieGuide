using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace MovieGuide
{
    public class OMDb
    {
        readonly static DatabaseOperations database = new DatabaseOperations();
        private readonly static string api = File.ReadAllText(@"api.txt");

        //API kullanarak film bilgilerini alan metot.
        public static Movie GetMovieInfo(string movieTitle)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://www.omdbapi.com/?t=" + movieTitle + "&apikey=" + api);
            }
            if (json[2] == 'R')
                return null;
            else if(json[2] == 'T')
                return JsonConvert.DeserializeObject<Movie>(json);
            return null;
        }
        public static string ClearString(string path)
        {
            path = path.ToLower();
            path = path.Substring(path.LastIndexOf('\\')+1);
            path=path.Replace("extended", "");
            path=path.Replace("directors cut", "");
            path=path.Replace("director's cut", "");
            path=path.Replace("(", "");
            path = path.Replace("[", "");
            path = path.Replace("]", "");
            path =path.Replace(")", "");
            path=path.Replace("'", "");

            return path;
        }

        public static bool IsVideoFile(string fileName)
        {
            if (fileName.IndexOf(".avi") != -1 && fileName.IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1 || fileName.IndexOf(".mp4") != -1 && fileName.IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1 || fileName.IndexOf(".mkv") != -1 && fileName.IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1 || fileName.IndexOf(".ts") != -1 && fileName.IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static List<Movie> Scan(string path)
        {
            //TODO: return mutliple lists
            string[] movieFolders = Directory.GetDirectories(path);
            string movieTitle;
            Movie movie;
            List<Movie> movieList = new List<Movie>(); 
            for (int i = 0; i < movieFolders.Length; i++)
            {
                movieTitle = ClearString(movieFolders[i]);
                movie = GetMovieInfo(movieTitle);
                
                //use folder name instead of file name
                if (movie != null)
                {
                    movieList.Add(movie);
                }
                else
                {
                    movie=GetMovieInfo(ClearMore(movieTitle));
                    if (movie != null)
                    {
                        movieList.Add(movie);
                    }
                }
            }
            return movieList;
        }
        
        public static void AddToDatabase(List<Movie> movies)
        {
            foreach(Movie movie in movies)
            {
                database.Add(movie);
            }
        }

        public static int Start(string str)
        {
            //check if movie or path
            if (str.IndexOf(":\\") != -1)
            {
                if (Directory.Exists(str))
                {
                    if (OMDb.IsConnectionOK())
                    {
                        AddToDatabase(Scan(str));
                        return 1;
                    }
                    else
                    {
                        //internet problem
                        return -1;
                    }

                }
                else
                {
                    //path doesnt exist
                    return -2;
                }
            }
            else if (str.Length != 0)
            {
                if (GetMovieInfo(str)!=null)
                {
            //        pathTextBox.Clear();
            //        statusLabel.Hide();
            //        database.List("Movies");
            //        moviesDataGridView.DataSource = DatabaseOperations.table;
            //        DatabaseOperations.table.AcceptChanges();
            //    }
            //    else
            //    {
            //        statusLabel.Show();
            //        statusLabel.ForeColor = Color.Red;
            //        statusLabel.Text = StringLiterals.notFound;
            //    }
            }
            //else
            //{
            //    statusLabel.Show();
            //    statusLabel.ForeColor = Color.Red;
            //    statusLabel.Text = StringLiterals.errorBlank;
            }
            return 0;
        }
        //İnternet bağlantısını kontrolS eden metot
        public static bool IsConnectionOK()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://www.omdbapi.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        //İsimleri temizleyen metot.
        public static string ClearMore(string raw_title)
        {
            int digit = 0;
            {
                for (int i = raw_title.Length - 1; i >= 0; i--)
                {
                    if (raw_title[i].CompareTo('0') >= 0 && raw_title[i].CompareTo('9') <= 0)
                    {
                        digit++;
                        if (digit == 4 && String.Compare(raw_title.Substring(i, 4), "2100") < 0 && String.Compare(raw_title.Substring(i, 4), "1900") > 0)
                        {
                            raw_title = raw_title.Substring(0, i - 1);
                            raw_title = raw_title.Replace('.', ' ');
                            break;
                        }
                    }
                    else
                    {
                        digit = 0;
                    }
                }
                return raw_title;
            }
        }
    }
}


