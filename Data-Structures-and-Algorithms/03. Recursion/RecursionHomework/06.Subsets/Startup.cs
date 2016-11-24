using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Subsets
{
    class Startup
    {
        static int n;
        static int k;

        private static int[] arr;
        private static bool[] used;
        private static string[] strings;

        private static List<string> results = new List<string>();

        private static void Main()
        {
            Console.WriteLine("Enter k");
            k = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter strings separated by space");
            strings = Console.ReadLine().Split(' ');

            n = strings.Length;

            arr = new int[k];
            used = new bool[n];

            for (var i = 0; i < k; i++)
            {
                arr[i] = i;
            }

            GenerateVariations(0);

            foreach (var result in results)
            {
                Console.WriteLine(result);
            }
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
                    if (!used[i - 1])
                    {
                        used[i - 1] = true;
                        arr[index] = i;
                        GenerateVariations(index + 1);
                        used[i - 1] = false;
                    }
                }
            }
        }

        private static void Print()
        {
            var result = new StringBuilder("(");

            foreach (var t in arr)
            {
                result.Append(strings[t - 1] + " ");
            }
            result.Append(")");

            var stringified = result.ToString();

            if (!results.Contains(stringified))
            {
                results.Add(stringified);
            }
        }
    }
}
