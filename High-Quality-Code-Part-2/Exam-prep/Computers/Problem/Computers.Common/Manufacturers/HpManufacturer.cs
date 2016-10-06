using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Contracts;
using Computers.Common.Models.Abstract;
using Computers.Common.Models.Batteries;
using Computers.Common.Models.Components;
using Computers.Common.Models.Computers;
using Computers.Common.Models.Cpus;
using Computers.Common.Models.HardDrives;
using Computers.Common.Models.VideoCards;

namespace Computers.Common.Manufacturers
{
    public class HpManufacturer : IComputerManufacturer
    {
        public Laptop CreateLaptop()
        {
            var laptop = new Laptop(
                new Ram(4),
                new Cpu64(2),
                new[] { new SingleHardDrive(500) },
                new ColorfulVideoCard(),
                new LaptopBattery());
            return laptop;
        }

        public PersonalComputer CreatePersonalComputer()
        {
            var pc = new PersonalComputer(
                new Ram(2),
                new Cpu32(2),
                new[] { new SingleHardDrive(500) },
                new ColorfulVideoCard());
            return pc;
        }

        public Server CreateServer()
        {
            var server = new Server(
                 new Ram(32),
                 new Cpu32(4),
                 new List<HardDrive> { new RaidArray(new List<HardDrive> { new SingleHardDrive(1000), new SingleHardDrive(1000) }) },
                 new MonochromeVideoCard());
            return server;
        }
    }
}
