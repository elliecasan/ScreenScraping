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
    public class EniroScreenScraperService : IScreenScraperService
    {
        public string GetCompanyNameByOrgNr(long orgNr)
        {
            string url = "http://gulasidorna.eniro.se/hitta:" + orgNr;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            stream.Dispose();
            reader.Dispose();


            int firstChar = result.IndexOf("name_click");

            string name = result.Substring(firstChar);

            firstChar = name.IndexOf("\">");

            name = name.Substring(firstChar + 2);

            int lastChar = name.IndexOf("</a>");
            name = name.Substring(0, lastChar);

            return name;
        }
    }
}
