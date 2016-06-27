using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _23.Series_of_letters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            char symbol = input[0];
            output.Append(symbol);
            for (int i = 0; i < input.Length; i++)
            {
                if (symbol!=input[i])
                {
                    output.Append(input[i]);
                    symbol = input[i];
                }
            }
            Console.WriteLine(output.ToString());
        }
    }
}
