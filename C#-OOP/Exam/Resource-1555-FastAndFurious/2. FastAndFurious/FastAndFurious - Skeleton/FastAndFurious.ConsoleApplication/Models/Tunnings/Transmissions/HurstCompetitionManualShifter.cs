using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Abstract;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    class HurstCompetitionManualShifter : Transmission
    {
        private static int HurstWeight = 6000;
        private static decimal HurstPrice = 1900;
        private static int HurstTopSpeed = 0;
        private static int HurstAccelerationBonus = 20;
        private static TunningGradeType HurstType = TunningGradeType.MidGrade;
        private static TransmissionType HurstTransmissionType = TransmissionType.StockShifter;

        public HurstCompetitionManualShifter()
            : base(HurstWeight, HurstPrice, HurstTopSpeed, HurstAccelerationBonus, HurstType, HurstTransmissionType)
        {
        }
    }
}
