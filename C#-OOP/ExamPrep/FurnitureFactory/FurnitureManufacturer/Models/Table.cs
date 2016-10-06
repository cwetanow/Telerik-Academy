using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;

        public Table(decimal height, string material, string model, decimal price, decimal length, decimal width) : base(height, material, model, price)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                if (value<=0.00m)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0.00m)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Width * this.Length;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}Length: {1}, Width: {2}, Area: {3}", base.ToString(), this.Length, this.Width, this.Area);
        }
    }
}
