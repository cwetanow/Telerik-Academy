using SocialNetwork.Data;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            var dbContext = new SocialNetworkEntities();
            dbContext.Database.CreateIfNotExists();

            var importer = new XmlImporter(dbContext);

            importer.Import();
        }
    }
}
