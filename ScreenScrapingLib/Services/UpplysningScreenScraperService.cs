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
    public class UpplysningScreenScraperService : CompanyBase
    {
        public override string ScrapeUrl
        {
            get { return "http://www.upplysning.se/{0}"; }
        }

        public override string xPath
        {
            get { return @"/html/head/title"; }
        }
    }
}
