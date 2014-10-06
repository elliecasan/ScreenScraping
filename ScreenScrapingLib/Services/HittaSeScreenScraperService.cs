﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using HtmlAgilityPack;

namespace ScreenScrapingLib.Services
{
    public class HittaSeScreenScraperService : IScreenScraperService
    {
        public string GetCompanyNameByOrgNr(long orgNr)
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            string url = "http://www.hitta.se/sök?vad=" + orgNr;
            HtmlDocument htmlDocument = htmlWeb.Load(url);

            if (url == null) return null;

            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            if (stream == null) return null;

            var reader = new StreamReader(stream);
            string result = reader.ReadToEnd();
            stream.Dispose();
            reader.Dispose();


            var findclasses = htmlDocument.DocumentNode.Descendants("h2").Where(d =>
                                d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("legalname")).ToList();
            int firstChar = result.IndexOf("legalname\">");
            string Name = result.Substring(firstChar);
            int lastChar = Name.IndexOf("</h2>");
            Name = Name.Substring(0, lastChar);

            string Name = findclasses[0].InnerHtml;
            return Name;
        }
    }
}
