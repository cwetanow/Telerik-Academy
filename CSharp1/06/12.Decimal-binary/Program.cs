using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Decimal_binary
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string binary="";
           
            do
            {

                binary += (n % 2).ToString();
              
                n /= 2;
            } while (n!=0);
           
            char[] badBinary=binary.ToArray();
            Array.Reverse(badBinary);
            binary = new string(badBinary);
            Console.WriteLine(binary);
    
        }
    }
}
