using NUnit.Framework;
using RestSharp;
using System.Net;

namespace RestSharpApiTests
{
    [TestFixture]
    class TestApi1
    {
        [Test]
        public void ApiTest_01()
        {
            // arrange
            RestClient client = new RestClient("http://api.zippopotam.us");
            RestRequest request = new RestRequest("nl/3825", Method.GET);

            // act
            IRestResponse response = client.Execute(request);

            // assert status code
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            // assert response type
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

        [Test]
        public void EmtApiTest_Get()
        {
            // arrange
            RestClient client = new RestClient("http://172.25.80.212:84");
            RestRequest request = new RestRequest("/api/User", Method.GET);
            request.RequestFormat = DataFormat.Json;
            // act
            IRestResponse response = client.Execute(request);
            // assert status code
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            // assert response type
            Assert.That(response.ContentType, Is.EqualTo("application/json; charset=utf-8"));
            int responseCount = response.Content.Length;
           
        }
    }
}
