using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace MovieGuide
{
    class OMDb
    {

        DatabaseOperations database = new DatabaseOperations();
        private string Api = File.ReadAllText(@"api.txt");

        //API kullanarak film bilgilerini alan metot.

        private Movie GetMovie(string movieTitle)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://www.omdbapi.com/?t=" + movieTitle + "&apikey=" + Api);
            }
            if (json[4] == 'R')
                return null;
            else if(json[4] == 'T')
                return JsonConvert.DeserializeObject<Movie>(json);
            return null;
        }

        //dosyaları tarayan ve film isimlerini alan metot.
        public void Scan(string path)
        {
            string[] movies = Directory.GetDirectories(path);
            for (int j = 0; j < movies.Length; j++)
            {
                string[] array = Directory.GetFiles(movies[j]);

                for (int k = 0; k < array.Length; k++)
                {
                    if (array[k].IndexOf(".avi") != -1 && array[k].IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1 || array[k].IndexOf(".mp4") != -1 && array[k].IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1 || array[k].IndexOf(".mkv") != -1 && array[k].IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1 || array[k].IndexOf(".ts") != -1 && array[k].IndexOf("sample", StringComparison.CurrentCultureIgnoreCase) == -1)
                    {
                        //if (!Parse(array[k].Remove(0, array[k].LastIndexOf("\\") + 1)))
                        //{
                        //    database.Add(array[k]);
                        //}
                    }
                }
            }

        }
        public int List(string str)
        {
            ////Girilen stringin içinde :\ olup olmadığı kontrol ediliyor. Varsa dosya yolu yoksa film adı olarak işlem yapılıyor.
            //if (str.IndexOf(":\\") != -1)
            //{
            //    if (Directory.Exists(str))
            //    {
            //        if (OMDb.IsConnectionOK())
            //        {
            //            // bilgileri al 
            //        }
            //        else
            //        {
            //            statusLabel.Show();
            //            statusLabel.ForeColor = Color.Red;
            //            statusLabel.Text = StringLiterals.connectionIssue;
            //        }

            //    }
            //    else
            //    {
            //        statusLabel.Show();
            //        statusLabel.ForeColor = Color.Red;
            //        statusLabel.Text = StringLiterals.incorrectPath;
            //    }
            //}
            //else if (pathTextBox.Text.Length != 0)
            //{
            //    if (ombd.ScanviaID(pathTextBox.Text))
            //    {
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
            //}
            //else
            //{
            //    statusLabel.Show();
            //    statusLabel.ForeColor = Color.Red;
            //    statusLabel.Text = StringLiterals.errorBlank;
            //}
            return 0;
        }
        public bool ScanviaID(string id )
        {
            Movie movie = GetMovie(id);
           

            if (Parse(id))
                return true;
            else
                return false;
        }
        //İnternet bağlantısını kontrol eden metot
        public static bool IsConnectionOK()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.omdbapi.com"))
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
            if (GetMovie(raw_title)  != null)
            {
                GetMovie(raw_title);
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
                            if (GetMovie(raw_title) != null)
                            {
                                GetMovie(raw_title);
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


