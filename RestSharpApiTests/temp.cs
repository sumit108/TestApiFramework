//using FluentAssertions;
//using Newtonsoft.Json;
//using NUnit.Framework;
//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Net;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace RestSharpApiTests
//{
//    class temp
//    {

//        [Test]
//        public void GetResponse_ExcelTRIAL()
//        {

//var newType = Type.GetType(MyDetails);
//var tss = Activator.CreateInstance(newType);
//            var dt = ExcelHelper.ExcelRead();
//            foreach (DataRow row in dt.Rows)
//            {
//                ExcelProperties.Name = row[ExcelColumns.Name.ToString()].ToString();
//                ExcelProperties.RestClient = row[ExcelColumns.RestClient.ToString()].ToString();
//                ExcelProperties.RestRequest = row[ExcelColumns.RestRequest.ToString()].ToString();
//                ExcelProperties.RequestMethod = row[ExcelColumns.RequestMethod.ToString()].ToString();
//                ExcelProperties.ExpectedResponse = row[ExcelColumns.ExpectedResponse.ToString()].ToString();
//                string MyDetails = "MyDetail";
//                //var newType = Type.GetType(MyDetails);
//                //var tss = Activator.CreateInstance(newType);

//                Type[] types = Assembly.GetExecutingAssembly().GetTypes();
//                foreach (var t in types)
//                    if (t.Name == MyDetails)
//                    {
//                        RestClient client = new RestClient(ExcelProperties.RestClient);
//                        // RestRequest request = new RestRequest(ExcelProperties.RestRequest, ApiMethod(ExcelProperties.RequestMethod.ToString()));
//                        // request.RequestFormat = DataFormat.Json;
//                        IRestResponse response = client.Execute(request);

//                        //var expectedData = JsonConvert.DeserializeObject(ExcelProperties.ExpectedResponse,);
//                        //var responseData = JsonConvert.DeserializeObject(response.Content, t.GetType());

//                        var expectedData = DeserializeObject(ExcelProperties.ExpectedResponse);
//                        var responseData = JsonConvert.DeserializeObject(response.Content, t.GetType());


//                        if (response.StatusCode == HttpStatusCode.OK)
//                        {
//                            responseData.Should().BeEquivalentTo(expectedData);

//                        }

//                        else
//                            Assert.Fail("Expected response code was " + HttpStatusCode.OK + " but was " + response.StatusCode);
//                    }
//            }
//        }

//        public static T DeserializeObject<T>(string value)
//        {
//            T result = default(T);

//            try
//            {
//                result = JsonConvert.DeserializeObject<T>(value);
//                System.Diagnostics.Debug.WriteLine($"\nDeserialization Success! : { result }\n");
//            }
//            catch (Exception ex)
//            {
//                System.Diagnostics.Debug.WriteLine($"\nDeserialization failed with exception : { ex }\n");
//            }

//            return result;
//        }


//        private static object CreateByTypeName(string typeName)
//        {
//            // scan for the class type
//            var type = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
//                        from t in assembly.GetTypes()
//                        where t.Name == typeName  // you could use the t.FullName aswel
//                        select t).FirstOrDefault();

//            if (type == null)
//                throw new InvalidOperationException("Type not found");

//            return Activator.CreateInstance(type);
//        }

//    }
//}
