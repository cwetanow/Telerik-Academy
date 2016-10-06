using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Abstract
{
    public abstract class HardDrive : IHardDrive
    {
        public abstract int Capacity { get; }

        public abstract void SaveData(int address, string newData);

        public abstract string LoadData(int address);
    }
}
