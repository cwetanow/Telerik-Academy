using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems.Abstract;


namespace FastAndFurious.ConsoleApplication.Models.Tunnings.ExhaustSystems
{
    public class MagnaFlowExhaust : Exhaust
    {
        private static int MagnaFlowWeight = 12800;
        private static decimal MagnaFlowPrice = 379;
        private static int MagnaFlowTopSpeed = 25;
        private static int MagnaFlowAccelerationBonus = 5;
        private static TunningGradeType MagnaFlowType = TunningGradeType.LowGrade;
        private static ExhaustType MagnaFlowExhaustType = ExhaustType.NickelChromePlated;

        public MagnaFlowExhaust() 
            : base(MagnaFlowWeight, MagnaFlowPrice, MagnaFlowTopSpeed, MagnaFlowAccelerationBonus, MagnaFlowType, MagnaFlowExhaustType)
        {
        }
    }
}
