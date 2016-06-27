using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Maximal_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            int maxSum = arr[0];
            int currentMax=arr[0];
            for (int i = 0; i < n; i++)
            {
                currentMax = Math.Max(currentMax+arr[i],arr[i]);
                if (currentMax>maxSum)
                {
                    maxSum = currentMax;
                }
            }
            Console.WriteLine("{0}",maxSum);
        }
    }
}
