using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Square_root
{
    class Program
    {
        static void Main(string[] args)
        { 

            try
            {
                double thing=double.Parse(Console.ReadLine());
                if (thing<0)
                {
                     Console.WriteLine("Invalid number");
                }
                else
                {
                    Console.WriteLine("{0:F3}", Math.Sqrt(thing));
                }
                
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid number");
                
            }
            finally {
                Console.WriteLine("Good bye");
            }
        }
    }
}
