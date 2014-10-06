using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ScreenScrapingLib.Services
{
    public abstract class CompanyBase:IScreenScraperService
    {
        public string GetCompanyNameByOrgNr(long orgNr)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            string url = string.Format(this.ScrapeUrl, orgNr);
            HtmlDocument htmlDocument = htmlWeb.Load(url);

            HtmlNode companyName = htmlDocument.DocumentNode.SelectSingleNode(this.xPath);
            
            return companyName.InnerHtml;
        }

        public abstract  string ScrapeUrl { get; }
        public abstract string xPath { get; }
    }
}
