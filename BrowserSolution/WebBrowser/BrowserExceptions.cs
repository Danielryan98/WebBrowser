using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public static class BrowserExceptions
    {

        public class DuplicateURLException : Exception
        {
            public DuplicateURLException(string value)
                : base(String.Format("URL" + value + " already exists"))
            {

            }
        }
    }
}
