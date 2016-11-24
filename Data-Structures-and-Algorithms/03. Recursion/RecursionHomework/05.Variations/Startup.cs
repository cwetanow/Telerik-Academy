using System;

namespace _05.Variations
{
    public class Startup
    {
        static int n;
        static int k;

        private static int[] arr;

        private static void Main()
        {
            Console.WriteLine("Enter n");
            n = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter k");
            k = int.Parse(Console.ReadLine());

            arr = new int[k];

            for (var i = 1; i <= k; i++)
            {
                arr[i - 1] = i;
            }

            GenerateVariations(0);
        }

        public static void GenerateVariations(int index)
        {
            if (index >= k)
            {
                Print();
            }
            else
            {
                for (var i = 1; i <= n; i++)
                {
                    arr[index] = i;
                    GenerateVariations(index + 1);
                }
            }
        }

        private static void Print()
        {
            Console.WriteLine("(" + string.Join(", ", arr) + ")");
        }
    }
}
