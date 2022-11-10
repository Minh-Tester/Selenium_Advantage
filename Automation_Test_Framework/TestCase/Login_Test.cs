using Automation_Test_Framework.TestSetup;
using NUnit.Framework;
using Test.PageObject;
using NUnit.Framework.Internal;

namespace Automation_Test_Framework.TestCase

{
    [TestFixture]
    public class Login_Test : ProjectNUnit
    {
        [Test]
        public void Id1_Login()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("test");
        }

        [Test]
        public void Id2_Login()
        {
            LoginPage loginPage = new LoginPage(_driver);
            loginPage.inputUserName("test");
        }
    }
}
