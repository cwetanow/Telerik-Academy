using Computers.Common.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Utils;

namespace Computers.Common.Models.Cpus
{
    public class Cpu128 : Cpu
    {
        public Cpu128(byte numberOfCores)
            : base(numberOfCores)
        {
            this.MaxValue = GlobalConstants.Cpu32BitMaxValue;
        }
    }
}
