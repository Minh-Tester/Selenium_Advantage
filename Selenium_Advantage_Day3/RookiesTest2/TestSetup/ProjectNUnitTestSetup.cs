using Core_Framework.NUnit_Test_Setup;
using NUnit.Framework;

namespace RookiesTest2.TestSetup
{
    public class ProjectNUnitTestSetup : NUnit_Test_Setup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://www.google.com.vn/";
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}