using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.String_lenght
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().Trim(' ');
            
            StringBuilder output = new StringBuilder();
            output.Append(input);
            for (int i = 0; i < 20-input.Length; i++)
            {
                output.Append("*");
            }
            Console.WriteLine(output.ToString());
            Console.WriteLine(output.ToString().Length);
        }
    }
}
