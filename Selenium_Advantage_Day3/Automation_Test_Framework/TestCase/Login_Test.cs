using Automation_Test_Framework.TestSetup;
using NUnit.Framework;
using Test.PageObject;
using NUnit.Framework.Internal;
using Automation_Test_Framework.DriverCore;
using Automation_Test_Framework.PageObject;

namespace Automation_Test_Framework.TestCase

{
    [TestFixture]
    public class Login_Test : ProjectNUnit
    {
        [Test]
        public void Login()
        {
            Home_Page homePage = new Home_Page(_driver);
            homePage.ClickLogin();

            LoginPage loginPage = new LoginPage(_driver);
            loginPage.InputUserName("tonyautotest");
            loginPage.InputPassword("Aa@123456");
            loginPage.ClickLogin();

            Profile_Page profilePage = new Profile_Page(_driver);
            Assert.IsTrue(profilePage.GetUserName().Equals("tonyautotest"));
            TestContext.WriteLine("Login Successfully");
        }
    }
}
