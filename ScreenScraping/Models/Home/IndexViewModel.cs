using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ScreenScraping.Models.Home
{
    public class IndexViewModel
    {
        [Required(ErrorMessage = "Enter correct value")]

        public long ORGNumber{ get; set; }

        public string CompanyName { get; set; }
    }
}