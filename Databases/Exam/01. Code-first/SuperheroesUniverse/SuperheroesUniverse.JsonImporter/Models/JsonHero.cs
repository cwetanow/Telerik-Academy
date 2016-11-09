using System.Collections.Generic;

namespace SuperheroesUniverse.JsonImporter.Models
{
    public class JsonHero
    {
        public string name { get; set; }
        public string secretIdentity { get; set; }
        public JsonCity city { get; set; }
        public string alignment { get; set; }
        public string story { get; set; }
        public List<string> powers { get; set; }
        public List<string> fractions { get; set; }
    }
}
