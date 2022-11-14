using Automation_Test_Framework.DriverCore;
using OpenQA.Selenium;

namespace Automation_Test_Framework.PageObject
{
    internal class Home_Page : WebDriverAction
    {
        public Home_Page(IWebDriver driver) : base(driver)
        {
        }

        private static string bttLogin = "//button[@id='login']";
        private static string inputSearch = "//input[@id='searchBox']";

        public void ClickLogin()
        {
            Click(bttLogin);
        }

        public void InputSearchBox(string keyword)
        {
            SendKeys_(inputSearch, keyword);
        }
    }
}
