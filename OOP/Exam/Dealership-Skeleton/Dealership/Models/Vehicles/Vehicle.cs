using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;

namespace Dealership.Models.Vehicles
{
    using Common;
    public abstract class Vehicle : IVehicle
    {
        
        private string make;
        private string model;
        private decimal price;
        private int wheels;

        public Vehicle(string make, string model, decimal price, int wheels)
        {
            this.Comments = new List<IComment>();
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Wheels = wheels;
        }

        public IList<IComment> Comments
        {
            get; set;
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            protected set
            {
                Validator.ValidateNull(value, Constants.VehicleCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinMakeLength, Constants.MaxMakeLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Make", Constants.MinMakeLength, Constants.MaxMakeLength));
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            protected set
            {
                Validator.ValidateNull(value, Constants.VehicleCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinModelLength, Constants.MaxModelLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax, "Model", Constants.MinModelLength, Constants.MaxModelLength));
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {

                Validator.ValidateDecimalRange(value, Constants.MinPrice, Constants.MaxPrice,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Price", Constants.MinPrice, Constants.MaxPrice));
                this.price = value;
            }
        }

        public VehicleType Type
        {
            get; protected set;
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
            protected set
            {

                Validator.ValidateIntRange(value, Constants.MinWheels, Constants.MaxWheels,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Wheels", Constants.MinWheels, Constants.MaxWheels));
                this.wheels = value;
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.GetType().Name + ":");
            builder.AppendLine(string.Format("  Make: {0}", this.Make));
            builder.AppendLine(string.Format("  Model: {0}", this.Model));
            builder.AppendLine(string.Format("  Wheels: {0}", this.Wheels));
            builder.Append(string.Format("  Price: ${0}", this.Price));
            return builder.ToString();
        }
    }
}
