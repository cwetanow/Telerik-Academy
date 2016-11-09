using System.ComponentModel.DataAnnotations;

namespace SuperheroesUniverse.Models
{
    public class Relationship
    {
        [Key]
        public int Id { get; set; }

        public RelationshipType RelationshipType { get; set; }

        public Superhero FirstSuperhero { get; set; }

        public Superhero SecondSuperhero { get; set; }
    }
}
