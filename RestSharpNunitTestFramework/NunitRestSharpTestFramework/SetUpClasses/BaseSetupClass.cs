using NUnit.Framework;
using System.Collections.Generic;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using RestSharp;

namespace NunitRestSharpTestFramework
{
    public class BaseSetupClass : ExtentManager
    {
        public ExtentReports extent;
        public ExtentTest test;
        public static string validURI { get; set; }
        public RestClient client;
        [SetUp]
        [Description("This set up method will create an instance of Extent report and reads the test case"
            + "configuration sheet. Based on the data available in sheet, any test execution can be ignored")]
        public void BeforeTest()
        {
            extent = ExtentManager.getExtent();
            string testCaseName = TestContext.CurrentContext.Test.Name;
            test = extent.CreateTest(testCaseName);

            string testCaseConfigurationLocation = projectDirectory + "\\TestCaseConfiguration\\TestCaseConfiguration.xlsx";
            TestCaseConfiguration tcConfig = new TestCaseConfiguration();
            List<TestCaseData> readConfig = tcConfig.testCaseConfigurationReader(testCaseName, testCaseConfigurationLocation);
            if (readConfig[0].executeValue == "NO")
            {
                Assert.Ignore();
            }
            string uri = readConfig[0].uri;
            if (uri != "NA")
            {
                validURI = uri;
            }
            if (validURI == "NA")
            {
                test.Log(Status.Skip, "Test has been skipped since required URI has not been provided");
                Assert.Ignore();
            }
            //Console.WriteLine(validURI);
            client = new RestClient();
            client.BaseUrl = new System.Uri(validURI);
        }
    
        [TearDown]
        [Description("This method will run after execution of every test script. Execution status of each"
            +"test case will be reported to extent reports")]
        public void AfterTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                    ? ""
                    : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            extent.Flush();
        }
    }
}

