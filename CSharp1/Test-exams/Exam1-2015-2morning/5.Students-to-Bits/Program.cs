using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Students_to_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }
            string bits="";
            long maxOnes = 0, maxZeros = 0, currentMax0 = 0, currentMax1 = 0;
            for (int i = 0; i < n; i++)
            {
                bits += Convert.ToString(numbers[i], 2).PadLeft(30, '0');
            }
            
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '0') { 
                
                               currentMax0++;
                               if (maxOnes < currentMax1)
                               {
                                   maxOnes = currentMax1;
                               }
                               currentMax1 = 0;
                 } else {
                               currentMax1++;
                               if (maxZeros < currentMax0)
                               {
                                   maxZeros = currentMax0;
                               }
                               currentMax0 = 0;
                           
                }
                
            }
            Console.WriteLine(maxZeros);
            Console.WriteLine(maxOnes);
            

        }
    }
}
