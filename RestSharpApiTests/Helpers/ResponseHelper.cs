using NUnit.Framework;
using RestSharp;
using RestSharpApiTests.PropertyClass;
using System.Net;

namespace RestSharpApiTests.Helpers
{
    public class ResponseHelper
    {
        public IRestResponse GetResponseFromApi(ExcelProperties excelProperties)
        {
            RestClient client = new RestClient(excelProperties.RestClient);
            RestRequest request = new RestRequest(excelProperties.RestRequest, HTTPMethods.ApiMethod(excelProperties.RequestMethod.ToString()));
            if (excelProperties.RequestMethod == Method.POST.ToString() || excelProperties.RequestMethod == Method.PUT.ToString())
            {
                request.AddParameter("application/json; charset=utf-8", excelProperties.JsonRequest, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
            }
            IRestResponse response = client.Execute(request);
            return response;
        }

        public void AssertResponseStatusCode(int expectedStatusCode, HttpStatusCode statusCode)
        {
            int statusCodeInt = (int)statusCode;
            if (expectedStatusCode == statusCodeInt)
                return;
            else
                Assert.Fail("Expected response code was " + expectedStatusCode + " but received " + statusCodeInt);
        }
    }
}
