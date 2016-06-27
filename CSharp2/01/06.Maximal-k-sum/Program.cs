using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Maximal_k_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            
           for (int i = 0; i < n; i++)
           {
               arr[i] = int.Parse(Console.ReadLine());
           }
            int maxSum = 0, maxElement=arr[1];
            int min = arr.Min();
            int max;
            for (int j = 0; j < k; j++)
            {
                max = arr.Max();
                maxSum += max;
                for (int i = 0; i < n; i++)
                {
                    if (arr[i] == max)
                    {
                        arr[i] = min;
                        break;
                    }
                }
            }
            
            Console.WriteLine("{0}",maxSum);
        }
    }
}
