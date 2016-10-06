using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Prime_check
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            bool dividers=true;
            if (n < 1)
            {
                Console.WriteLine("false");
            }
            else {
                for (int i = 2; i <= Math.Sqrt(n); i++) {
                    if (n % i == 0) {
                        
                        dividers = false;
                        break;
                    }
                }
                if (dividers)
                {
                    Console.WriteLine("true");
                }
                else {
                    Console.WriteLine("false");
                }
                
            }
        }
    }
}
