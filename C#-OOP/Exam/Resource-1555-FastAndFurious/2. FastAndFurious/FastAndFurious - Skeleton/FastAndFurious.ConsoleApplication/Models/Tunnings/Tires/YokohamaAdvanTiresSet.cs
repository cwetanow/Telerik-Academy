using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires
{
    public class YokohamaAdvanTiresSet : TiresSet, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        private const int YokohamaAdvanTireWeightInGrams = 6600;
        private const int YokohamaAdvanTireAccelerationBonus = 5;
        private const int YokohamaAdvanTireTopSpeedBonus = 1;
        private const decimal YokohamaAdvanTirePriceInUSADollars = 589;

        public YokohamaAdvanTiresSet()
        {
        }
    }
}
