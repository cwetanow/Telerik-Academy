using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3.Compare_advanced_maths.Operations;

namespace Task_3.Compare_advanced_maths
{
    class Startup
    {
        static void Main(string[] args)
        {
            Sqrt.DisplayAll();
            Console.WriteLine("----------------------------");

            //Logarithm throws StackOverflowException
            // Logarithm.DisplayAll();
            Console.WriteLine("----------------------------");

            Sinus.DisplayAll();
            Console.WriteLine("----------------------------");
        }
    }
}
