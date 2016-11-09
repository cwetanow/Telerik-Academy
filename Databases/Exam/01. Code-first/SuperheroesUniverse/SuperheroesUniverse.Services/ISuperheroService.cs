using System.Collections.Generic;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Services
{
    public interface ISuperheroService
    {
        IEnumerable<Planet> AddPlanets(IEnumerable<Planet> entities);

        IEnumerable<Power> AddPowers(IEnumerable<Power> entities);

        IEnumerable<Country> AddCountries(IEnumerable<Country> entities);

        IEnumerable<City> AddCities(IEnumerable<City> entities);

        IEnumerable<Fraction> AddFractions(IEnumerable<Fraction> entities);

        IEnumerable<Superhero> AddHeroes(IEnumerable<Superhero> entities);

        void LinkPlanetsWithFractions();
    }
}
