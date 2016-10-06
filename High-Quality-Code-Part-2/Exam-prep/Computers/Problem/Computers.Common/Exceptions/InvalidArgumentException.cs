using System;

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
