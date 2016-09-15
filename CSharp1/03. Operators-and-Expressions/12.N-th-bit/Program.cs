using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.N_th_bit
{
    class Program
    {
        static void Main(string[] args)
        {
            long  p = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            
            Console.WriteLine((p>>n)%2);
        }
    }
}
