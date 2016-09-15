using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Int_double_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "integer":
                    {
                        short value = short.Parse(Console.ReadLine());
                        Console.WriteLine("{0}", value + 1);
                        break;
                    }
                case "real":
                    {
                        float value = float.Parse(Console.ReadLine());
                            Console.WriteLine("{0:F2}",value+1);
                        break;
                    }
                case "text":
                    {
                        string value = Console.ReadLine();
                        Console.WriteLine(value+"*");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
