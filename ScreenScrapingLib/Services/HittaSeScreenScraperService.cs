using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;


namespace ScreenScrapingLib.Services
{
    
    public class HittaSeScreenScraperService : IScreenScraperService
    {
        public string GetCompanyNameByOrgNr(long orgNr)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            
            var findclasses = htmlDocument.DocumentNode.Descendants("h2").Where(d =>
                                d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("legalname")).ToList();
            

            var url = htmlweb.Load("http://www.hitta.se/sök?vad="+ orgNr);

            //HtmlDocument doc = htmlweb.Load(url);

            //string url = "http://www.hitta.se/sök?vad=" + orgNr;

            //url = HttpUtility.UrlEncode(url);
            //WebRequest request = WebRequest.Create(url);
            //WebResponse response = request.GetResponse();
            //Stream stream = response.GetResponseStream();
            //StreamReader reader = new StreamReader(stream);
            //string result = reader.ReadToEnd();
            //stream.Dispose();
            //reader.Dispose();

            //int firstChar = result.IndexOf("legalname\">");
            //string Name = result.Substring(firstChar);
            //int lastChar = Name.IndexOf("</h2>");
            //Name = Name.Substring(0, lastChar);

            return null;
        }
    }
}
