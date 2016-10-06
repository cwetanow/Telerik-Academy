using Computers.Common.Contracts;
using Computers.Common.Utils;

namespace Computers.Common.Models.Batteries
{
    public class LaptopBattery : IBattery
    {
        public LaptopBattery()
        {
            this.PercentagePowerLeft = GlobalConstants.LaptopBatteryInitialCharge;
        }

        public int PercentagePowerLeft { get; protected set; }

        public void Charge(int percentage)
        {
            this.PercentagePowerLeft += percentage;

            if (this.PercentagePowerLeft > GlobalConstants.MaxLaptopBatteryCharge)
            {
                this.PercentagePowerLeft = GlobalConstants.MaxLaptopBatteryCharge;
            }
            else if (this.PercentagePowerLeft < GlobalConstants.MinLaptopBatteryCharge)
            {
                this.PercentagePowerLeft = GlobalConstants.MinLaptopBatteryCharge;
            }
        }
    }
}
