using System.IO;
using System.Reflection;
using Ninject;

namespace SuperheroesUniverse.XmlExporter
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var kernel = GetKernel();

            var exporter = kernel.Get<ISuperheroesUniverseExporter>();

            var allSuperheroes = exporter.ExportAllSuperheroes();
            File.WriteAllText("../../../../../03. Xml Files/allHeroes.xml", allSuperheroes);

            var heroesByCity = exporter.ExportSuperheroesByCity("Gotham");
            File.WriteAllText("../../../../../03. Xml Files/heroesByCity.xml", heroesByCity);

            var heroesWithPower = exporter.ExportSupperheroesWithPower("Utility belt");
            File.WriteAllText("../../../../../03. Xml Files/heroesWithPower.xml", heroesWithPower);

            var heroDetails = exporter.ExportSuperheroDetails(1);
            File.WriteAllText("../../../../../03. Xml Files/heroDetails.xml", heroDetails);

            var fractionDetails = exporter.ExportFractionDetails(1);
            File.WriteAllText("../../../../../03. Xml Files/fractionDetails.xml", fractionDetails);

            var allFractions = exporter.ExportFractions();
            File.WriteAllText("../../../../../03. Xml Files/allFractions.xml", allFractions);
        }

        private static IKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel;
        }
    }
}
