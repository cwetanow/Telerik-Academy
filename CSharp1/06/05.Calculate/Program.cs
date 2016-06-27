using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Calculate
{
    class Program
    {
        static int factoriel(int n){
            if (n == 1) { 
                return 1; 
            } else {
                return n * (factoriel(n - 1));
            }
        }
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            decimal freakishSum = 1;
            for (int i = 1; i <= n; i++)
            {
                freakishSum += (decimal)(factoriel(i) / Math.Pow(x, i));
                Console.WriteLine(freakishSum);
            }
            Console.WriteLine("{0:F5}",freakishSum);
        }
    }
}
