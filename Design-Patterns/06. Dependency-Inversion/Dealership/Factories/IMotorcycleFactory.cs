using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface IMotorcycleFactory
    {
        IMotorcycle CreateMotorcycle(string make, string model, decimal price, string category);
    }
}