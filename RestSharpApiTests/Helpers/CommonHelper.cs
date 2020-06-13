using NUnit.Framework;
using RestSharp;
using System.Net;

namespace RestSharpApiTests
{
    public static class CommonHelper
    {
        public static string GetCurrentMethodName()
        {
          return  TestContext.CurrentContext.Test.Name;
        }

        public static IRestResponse GetResponseFromApi(ExcelProperties excelProperties)
        {
            RestClient client = new RestClient(excelProperties.RestClient);
            RestRequest request = new RestRequest(excelProperties.RestRequest, ApiMethod(excelProperties.RequestMethod.ToString()));
            if (excelProperties.RequestMethod == Method.POST.ToString() || excelProperties.RequestMethod == Method.PUT.ToString())
            {
                request.AddParameter("application/json; charset=utf-8", excelProperties.JsonRequest, ParameterType.RequestBody);
                request.RequestFormat = DataFormat.Json;
            }
            IRestResponse response = client.Execute(request);
            return response;
        }

        public static Method ApiMethod(string RequestMethod)
        {
            switch (RequestMethod)
            {
                case "GET":
                    return Method.GET;
                case "POST":
                    return Method.POST;
                case "PUT":
                    return Method.PUT;
                case "DELETE":
                    return Method.DELETE;
            }
            return Method.GET;
        }

        public static void AssertResponseStatusCode(int expectedStatusCode,HttpStatusCode statusCode)
        {
            int statusCodeInt = (int)statusCode;
            if (expectedStatusCode == statusCodeInt)
                return;
            else
                Assert.Fail("Expected response code was " + expectedStatusCode + " but received " + statusCodeInt);
        }

        //public static void AssertResponse(object expectedData,object responseData)
        //{
        //    if (responseData.StatusCode == HttpStatusCode.OK)
        //        responseData.Should().BeEquivalentTo(expectedData);
        //    else
        //        Assert.Fail("Expected response code was " + HttpStatusCode.OK + " but was " + response.StatusCode);
        //}
    }
}
