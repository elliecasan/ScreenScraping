using System.Linq;
using System.Web.Mvc;
using ScreenScraping.Models.Home;
using ScreenScrapingLib.Services;


namespace ScreenScraping.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScreenScraperFactory _screenScraperFactory;

        public HomeController(IScreenScraperFactory screenScraperFactory)
        {
            _screenScraperFactory = screenScraperFactory;
        }

        public ActionResult Index(string message)
        {
            var viewModel = new IndexViewModel();
            viewModel.ORGNumber = 5565995239;
            if (!string.IsNullOrEmpty(message))
                viewModel.CompanyName = message;
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            IScreenScraperService service = _screenScraperFactory.CreateFactory(model.SelectedListItem);

            var name = service.GetCompanyNameByOrgNr(model.ORGNumber);

            var company = model.DropDownItems.FirstOrDefault(c => c.Value == model.SelectedListItem);
            var companyName = string.Empty;
            if (company != null)
            {
                companyName = company.Text + ": ";
            }

            return RedirectToAction("Index", "Home", new {message = companyName + name});
        }

        
    }
}
