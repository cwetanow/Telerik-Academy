using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Check_for_card
{
    class Program
    {
        static void Main(string[] args)
        {
            string card = Console.ReadLine();
            switch (card) {
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "10":
                case "J":
                case "Q":
                case "K":
                case "A":
                    {
                        Console.WriteLine("yes {0}", card);
                        break;
                    }
                default: {
                    Console.WriteLine("no {0}", card);
                    break;
                }

            }
        }
    }
}
