using System.Reflection;
using Ninject;

namespace SuperheroesUniverse.JsonImporter
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var kernel = GetKernel();
            var importer = kernel.Get<JsonImporter>();

            // Hardcoded path
            var path = "../../../../../02. Json-Data";
            importer.Import(path);
        }

        private static IKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel;
        }
    }
}
