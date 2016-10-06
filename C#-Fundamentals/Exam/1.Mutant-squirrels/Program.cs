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
            int trees = int.Parse(Console.ReadLine());
            int branches = int.Parse(Console.ReadLine());
            int squirrel = int.Parse(Console.ReadLine());
            int averageTails = int.Parse(Console.ReadLine());

            double allTails = trees;
            allTails *= branches;
            allTails *= squirrel;
            allTails *= averageTails;

            if (allTails % 2 == 0)
            {
                allTails *= 376439;
                Console.WriteLine("{0:F3}", allTails);
            }
            else if (allTails % 2 == 1)
            {
                allTails /= 7;
                Console.WriteLine("{0:F3}", allTails);
            }

        }
    }
}
