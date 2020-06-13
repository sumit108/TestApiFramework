//using Newtonsoft.Json;
//using NUnit.Framework;
//using RestSharp;
//using FluentAssertions;
//using System.Data;
//using System.Net;
//using System;
//using System.Linq;
//using DocumentFormat.OpenXml.Wordprocessing;
//using System.Reflection;

//namespace RestSharpApiTests
//{
//    public static class ExcelProperties
//    {
//        public static string Name { get; set; }
//        public static string RestClient { get; set; }
//        public static string RestRequest { get; set; }
//        public static string RequestMethod { get; set; }
//        public static string ExpectedResponse { get; set; }
//    }

//    public enum ExcelColumns
//    {
//        Name,
//        RestClient,
//        RestRequest,
//        RequestMethod,
//        ExpectedResponse
//    }
//    [TestFixture]
//    class requres
//    {
//        [Test]
//        public void GetResponse()
//        {
//            string jsonResponseExpectedString = "{\"data\":{\"id\":2,\"email\":\"janet.weaver@reqres.in\",\"first_name\":\"Janet\",\"last_name\":\"Weaver\",\"avatar\":\"https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg\"},\"ad\":{\"company\":\"StatusCode Weekly\",\"url\":\"http://statuscode.org/\",\"text\":\"A weekly newsletter focusing on software development, infrastructure, the server, performance, and the stack end of things.\"}}";

//            RestClient client = new RestClient("https://reqres.in/");
//            RestRequest request = new RestRequest("/api/users/2", Method.GET);
//            // request.RequestFormat = DataFormat.Json;
//            IRestResponse<MyDetail> response = client.Execute<MyDetail>(request);

//            var expectedData = JsonConvert.DeserializeObject<MyDetail>(jsonResponseExpectedString);
//            var responseData = JsonConvert.DeserializeObject<MyDetail>(response.Content);
//            responseData.Should().BeEquivalentTo(expectedData);

//            #region manual Assertions
//            /*
//            Assert.AreEqual(expectedData.data.id, response.Data.data.id, "Expected and actual Id are different. Expected " + expectedData.data.id + " but was " + response.Data.data.id);
//            Assert.AreEqual(expectedData.data.email, response.Data.data.email, "Expected and actual email are different. Expected " + expectedData.data.email + " but was " + response.Data.data.email);
//            Assert.AreEqual(expectedData.data.first_name, response.Data.data.first_name, "Expected and actual first_name are different. Expected " + expectedData.data.first_name + " but was " + response.Data.data.first_name);
//            Assert.AreEqual(expectedData.data.last_name, response.Data.data.last_name, "Expected and actual lastName are different. Expected " + expectedData.data.last_name + " but was " + response.Data.data.last_name);
//            Assert.AreEqual(expectedData.data.avatar, response.Data.data.avatar, "Expected and actual avatar are different. Expected " + expectedData.data.avatar + " but was " + response.Data.data.avatar);

//            Assert.AreEqual(expectedData.ad.company, response.Data.ad.company, "Expected and actual company are different. Expected " + expectedData.ad.company + " but was " + response.Data.ad.company);
//            Assert.AreEqual(expectedData.ad.url, response.Data.ad.url, "Expected and actual url are different. Expected " + expectedData.ad.url + " but was " + response.Data.ad.url);
//            Assert.AreEqual(expectedData.ad.text, response.Data.ad.text, "Expected and actual text are different. Expected " + expectedData.ad.text + " but was " + response.Data.ad.text);
//            */
//            #endregion
//        }

//        [Test]
//        public void GetResponse_Excel()
//        {

//            var dt = ExcelHelper.ExcelRead();
//            foreach (DataRow row in dt.Rows)
//            {
//                ExcelProperties.Name = row[ExcelColumns.Name.ToString()].ToString();
//                ExcelProperties.RestClient = row[ExcelColumns.RestClient.ToString()].ToString();
//                ExcelProperties.RestRequest = row[ExcelColumns.RestRequest.ToString()].ToString();
//                ExcelProperties.RequestMethod = row[ExcelColumns.RequestMethod.ToString()].ToString();
//                ExcelProperties.ExpectedResponse = row[ExcelColumns.ExpectedResponse.ToString()].ToString();
               
//                RestClient client = new RestClient(ExcelProperties.RestClient);
//                RestRequest request = new RestRequest(ExcelProperties.RestRequest, ApiMethod(ExcelProperties.RequestMethod.ToString()));
//                // request.RequestFormat = DataFormat.Json;
//                IRestResponse response = client.Execute(request);

//                var expectedData = JsonConvert.DeserializeObject<MyDetail>(ExcelProperties.ExpectedResponse);
//                var responseData = JsonConvert.DeserializeObject<MyDetail>(response.Content);

//                if (response.StatusCode == HttpStatusCode.OK)
//                    responseData.Should().BeEquivalentTo(expectedData);
//                else
//                    Assert.Fail("Expected response code was " + HttpStatusCode.OK + " but was " + response.StatusCode);
//            }
//        }

//        public Method ApiMethod(string RequestMethod)
//        {
//            switch (RequestMethod)
//            {
//                case "GET":
//                    return Method.GET;
//                case "POST":
//                    return Method.POST;
//                case "PUT":
//                    return Method.PUT;
//                case "DELETE":
//                    return Method.DELETE;
//            }
//            return Method.GET;
//        }

//        public class MyDetail
//        {
//            public data data { get; set; }
//            public ad ad { get; set; }
//        }
//        public class data
//        {
//            public int id { get; set; }
//            public string email { get; set; }
//            public string first_name { get; set; }
//            public string last_name { get; set; }
//            public string avatar { get; set; }
//        }
//        public class ad
//        {
//            public string company { get; set; }
//            public string url { get; set; }
//            public string text { get; set; }
//        }
//    }
//}
