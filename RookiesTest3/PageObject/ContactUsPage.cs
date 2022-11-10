using Automation_Test_Framework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace RookiesTest3.PageObject
{
    internal class ContactUsPage : WebDriverAction
    {
        public ContactUsPage(IWebDriver driver) : base(driver)
        {
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
        public void back()
        {
            Back();
        }

        private void Back()
        {
            throw new NotImplementedException();
        }
    }
}