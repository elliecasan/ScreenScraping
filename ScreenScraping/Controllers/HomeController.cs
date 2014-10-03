﻿using System;
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
        private readonly IScreenScraperFactory _screenScraperFactory;

        public HomeController(IScreenScraperFactory ScreenScraperFactory)
        {
            _screenScraperFactory = ScreenScraperFactory;
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

            IScreenScraperService service = _screenScraperFactory.CreateFactory(model.SelectedListItem);

            var name = service.GetCompanyNameByOrgNr(model.ORGNumber);

            return RedirectToAction("Index", "Home", new {message = name});
        }

        
    }
}
