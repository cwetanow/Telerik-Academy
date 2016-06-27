using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Unicode_char
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var output = new StringBuilder();
            foreach (var character in input)
            {
                output.Append("\\u" + ((int)character).ToString("X4"));
            }
            Console.WriteLine(output.ToString());
        }

    }
}
