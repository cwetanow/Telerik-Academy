using Dealership.Contracts;

namespace Dealership.Factories
{
    public interface ICarFactory
    {
        ICar CreateCar(string make, string model, decimal price, int seats);
    }
}
