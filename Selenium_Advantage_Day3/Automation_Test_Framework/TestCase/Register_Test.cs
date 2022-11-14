using Automation_Test_Framework.PageObject;
using Core_Framework.NUnit_Test_Setup;
using NUnit.Framework;
using Test.PageObject;

namespace Automation_Test_Framework.TestCase
{
    public class Register_Test : NUnit_Test_Setup
    {
        [Test]
        public void Register()
        {
            Home_Page homePage = new Home_Page(_driver);
            homePage.ClickLogin();

            LoginPage loginPage = new LoginPage(_driver);
            loginPage.ClickNewUser();

            Register_Page registerPage = new Register_Page(_driver);
            registerPage.InputFirstName("Tony");
            registerPage.InputLastName("Tran");
            registerPage.InputUserName("tonyautotest");
            registerPage.InputPassword("Aa@123456");
            //registerPage.CheckCaptcha();
            registerPage.ClickRegister();
        }
    }
}
