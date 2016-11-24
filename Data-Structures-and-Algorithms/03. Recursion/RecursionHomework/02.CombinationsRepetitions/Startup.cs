using System;

namespace _02.CombinationsRepetitions
{
    class Startup
    {
        private static int k;
        private static int n;

        private static int[] arr;

        static void Main(string[] args)
        {
            Console.WriteLine("Enter n");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter k");
            k = int.Parse(Console.ReadLine());

            arr = new int[k];
            GenerateCombinations(0, 1);
        }

        static void GenerateCombinations(int index, int start)
        {
            if (index >= k)
            {
                PrintVariations();
                return;
            }

            for (var i = start; i <= n; i++)
            {
                arr[index] = i;
                GenerateCombinations(index + 1, i);
            }
        }

        private static void PrintVariations()
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }
    }
}
