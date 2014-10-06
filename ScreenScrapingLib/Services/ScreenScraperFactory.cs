namespace ScreenScrapingLib.Services
{
    public class ScreenScraperFactory : IScreenScraperFactory
    {
        public IScreenScraperService CreateFactory(string type)
        {
            IScreenScraperService screenScraperService = null;

            switch (type)
            {
                case "eniro": screenScraperService = new EniroScreenScraperService();
                    break;

                case "allabolag": screenScraperService = new AllaBolagScreenScraperService();
                    break;

                case "hittase": screenScraperService = new HittaSeScreenScraperService();
                    break;

                case "upplysning": screenScraperService = new UpplysningScreenScraperService();
                    break;

                default:
                    break;
            }

            return screenScraperService;
        }
    }
}
