using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _3.Saddy_kopper
{
    class Program
    {
        static void Main(string[] args)
        {

            //input            
            string number = Console.ReadLine();
            short transformations = 0;
            BigInteger product = 1;
            int sum = 0;

            //conversions
            while (number.Length != 1 && transformations < 10)
            {
                product = 1;
                while (number.Length > 1)
                {
                    number = number.Remove(number.Length - 1);
                    sum = 0;
                    for (int i = 0; i < number.Length; i += 2)
                    {
                        sum += number[i]-'0';
                    }
                    product *= sum;
                }
                number = product.ToString();
                transformations++;
            }

            //output
            if (transformations < 10)
            {
                Console.WriteLine(transformations);
                Console.WriteLine(number);
            }
            else
            {
                Console.WriteLine(number);
            }

        }
    }
}
