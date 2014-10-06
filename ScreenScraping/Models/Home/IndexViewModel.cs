using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ScreenScraping.Models.Home
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            DropDownItems = new List<SelectListItem>
            {
                new SelectListItem {Text = "Alla Bolag", Value = "allabolag"},
                new SelectListItem {Text = "Eniro", Value = "eniro"},
                new SelectListItem {Text = "Hitta.se", Value = "hittase"},
                new SelectListItem {Text = "Upplysning.se", Value = "upplysning"}
            };
        }

        [Required(ErrorMessage = "Enter correct value")]

        public long ORGNumber{ get; set; }

        public string CompanyName { get; set; }

        public string SelectedListItem { get; set; }

        public List<SelectListItem> DropDownItems { get; set; }
    }
}