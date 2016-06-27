using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _16.Trailing_0_n_
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
           
            int zeros = 0;
            
            int powOf5=1;
            int i=1;
            do
            {
                powOf5 = (int)Math.Pow(5, i);
                zeros += n / powOf5;
                i++;

            } while (powOf5 <= n);
            Console.WriteLine(zeros);
        }
    }
}
