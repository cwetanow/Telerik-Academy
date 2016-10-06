using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.Replace_tags
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            input = input.Replace("<a href=\"","[URL=");
            input = input.Replace("\">", "]");
            input = input.Replace("</a>","(/URL)");
            Console.WriteLine(input);
        }
    }
}
