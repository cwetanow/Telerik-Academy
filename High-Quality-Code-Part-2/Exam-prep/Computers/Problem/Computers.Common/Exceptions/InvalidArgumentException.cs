using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers.Common.Exceptions
{
    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException(string message) 
            : base(message)
        {
            
        }
    }
}
