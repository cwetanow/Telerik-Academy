using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract
{
    public abstract class Turbocharger : TunningPart, ITurbocharger
    {
        public Turbocharger(int weight, decimal price, int topSpeed, int acceleration, TunningGradeType type, TurbochargerType turboType)
            : base(weight, price, topSpeed, acceleration, type)
        {
            this.TurbochargerType = turboType;
        }

        public TurbochargerType TurbochargerType
        {
            get; protected set;
        }


    }
}
