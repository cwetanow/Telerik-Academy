using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _1.Mutant_squirrels
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            int t = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            double allTails = t * b;
            allTails *= s;
            allTails *= n;
            
            if (allTails%2==0)
            {

                allTails *= 376439;
                Console.WriteLine("{0:F3}", allTails);
            }
            else if (allTails%2==1)
            {

                allTails /= 7;
               Console.WriteLine("{0:F3}", allTails);
            }

        }
    }
}
