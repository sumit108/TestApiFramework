using RestSharp;

namespace RestSharpApiTests.Helpers
{
    public class HTTPMethods
    {
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
    }
}
