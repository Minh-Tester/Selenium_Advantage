using NUnit.Framework;
using OpenQA.Selenium;
using Automation_Test_Framework.DriverCore;

namespace RookiesTest3.PageObject

{
    public class HomePage : WebDriverAction
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }
        private readonly String tfContactUs = "//*[@title=\"Contact us\"]";
        public void clickOnContactus()
        {
            Click(tfContactUs);
        }
        public void verifyTitle(string expectedTitle)
        {
            try
            {
                Assert.AreEqual(expectedTitle, getTitle());
                TestContext.Write("2 Title match");
            }
            catch (Exception ex)
            {
                TestContext.Write("2 Title not match");
                throw ex;
            }


        }
    }
}