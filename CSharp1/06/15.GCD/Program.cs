using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.GCD
{
    class Program
    {
        static int gcd(int a, int b) {
            int first = Math.Max(a, b);
            int second = Math.Min(a, b);
            int q, r;
            if (a==0)
            {
                return b;
            }
            else if (b == 0)
            {
                return a;
            }
            else {
                q = first/second;
                r = first%second;
                return gcd(second, r);
            }
        }
        static void Main(string[] args)
        {
            
            string numbers = Console.ReadLine();
            int a=0, b=0;
            //finding a,b
            int counter1 = 0, counter2=0;
            for (int i = numbers.Length-1; i >=0 ; i--)
            {
                if (char.IsDigit(numbers[i])) {
                    if (counter2 == 0)
                    {
                        b += int.Parse(numbers[i].ToString()) * (int)Math.Pow(10, counter1);
                        counter1++;
                    }
                    else { 
                    a += int.Parse(numbers[i].ToString()) * (int)Math.Pow(10, counter1);
                        counter1++;
                    }
                    } else{
                counter1=0;
                    counter2=1;
                }
                }
            //gcd
            Console.WriteLine(gcd(a,b));
            }
        }
    }

