using Automation_Test_Framework.DriverCore;
using OpenQA.Selenium;

namespace Automation_Test_Framework.PageObject
{
    public class Profile_Page : WebDriverAction
    {
        public Profile_Page(IWebDriver driver) : base(driver)
        {
        }

        private static String btnLogout = "//button[text()='Log out']";
        private static String btnGoToStore = "//button[@id='gotoStore']";
        private static String txtfSearch = "//input[@type='text']";
        private static String lblUserName = "//label[@id='userName-label']//following-sibling::label";

        public void BookSearch(String keyword)
        {
            SendKeys_(txtfSearch, keyword);
        }

        public void LogOut()
        {
            Click(btnLogout);
        }

        public void GoToStore()
        {
            Click(btnGoToStore);
        }

        public string GetUserName()
        {
            return GetText(lblUserName);
        }
    }
}


