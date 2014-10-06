using System.IO;
using System.Net;

namespace ScreenScrapingLib.Services
{
    public class EniroScreenScraperService : CompanyBase
    {

           public override string ScrapeUrl
        {
            get { return "http://gulasidorna.eniro.se/hitta:{0}"; }
        }

        public override string xPath
        {
            get { return @"id('hit-list')/li/article/header/div[2]/h2/span/a"; }
       
        }
    
    }
}
