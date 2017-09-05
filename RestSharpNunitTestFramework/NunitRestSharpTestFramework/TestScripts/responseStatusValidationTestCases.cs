using NUnit.Framework;
using RestSharp;
using System.Net;


namespace NunitRestSharpTestFramework
{
    [TestFixture]
    public class responseStatusValidationTestCases : BaseSetupClass
    {

        [Test]
            public void responseStatusCodeVerificationForComments()
            {
                test.AssignAuthor("Srinivas");//reporting purpose
                test.AssignCategory("StatusVerification");//reporting purpose
                //RestSharpSupportingClass executingMethod = new RestSharpSupportingClass();

                var request = new RestRequest("comments");

                IRestResponse response = client.Execute(request);
                  Assert.AreEqual(HttpStatusCode.OK, response.StatusCode,
                    string.Format("Expected status code {0} is not matching with actual {1}", HttpStatusCode.OK, response.StatusCode));
            }

            [Test]
            public void responseStatusCodeVerificationForPosts()
            {
                test.AssignAuthor("Srinivas");//reporting purpose
                test.AssignCategory("StatusVerification");

                var request = new RestRequest("posts");
                IRestResponse response = client.Execute(request);
               Assert.AreEqual(HttpStatusCode.OK, response.StatusCode,
                    string.Format("Expected status code {0} is not matching with actual {1}", HttpStatusCode.OK, response.StatusCode));
            }

            [Test]
            public void responseStatusCodeVerificationForAlbums()
            {
                 test.AssignAuthor("Srinivas");//reporting purpose
                test.AssignCategory("StatusVerification");//reporting purpose

                var request = new RestRequest("albums");

                IRestResponse response = client.Execute(request);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode,
                    string.Format("Expected status code {0} is not matching with actual {1}", HttpStatusCode.OK, response.StatusCode));
            }

            [Test]
            public void responseStatusCodeVerificationForPhotos()
            {
            test.AssignAuthor("Srinivas");//reporting purpose
            test.AssignCategory("StatusVerification");//reporting purpose

            var request = new RestRequest("photos");

                IRestResponse response = client.Execute(request);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode,
                    string.Format("Expected status code {0} is not matching with actual {1}", HttpStatusCode.OK, response.StatusCode));
            }

            [Test]
            public void responseStatusCodeVerificationForTodos()
            {
                test.AssignAuthor("Srinivas");//reporting purpose
                test.AssignCategory("StatusVerification");//reporting purpose
                var request = new RestRequest("todos");
                IRestResponse response = client.Execute(request);
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode,
                    string.Format("Expected status code {0} is not matching with actual {1}", HttpStatusCode.OK, response.StatusCode));
            }

           
        }
    }