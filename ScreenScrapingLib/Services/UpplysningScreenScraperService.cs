using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ScreenScrapingLib.Services
{
    public class UpplysningScreenScraperService : IScreenScraperService
    {
        public string GetCompanyNameByOrgNr(long orgNr)
        {
            string url = "http://www.upplysning.se/" + orgNr;
            //url = HttpUtility.UrlEncode(url);

            if (url == null) return null;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            if (stream == null) return null;

            var reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            stream.Dispose();
            reader.Dispose();

            int firstChar = result.IndexOf("<title") + 7;
            string Name = result.Substring(firstChar);
            int lastChar = Name.IndexOf("</title>");
            Name = Name.Substring(0, lastChar);

            return Name;
        }
    }
}
