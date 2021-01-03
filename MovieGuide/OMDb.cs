using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace MovieGuide
{
    class OMDb
    {
        readonly DatabaseOperations database = new DatabaseOperations();
        private readonly string api = File.ReadAllText(@"api.txt");

        //API kullanarak film bilgilerini alan metot.
        private Movie GetMovieInfo(string movieTitle)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("https://www.omdbapi.com/?t=" + movieTitle + "&apikey=" + api);
            }
            Console.WriteLine(json);
            if (json[2] == 'R')
                return null;
            else if(json[2] == 'T')
                return JsonConvert.DeserializeObject<Movie>(json);
            return null;
        }
        public bool IsVideoFile(string fileName)
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
        public void Scan(string path)
        {
            string[] movies = Directory.GetDirectories(path);
            for (int j = 0; j < movies.Length; j++)
            {
                string[] array = Directory.GetFiles(movies[j]);

                for (int k = 0; k < array.Length; k++)
                {
                    if (IsVideoFile(array[k]))
                    {
                        if (!Parse(array[k].Remove(0, array[k].LastIndexOf("\\") + 1)))
                        {
                            //database.AddBody(GetMovie(array[k]));
                        }
                    }
                }
            }
        }
        public int List(string str)
        {
            //Girilen stringin içinde :\ olup olmadığı kontrol ediliyor. Varsa dosya yolu yoksa film adı olarak işlem yapılıyor.
            if (str.IndexOf(":\\") != -1)
            {
                if (Directory.Exists(str))
                {
                    if (OMDb.IsConnectionOK())
                    {
                        Scan(str);
                        return 1;
                    }
                    else
                    {
                        //statusLabel.Show();
                        //statusLabel.ForeColor = Color.Red;
                        //statusLabel.Text = StringLiterals.connectionIssue;
                    }

                }
                else
                {
                    //statusLabel.Show();
                    //statusLabel.ForeColor = Color.Red;
                    //statusLabel.Text = StringLiterals.incorrectPath;
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
        public bool Parse(string raw_title)
        {
            int digit = 0;
            //buralari duzelt
            if (GetMovieInfo(raw_title)!= null)
            {
                database.AddBody(GetMovieInfo(raw_title));
                return true;
            }
            else
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
                            //buralari duzelt
                            if (GetMovieInfo(raw_title) != null)
                            {
                                database.AddBody(GetMovieInfo(raw_title));
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        digit = 0;
                    }
                }
                return false;
            }
        }
    }
}


