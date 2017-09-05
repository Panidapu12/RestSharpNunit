using RestSharp;
using System;

namespace NunitRestSharpTestFramework
{
    public class RestSharpSupportingClass
    {
        public T Execute<T>(RestRequest request, RestClient client) where T : new()
        {
            var response = client.Execute<T>(request);
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                var twilioException = new ApplicationException(message, response.ErrorException);
                throw twilioException;
            }
            return response.Data;
        }
    }
}
