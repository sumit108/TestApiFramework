namespace RestSharpApiTests.PropertyClass
{
    public class CreatePartial
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class Create: CreatePartial
    {
        public string id { get; set; }
        public string createdAt { get; set; }
    }
}
