using OpenQA.Selenium;
using Automation_Test_Framework.DriverCore;

namespace Test.PageObject
{
    public class LoginPage : WebDriverAction

    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        private readonly String tfUsername = "//input[@name='abc']";

        public void inputUserName(String UserName)
        {
            SendKeys_(tfUsername, UserName);
        }
    }
}
