using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16.Long_sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 1000; i++) {
                if (i % 2 == 0) {
                    Console.WriteLine("-"+(i+1));
                } 
                else {
                Console.WriteLine(i+1);
                }
            }
        }
    }
}
