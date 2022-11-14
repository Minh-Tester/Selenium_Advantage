using Automation_Test_Framework.DriverCore;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using Core_Framework.Reporter;

namespace Core_Framework.NUnit_Test_Setup
{
    [TestFixture]
    public class NUnit_Test_Setup
    {
        public IWebDriver _driver;
        public WebDriverAction driverBaseAction;

        protected ExtentReports? _extentReport;
        protected ExtentTest? _extentSuite;
        protected ExtentTest? _extentTestCase;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            HtmlReport.createReport();
            HtmlReport.createTest(TestContext.CurrentContext.Test.ClassName);
        }


        [SetUp]
        public void SetUp()
        {
            HtmlReport.createNode(TestContext.CurrentContext.Test.ClassName, TestContext.CurrentContext.Test.Name);
            WebDriverManager.InitDriver("chrome", 1920, 1080);
            _driver = WebDriverManager.GetCurrentDriver();
           // driverBaseAction = new WebDriverAction(_driver);

        }

        [TearDown]
        public void TearDown()
        {
            _driver?.Quit();
            TestStatus testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus.Equals(TestStatus.Passed))
            {
                //_extentTestCase?.Pass($"[Passed] Test {TestContext.CurrentContext.Test.Name}");
            }
            else if (testStatus.Equals(TestStatus.Failed))
            {
                //_extentTestCase?.Fail($"[Failed] Test {TestContext.CurrentContext.Test.Name} because the error \n - {TestContext.CurrentContext.Test.Name}");
            }

            HtmlReport.flush();
        }
    }
}


 
       
