using NUnit.Framework;
using NUnit.Framework.Internal;
using RookiesTest2.TestSetup;
using RookiesTest2.PageObject;
using AventStack.ExtentReports;

namespace RookiesTest.TestCase
{
    public class SimpleTest : ProjectNUnitTestSetup
    {
        [Test]
        public void simpleTest()
        {
            SearchPage searchPage = new SearchPage(_driver);
            ResultPage resultPage = new ResultPage(_driver);

            searchPage.inputSearchKey("Selenium");
            searchPage.getResultPage();

            resultPage.verifySearchTitle("Selenium");
            resultPage.clickOnFirstResult();
            resultPage.verifyPageSearchBoxText("Search");
        }
    }
}