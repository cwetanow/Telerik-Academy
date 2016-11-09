using System.Collections.Generic;

namespace SuperheroesUniverse.JsonImporter.Models
{
    public class JsonRoot
    {
        public JsonRoot()
        {
            this.data = new List<JsonHero>();
        }

        public List<JsonHero> data { get; set; }
    }
}
