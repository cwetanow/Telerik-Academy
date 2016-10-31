using System.Data.Entity;
using SocialNetwork.ConsoleClient.Searcher;
using SocialNetwork.Data;
using SocialNetwork.Data.Migrations;

namespace SocialNetwork.ConsoleClient
{
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SocialNetworkEntities, Configuration>());

            var dbContext = new SocialNetworkEntities();
            dbContext.Database.CreateIfNotExists();

            var importer = new XmlImporter(dbContext);
            importer.Import();

            var service = new SocialNetworkService(dbContext);

            DataSearcher.Search(service);
        }
    }
}
