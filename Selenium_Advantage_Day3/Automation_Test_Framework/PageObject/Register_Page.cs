using Automation_Test_Framework.DriverCore;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Automation_Test_Framework.PageObject
{
    public class Register_Page : WebDriverAction
    {
        public Register_Page(IWebDriver driver) : base(driver)
        {
        }

        private static String txtFirstName = "//input[@id='firstname']";
        private static String txtLastName = "//input[@id='lastname']";
        private static String txtUserName = "//input[@id='userName']";
        private static String txtPassword = "//input[@id='password']";
        //private readonly String cbCaptcha = "//div[@class='recaptcha-anchor']";
        private static String btnRegister = "//button[@id='register']";
        private static String btnBackToLogin = "//button[@id='gotologin']";

        public void InputFirstName(String firstName)
        {
            SendKeys_(txtFirstName, firstName);
        }
        public void InputLastName(String lastName)
        {
            SendKeys_(txtLastName, lastName);
        }
        public void InputUserName(String userName)
        {
            SendKeys_(txtUserName, userName);
        }
        public void InputPassword(String password)
        {
            SendKeys_(txtPassword, password);
        }

        //public void CheckCaptcha()
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt
        //        (ByXpath("//iframe[starts-with(@name, 'a-') and starts-with(@src, 'https://www.google.com/recaptcha')]")));
        //    Click(cbCaptcha);
        //}

        public void ClickRegister()
        {
            Click(btnRegister);
        }

        public void ClickBackToLogin()
        {
            Click(btnBackToLogin);
        }
    }
}
