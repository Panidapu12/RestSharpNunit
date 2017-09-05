using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitRestSharpTestFramework
{
    [TestFixture]
    public class PostTestCases : BaseSetupClass
    {
        [Test]
        public void verifyPostedResource()
        {
            test.AssignCategory("Test Case related to post");
            test.AssignAuthor("Srinivas");
            RestSharpSupportingClass executingMethod = new RestSharpSupportingClass();


            var restRequest = new RestRequest("/posts",Method.POST);
            restRequest.AddParameter("application/json; charset=utf-8", ParameterType.RequestBody);
            restRequest.AddParameter("title", "foo");
            restRequest.AddParameter("body", "bar");
            restRequest.AddParameter("userID", 1);
            var response = executingMethod.Execute<Posts>(restRequest,client);
            Assert.AreEqual("bar", response.body, string.Format("Expected body {0} is not matching with actual posted {1}", "bar", response.body));
            // Console.WriteLine(response.title);
        }
    }
}
