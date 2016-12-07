using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeRates
{
    class Startup
    {
        private static decimal max;

        static void Main(string[] args)
        {
            var currentMoney = decimal.Parse(Console.ReadLine());

            var n = int.Parse(Console.ReadLine());

            var list = new List<List<decimal>>(n);
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();
                list.Add(new List<decimal>());
                list[i].AddRange(input);
            }

            var result = currentMoney;
            var isFirstCurrency = true;
            max = currentMoney;

            for (var i = 0; i < list.Count; i++)
            {
                var c1c2 = list[i][0];
                var c2c1 = list[i][1];

                if (isFirstCurrency && i < list.Count - 1)
                {
                    var inOtherCurrency = result * c1c2;
                    var turnedBack = inOtherCurrency * c2c1;
                    if (turnedBack > result)
                    {
                        result = inOtherCurrency;
                        if (turnedBack > max)
                        {
                            max = turnedBack;
                        }
                        isFirstCurrency = false;
                    }
                }
                else if (!isFirstCurrency)
                {
                    var inOtherCurrency = result * c2c1;

                    if (inOtherCurrency > max)
                    {
                        max = inOtherCurrency;
                        result = inOtherCurrency;
                        isFirstCurrency = true;
                    }
                }
            }

            Console.WriteLine("{0:F2}", max);
        }
    }
}
