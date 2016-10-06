using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Speeds
{
    class Program
    {
        static void Main(string[] args)
        {
            var carsCount = int.Parse(Console.ReadLine());
            var speeds = new int[carsCount];

            for (var i = 0; i < carsCount; i++)
            {
                speeds[i] = int.Parse(Console.ReadLine());
            }

            var maxGroup = 1;
            var currentMaxGroup = 1;
            var maxSum = 0;
            var currentMaxSum = 0;
            var currentCar = speeds[0];

            for (var i = 0; i < carsCount; i++)
            {
                if (currentCar >= speeds[i])
                {
                    currentMaxGroup = 1;
                    currentMaxSum = speeds[i];
                    currentCar = speeds[i];
                }
                else
                {
                    currentMaxGroup++;
                    currentMaxSum += speeds[i];

                    if (currentMaxGroup >= maxGroup)
                    {
                        maxGroup = currentMaxGroup;

                        if (maxSum <= currentMaxSum)
                        {
                            maxSum = currentMaxSum;
                        }

                    }



                }
            }

            if (maxGroup == 1)
            {
                for (var i = 0; i < carsCount; i++)
                {
                    if (maxSum < speeds[i])
                    {
                        maxSum = speeds[i];
                    }
                }
            }

            Console.WriteLine(maxSum);

        }
    }
}
