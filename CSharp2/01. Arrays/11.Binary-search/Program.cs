using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Binary_search
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
            int x = int.Parse(Console.ReadLine());
            int index = System.Array.BinarySearch(arr, x);
            if (index < 0)
            {
                Console.WriteLine("-1");
            }
            else {
                Console.WriteLine(index);
            }
            
        }
    }
}
