using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using Core_Framework.API_Core;
using Core_Framework.Reporter.ExtentMarkup;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using System.IO;

namespace Core_Framework.Reporter
{
    internal class HtmlReport
    {
        private static ExtentReports _report;
        private static ExtentTest extentTestSuite;
        private static ExtentTest extentTestCase;
       

        public static ExtentReports createReport()
        {
            if(_report == null)
            {
                _report = createInstance();
            }
            return _report;
        }

        private static ExtentReports createInstance()
        {
            HtmlReportDirectory.InitReportDirection();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(HtmlReportDirectory.REPORT_FILE_PATH);
            htmlReporter.Config.DocumentTitle = "Automation Test Report";
            htmlReporter.Config.ReportName = "Automation Test Report";
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }

        public static void flush()
        {
            if(_report != null)
            {
                _report.Flush();
            }
        }

        public static ExtentTest createTest(string className, string classDescription = "")
        {
            if(_report == null)
            {
                _report = createInstance();
            }
            extentTestSuite = _report.CreateTest(className, classDescription);
            return extentTestSuite;
        }

        public static ExtentTest createNode(string className, string testcase, string description = "")
        {
            if(extentTestSuite == null)
            {
                extentTestSuite = createTest(className);
            }
            extentTestCase = extentTestSuite.CreateNode(testcase, description);
            return extentTestCase;
        }

        public static ExtentTest GetParent()
        {
            return extentTestSuite;
        }

        public static ExtentTest GetNode()
        {
            return extentTestCase;
        }

        public static ExtentTest GetTest()
        {
            if(GetNode() ==  null)
            {
                return GetParent();
            }
            return GetNode();
        }

        public static void Pass(string des)
        {
            GetTest().Pass(MarkupHelper.CreateLabel(des, ExtentColor.Green));
        }
        internal static void Pass(string v, object m)
        {
            throw new System.NotImplementedException();
        }
        public static void Fail(string des, string path)
        {
            GetTest().Fail(MarkupHelper.CreateLabel(des, ExtentColor.Green)).AddScreenCaptureFromPath(path);
        }

        public static void Fail(string des, string ex, string path)
        {
            GetTest().Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
            TestContext.WriteLine(des);
        }

        public static void Info(string des)
        {
            GetTest().Info(des);
            TestContext.WriteLine(des);
        }

        public static void Warning(string des)
        {
            GetTest().Warning(des);
            TestContext.WriteLine(des);
        }

        public static void Skip(string des)
        {
            GetTest().Skip(des);
            TestContext.WriteLine(des);
        }
        public static void MarkUpJson()
        {
            var json = "{'name':'Tony', 'age':22, 'car':null}";
            GetTest().Info(MarkupHelper.CreateCodeBlock(json, CodeLanguage.Json));
        }

        public static void MarkUpTable()
        {
            string[][] table = new string[][] { new string[]
            { "TestID", "TestName", "Description" },
            new string[]
            { "01", "Login Test", "Login with existed username and password" },
            new string[]
            { "02", "Register Test", "Create new account" },
            new string[]
            { "03", "Logout Test", "Logout" }
            };
            GetTest().Info(MarkupHelper.CreateTable(table));
        }

        public static void CreateAPIRequestLog(API_Request request, API_Response response)
        {
            GetTest().Info(Markup_Helper_Plus.CreateAPIRequestLog(request, response));
        }
    }
}
