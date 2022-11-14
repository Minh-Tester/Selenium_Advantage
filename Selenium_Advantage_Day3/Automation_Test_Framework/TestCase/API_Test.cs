using Automation_Test_Framework.Service;
using Automation_Test_Framework.TestSetup;
using Core_Framework.API_Core;
using NUnit.Framework;


namespace Automation_Test_Framework.TestCase
{
    [TestFixture]
    public class API_Test : ProjectNUnit
    {
        [Test]
        public void APIResquestTest()
        {
            API_Response response = new Mock_API_Login_Service().LoginRequest("tonyautotest", "Aa@123456");
            Assert.AreEqual(response.responseStatusCode, "OK");
        }
    }
}
