using NUnit.Framework;
using RestSharp;

namespace NunitRestSharpTestFramework
{
    [TestFixture]
    public class CommentsTestCases : BaseSetupClass
    {
        [Test] 
        public void validatingCommentsOfAParticularID()
        {
            test.AssignAuthor("Srinivas");//reporting purpose
            test.AssignCategory("Comments");//reporting purpose
            RestSharpSupportingClass executingMethod = new RestSharpSupportingClass();


            var request = new RestRequest("comments/11", Method.GET);
            request.AddUrlSegment("id", "11");

            var responseDataOfCommentsModel = executingMethod.Execute<Comments>(request, client);
            //Assert.AreEqual(11, responseDataOfCommentsModel.id, string.Format("ID {0} does not match actually {1}", 11, responseDataOfCommentsModel.id));
            Assert.AreEqual(3, responseDataOfCommentsModel.postId);
            //var assert = responseDataOfCommentsModel.name.Contains("fugit");
            //Assert.IsTrue(assert);

        }


        //Parameterization
        [TestCase ("11",3)]
        [TestCase("12", 3)]
        [TestCase("13", 3)]
        [TestCase("14", 4)]//Failure Scenario
        [TestCase("16", 4)]
        [TestCase("17", 6)]//Failure Scenario
        public void ValidatingCommentWithPostID(string postID,int id)
        {
            test.AssignAuthor("Srinivas");
            test.AssignCategory("CommentsParameterization");
            RestSharpSupportingClass executingMethod = new RestSharpSupportingClass();
            
            var request = new RestRequest("comments/" + postID, Method.GET);
            request.AddUrlSegment("postId", postID);
            var responseDataOfCommentsModel = executingMethod.Execute<Comments>(request, client);
            Assert.AreEqual(id, responseDataOfCommentsModel.postId, string.Format("ID {0} does not match actually {1}", id, responseDataOfCommentsModel.id));
        }
    }
}
    