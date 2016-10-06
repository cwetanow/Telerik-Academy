using System.Collections.Generic;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Abstract
{
    public abstract class Computer
    {
        private IMotherboard motherboard;

        internal Computer(IRam ram, ICpu cpu, IEnumerable<IHardDrive> drives, IVideoCard videoCard)
        {
            this.Ram = ram;
            this.Cpu = cpu;
            this.Drives = drives;
            this.VideoCard = videoCard;

            this.motherboard = new Motherboard(ram, cpu, videoCard);
        }

        public IVideoCard VideoCard { get; set; }

        public IEnumerable<IHardDrive> Drives { get; set; }

        public ICpu Cpu { get; set; }

        public IRam Ram { get; set; }
    }
}
