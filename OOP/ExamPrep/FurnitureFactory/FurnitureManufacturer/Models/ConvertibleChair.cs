using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private readonly decimal initialHeight;

        public ConvertibleChair(decimal height, string material, string model, decimal price, int numOfLegs) : base(height, material, model, price, numOfLegs)
        {
            this.IsConverted = false;
            this.initialHeight = this.Height;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.isConverted = false;
                this.Height = this.initialHeight;
            }
            else
            {
                this.IsConverted = true;
                this.Height = 0.1m;
            }
        }
        public override string ToString()
        {
            return string.Format("{0}, State: {1}", base.ToString(), this.IsConverted ? "Converted" : "Normal");
        }
    }
}
