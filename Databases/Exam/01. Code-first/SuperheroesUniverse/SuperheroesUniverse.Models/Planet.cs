using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Planet
    {
        private ICollection<Country> countries;
        private ICollection<Fraction> fractionsThatProtectIt;

        public Planet()
        {
            this.countries = new HashSet<Country>();
            this.fractionsThatProtectIt = new HashSet<Fraction>();
        }

        [Key]
        public int PlanetId { get; set; }

        [MaxLength(30), MinLength(2)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Country> Countries
        {
            get { return this.countries; }
            set { this.countries = value; }
        }

        public virtual ICollection<Fraction> FractionsThatProtectIt
        {
            get { return this.fractionsThatProtectIt; }
            set { this.fractionsThatProtectIt = value; }
        }
    }
}