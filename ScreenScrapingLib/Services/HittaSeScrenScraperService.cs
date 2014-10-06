using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ScreenScrapingLib.Services
{
    public class HittaSeScrenScraperService:IScreenScraperService
    {
        public string GetCompanyNameByOrgNr(long orgNr)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            string url = "http://www.hitta.se/sök?vad=" + orgNr;
            HtmlDocument htmlDocument = htmlWeb.Load(url);


            var findclasses = htmlDocument.DocumentNode.Descendants("h2").Where(d =>
                                d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("legalname")).ToList();

            string Name = findclasses[0].InnerHtml;
            return Name;
        }
    }
}
