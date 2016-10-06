using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Flights
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            string input;

            var f=new StringBuilder();

            do
            {
                input = Console.ReadLine();
                if (input == "-1 -1")
                {
                    break;
                }
                else
                {
                    f.Append(Console.ReadLine()+" / ");
                }
            } while (true);
            var allFlights=new int[n,n];
            var safe = 0;
           
            Console.WriteLine(safe);
        }
    }
}
