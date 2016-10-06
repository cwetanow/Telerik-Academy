using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Bit_exchange
{
    class Program
    {
        static void Main(string[] args)
        {
            uint n = uint.Parse(Console.ReadLine());
            uint bit3, bit4, bit5, bit24, bit25, bit26;
            bit3 = (n >> 24) % 2;
            bit4 = (n >> 25) % 2;
            bit5 = (n >> 26) % 2;
            bit24 = (n >> 3) % 2;
            bit25 = (n >> 4) % 2;
            bit26 = (n >> 5) % 2;
            n = n - (bit24 * (uint)Math.Pow(2, 3) + bit25 * (uint)Math.Pow(2, 4) + bit26 * (uint)Math.Pow(2, 5) + bit3 * (uint)Math.Pow(2, 24) + bit4 * (uint)Math.Pow(2, 25) + bit5 * (uint)Math.Pow(2, 26)) + 
                (bit24 * (uint)Math.Pow(2, 24) + bit25 * (uint)Math.Pow(2, 25) + bit26 * (uint)Math.Pow(2, 26) + bit3 * (uint)Math.Pow(2, 3) + bit4 * (uint)Math.Pow(2, 4) + bit5 * (uint)Math.Pow(2, 5));
            Console.WriteLine(n);
        }
    }
}
