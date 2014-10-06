namespace ScreenScrapingLib.Services
{
    public interface IScreenScraperFactory
    {

        IScreenScraperService CreateFactory(string type);
    }
}
