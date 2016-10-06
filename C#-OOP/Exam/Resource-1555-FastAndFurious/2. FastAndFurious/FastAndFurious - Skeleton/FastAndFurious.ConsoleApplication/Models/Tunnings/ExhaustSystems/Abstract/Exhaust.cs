using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract
{
    public abstract class Exhaust : TunningPart, IExhaust
    {
        private readonly ExhaustType exhaustType;

        public Exhaust(int weight, decimal price, int topSpeed, int acceleration, TunningGradeType type, ExhaustType exhaustType)
            : base(weight, price, topSpeed, acceleration, type)
        {
            this.exhaustType = exhaustType;
        }


        public ExhaustType ExhaustType
        {
            get
            {
                return this.exhaustType;
            }
        }


    }
}
