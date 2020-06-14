namespace RestSharpApiTests.PropertyClass
{
    public class CreateUserPartial
    {
        public string name { get; set; }
        public string job { get; set; }
    }

    public class CreateUser: CreateUserPartial
    {
        public string id { get; set; }
        public string createdAt { get; set; }
    }
}
