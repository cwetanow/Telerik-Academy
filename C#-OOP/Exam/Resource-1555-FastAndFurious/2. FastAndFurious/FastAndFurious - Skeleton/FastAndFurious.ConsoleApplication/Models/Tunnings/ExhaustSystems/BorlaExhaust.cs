using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastAndFurious.ConsoleApplication.Common.Enums;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    
    public class BorlaExhaust : Exhaust
    {
        private static int BorlaWeight = 14600;
        private static decimal BorlaPrice = 1299;
        private static int BorlaTopSpeed = 40;
        private static int BorlaAccelerationBonus = 12;
        private static TunningGradeType BorlaType = TunningGradeType.HighGrade;
        private static ExhaustType BorlaExhaustType = ExhaustType.CeramicCoated;

        public BorlaExhaust() : base(BorlaWeight,BorlaPrice,BorlaTopSpeed,BorlaAccelerationBonus,BorlaType,BorlaExhaustType)
        {
        }
    }
}
