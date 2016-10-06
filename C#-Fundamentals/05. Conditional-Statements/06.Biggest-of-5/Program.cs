using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Biggest_of_5
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] numbers = new float[5];
            float biggest;
            for (int i = 0; i < 5; i++)
            {
                numbers[i] = float.Parse(Console.ReadLine());
            }
            biggest=numbers[0];
            for (int i = 1; i < 5; i++)
            {
                biggest = Math.Max(biggest, numbers[i]);
            }
            Console.WriteLine("{0}", biggest);

        }
    }
}
