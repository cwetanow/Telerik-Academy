using SuperheroesUniverse.Data;

namespace SuperheroesUniverse.ConsoleInterface
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var context = new SuperheroeEntities();
            context.Database.CreateIfNotExists();
        }
    }
}
