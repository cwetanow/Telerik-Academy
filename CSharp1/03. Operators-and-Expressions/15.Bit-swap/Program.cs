using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Bit_swap
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            uint bit;
            uint replaceWithBit;
            for (int i = 0; i < k; i++) {
                bit = ((n >> (p + i)) % 2);
                replaceWithBit = ((n >> (q + i)) % 2);
                Console.WriteLine(bit+" "+replaceWithBit);

                n = n - (bit * (uint)Math.Pow(2, (p + i)) + replaceWithBit * (uint)Math.Pow(2, (q + i))) + (replaceWithBit * (uint)Math.Pow(2, (p + i))+bit * (uint)Math.Pow(2, (q + i)));
                Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
                Console.WriteLine(n);
            }
            
        }
    }
}
