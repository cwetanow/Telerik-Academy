using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class EvolutionXPerformanceIntercooler : Intercooler
    {
        private static int IntercoolerWeight = 4500;
        private static decimal IntercoolerPrice = 499;
        private static int IntercoolerTopSpeed = 40;
        private static int IntercoolerAccelerationBonus = -5;
        private static TunningGradeType IntercoolerTunningType = TunningGradeType.HighGrade;
        private static IntercoolerType IntercoolerCType = IntercoolerType.AirToLiquidIntercooler;
        public EvolutionXPerformanceIntercooler() 
            : base(IntercoolerWeight, IntercoolerPrice,IntercoolerTopSpeed,IntercoolerAccelerationBonus,IntercoolerTunningType,IntercoolerCType)
        {
        }
    }
}
