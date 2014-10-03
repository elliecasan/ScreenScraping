using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenScrapingLib.Services;

namespace ScreenScraperTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Find_Company_AllaBolag_By_OrgNr()
        {
            //ARRANGE
            long orgNr = 5565995239;
            string company = "Mattias Asplund Aktiebolag";

            IScreenScraperService screenScraperService = new AllaBolagScreenScraperService();

            //ACT
            var result = screenScraperService.GetCompanyNameByOrgNr(orgNr);

            //ASSERT
            Assert.AreEqual(company, result);
        }

        [TestMethod]
        public void Find_Company_Eniro_By_OrgNr()
        {
            //ARRANGE
            long orgNr = 5565995239;
            string company = "Mattias Asplund Aktiebolag";

            IScreenScraperService screenScraperService = new EniroScreenScraperService();

            //ACT
            var result = screenScraperService.GetCompanyNameByOrgNr(orgNr);

            //ASSERT
            Assert.AreEqual(company, result);
        }
    }
}
