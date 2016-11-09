using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperheroesUniverse.Models
{
    public class Power
    {
        private ICollection<Superhero> superheroesThatHaveIt;

        public Power()
        {
            this.superheroesThatHaveIt = new HashSet<Superhero>();
        }
        [Key]
        public int PowerId { get; set; }

        [MaxLength(35), MinLength(3)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Superhero> SuperherosThatHaveIt
        {
            get { return this.superheroesThatHaveIt; }
            set { this.superheroesThatHaveIt = value; }
        }
    }
}