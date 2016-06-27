using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace _3.ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = -1;
            List<String> input = new List<string>();
            int transformtations = 0;        
            do
            {
                n++;
                input.Add(Console.ReadLine());
                
            } while (input[n] != "END") ;
            long[] numbers = new long[n];
            string[] number=input.ToArray();
            for (int i = 0; i < n; i++)
            {
                numbers[i] =int.Parse(number[i]);
                
            }
            ulong products = 1;
           ulong productOfLess = 1;
            
            if (n < 11)
            {
                for (int i = 1; i < n; i += 2)
                {
                    long numb = numbers[i];
                    if (numb == 0)
                    {

                        continue;
                    }
                    else
                    {
                        do
                        {
                            if (numb % 10 == 0)
                            {
                                continue;
                            }
                            products *= (ulong)numb % 10;
                            numb /= 10;

                        } while (numb != 0);

                    }

                    transformtations++;
                }
            }
            else {
                
                for (int i = 1; i < n; i += 2)
                {
                    long numb = numbers[i];
                    if (numb == 0)
                    {

                        continue;
                    }
                    else
                    {
                        do
                        {
                            if (numb % 10 == 0)
                            {
                                continue;
                            }
                            products *= (ulong)numb % 10;
                            numb /= 10;

                        } while (numb != 0);

                    }

                    transformtations++;
                }
                for (int i = 1; i < 10; i += 2)
                {
                    long numb = numbers[i];
                    if (numb == 0)
                    {

                        continue;
                    }
                    else
                    {
                        do
                        {
                            if (numb % 10 == 0)
                            {
                                continue;
                            }
                            productOfLess *= (ulong)numb % 10;
                            numb /= 10;

                        } while (numb != 0);

                    }

                    
                }
            }

            if (transformtations < 11)
            {
                Console.WriteLine(products);
            }
            else {
                Console.WriteLine(products);
                Console.WriteLine(productOfLess);
                
            }

            



        }
    }
}
