using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Compare_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] a = new int[n];
            int[] b = new int[n];
            bool equal = true;
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i < n; i++)
            {
                b[i] = int.Parse(Console.ReadLine());
                if (a[i]!=b[i])
                {
                    equal = false;
                }

            }
            if (equal)
            {
                Console.WriteLine("Equal");
            }
            else {
                Console.WriteLine("Not equal");
            }
        }
    }
}
