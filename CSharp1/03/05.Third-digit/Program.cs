using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Third_digit
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            //N = N / 100;
            if ((N / 100) % 10 == 7)
            {
                Console.WriteLine("true");
            }
            else {
                Console.WriteLine("false " + (N / 100) % 10);
            }
        }
    }
}
