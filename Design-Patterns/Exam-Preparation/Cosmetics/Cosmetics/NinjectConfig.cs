using Cosmetics.Contracts;
using Cosmetics.Core;
using Cosmetics.Engine;
using Cosmetics.Products;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Cosmetics
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            //Kernel.Bind(x =>
            //{
            //    x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
            //    .SelectAllClasses()
            //    .BindDefaultInterface();
            //});

            this.Bind<ICategory>().To<Category>();
            this.Bind<IToothpaste>().To<Toothpaste>();
            this.Bind<IShampoo>().To<Shampoo>();

            this.Bind<ICommand>().To<Command>();

            this.Bind<ICommandFactory>().ToFactory().InSingletonScope();
            this.Bind<ICosmeticsFactory>().ToFactory().InSingletonScope();

            this.Bind<IShoppingCart>().To<ShoppingCart>();
            this.Bind<ICommandParser>().To<ConsoleCommandParser>();

            this.Bind<IWriter>().To<ConsoleReaderWriter>();
            this.Bind<IReader>().To<ConsoleReaderWriter>();

            this.Bind<IEngine>().To<CosmeticsEngine>().InSingletonScope();
        }
    }
}
