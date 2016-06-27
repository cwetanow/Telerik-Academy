using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Three_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            
            int max=Math.Max(a,b);
            max=Math.Max(max,c);
            int min=Math.Min(a,b);
            min=Math.Min(min,c);
            double arithmetic = (a + b + c) /3.0;

            Console.WriteLine("{0}",max);
            Console.WriteLine("{0}",min);
            Console.WriteLine("{0:F2}",arithmetic);
        }
    }
}
