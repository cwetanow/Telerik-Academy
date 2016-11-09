using System.Data.Entity;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Data
{
    public class SuperheroeEntities : DbContext
    {
        public SuperheroeEntities()
            : base("Superheroes")
        {
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Fraction> Fractions { get; set; }

        public DbSet<Planet> Planets { get; set; }

        public DbSet<Power> Powers { get; set; }

        public DbSet<Relationship> Relationships { get; set; }

        public DbSet<Superhero> Superheroes { get; set; }
    }
}
