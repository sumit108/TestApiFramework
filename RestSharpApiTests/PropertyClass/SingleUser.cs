namespace RestSharpApiTests.PropertyClass
{
    class SingleUser
    {
        public data data { get; set; }
        public ad ad { get; set; }
    }
    public class data
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string avatar { get; set; }
    }
    public class ad
    {
        public string company { get; set; }
        public string url { get; set; }
        public string text { get; set; }
    }
}
