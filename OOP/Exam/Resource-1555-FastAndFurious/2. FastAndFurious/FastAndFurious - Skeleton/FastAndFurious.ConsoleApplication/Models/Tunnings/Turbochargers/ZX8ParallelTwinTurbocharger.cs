using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    public class ZX8ParallelTwinTurbocharger : Turbocharger
    {
        private static int ZXWeight = 3900;
        private static decimal ZXPrice = 669;
        private static int ZXTopSpeed = 85;
        private static int ZXAccelerationBonus = 10;
        private static TunningGradeType ZXType = TunningGradeType.HighGrade;
        private static TurbochargerType ZXTurbochargerType = TurbochargerType.SequentialTurbo;
        public ZX8ParallelTwinTurbocharger()
            : base(ZXWeight, ZXPrice, ZXTopSpeed, ZXAccelerationBonus, ZXType, ZXTurbochargerType)
        {
        }
    }
}
