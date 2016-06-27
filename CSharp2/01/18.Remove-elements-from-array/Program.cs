using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Remove_elements_from_array
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
            int[] size = new int[n];
            for (int i = 0; i < n; i++)
            {
                size[i] = 1;
            }
            int max = 1;
            int currentMax = 1;
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
            Console.WriteLine("{0}",n-max);

        }
    }
}
