    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    namespace _08.Number_as_array
    {
        class Program
        {

           static int[] Sum(int[] one, int[] two) {
               int[] numbers = new int[one.Length];
           
               for (int i = 0; i < one.Length; i++)
               {
                   //current digit
                   numbers[i] += one[i] + two[i];
                   //if the sum is a two digit number
                   if (numbers[i]>9)
                   {
                       numbers[i] %= 10;
                      //if it is the last digits 
                       if (i == one.Length-1)
                       {
                           //create new array with lenght +1
                           int[] numbersZwei = new int[one.Length+1];
                           for (int j = 0; j < numbers.Length; j++)
                           {
                               numbersZwei[j] = numbers[j];
                           }
                           numbersZwei[numbers.Length] = 1;
                           return numbersZwei;
                       }
                       //add one to the next element
                       numbers[i + 1] = 1;
                 

                   }
             
               }
               return numbers;
           }
       
            static void Main(string[] args)
            {

                string empty = Console.ReadLine(); //first line, meaningless
                string first = Console.ReadLine().Replace(" ", string.Empty); // first number
                string second = Console.ReadLine().Replace(" ", string.Empty); //second number
                int[] zwei = new int[Math.Max(first.Length, second.Length)]; 
                int[] eins = new int[Math.Max(first.Length, second.Length)];
                //get two arrays with equal length and fill the remaining spaces with 0
                for (int i = 0; i < eins.Length; i++) 
                {
                    if (i<first.Length)
                    {
                        eins[i] = first[i]-'0';
                    }
                    if (i<second.Length)
                    {
                        zwei[i] = second[i]-'0';
                    }
                }
                int[] numbers = Sum(eins, zwei);
              //print 
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i==numbers.Length-1)
                    {
                        Console.Write("{0}",numbers[i]);
                    }
                    else
                    {
                        Console.Write("{0} ", numbers[i]);
                    }
                }
            }
        }
    }
