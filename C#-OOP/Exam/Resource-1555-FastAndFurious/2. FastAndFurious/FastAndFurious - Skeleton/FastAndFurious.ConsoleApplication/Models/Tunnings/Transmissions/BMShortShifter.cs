using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
   public class BMShortShifter:Transmission
    {
        private static int BMWeight =5700 ;
        private static decimal BMPrice = 2799;
        private static int BMTopSpeed = 0;
        private static int BMAccelerationBonus = 28;
        private static TunningGradeType BMType = TunningGradeType.HighGrade;
        private static TransmissionType BMTransmissionType = TransmissionType.ManualShortShifter;

        public BMShortShifter() 
            : base(BMWeight,BMPrice,BMTopSpeed,BMAccelerationBonus,BMType,BMTransmissionType)
        {
        }
    }
}
