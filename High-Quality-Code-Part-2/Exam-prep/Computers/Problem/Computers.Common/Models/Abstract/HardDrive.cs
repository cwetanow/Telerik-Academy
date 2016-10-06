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
