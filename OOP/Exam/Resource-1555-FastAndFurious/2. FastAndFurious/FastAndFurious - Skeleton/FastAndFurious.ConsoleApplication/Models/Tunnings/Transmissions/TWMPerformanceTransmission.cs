using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Transmissions
{
    class TWMPerformanceTransmission : Transmission
    {
        private static int TWMWeight = 4799;
        private static decimal TWMPrice = 1599;
        private static int TWMTopSpeed = 0;
        private static int TWMAccelerationBonus = 15;
        private static TunningGradeType TWMType = TunningGradeType.LowGrade;
        private static TransmissionType TWMTransmissionType;
        public TWMPerformanceTransmission()
            : base(TWMWeight, TWMPrice, TWMTopSpeed, TWMAccelerationBonus, TWMType, TWMTransmissionType)
        {
        }
    }
}
