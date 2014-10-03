using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ScreenScraping.Models.Home;
using ScreenScrapingLib.Services;


namespace ScreenScraping.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScreenScraperService _screenScraperService;

        public HomeController(IScreenScraperService ScreenScraperService)
        {
            _screenScraperService = ScreenScraperService;
        }

        public ActionResult Index(string message)
        {
            var viewModel = new IndexViewModel();

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

            string Name = _screenScraperService.GetCompanyNameByOrgNr(model.ORGNumber);

            return RedirectToAction("Index", "Home", new {message = Name});
        }

    }
}
