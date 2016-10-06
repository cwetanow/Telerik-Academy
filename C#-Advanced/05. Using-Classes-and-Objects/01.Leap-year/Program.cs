using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01.Leap_year
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime.IsLeapYear(int.Parse(Console.ReadLine()));
            Console.WriteLine(DateTime.IsLeapYear(int.Parse(Console.ReadLine()))?"Leap":"Common");
            



        }
    }
}
