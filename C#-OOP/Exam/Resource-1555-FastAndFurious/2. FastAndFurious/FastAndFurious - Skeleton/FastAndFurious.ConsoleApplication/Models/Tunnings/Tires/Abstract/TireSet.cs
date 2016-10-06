using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract
{
    public abstract class TiresSet : ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        public TiresSet() 
        {
        }

        public int Acceleration
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TunningGradeType GradeType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public decimal Price
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public TireType TireType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int TopSpeed
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Weight
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
