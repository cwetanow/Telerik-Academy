using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface IVehicleFactory
    {
        IVehicle CreateVehicle(VehicleType type, string make, string model, decimal price, string additionalParam);
    }
}
