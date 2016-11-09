using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Country
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        [Key]
        public int CountryId { get; set; }

        [MaxLength(30), MinLength(2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [ForeignKey("Planet")]
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }

        public virtual ICollection<City> Cities
        {
            get { return this.cities; }
            set { this.cities = value; }
        }
    }
}
