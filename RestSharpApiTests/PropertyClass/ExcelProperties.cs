namespace RestSharpApiTests.PropertyClass
{

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

}
