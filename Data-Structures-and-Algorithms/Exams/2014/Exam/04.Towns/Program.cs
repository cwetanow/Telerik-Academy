using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var array = new int[n];

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(' ')
                    .ToArray();

                array[i] = int.Parse(input[0]);
            }

            var longestTuple = GetMaximalIncreasingSequence(n, array);
            var longestIncreasingSequence = longestTuple.Item1;
            var maxIndex = longestTuple.Item2;

            var longestDecreasingSequence = GetMaximalDecreasingSequence(n, array, maxIndex);

            Console.WriteLine(longestDecreasingSequence + longestIncreasingSequence - 1);
        }

        static int GetMaximalDecreasingSequence(int n, int[] array, int index)
        {
            var increasingSequences = new int[n];
            var prevIncreasingSequences = new int[n];

            var maxLength = 1;
            var bestEnd = 0;
            increasingSequences[0] = 1;
            prevIncreasingSequences[0] = -1;

            for (var i = index; i < n; i++)
            {
                increasingSequences[i] = 1;
                prevIncreasingSequences[i] = -1;

                for (var j = i - 1; j >= index; j--)
                    if (increasingSequences[j] + 1 > increasingSequences[i] && array[j] > array[i])
                    {
                        increasingSequences[i] = increasingSequences[j] + 1;
                        prevIncreasingSequences[i] = j;
                    }

                if (increasingSequences[i] > maxLength)
                {
                    bestEnd = i;
                    maxLength = increasingSequences[i];
                }
            }

            return increasingSequences.Max();
        }

        static Tuple<int, int> GetMaximalIncreasingSequence(int n, int[] array)
        {
            var increasingSequences = new int[n];
            var prevIncreasingSequences = new int[n];

            var maxLength = 1;
            var bestEnd = 0;
            increasingSequences[0] = 1;
            prevIncreasingSequences[0] = -1;

            for (var i = 1; i < n; i++)
            {
                increasingSequences[i] = 1;
                prevIncreasingSequences[i] = -1;

                for (var j = i - 1; j >= 0; j--)
                    if (increasingSequences[j] + 1 > increasingSequences[i] && array[j] < array[i])
                    {
                        increasingSequences[i] = increasingSequences[j] + 1;
                        prevIncreasingSequences[i] = j;
                    }

                if (increasingSequences[i] > maxLength)
                {
                    bestEnd = i;
                    maxLength = increasingSequences[i];
                }
            }

            var maxSequence = increasingSequences
                .ToList()
                .IndexOf(increasingSequences.Max());

            return new Tuple<int, int>(increasingSequences[maxSequence], maxSequence);
        }
    }
}
