using System.Collections.Generic;
using System.Linq;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        private readonly ICarFactory carFactory;
        private readonly IMotorcycleFactory motorcycleFactory;
        private readonly ITruckFactory truckFactory;

        public VehicleFactory(ICarFactory carFactory, IMotorcycleFactory motorcycleFactory, ITruckFactory truckFactory)
        {
            this.carFactory = carFactory;
            this.motorcycleFactory = motorcycleFactory;
            this.truckFactory = truckFactory;
        }

        public IVehicle CreateVehicle(VehicleType type, string make, string model, decimal price, string additionalParam)
        {
            if (type == VehicleType.Car)
            {
                var seats = int.Parse(additionalParam);
                return this.carFactory.CreateCar(make, model, price, seats);
            }

            if (type == VehicleType.Motorcycle)
            {
                var category = additionalParam;
                return this.motorcycleFactory.CreateMotorcycle(make, model, price, category);
            }

            var weightCapacity = int.Parse(additionalParam);
            return this.truckFactory.CreateTruck(make, model, price, weightCapacity);
        }
    }
}

