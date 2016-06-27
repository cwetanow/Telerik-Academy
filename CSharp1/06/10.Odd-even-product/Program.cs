using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Odd_even_product
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] splitLine = Console.ReadLine().Split(new string[] {" "}, n, StringSplitOptions.RemoveEmptyEntries);

            long oddProduct=1, evenProduct=1;
            
            for (int i = 0; i < n; i++)
            {
                
                if (i % 2 == 0)
                {
                    
                    oddProduct *= int.Parse(splitLine[i]);
                }
                else {
                    evenProduct *= int.Parse(splitLine[i]);
                }
            }
            if (evenProduct == oddProduct)
            {
                Console.WriteLine("yes {0}", oddProduct);
            }
            else {
                Console.WriteLine("no {0} {1} ",oddProduct, evenProduct);
            }
            {
                
            }
        }
    }
}
