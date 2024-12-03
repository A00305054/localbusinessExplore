using System.Collections.Generic;

namespace localbusinessExplore.Entities
{
    public class Place
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Rating { get; set; }
        public string OpeningHours { get; set; }
        public string BusinessStatus { get; set; }
        public string Location { get; set; }
        public List<string> Photos { get; set; }
    }
}
