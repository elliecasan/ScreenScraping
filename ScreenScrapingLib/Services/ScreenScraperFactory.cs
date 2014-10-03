using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenScrapingLib.Services
{
    public class ScreenScraperFactory : IScreenScraperFactory
    {
        public IScreenScraperService CreateFactory(string type)
        {
            IScreenScraperService _screenScraperService = null;

            if (type == "eniro")
            {

                _screenScraperService = new EniroScreenScraperService();
                 
            }

            if (type == "allabolag")
            {
                _screenScraperService = new AllaBolagScreenScraperService();
            }

            return _screenScraperService;
        }
    }
}
