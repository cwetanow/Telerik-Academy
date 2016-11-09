using Ninject.Modules;
using SuperheroesUniverse.Data;
using SuperheroesUniverse.Data.Repositories;
using SuperheroesUniverse.Services;

namespace SuperheroesUniverse.JsonImporter
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            this.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
            this.Bind<JsonImporter>().To<JsonImporter>();
            this.Bind<SuperheroeEntities>().To<SuperheroeEntities>().InSingletonScope();

            this.Bind<ISuperheroService>().To<SuperheroService>();
        }
    }
}
