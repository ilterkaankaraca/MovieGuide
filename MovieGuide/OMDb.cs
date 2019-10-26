using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Data;
using System.Data.OleDb;

namespace Proje
{
    class OMDb
    {
        Database Db = new Database();
        //API kullanarak film bilgilerini alan metot.
        private string getMovieJSON(string movie_title)
        {
            string json;
            using (WebClient wc = new WebClient())
            {
                json = wc.DownloadString("http://www.omdbapi.com/?t=" + movie_title + "&apikey=" + Database.API);
            }
            return json;
        }
        //Gelen Json stringini deserialize ederek bir movie nesnesine yazan metot.
        public void Deserialize(string json)
        {
            Movie movie = JsonConvert.DeserializeObject<Movie>(json);
            Db.Add(movie);
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
                        if (!Parse(array[k].Remove(0, array[k].LastIndexOf("\\") + 1)))
                        {
                            Db.Add(array[k]);
                        }
                    }
                }
            }

        }
        public bool ScanviaID(string id)
        {
            if (Parse(id))
                return true;
            else
                return false;
            
        }
        public void Scan() { }
        //İnternet bağlantısını kontrol eden metot
        public static bool isConnectionOK()
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
            if (getMovieJSON(raw_title)[2] != 'R')
            {
                Deserialize(getMovieJSON(raw_title));
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
                            if (getMovieJSON(raw_title)[2] != 'R')
                            {
                                Deserialize(getMovieJSON(raw_title));
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


