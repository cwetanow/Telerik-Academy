using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
   public class ViperGenieIntercooler:Intercooler
    {
        private static int IntercoolerWeight = 5300;
        private static decimal IntercoolerPrice = 289;
        private static int IntercoolerTopSpeed = 25;
        private static int IntercoolerAccelerationBonus = 0;
        private static TunningGradeType IntercoolerTunningType = TunningGradeType.MidGrade;
        private static IntercoolerType IntercoolerCType = IntercoolerType.ChargeAirIntercooler;
        public ViperGenieIntercooler() 
            : base(IntercoolerWeight, IntercoolerPrice,IntercoolerTopSpeed,IntercoolerAccelerationBonus,IntercoolerTunningType,IntercoolerCType)
        {
        }
    }
}
