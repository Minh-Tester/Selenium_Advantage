using Automation_Test_Framework.DriverCore;
using NUnit.Framework;
using OpenQA.Selenium;

namespace RookiesTest2.PageObject

{
    public class SearchPage : WebDriverAction
    {
        public SearchPage(IWebDriver driver) : base(driver)
        {
        }
        private static String tfSearchBox = "//*[@class='gLFyf gsfi']";
        public void inputSearchKey(string Key)
        {
            SendKeys_(tfSearchBox, Key);
        }
        public void getResultPage()
        {
            SendKeys_(tfSearchBox, Keys.Enter);
        }
    }
}