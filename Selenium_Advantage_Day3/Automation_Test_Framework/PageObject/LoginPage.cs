using OpenQA.Selenium;
using Automation_Test_Framework.DriverCore;

namespace Test.PageObject
{
    public class LoginPage : WebDriverAction

    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        private static String txtUserName = "//input[@id='userName']";
        private static String txtPassword = "//input[@id='password']";
        private static String btnLogin = "//button[@id='login']";
        private static String btnNewUser = "//button[@id='newUser']";


        public void InputUserName(String userName)
        {
            SendKeys_(txtUserName, userName);
        }

        public void InputPassword(String password)
        {
            SendKeys_(txtPassword, password);
        }

        public void ClickLogin()
        {
            Click(btnLogin);
        }

        public void ClickNewUser()
        {
            Click(btnNewUser);
        }
    }
}
