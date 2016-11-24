using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ColorfulRabbits
{
    class Startup
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var numbers = new List<int>();
            for (var i = 0; i < n; i++)
            {
                numbers.Add(int.Parse(Console.ReadLine()));
            }

            var result = GetRabbits(numbers);
            Console.WriteLine(result);
        }

        public static int GetRabbits(IList<int> numbers)
        {
            numbers = FilterRabbits(numbers);

            var result = 0;

            foreach (var number in numbers)
            {
                if (number >= 0)
                {
                    result += (number + 1);
                }
            }

            return result;
        }

        public static IList<int> FilterRabbits(IList<int> numbers)
        {
            var numbersCount = numbers.Count;
            for (var index = 0; index < numbersCount; index++)
            {
                if (numbers[index] < 1)
                {
                    continue;
                }

                var counter = 0;
                for (var i = index + 1; i < numbersCount; i++)
                {
                    if (numbers[i] == numbers[index])
                    {
                        numbers[i] = -1;
                        counter++;
                        if (counter == numbers[index])
                        {
                            break;
                        }
                    }
                }
            }

            return numbers;
        }
    }
}
