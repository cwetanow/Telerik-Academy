using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Frequent_number
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
            int number=arr[1];
            int currentTimes=0;
            int times = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    if (arr[i]==arr[j])
                    {
                        currentTimes++;
                    }
                }
                if (currentTimes>times)
                {
                    times = currentTimes;
                    number = arr[i];
                }
                currentTimes = 0;
            }
            Console.WriteLine("{0} ({1} times)",number,times);
        }
    }
}
