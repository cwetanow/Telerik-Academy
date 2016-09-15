using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Binary_short
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(n,2).PadLeft(16,'0'));
        }
    }
}
