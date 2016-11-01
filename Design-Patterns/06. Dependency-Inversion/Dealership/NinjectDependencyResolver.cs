using Dealership.Contracts;
using Dealership.Core;
using Dealership.Engine;
using Ninject.Modules;

namespace Dealership
{
    public class NinjectDependencyResolver : NinjectModule
    {
        public override void Load()
        {
            Bind<IEngine>().To<DealershipEngine>();

            Bind<IWriter>().To<ConsoleInterface>();
            Bind<IReader>().To<ConsoleInterface>();
        }
    }
}
