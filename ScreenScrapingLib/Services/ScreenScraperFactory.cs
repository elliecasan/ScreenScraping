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

            switch (type)
            {
                case "eniro": _screenScraperService = new EniroScreenScraperService();
                    break;

                case "allabolag": _screenScraperService = new AllaBolagScreenScraperService();
                    break;

                case "hittase": _screenScraperService = new HittaSeScreenScraperService();
                    break;

                default:
                    break;
            }

            return _screenScraperService;
        }
    }
}
