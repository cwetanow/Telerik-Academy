using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    public class Chair: Furniture, IChair
    {
        private decimal height;
        private string material;
        private string model;
        private decimal price;
        private int numLegs;
        

        public Chair(decimal height, string material, string model, decimal price, int numOfLegs) : base(height, material, model, price)
        {
            this.NumberOfLegs = numOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numLegs;
            }
            private set
            {
                
                this.numLegs = value;
            }
        }

        public void SetHeight(decimal height)
        {
            this.Height = height;
        }
        public override string ToString()
        {
            return string.Format("{0}Legs: {1}", base.ToString(), this.NumberOfLegs);
        }
    }
}
