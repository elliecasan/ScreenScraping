using System.IO;
using System.Net;

namespace ScreenScrapingLib.Services
{
    public class AllaBolagScreenScraperService : CompanyBase
    {

         public override string ScrapeUrl
        {
            get { return "http://www.allabolag.se/{0}"; }
        }

        public override string xPath
        {
            get { return @"id('printTitle')"; }
         
        }
   
    }
}
