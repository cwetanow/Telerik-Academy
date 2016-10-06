using Dealership.Contracts;
using System;
using Dealership.Models;
using Dealership.Common.Enums;
using Dealership.Models.Vehicles;

namespace Dealership.Factories
{
    public class DealershipFactory : IDealershipFactory
    {
        public IVehicle CreateCar(string make, string model, decimal price, int seats)
        {
            IVehicle car = new Car(make, model, price, seats);
            return car;
        }

        public IVehicle CreateMotorcycle(string make, string model, decimal price, string category)
        {
            IVehicle moto = new Motorcycle(make, model, price, category);
            return moto;
        }

        public IVehicle CreateTruck(string make, string model, decimal price, int weightCapacity)
        {       
            IVehicle truck = new Truck(make, model, price, weightCapacity);
            return truck;
        }

        public IUser CreateUser(string username, string firstName, string lastName, string password, string role)
        {          
            var userrole = new Role();
            Enum.TryParse(role, out userrole);
            IUser user = new User(firstName, lastName, password, username, userrole);
            return user;
        }

        public IComment CreateComment(string content)
        {
            IComment comment = new Comment(content);
            return comment;
        }
    }
}
