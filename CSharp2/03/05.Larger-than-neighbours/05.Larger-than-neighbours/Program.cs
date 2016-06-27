using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Larger_than_neighbours
{
    class Program
    {
        static int Neighbours(int[] numbers) {
            int counter = 0;
            for (int i = 1; i < numbers.Length-1; i++)
            {
                if (numbers[i] > numbers[i - 1] && numbers[i] > numbers[i +1])
                {
                    counter++;
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Console.WriteLine(Neighbours(numbers));
        }
    }
}
