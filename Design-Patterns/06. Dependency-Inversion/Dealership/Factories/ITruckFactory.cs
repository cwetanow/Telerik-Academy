using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface ITruckFactory
    {
        ITruck CreateTruck(string make, string model, decimal price, int weightCapacity);
    }
}