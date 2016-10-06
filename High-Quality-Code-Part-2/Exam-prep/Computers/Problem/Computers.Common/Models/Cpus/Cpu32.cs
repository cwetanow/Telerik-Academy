using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Models.Abstract;
using Computers.Common.Utils;

namespace Computers.Common.Models.Cpus
{
    public class Cpu32 : Cpu
    {
        public Cpu32(byte numberOfCores)
            : base(numberOfCores)
        {
            this.MaxValue = GlobalConstants.Cpu32BitMaxValue;
        }
    }
}
