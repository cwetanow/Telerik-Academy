using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        private ICollection<Superhero> superheroes;
        private ICollection<Planet> platesThatProtects;

        public Fraction()
        {
            this.superheroes = new HashSet<Superhero>();
            this.platesThatProtects = new HashSet<Planet>();
        }
        [Key]
        public int FractionId { get; set; }

        [MaxLength(30), MinLength(2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public AlignmentType Alignment { get; set; }

        public virtual ICollection<Planet> PlanetsThatProtects
        {
            get { return this.platesThatProtects; }
            set { this.platesThatProtects = value; }
        }

        public virtual ICollection<Superhero> Superheroes
        {
            get { return this.superheroes; }
            set { this.superheroes = value; }
        }
    }
}