using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Maximal_increasing_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int currentMax = 1, max = 1;
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n - 1; i++)
            {

                if (arr[i] < arr[i + 1])
                {
                    currentMax++;
                    if (currentMax > max)
                    {
                        max = currentMax;
                    }
                }
                else
                {
                    currentMax = 1;
                }
            }
            Console.WriteLine("{0}", max);
        }
    }
}
