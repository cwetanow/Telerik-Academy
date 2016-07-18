using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Motors.Abstract
{
    public abstract class Motor : IMotor, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        public Motor(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            int horsepower,
            TunningGradeType gradeType,
            CylinderType cylinderType,
            MotorType engineType)
        {
        }

        public int Id
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

        public int Acceleration
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

        public decimal Price
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int Horsepower
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MotorType EngineType
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CylinderType CylinderType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
