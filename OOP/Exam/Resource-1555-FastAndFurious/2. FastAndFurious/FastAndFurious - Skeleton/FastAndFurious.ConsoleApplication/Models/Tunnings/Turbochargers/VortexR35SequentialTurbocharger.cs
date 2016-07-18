using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    class VortexR35SequentialTurbocharger : Turbocharger
    {
        private static int VortexWeight = 3900;
        private static decimal VortexPrice = 669;
        private static int VortexTopSpeed = 85;
        private static int VortexAccelerationBonus = 10;
        private static TunningGradeType VortexType = TunningGradeType.HighGrade;
        private static TurbochargerType VortexTurbochargerType = TurbochargerType.SequentialTurbo;
        public VortexR35SequentialTurbocharger()
            : base(VortexWeight, VortexPrice, VortexTopSpeed, VortexAccelerationBonus, VortexType, VortexTurbochargerType)
        {
        }
    }
}
