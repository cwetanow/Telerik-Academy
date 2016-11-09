using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using SuperheroesUniverse.Data.Repositories;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.XmlExporter
{
    public class XmlSuperheroesUniverseExporter : ISuperheroesUniverseExporter
    {
        private const string XmlFormatting = "<?xml version=\"1.0\" encoding=\"UTF-8\"?> \n";

        private readonly IRepository<Superhero> superheroes;
        private readonly IRepository<Fraction> fractions;

        public XmlSuperheroesUniverseExporter(IRepository<Superhero> repository, IRepository<Fraction> fractionsRepository)
        {
            this.superheroes = repository;
            this.fractions = fractionsRepository;
        }

        private string GetSuperheroes(IEnumerable<Superhero> superheros, bool cityOnTop = false)
        {
            var heroes = new List<XElement>();
            foreach (var superhero in superheros)
            {
                var powers = new Collection<XElement>();
                foreach (var power in superhero.Powers)
                {
                    var powerElement = new XElement("power", power.Name);
                    powers.Add(powerElement);
                }

                var powersElement = new XElement("powers", powers);

                var heroElement = new XElement("superhero",
                new XAttribute("id", superhero.SuperheroId),
                    new XElement("name", superhero.Name),
                    new XElement("secretIdentity", superhero.SecretIdentity),
                    new XElement("alignment", superhero.Alignment.ToString().ToLower()),
                    cityOnTop ? (new XElement("city",
                        $"{superhero.City.Name}, {superhero.City.Country.Name}, {superhero.City.Country.Planet.Name}"))
                        : powersElement,

                    cityOnTop ? powersElement :
                    new XElement("city",
                        $"{superhero.City.Name}, {superhero.City.Country.Name}, {superhero.City.Country.Planet.Name}")
                    );

                heroes.Add(heroElement);
            }

            var rootElement = new XElement("superheroes", heroes);

            return XmlFormatting + rootElement;
        }

        public string ExportAllSuperheroes()
        {
            return this.GetSuperheroes(this.superheroes.Entities);
        }

        public string ExportSupperheroesWithPower(string power)
        {
            var superheroesWithPower = this.superheroes.Entities
                .Where(s =>
                s.Powers.Select(p => p.Name).Contains(power));

            return this.GetSuperheroes(superheroesWithPower);
        }

        public string ExportSuperheroDetails(object superheroId)
        {
            var superhero = this.superheroes.GetById(superheroId);

            var powers = new Collection<XElement>();
            foreach (var power in superhero.Powers)
            {
                var powerElement = new XElement("power", power.Name);
                powers.Add(powerElement);
            }

            var powersElement = new XElement("powers", powers);

            var fractions = new Collection<XElement>();
            foreach (var fraction in superhero.Fractions)
            {
                var fractionElement = new XElement("fraction", fraction.Name);
                fractions.Add(fractionElement);
            }

            var fractionsElement = new XElement("fractions", fractions);

            var heroElement = new XElement("superhero",
                new XAttribute("id", superhero.SuperheroId),
                new XElement("name", superhero.Name),
                new XElement("secretIdentity", superhero.SecretIdentity),
                new XElement("alignment", superhero.Alignment.ToString().ToLower()),
                powersElement,
                fractionsElement,
                new XElement("city",
                    $"{superhero.City.Name}, {superhero.City.Country.Name}, {superhero.City.Country.Planet.Name}"),
                new XElement("story", superhero.Story)
                );

            return XmlFormatting + heroElement;
        }

        public string ExportFractions()
        {
            var fractions = new List<XElement>();

            foreach (var fraction in this.fractions.Entities)
            {
                var planets = fraction.PlanetsThatProtects
                   .Select(planet => new XElement("planet", planet.Name))
                   .ToList();

                var planetsElement = new XElement("planets", planets);

                fractions.Add(new XElement("fraction",
             new XAttribute("id", fraction.FractionId),
             new XAttribute("membersCount", fraction.Superheroes.Count),
             new XElement("name", fraction.Name),
             planetsElement));
            }

            var root = new XElement("fractions", fractions);

            return XmlFormatting + root;
        }

        public string ExportFractionDetails(object fractionId)
        {
            var fraction = this.fractions.GetById(fractionId);

            var planets = fraction.PlanetsThatProtects
                .Select(planet => new XElement("planet", planet.Name))
                .ToList();

            var planetsElement = new XElement("planets", planets);

            var members = fraction.Superheroes
                .Select(member => new XElement("member",
                new XAttribute("id", member.SuperheroId),
                member.Name))
                .ToList();

            var membersElement = new XElement("members", members);

            var root = new XElement("fraction",
                new XAttribute("id", fraction.FractionId),
                new XAttribute("membersCount", fraction.Superheroes.Count),
                new XElement("name", fraction.Name),
                planetsElement,
                membersElement);

            return XmlFormatting + root;
        }

        public string ExportSuperheroesByCity(string cityName)
        {
            var heroesFromCity = this.superheroes.Entities
                .Where(s => s.City.Name.Equals(cityName));

            return this.GetSuperheroes(heroesFromCity, true);
        }
    }
}
