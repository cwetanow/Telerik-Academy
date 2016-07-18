using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05
{
    public class InvalidRangeException<T> : ArgumentException
    {
        public InvalidRangeException(string msg)
            : base(msg)
        { }
        public InvalidRangeException(string msg,string start, string end)
            : base(msg)
        {
            Console.WriteLine("{0}, must be between {1}-{2}",msg,start,end);

        }
        public InvalidRangeException(): base()
        {

        }
        public InvalidRangeException(string msg,
    Exception innerEx)
            : base(msg, innerEx)
        { }
    }
}
