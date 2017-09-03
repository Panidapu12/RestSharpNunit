using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using System;
using System.IO;

namespace NunitRestSharpTestFramework
{
    public class ExtentManager
    {
        private static ExtentReports extent;
        private static ExtentTest test;
        private static ExtentHtmlReporter htmlReporter;
        public static string projectDirectory = getProjectPath();
        private static string filePath = projectDirectory + "\\TestExecutionReports\\TetExecutionReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html";

        public static ExtentReports getExtent()
        {

            if (extent != null)
            {
                htmlReporter.AppendExisting = true;
                return extent;
            }
            extent = new ExtentReports();
            extent.AttachReporter(getHtmlReporter());
            return extent;
        }

        private static ExtentHtmlReporter getHtmlReporter()
        {
            htmlReporter = new ExtentHtmlReporter(filePath);
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            htmlReporter.Configuration().DocumentTitle = "Test Execution Report";
            htmlReporter.Configuration().Encoding = "UTF-8";
            htmlReporter.Configuration().Protocol = Protocol.HTTPS;
            htmlReporter.Configuration().ReportName = "Build";
            htmlReporter.Configuration().ChartLocation = ChartLocation.Top;
            htmlReporter.Configuration().Theme = Theme.Dark;
            return htmlReporter;

        }
        public static string getProjectPath()
        {
            string projectDirectory = Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory));
            return projectDirectory;
        }
        public static ExtentTest createTest(String Name, String Description)
        {
            test = extent.CreateTest(Name, Description);
            return test;
        }
    }
}
