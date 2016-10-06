using System.Collections.Generic;
using Computers.Common.Models.Abstract;

namespace Computers.Common.Models.HardDrives
{
    public class SingleHardDrive : HardDrive
    {
        private int capacity;

        private Dictionary<int, string> data;

        public SingleHardDrive(int capacity)
        {
            this.capacity = capacity;
            this.data = new Dictionary<int, string>();
        }

        public override int Capacity
        {
            get
            {
                return this.capacity;
            }
        }

        public override void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public override string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
