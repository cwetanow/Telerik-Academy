using FastAndFurious.ConsoleApplication.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract
{
    public abstract class TunningPart : ITunningPart
    {

        private int id;

        public TunningPart(int weight, decimal price, int topSpeed, int acceleration, TunningGradeType type)
        {
            this.id = DataGenerator.GenerateId();
            this.Weight = weight;
            this.Price = price;
            this.TopSpeed = topSpeed;
            this.Acceleration = acceleration;
            this.GradeType = type;
        }
        public int Acceleration
        {
            get; protected set;
        }

        public TunningGradeType GradeType
        {
            get; protected set;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public decimal Price
        {
            get; protected set;
        }

        public int TopSpeed
        {
            get; protected set;
        }

        public int Weight
        {
            get; protected set;
        }
    }
}
