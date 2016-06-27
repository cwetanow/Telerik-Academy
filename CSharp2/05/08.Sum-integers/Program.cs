using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Sum_integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                   .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(item => int.Parse(item))
                   .ToArray();
            Console.WriteLine(numbers.Sum());
        }
    }
}
