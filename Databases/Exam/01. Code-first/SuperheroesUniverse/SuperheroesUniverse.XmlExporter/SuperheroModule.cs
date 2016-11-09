using Ninject.Modules;
using SuperheroesUniverse.Data.Repositories;

namespace SuperheroesUniverse.XmlExporter
{
    public class SuperheroModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISuperheroesUniverseExporter>().To<XmlSuperheroesUniverseExporter>();
            this.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
        }
    }
}
