using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Superhero
    {
        private ICollection<Fraction> fractions;
        private ICollection<Power> powers;

        public Superhero()
        {
            this.fractions = new HashSet<Fraction>();
            this.powers = new HashSet<Power>();
        }

        [Key]
        public int SuperheroId { get; set; }

        [Required]
        [MaxLength(60), MinLength(3)]
        public string Name { get; set; }

        [MaxLength(20), MinLength(3)]
        [Required]
        [Index(IsUnique = true)]
        public string SecretIdentity { get; set; }

        [Required]
        public AlignmentType Alignment { get; set; }

        [Required]
        [MinLength(1)]
        public string Story { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Fraction> Fractions
        {
            get { return this.fractions; }
            set { this.fractions = value; }
        }

        public virtual ICollection<Power> Powers
        {
            get { return this.powers; }
            set { this.powers = value; }
        }
    }
}
