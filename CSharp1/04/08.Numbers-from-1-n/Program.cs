using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Numbers_from_1_n
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for(int i=1; i<=n; i++){
                Console.WriteLine("{0}",i);
            }
        }
    }
}
