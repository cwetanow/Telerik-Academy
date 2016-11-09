using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using SuperheroesUniverse.JsonImporter.Models;
using SuperheroesUniverse.Models;
using SuperheroesUniverse.Services;

namespace SuperheroesUniverse.JsonImporter
{
    public class JsonImporter
    {
        private readonly ISuperheroService service;

        public JsonImporter(ISuperheroService service)
        {
            this.service = service;
        }

        public void Import(string filePath)
        {
            var files = Directory.GetFiles(filePath)
                .Where(x => x.EndsWith(".json"));

            var root = new JsonRoot();

            foreach (var file in files)
            {
                var fileRoot = GetRoot(file);
                root.data.AddRange(fileRoot.data);
            }

            var planets = this.service.AddPlanets(this.GetPlanets(root));

            var countries = this.service.AddCountries(this.GetCountries(root, planets));

            var cities = this.service.AddCities(this.GetCities(root, countries));

            var fractions = this.service.AddFractions(this.GetFractions(root));

            var powers = this.service.AddPowers(this.GetPowers(root));

            this.service.AddHeroes(this.GetHeroes(root, cities, fractions, powers));

            this.service.LinkPlanetsWithFractions();
        }

        private IEnumerable<Superhero> GetHeroes(
            JsonRoot root,
            IEnumerable<City> cities,
            IEnumerable<Fraction> fractions,
            IEnumerable<Power> powers)
        {
            var heroes = new Collection<Superhero>();

            foreach (var jsonHero in root.data)
            {
                var hero = new Superhero
                {
                    Name = jsonHero.name,
                    CityId = cities.FirstOrDefault(c => c.Name.Equals(jsonHero.city.name)).CityId,
                    SecretIdentity = jsonHero.secretIdentity,
                    Story = jsonHero.story,
                    Alignment = (jsonHero.alignment == "good"
                        ? AlignmentType.Good
                        : jsonHero.alignment == "bad"
                            ? AlignmentType.Bad
                            : AlignmentType.Evil),


                };

                hero.Powers = powers
                    .Where(p => jsonHero.powers
                    .Contains(p.Name))
                    .ToList();

                if (jsonHero.fractions != null)
                {
                    hero.Fractions = fractions
                        .Where(f => jsonHero.fractions.Contains(f.Name)).ToList();
                }

                heroes.Add(hero);
            }

            return heroes
                .GroupBy(h => h.SecretIdentity)
                .Select(g => g.First());
        }

        private IEnumerable<Fraction> GetFractions(JsonRoot root)
        {
            var fractionNames = new Dictionary<string, AlignmentType>(StringComparer.OrdinalIgnoreCase);

            foreach (var jsonHero in root.data)
            {
                if (jsonHero.fractions != null)
                {
                    foreach (var jsonHeroFraction in jsonHero.fractions)
                    {
                        if (!fractionNames.ContainsKey(jsonHeroFraction))
                        {
                            fractionNames.Add(jsonHeroFraction,
                                jsonHero.alignment == "good" ? AlignmentType.Good :
                                jsonHero.alignment == "bad" ? AlignmentType.Bad
                                : AlignmentType.Evil);
                        }
                    }
                }
            }

            var fractions = fractionNames
                .Select(f => new Fraction
                {
                    Name = f.Key,
                    Alignment = f.Value
                });


            return fractions;
        }

        private JsonRoot GetRoot(string file)
        {
            var content = File.ReadAllText(file);
            var root = JsonConvert.DeserializeObject<JsonRoot>(content);

            return root;
        }

        private IEnumerable<City> GetCities(JsonRoot root, IEnumerable<Country> countries)
        {
            return root.data
                    .Select(x => new
                    {
                        x.city.country,
                        x.city.name
                    })
                    .GroupBy(x => x.name)
                    .Select(g => g.First())
                    .Select(x => new City
                    {
                        CountryId = countries.FirstOrDefault(c => c.Name.Equals(x.country)).CountryId,
                        Name = x.name
                    });
        }

        private IEnumerable<Country> GetCountries(JsonRoot root, IEnumerable<Planet> planets)
        {
            return root.data
                        .Select(x => new
                        {
                            x.city.country,
                            x.city.planet
                        })
                        .GroupBy(x => x.country)
                        .Select(g => g.First())
                        .Select(x => new Country
                        {
                            Name = x.country,
                            PlanetId = planets.FirstOrDefault(p => p.Name.Equals(x.planet)).PlanetId
                        });
        }

        private IEnumerable<Planet> GetPlanets(JsonRoot root)
        {
            return root.data
                    .Select(h => h.city.planet)
                    .Distinct()
                    .Select(p => new Planet
                    {
                        Name = p
                    });
        }

        private IEnumerable<Power> GetPowers(JsonRoot root)
        {
            return root.data
                .SelectMany(p => p.powers)
                .Distinct()
                .Select(p => new Power
                {
                    Name = p
                });
        }
    }
}
