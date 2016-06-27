using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Four_digits
{
    class Program
    {
        static void Main(string[] args)
        {
            int abcd = int.Parse(Console.ReadLine());
            int fourth = abcd / 1000;
            int second = (abcd/10)%10;
            int third = (abcd/100)%10;
            int first = abcd % 10;
            String frth = fourth.ToString();
            String scnd = second.ToString();
            String thrd = third.ToString();
            String frst = first.ToString();
            Console.WriteLine(first + second + third + fourth);
            Console.WriteLine(frst+scnd+thrd+frth);
            Console.WriteLine(frst+frth+thrd+scnd);
            Console.WriteLine(frth+scnd+thrd+frst);
                      
        }
    }
}
