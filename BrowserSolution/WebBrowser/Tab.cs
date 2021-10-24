using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    class Tab
    {
        private string responseCode;
        public string accessResponseCode
        {
            get { return this.responseCode; }
            set { this.responseCode = value; }
        }

        private string responseBody;

        public string accessResponseBody
        {
            get { return this.responseBody; }
            set { this.responseBody = value; }
        }

        private String url;
        public string accessUrl
        {
            get { return this.url; }
            set { this.url = value; }
        }

        public override string ToString()
        {
            return "CODE: " + accessResponseCode + " URL: " + url;
        }
    }
}
