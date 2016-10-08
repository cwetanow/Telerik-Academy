using System.Collections.Generic;
using Computers.Common.Contracts;
using Computers.Common.Models.Abstract;
using Computers.Common.Utils;

namespace Computers.Common.Models.Computers
{
    public class Laptop : Computer
    {
        public Laptop(IRam ram, ICpu cpu, IEnumerable<IHardDrive> drives, IVideoCard videoCard, IBattery battery)
            : base(ram, cpu, drives, videoCard)
        {
            this.Battery = battery;
        }

        public IBattery Battery { get; protected set; }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);

            this.VideoCard.Draw(string.Format(GlobalConstants.BatteryStatusStringFormat, this.Battery.PercentagePowerLeft));
        }
    }
}
