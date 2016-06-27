using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Adding_polynomials
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            int[] first = Console.ReadLine()
                   .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(item => int.Parse(item))
                   .ToArray();
            
            int[] second = Console.ReadLine()
                   .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(item => int.Parse(item))
                   .ToArray();
            int[] numbers = Polynomials(first, second);
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i == numbers.Length - 1)
                {
                    Console.Write("{0}", numbers[i]);
                }
                else
                {
                    Console.Write("{0} ", numbers[i]);
                }
            }
            
        }
        static int[] Polynomials(int[] one, int[] two) {
            int[] result = new int[one.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = one[i] + two[i];
            }
            return result;
        }
    }
}
