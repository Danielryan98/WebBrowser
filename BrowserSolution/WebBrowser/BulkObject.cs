using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser
{
    /*This class is the template for a Bulk Object for the Bulk Download feature.
     A bulk object contains a response code, a url, and the bytes associated with
    the response from the url. The main browser class can access the private 
    variables through the getters and setters.*/
    class BulkObject
    {
        private string responseCode;
        public string accessResponseCode
        {
            get { return responseCode; }
            set { responseCode = value; }
        }

        private byte[] urlBytes;
        public byte[] accessUrlBytes
        {
            get { return urlBytes; }
            set { urlBytes = value; }
        }

        private String url;
        public string accessUrl
        {
            get { return url; }
            set { url = value; }
        }
    }
}
