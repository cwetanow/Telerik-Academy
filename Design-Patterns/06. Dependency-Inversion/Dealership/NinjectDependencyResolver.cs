using Dealership.Contracts;
using Dealership.Core;
using Dealership.Engine;
using Dealership.Factories;
using Dealership.Models;
using Ninject.Extensions.Factory;
using Ninject.Modules;

namespace Dealership
{
    public class NinjectDependencyResolver : NinjectModule
    {
        private const string CarName = "Car";
        private const string MotorcycleName = "Motorcycle";
        private const string TruckName = "Truck";


        public override void Load()
        {
            Bind<IInputOutputProvider>().To<ConsoleInputOutputProvider>();

            Bind<ICommand>().To<Command>();
            Bind<IComment>().To<Comment>();
            Bind<IUser>().To<User>();

            Bind<ICommandFactory>().ToFactory().InSingletonScope();
            Bind<ICommentFactory>().ToFactory().InSingletonScope();
            Bind<IUserFactory>().ToFactory().InSingletonScope();

            Bind<ICar>().To<Car>();
            Bind<ITruck>().To<Truck>();
            Bind<IMotorcycle>().To<Motorcycle>();

            Bind<ITruckFactory>().ToFactory().InSingletonScope();
            Bind<ICarFactory>().ToFactory().InSingletonScope();
            Bind<IMotorcycleFactory>().ToFactory().InSingletonScope();

            Bind<IVehicleFactory>().To<VehicleFactory>();

            Bind<IEngine>().To<DealershipEngine>();
        }
    }
}
