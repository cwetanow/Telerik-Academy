using System;
using System.Collections.Generic;
using System.Linq;

namespace OddNumber
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var res = 0l;

            for (int i = 0; i < n; i++)
            {
                res = res ^ long.Parse(Console.ReadLine());
            }

            Console.WriteLine(res);
        }

    }
}