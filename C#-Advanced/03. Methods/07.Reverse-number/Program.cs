using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Reverse_number
{
    class Program
    {
        static string Reverse(string number) {
            char[] temp = number.ToCharArray();
            Array.Reverse(temp);
            return new string(temp);
           
        }
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            Console.WriteLine(Reverse(number));
        }
    }
}
