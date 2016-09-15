using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Sorting_array
{
    class Program
    {
        static int[] Sort(int[] array )  {
            int[] sortedArray = new int[array.Length];
            int min = array[0];
            int position = 0;
            for (int i = 0; i < array.Length; i++)
            {
                min = array.Max();
                for (int j = 0; j < array.Length; j++)
                {
                    if (min>array[j])
                    {
                        min = array[j];
                        position = j;
                    }
                }
                sortedArray[i] = min;
                array[position] = array.Max();
            }

            return sortedArray;
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = Console.ReadLine()
                   .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(item => int.Parse(item))
                   .ToArray();
            numbers = Sort(numbers);
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
    }
}
