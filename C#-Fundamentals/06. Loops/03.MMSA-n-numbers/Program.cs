using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MMSA_n_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[] numbers = new double[n];
            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                numbers[i] = double.Parse(Console.ReadLine());
                sum += numbers[i];
            }

            Console.WriteLine("min={0:F2}",numbers.Min() );
            Console.WriteLine("max={0:F2}", numbers.Max());
            Console.WriteLine("sum={0:F2}", sum);
            Console.WriteLine("avg={0:F2}", (double)(sum/n));
        }
    }
}
