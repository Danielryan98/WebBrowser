using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    class Favourite
    {

        public int URL_ID { get; set; }
        public string URL { get; set; }
        public string TITLE { get; set; }

        public void NewFavourite(int urlId, string url, string title)
        {
            URL_ID = urlId;
            URL = url;
            TITLE = title;
        }

    }
}
