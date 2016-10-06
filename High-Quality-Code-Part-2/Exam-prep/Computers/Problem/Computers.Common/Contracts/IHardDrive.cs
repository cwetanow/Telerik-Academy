using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Common.Contracts
{
    public interface IHardDrive
    {
        int Capacity { get; }

        void SaveData(int address, string newData);

        string LoadData(int address);
    }
}
