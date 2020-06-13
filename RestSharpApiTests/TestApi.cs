using Newtonsoft.Json;
using NUnit.Framework;
using FluentAssertions;
using RestSharpApiTests.PropertyClass;
using static RestSharpApiTests.CommonHelper;

namespace RestSharpApiTests
{
    // storing Excel Data
    public class ExcelProperties
    {
        public string Name { get; set; }
        public string RestClient { get; set; }
        public string RestRequest { get; set; }
        public string RequestMethod { get; set; }
        public string JsonRequest { get; set; }
        public string ExpectedResponseJson { get; set; }
        public int ExpectedResponseCode { get; set; }
        public bool RunFlag { get; set; }
    }

    // Excel test data columns enum
    public enum ExcelColumnsEnum
    {
        Name,
        RestClient,
        RestRequest,
        RequestMethod,
        JsonRequest,
        ExpectedResponseJson,
        ExpectedResponseCode,
        RunFlag
    }

    [TestFixture]
    class requres
    {
        // Global Variables
        public static string testCaseName { get; set; }

        [SetUp]
        public void SetupPre()
        {
            testCaseName = TestContext.CurrentContext.Test.Name;
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();
            if (!exlData.RunFlag)
                Assert.Ignore("Ignored the test case as run falg is set to " + exlData.RunFlag + " in Test data");
        }

        [Test(Description = "Single User with Id 2 API")]
        public void SingleUser2()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send Request and Get ressponse
            var response = GetResponseFromApi(exlData);

            // Deserialize response to json
            var expectedData = JsonConvert.DeserializeObject<SingleUserPropertyClass>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<SingleUserPropertyClass>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "Single User with Id 1 API")]
        public void SingleUser1()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<SingleUserPropertyClass>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<SingleUserPropertyClass>(response.Content);
            
            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for List of all users")]
        public void ListUsers()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<ListUsersPropertyClass>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<ListUsersPropertyClass>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Single user not found")]
        public void SingleUserNotFound()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
        }

        [Test(Description = "API for List of Resources")]
        public void ListResource()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<ListUsersPropertyClass>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<ListUsersPropertyClass>(response.Content);
            
            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Single Resource")]
        public void SingleResource()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<SingleUserPropertyClass>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<SingleUserPropertyClass>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Single Resource not found")]
        public void SingleResourceNotFound()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
        }

        [Test(Description = "API for Create")]
        public void Create()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<CreatePartial>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<CreatePartial>(response.Content);
            var responseOtherData = JsonConvert.DeserializeObject<Create>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
            Assert.IsNotNull(responseOtherData.createdAt);
            Assert.IsNotNull(responseOtherData.id);
        }

        [Test(Description = "API for Update")]
        public void Update()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<CreatePartial>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<CreatePartial>(response.Content);
            var responseOtherData = JsonConvert.DeserializeObject<Update>(response.Content);
           
            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
            Assert.IsNotNull(responseOtherData.updatedAt);
        }

        [Test(Description = "API for Delete")]
        public void Delete()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);
            
            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
        }

        [Test(Description = "API for Register Successful")]
        public void RegisterSuccessful()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<Register>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<Register>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Register UnSuccessful")]
        public void RegisterUnSuccessful()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<Register>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<Register>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Login Successful")]
        public void LoginSuccessful()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<Register>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<Register>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Login UnSuccessful")]
        public void LoginUnSuccessful()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<Register>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<Register>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }

        [Test(Description = "API for Delayed Response")]
        public void DelayedResponse()
        {
            // Get Data Related to Current Executing TC from excel
            var exlData = ExcelHelper.GetExcelDataRelativeToTc();

            // Send the data to a () that return response
            var response = GetResponseFromApi(exlData);

            // Deserialize json
            var expectedData = JsonConvert.DeserializeObject<ListUsersPropertyClass>(exlData.ExpectedResponseJson);
            var responseData = JsonConvert.DeserializeObject<ListUsersPropertyClass>(response.Content);

            // Assert Response
            AssertResponseStatusCode(exlData.ExpectedResponseCode, response.StatusCode);
            responseData.Should().BeEquivalentTo(expectedData);
        }
    }
}
