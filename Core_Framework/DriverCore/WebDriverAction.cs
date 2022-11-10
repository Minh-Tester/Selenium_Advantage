using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using Core_Framework.Reporter;


namespace Automation_Test_Framework.DriverCore
{
    public class WebDriverAction
    {
        public IWebDriver driver;
        public WebDriverAction(IWebDriver driver)
        {
            this.driver = driver;
        }

        public By ByXpath(String locator)
        {
            return By.XPath(locator);
        }

        public string getTitle()
        {
            return driver.Title;
        }

        public IWebElement FindElementByXpath(string locator)
        {
            IWebElement e = driver.FindElement(ByXpath(locator));
            highlightElement(e);
            return e; 
        }

        public IList<IWebElement>FindElementsByXPath(String locator)
        {
            return driver.FindElements(ByXpath(locator));
        }

        public IWebElement highlightElement (IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript("arguments[0].style.border='2px solid red'", element);
            return element;
        }


        public void Click(IWebElement e)
        {
            try
            {
                highlightElement(e);
                e.Click();
                TestContext.WriteLine("click in to element" + e.ToString() + "passed");
            }
            catch(Exception ex)
            {
                TestContext.WriteLine("click in to element" + e.ToString() + "failed");     
                throw ex;
            }
        }

        public void Click(String locator)
        {

            try
            {
                FindElementByXpath(locator).Click();
                TestContext.WriteLine("click into element" + locator + "passed");

            }
            catch (Exception ex)
            {

                TestContext.WriteLine("click into element" + locator + "failed");
                throw ex;
            }
        }


        public void SendKeys_(IWebElement e, string key)
        {
            try
            {
                e.SendKeys(key);
                TestContext.WriteLine("Sendkey into element " + e.ToString() + " successfuly");
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Sendkey into element " + e.ToString() + " failed");
                throw ex;
            }
        }
        public void SendKeys_(String locator, String key)
        {
            try
            {
                FindElementByXpath(locator).SendKeys(key);
                TestContext.WriteLine("Sendkey into element" + locator + "passed");
                HtmlReport.Pass("Sendkey into element" + locator + "passed");
            }
            catch (Exception ex)
            {

                TestContext.WriteLine("Sendkey into element" + locator + "failed");
                HtmlReport.Fail("Sendkey into element" + locator + "failed",TakeScreenShot());
                throw ex;
            }
        }

        public void SelectOption(String locator, String key)
        {
            try
            {
                IWebElement mySelectOption = FindElementByXpath(locator);
                SelectElement dropdown = new SelectElement(mySelectOption);
                dropdown.SelectByText(key);
                TestContext.WriteLine("Select element " + locator + " successfuly with " + key);
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Select element " + locator + " failed with " + key);
                throw ex;
            }
        }

        public string TakeScreenShot()
        {
            string path = HtmlReportDirectory.SCREENSHOT_PATH + ("/screenshot_" + DateTime.Now.ToString("yyyyMMddHHmmss")) + ".png";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
            return path;
        }
    }
}
