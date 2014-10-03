using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenScrapingLib.Services
{
    public interface IScreenScraperFactory
    {

        IScreenScraperService CreateFactory(string type);
    }
}
