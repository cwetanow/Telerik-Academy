using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Common.Utils
{
    public static class GlobalConstants
    {
        public const string NumberTooHighMessage = "Number too high.";
        public const string NumberTooLowMessage = "Number too low.";

        public const int Cpu32BitMaxValue = 500;
        public const int Cpu64BitMaxValue = 1000;
        public const int Cpu128BitMaxValue = 2000;

        public const int LaptopBatteryInitialCharge = 50;
        public const int MaxLaptopBatteryCharge = 100;
        public const int MinLaptopBatteryCharge = 0;

        public const string WrongNumberStringFormat = "You didn't guess the number {0}.";
        public const string WinMessage = "You win!";

        public const string BatteryStatusStringFormat = "Battery status: {0}%";
    }
}
