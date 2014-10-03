using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ScreenScraping.Models.Home;

namespace ScreenScraping.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(string message)
        {
            var viewModel = new IndexViewModel();

            if (!string.IsNullOrEmpty(message))
                viewModel.CompanyName = message;
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            string url = "http://www.allabolag.se/" + model.ORGNumber;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            stream.Dispose();
            reader.Dispose();

            int firstChar = result.IndexOf("reportTitleBig")+16;
            string Name = result.Substring(firstChar, 100);
            int lastChar = Name.IndexOf("</span>");
            Name = Name.Substring(0, lastChar);

            return RedirectToAction("Index", "Home", new {message = Name});
        }

    }
}
