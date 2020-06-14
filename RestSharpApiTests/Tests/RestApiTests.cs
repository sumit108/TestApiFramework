using Newtonsoft.Json;
using NUnit.Framework;
using FluentAssertions;
using RestSharpApiTests.PropertyClass;
using RestSharpApiTests.Helpers;

namespace RestSharpApiTests
{
   
    [TestFixture]
    public class RestApiTests:GlobalSetUp
    {
        private ResponseHelper _CommonHelper { get; set; }

        public RestApiTests()
        {
            var commonHelper = new ResponseHelper();
            _CommonHelper = commonHelper;
        }

        // Global Variables
        public static string testCaseName { get; set; }


        [Test(Description = "Single User with Id 2 API")]
        public void SingleUser2()
        {
            // Send Request and Get ressponse
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize response to json
            var expectedData = JsonConvert.DeserializeObject<SingleUser>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<SingleUser>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "Single User with Id 1 API")]
        public void SingleUser1()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<SingleUser>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<SingleUser>(response.Content);
            
            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for List of all users")]
        public void ListUsers()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<ListOfUsers>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<ListOfUsers>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Single user not found")]
        public void SingleUserNotFound()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
        }

        [Test(Description = "API for List of Resources")]
        public void ListResource()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<ListOfUsers>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<ListOfUsers>(response.Content);
            
            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Single Resource")]
        public void SingleResource()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<SingleUser>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<SingleUser>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Single Resource not found")]
        public void SingleResourceNotFound()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
        }

        [Test(Description = "API for Create")]
        public void Create()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<CreateUserPartial>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<CreateUserPartial>(response.Content);
            var responseOtherData = JsonConvert.DeserializeObject<CreateUser>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
            Assert.IsNotNull(responseOtherData.createdAt);
            Assert.IsNotNull(responseOtherData.id);
        }

        [Test(Description = "API for Update")]
        public void Update()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<CreateUserPartial>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<CreateUserPartial>(response.Content);
            var responseOtherData = JsonConvert.DeserializeObject<UpdateUser>(response.Content);
           
            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
            Assert.IsNotNull(responseOtherData.updatedAt);
        }

        [Test(Description = "API for Delete")]
        public void Delete()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);
            
            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
        }

        [Test(Description = "API for Register Successful")]
        public void RegisterSuccessful()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<RegisterUser>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<RegisterUser>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Register UnSuccessful")]
        public void RegisterUnSuccessful()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<RegisterUser>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<RegisterUser>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Login Successful")]
        public void LoginSuccessful()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<RegisterUser>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<RegisterUser>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Login UnSuccessful")]
        public void LoginUnSuccessful()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<RegisterUser>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<RegisterUser>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Delayed Response")]
        public void DelayedResponse()
        {
            // Send the data to a () that return response
            var response = _CommonHelper.GetResponseFromApi(_TestData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<ListOfUsers>(_TestData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<ListOfUsers>(response.Content);

            // Assert Response
            _CommonHelper.AssertResponseStatusCode(_TestData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }
    }
}
