using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ScreenScrapingLib.Services
{
    public class HittaSeScrenScraperService:CompanyBase
    {
        public override string ScrapeUrl
        {
            get { return "http://www.hitta.se/sök?vad={0}"; }
        }

        public override string xPath
        {
            get { return @"id('company-financials')/h2"; }
        }
    }
}
