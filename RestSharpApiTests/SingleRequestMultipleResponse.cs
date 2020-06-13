using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;

namespace RestSharpApiTests
{
    class SingleRequestMultipleResponse
    {
        [Test]
        public void SingleRequestMultipleResponseApiTestCase()
        {
            RestClient restClient = new RestClient("http://api.zippopotam.us/IN/110001");

            //RestRequest restRequest = new RestRequest("/register", Method.POST);
            RestRequest restRequest = new RestRequest(Method.GET);

            IRestResponse restResponse = restClient.Execute(restRequest);

            // Deserialize Json response to C# object
            var responseData = JsonConvert.DeserializeObject<Datum>(restResponse.Content);

            string country = "India";
            int post_code = 110001;
            string country_abbreviation = "IN";

            Assert.AreEqual(responseData.country, country, "Country expected was " + country + " but was" + responseData.country);
            Assert.AreEqual(responseData.post_code, post_code, "post_code expected was " + post_code + " but was" + responseData.post_code);
            Assert.AreEqual(responseData.country_abbreviation, country_abbreviation, "country_abbreviation expected was " + country_abbreviation + " but was" + responseData.country_abbreviation);
        }
    }
}
