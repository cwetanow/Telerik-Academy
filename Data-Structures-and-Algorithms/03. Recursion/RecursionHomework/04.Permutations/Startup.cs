using System;

namespace _04.Permutations
{
    class Startup
    {
        private static int[] array;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            var n = int.Parse(Console.ReadLine());

            array = new int[n];

            for (var i = 1; i <= n; i++)
            {
                array[i - 1] = i;
            }

            GeneratePermutations(0);
        }

        private static void GeneratePermutations(int num)
        {
            if (num >= array.Length)
            {
                Console.WriteLine(string.Join(", ", array));
                return;
            }

            GeneratePermutations(num + 1);

            for (var i = num + 1; i < array.Length; i++)
            {
                Swap(num, i);
                GeneratePermutations(num + 1);
                Swap(num, i);
            }
        }

        private static void Swap(int firstIndex, int secondIndex)
        {
            var first = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = first;
        }
    }
}
