using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class RemusExhaust : Exhaust
    {
        private static int RemusWeight = 11500;
        private static decimal RemusPrice = 679;
        private static int RemusTopSpeed = 32;
        private static int RemusAccelerationBonus = 8;
        private static TunningGradeType RemusType = TunningGradeType.MidGrade;
        private static ExhaustType RemusExhaustType = ExhaustType.StainlessSteel;

        public RemusExhaust() : base(RemusWeight, RemusPrice, RemusTopSpeed, RemusAccelerationBonus, RemusType, RemusExhaustType)
        {
        }
    }
}
