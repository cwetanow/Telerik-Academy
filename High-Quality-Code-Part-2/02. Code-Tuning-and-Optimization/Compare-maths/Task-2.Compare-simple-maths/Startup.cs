using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task_2.Compare_simple_maths.Operations;
using Task_2.Compare_simple_maths.Operations.Task_2.Compare_simple_maths;

namespace Task_2.Compare_simple_maths
{
    class Startup
    {
        static void Main(string[] args)
        {
            Add.DisplayAll();
            Console.WriteLine("----------------------------");

            Subtract.DisplayAll();
            Console.WriteLine("----------------------------");

            Increment.DisplayAll();
            Console.WriteLine("----------------------------");

            Multiply.DisplayAll();
            Console.WriteLine("----------------------------");

            Divide.DisplayAll();
        }
    }
}
