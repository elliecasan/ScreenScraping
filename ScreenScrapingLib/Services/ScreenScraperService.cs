using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScreenScrapingLib.Services
{
    public class ScreenScraperService : IScreenScraperService
    {
        public string GetCompanyNameByOrgNr(long orgNr)
        {

            string url = "http://www.allabolag.se/" + orgNr;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            stream.Dispose();
            reader.Dispose();

            int firstChar = result.IndexOf("reportTitleBig") + 16;
            string Name = result.Substring(firstChar, 100);
            int lastChar = Name.IndexOf("</span>");
            Name = Name.Substring(0, lastChar);

            return Name;
        }
    }
}
