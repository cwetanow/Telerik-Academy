using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Common.Contracts
{
    public interface IRam
    {
        int MaxAmount
        {
            get; set;
        }

        void SaveValue(int newValue);

        int LoadValue();
    }
}
