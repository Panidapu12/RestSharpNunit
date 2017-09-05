using NUnit.Framework;
using RestSharp;


namespace NunitRestSharpTestFramework
{
    [TestFixture]
    public class PhotoTestCases : BaseSetupClass
    {
        [Test]
        public void urlValidationOfaPhoto()
        {
            test.AssignAuthor("Srinivas");//reporting purpose
            test.AssignCategory("PhotoURLValidation");//reporting purpose
            RestSharpSupportingClass executingMethod = new RestSharpSupportingClass();

            var request = new RestRequest("photos/1");
            request.AddUrlSegment("id", "1");
          //  request.AddUrlSegment("id", "1");

            var responseDataOfCommentsModel = executingMethod.Execute<Photos>(request, client);
            Assert.AreEqual("http://placehold.it/600/92c952", responseDataOfCommentsModel.url, string.Format("Expected url {0} is not matching with actual {1}", "http://placehold.it/600/92c952", responseDataOfCommentsModel.url));
            //Console.WriteLine(responseDataOfCommentsModel.url);
        }

        [TestCase("2", "http://placehold.it/600/771796","1")]//Expected Failure
        [TestCase("7", "http://placehold.it/600/b0f7cc","1")]//Expected Failure
        [TestCase("10", "http://placehold.it/600/810b14","1")]//Expected Failure

        public void urlValidationOfaPhotoParameterized(string photoId, string url, string albumid)
        {
            test.AssignAuthor("Srinivas");//reporting purpose
            test.AssignCategory("PhotoUrlVerificationParameterization");//reporting purpose
            RestSharpSupportingClass executingMethod = new RestSharpSupportingClass();

            var request = new RestRequest("photos/"+albumid);
            request.AddUrlSegment("id", photoId);
            //  request.AddUrlSegment("id", "1");

            var responseDataOfCommentsModel = executingMethod.Execute<Photos>(request, client);
            Assert.AreEqual(url, responseDataOfCommentsModel.url, string.Format("Expected url {0} is not matching with actual {1}", url, responseDataOfCommentsModel.url));
            //Console.WriteLine(responseDataOfCommentsModel.url);
        }
    }
}
