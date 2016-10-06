using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Binary_decimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string binaryNumber = Console.ReadLine();
            
            long numberInDec=0;
            int currentBit;
            for (int i = binaryNumber.Length-1; i >=0; i--)
            {
                currentBit=int.Parse(binaryNumber[i].ToString());
                
                numberInDec += currentBit * (long)Math.Pow(2, binaryNumber.Length-1-i);

            }
            Console.WriteLine(numberInDec);
        }
    }
}
