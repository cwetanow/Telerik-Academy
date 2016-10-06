using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Get_largest_num
{
    class Program
    {
        static int GetMax(int a, int b) {
            return a > b ? a : b;
        }
        static void Main(string[] args)
        {
            string[] num=Console.ReadLine().Split(' ');
            int[] numbers=new int[3];
            numbers[0] = int.Parse(num[0]);
            numbers[1] = int.Parse(num[1]);
            numbers[2] = int.Parse(num[2]);
            Console.WriteLine(GetMax(GetMax(numbers[0],numbers[1]),numbers[2]));
        }
    }
}
