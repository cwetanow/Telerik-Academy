using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Appearance_count
{
    class Program
    {
        static int Counter(int[] numbers, int x) {
            int counter = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i]==x)
                {
                    counter++;
                }
            }
            return counter;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Array.ConvertAll(Console.ReadLine().Split(' '),int.Parse);
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine(Counter(numbers,x));
        }
    }
}
