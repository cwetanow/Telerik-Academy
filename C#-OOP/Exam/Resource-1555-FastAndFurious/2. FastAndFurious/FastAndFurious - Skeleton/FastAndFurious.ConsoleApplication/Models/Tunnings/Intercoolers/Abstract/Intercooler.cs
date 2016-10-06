using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract
{
    public abstract class Intercooler : TunningPart, IIntercooler
    {
        public Intercooler(int weight, decimal price, int topSpeed, int acceleration, TunningGradeType type, IntercoolerType intercooler) 
            : base(weight, price, topSpeed, acceleration, type)
        {
            this.IntercoolerType = intercooler;
        }

        public IntercoolerType IntercoolerType
        {
            get; protected set;
        }
    }
}
