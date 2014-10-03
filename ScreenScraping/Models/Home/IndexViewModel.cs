using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScreenScraping.Models.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            DropDownItems = new List<SelectListItem>();
            DropDownItems.Add(new SelectListItem { Text="Alla Bolag", Value="allabolag" });
            DropDownItems.Add(new SelectListItem { Text = "Eniro", Value="eniro" });
            DropDownItems.Add(new SelectListItem { Text = "Hitta.se", Value = "hittase" });
        }

        [Required(ErrorMessage = "Enter correct value")]

        public long ORGNumber{ get; set; }

        public string CompanyName { get; set; }

        public string SelectedListItem { get; set; }

        public List<SelectListItem> DropDownItems { get; set; }
    }
}