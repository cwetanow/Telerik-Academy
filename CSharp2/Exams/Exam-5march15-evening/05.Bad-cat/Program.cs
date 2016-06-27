using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Bad_cat
{
    class Program
    {
        static int[] InsertInArray(int[] array, int index, int num)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < index; i++)
            {
                result[i] = array[i];
            }
            result[index] = num;
            for (int i = index + 1; i < result.Length; i++)
            {
                result[i] = array[i - 1];
            }
            return result;
        }
        static void Main(string[] args)
        {
            var n = short.Parse(Console.ReadLine());
            var instructions = new string[n];
            var first = new short[n];
            var second = new short[n];
            var accumulator = new string[4];
            var numOfDigits = 0;
            for (int i = 0; i < n; i++)
            {
                accumulator = Console.ReadLine().Split(' ');
                instructions[i] = accumulator[2];
                first[i] = short.Parse(accumulator[0]);
                second[i] = short.Parse(accumulator[3]);
            }
            int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (digits[j] == first[i] || digits[j] == second[i])
                    {
                        digits[j] = -1;
                    }
                }
            }
            foreach (var item in digits)
            {
                if (item == -1)
                {
                    numOfDigits++;
                }
            }

            var result = new int[numOfDigits];
            for (int i = 0; i < numOfDigits; i++)
            {
                result[i] = 10;
            }
            for (int i = 0; i < n; i++)
            {
                var firstIs = false;
                var secondIs = false;
                for (int k = 0; k < numOfDigits; k++)
                {
                    if (first[i] == result[k])
                    {
                        firstIs = true;
                    }
                    if (second[i] == result[k])
                    {
                        secondIs = true;
                    }
                }
                if (instructions[i] == "before")
                {

                    var or = false;
                    for (int j = 0; j < numOfDigits; j++)
                    {
                        if (result[j] > first[i])
                        {
                            // result[j] = first[i];
                            if (or && !secondIs)
                            {
                                result = InsertInArray(result, j, second[i]);
                                break;
                            }
                            else if (!firstIs && !or)
                            {
                                result = InsertInArray(result, j, first[i]);
                                or = true;
                            }


                        }
                    }

                }
                else
                {

                    var or = false;
                    for (int j = 0; j < numOfDigits; j++)
                    {
                        if (result[j] > second[i])
                        {
                            // result[j] = first[i];
                            if (or && !firstIs)
                            {
                                result = InsertInArray(result, j, first[i]);
                                break;
                            }
                            else if (!secondIs && !or)
                            {
                                result = InsertInArray(result, j, second[i]);
                                or = true;
                            }


                        }
                    }
                }

            }
            foreach (var item in result)
            {
                Console.Write(item);
            }
            //  Console.WriteLine();
        }

    }
}