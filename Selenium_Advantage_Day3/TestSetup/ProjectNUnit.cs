using Core_Framework.NUnit_Test_Setup;
using NUnit.Framework;

namespace Automation_Test_Framework.TestSetup
{
    public class ProjectNUnit : NUnit_Test_Setup
    {
        [SetUp]
        public void SetUp()
        {
            _driver.Url = "https://demo.guru99.com/v4/index.php";
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
