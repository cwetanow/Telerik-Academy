using System.Collections.Generic;
using SuperheroesUniverse.Data.Repositories;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Services
{
    public class SuperheroService : ISuperheroService
    {
        private readonly IRepository<Superhero> superheroRepository;
        private readonly IRepository<Planet> planetRepository;
        private readonly IRepository<Country> countryRepository;
        private readonly IRepository<City> cityRepository;
        private readonly IRepository<Fraction> fractionRepository;
        private readonly IRepository<Power> powerRepository;

        private readonly IUnitOfWork unitOfWork;

        public SuperheroService(
            IUnitOfWork unitOfWork,
            IRepository<Superhero> superheroes,
            IRepository<Planet> planets,
            IRepository<Country> countries,
            IRepository<City> cities,
            IRepository<Fraction> fractions,
            IRepository<Power> powers)
        {
            this.planetRepository = planets;
            this.countryRepository = countries;
            this.cityRepository = cities;
            this.fractionRepository = fractions;
            this.powerRepository = powers;
            this.superheroRepository = superheroes;

            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Planet> AddPlanets(IEnumerable<Planet> entities)
        {
            foreach (var entity in entities)
            {
                this.planetRepository.Add(entity);
            }

            this.unitOfWork.Commit();

            return this.planetRepository.Entities;
        }

        public IEnumerable<Power> AddPowers(IEnumerable<Power> entities)
        {
            foreach (var entity in entities)
            {
                this.powerRepository.Add(entity);
            }

            this.unitOfWork.Commit();

            return this.powerRepository.Entities;
        }

        public IEnumerable<Country> AddCountries(IEnumerable<Country> entities)
        {
            foreach (var entity in entities)
            {
                this.countryRepository.Add(entity);
            }

            this.unitOfWork.Commit();

            return this.countryRepository.Entities;
        }

        public IEnumerable<City> AddCities(IEnumerable<City> entities)
        {
            foreach (var entity in entities)
            {
                this.cityRepository.Add(entity);
            }

            this.unitOfWork.Commit();

            return this.cityRepository.Entities;
        }

        public IEnumerable<Fraction> AddFractions(IEnumerable<Fraction> entities)
        {
            foreach (var entity in entities)
            {
                this.fractionRepository.Add(entity);
            }

            this.unitOfWork.Commit();

            return this.fractionRepository.Entities;
        }

        public IEnumerable<Superhero> AddHeroes(IEnumerable<Superhero> entities)
        {
            foreach (var entity in entities)
            {
                this.superheroRepository.Add(entity);
            }

            this.unitOfWork.Commit();

            return this.superheroRepository.Entities;
        }

        public void LinkPlanetsWithFractions()
        {
            foreach (var hero in this.superheroRepository.Entities)
            {
                foreach (var heroFraction in hero.Fractions)
                {
                    if (!heroFraction.PlanetsThatProtects.Contains(hero.City.Country.Planet))
                    {
                        heroFraction.PlanetsThatProtects.Add(hero.City.Country.Planet);
                    }
                }
            }

            this.unitOfWork.Commit();
        }
    }
}
