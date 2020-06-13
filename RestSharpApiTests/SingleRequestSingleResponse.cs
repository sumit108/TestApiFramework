using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Collections.Generic;

namespace RestSharpApiTests
{
    class SingleRequestSingleResponse
    {
        [Test]
        public void SingleRequestSingleResponseApiTestCase()
        {
            //RestClient restClient = new RestClient("https://reqres.in/api/users/2");
            RestClient restClient = new RestClient("http://api.zippopotam.us/us/90210");

            //RestRequest restRequest = new RestRequest("/register", Method.POST);
            RestRequest restRequest = new RestRequest(Method.GET);
            
            IRestResponse restResponse = restClient.Execute(restRequest);

            // Deserialize Json response to C# object
            var responseData = JsonConvert.DeserializeObject<Datum>(restResponse.Content);

            string country = "United States";
            int post_code = 90210;
            string country_abbreviation = "US";

            Assert.AreEqual(responseData.country, country, "Country expected was "+ country + " but was"+ responseData.country);
            Assert.AreEqual(responseData.post_code, post_code, "post_code expected was " + post_code + " but was" + responseData.post_code);
            Assert.AreEqual(responseData.country_abbreviation, country_abbreviation, "country_abbreviation expected was " + country_abbreviation + " but was" + responseData.country_abbreviation);
        }
    }
   
    public class Datum
    {
        [JsonProperty("post code")]
        public int post_code { get; set; }
        [JsonProperty("country")]
        public string country { get; set; }
        [JsonProperty("country abbreviation")]
        public string country_abbreviation { get; set; }
        [JsonProperty("places")]
        public List<Places> places { get; set; }
    }

    public class Places
    {
        [JsonProperty("place name")]
        public string place_name { get; set; }
        [JsonProperty("longitude")]
        public string longitude { get; set; }
        [JsonProperty("state")]
        public string state { get; set; }
        [JsonProperty("state abbreviation")]
        public string state_abbreviation { get; set; }
        [JsonProperty("latitude")]
        public string latitude { get; set; }
    }
}
