using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class City
    {
        private ICollection<Superhero> superheroes;

        public City()
        {
            this.superheroes = new HashSet<Superhero>();
        }

        [Key]
        public int CityId { get; set; }

        [MaxLength(30), MinLength(2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Superhero> Superheroes
        {
            get { return this.superheroes; }
            set { this.superheroes = value; }
        }
    }
}
