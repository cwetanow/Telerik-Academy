using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Models.Abstract;

namespace Computers.Common.Models.HardDrives
{
    public class RaidArray : HardDrive
    {
        private IEnumerable<HardDrive> drives;

        public RaidArray(IEnumerable<HardDrive> drives)
        {
            this.drives = drives;
        }

        public override int Capacity
        {
            get
            {
                return this.drives.Any() ? this.drives.First().Capacity : 0;
            }
        }

        public override void SaveData(int address, string newData)
        {
            foreach (var drive in this.drives)
            {
                drive.SaveData(address, newData);
            }
        }

        public override string LoadData(int address)
        {
            if (!this.drives.Any())
            {
                throw new OutOfMemoryException();
            }

            return this.drives.First()
                .LoadData(address);
        }
    }
}
