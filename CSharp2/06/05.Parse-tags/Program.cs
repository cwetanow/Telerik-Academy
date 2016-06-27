using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _05.Parse_tags
{
    class Program
    {
        static void Main(string[] args)
                        {
                            
            var input = Console.ReadLine().Split(new char[] {'<','>'});
            StringBuilder output = new StringBuilder();
            var open = "upcase";
            var close = "/upcase";
            var isOpen = false;
            foreach (var word in input)
            {
                if (word==open)
                {
                    isOpen = true;
                    continue;
                }
                if (word==close)
                {
                    isOpen = false;
                    continue;
                }
                if (isOpen)
                {
                    output.Append(word.ToUpper());
                }
                if (!isOpen)
                {
                    output.Append(word);
                }
            }

            Console.WriteLine(output.ToString());
            
        }

    }
}
