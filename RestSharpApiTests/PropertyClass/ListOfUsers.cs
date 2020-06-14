using System.Collections.Generic;

namespace RestSharpApiTests.PropertyClass
{
    class ListOfUsers
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public List<data>  data { get; set; }
        public ad ad { get; set; }
    }
}
