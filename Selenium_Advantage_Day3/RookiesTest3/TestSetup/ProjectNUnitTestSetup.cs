using Core_Framework.NUnit_Test_Setup;
using NUnit.Framework;

namespace RookiesTest.TestSetup
{
    public class ProjectNUnitTestSetup : NUnit_Test_Setup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "http://automationpractice.com/index.php";
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}