using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private decimal height;
        private string model;
        private decimal price;

        public Furniture(decimal height, string material, string model, decimal price)
        {
            this.Height = height;
            this.Material = char.ToUpper(material[0]) + material.Substring(1); ;

            this.Model = model;
            this.Price = price;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.height = value;
            }
        }

        public string Material
        {
            get; private set;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if (value.Length < 3 || value == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return string.Format(
            "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4:F2}, ",
            this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
