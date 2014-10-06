using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ScreenScrapingLib.Services;

namespace ScreenScraperTest
{
    [TestClass]
    public class UnitTestClass
    {
        [TestMethod]
        public void TestAllCompanies()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            UnitTest1.Find_Company_AllaBolag_By_OrgNr();
            UnitTest1.Find_Company_HittaSe_By_OrgNr();
            UnitTest1.Find_Company_Upplysning_By_OrgNr();

            stopWatch.Stop();
            Trace.WriteLine("Alla anrop sekventiellt: " + stopWatch.Elapsed);

            stopWatch.Reset();

            stopWatch.Start();
            var tasks = new[]
            {
                Task.Factory.StartNew(UnitTest1.Find_Company_AllaBolag_By_OrgNr),
                Task.Factory.StartNew(UnitTest1.Find_Company_HittaSe_By_OrgNr),
                Task.Factory.StartNew(UnitTest1.Find_Company_Upplysning_By_OrgNr)
            };

            Task.WaitAll(tasks);
            stopWatch.Stop();

            Trace.WriteLine("Alla anrop parallellt: " + stopWatch.Elapsed);
        }

    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void Find_Company_AllaBolag_By_OrgNr()
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
            ////ARRANGE
            //long orgNr = 5565995239;
            //string company = "Mattias Asplund Aktiebolag";

            //IScreenScraperService screenScraperService = new EniroScreenScraperService();

            ////ACT
            //var result = screenScraperService.GetCompanyNameByOrgNr(orgNr);

            ////ASSERT
            //Assert.AreEqual(company, result);
        }

        [TestMethod]
        public static void Find_Company_HittaSe_By_OrgNr()
        {
            //ARRANGE
            long orgNr = 5565995239;
            string company = "Mattias Asplund AB";

            IScreenScraperService screenScraperService = new HittaSeScrenScraperService();

            //ACT
            var result = screenScraperService.GetCompanyNameByOrgNr(orgNr);

            //ASSERT
            Assert.AreEqual(company, result);
        }
        
                [TestMethod]
        public static void Find_Company_Upplysning_By_OrgNr()
        {
            //ARRANGE
            long orgNr = 5565995239;
            string company = "Mattias Asplund Aktiebolag";

            IScreenScraperService screenScraperService = new UpplysningScreenScraperService();

            //ACT
            var result = screenScraperService.GetCompanyNameByOrgNr(orgNr);

            //ASSERT
            Assert.AreEqual(company, result);
        }
    }
}
