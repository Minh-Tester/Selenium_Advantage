using Automation_Test_Framework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace RookiesTest2.PageObject
{
    public class ResultPage : WebDriverAction
    {
        public ResultPage(IWebDriver driver) : base(driver)
        {
        }
        private static String tfFirtResult = "//*[@class='LC20lb MBeuO DKV0Md'][1]";
        private static String tfSearchBox = "//*[@class='DocSearch-Button-Placeholder']";
        public void verifySearchTitle(string expectedTitle)
        {
            try
            {
                Assert.AreEqual(expectedTitle + " - Tìm trên Google", getTitle());
                TestContext.Write("2 Title match");
            }
            catch (Exception ex)
            {
                TestContext.Write("2 Title not match");
                throw ex;
            }
        }
        public void clickOnFirstResult()
        {
            Click(tfFirtResult);
        }
        public String getTextOfPageSearchBox(string tfSearchBox)
        {
            return getTextOfPageSearchBox(tfSearchBox);
        }
        public void verifyPageSearchBoxText(string expectedText)
        {
            try
            {
                Assert.That(getTextOfPageSearchBox(), Is.EqualTo(expectedText));
                TestContext.Write("Text is" + expectedText);
            }
            catch (Exception ex)
            {
                TestContext.Write("Text not match");
                throw ex;
            }
        }

        private string getTextOfPageSearchBox()
        {
            throw new NotImplementedException();
        }
    }
}