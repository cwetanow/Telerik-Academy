using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates
{
    class Startup
    {
        static void Main(string[] args)
        {
            var currentMoney = double.Parse(Console.ReadLine());

            var n = int.Parse(Console.ReadLine());

            var list = new List<List<double>>(n);
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(double.Parse).ToList();
                list.Add(new List<double>());
                list[i].AddRange(input); 
            }

            var result = currentMoney;
            var isFirstCurrency = true;

            foreach (var day in list)
            {
                var c1c2 = day[0];
                var c2c1 = day[1];

                if (isFirstCurrency)
                {
                    var inOtherCurrency = result * c1c2;
                    var turnedBack = inOtherCurrency * c2c1;
                    if (turnedBack > result)
                    {
                        result = inOtherCurrency;
                        isFirstCurrency = !isFirstCurrency;
                    }
                }
                else
                {
                    var inOtherCurrency = result * c2c1;
                    var turnedBack = inOtherCurrency * c1c2;
                    if (turnedBack > result)
                    {
                        result = inOtherCurrency;
                        isFirstCurrency = !isFirstCurrency;
                    }
                }
            }

            if (!isFirstCurrency)
            {
                result *= list[list.Count - 1][1];
            }

            Console.WriteLine("{0:F2}", result);
        }
    }
}
