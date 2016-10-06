using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models
{
    class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(decimal height, string material, string model, decimal price, int numOfLegs) : base(height, material, model, price, numOfLegs)
        {
        }
    }
}
