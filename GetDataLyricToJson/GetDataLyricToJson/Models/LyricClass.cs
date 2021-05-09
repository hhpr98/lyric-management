using System;
using System.Collections.Generic;
using System.Text;

namespace GetDataLyricToJson.Models
{
    class LyricClass
    {
        public int id { get; set; }
        public string name { get; set; }
        public string composer { get; set; }
        public string filename { get; set; }
        public string url { get; set; }
        public string type { get; set; }
        public DateTime updated { get; set; }
        public DateTime recented { get; set; }
        public int rate { get; set; }
        public int isFavorite { get; set; }
        public string link { get; set; }
        public string content { get; set; }
    }
}
