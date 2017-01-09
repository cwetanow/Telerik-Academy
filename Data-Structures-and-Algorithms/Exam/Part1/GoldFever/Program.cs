using System;
using System.Collections.Generic;
using System.Linq;

namespace GoldFever
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var prices = Console.ReadLine()
                 .Split(' ')
                 .Select(long.Parse)
                 .ToArray();

            var profit = 0l;

            var max = 0l;

            for (var i = n - 1; i >= 0; i--)
            {
                var currentPrice = prices[i];
                if (max <= currentPrice)
                {
                    max = currentPrice;
                }

                profit += max - currentPrice;
            }

            Console.WriteLine(profit);
        }
    }
}
