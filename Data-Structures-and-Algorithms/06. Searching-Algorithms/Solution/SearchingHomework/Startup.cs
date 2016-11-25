using System;
using System.Collections.Generic;
using SortingHomework;

namespace SearchingHomework
{
    public class Startup
    {
        private const int min = 1;
        private const int max = 100;

        public static void Main(string[] args)
        {
            var collection = new List<int>();
            var random = new Random();

            for (var i = min; i <= max; i++)
            {
                var number = random.Next(min, max);
                collection.Add(number);
            }

            var firstSortableCollection = new SortableCollection<int>(collection);
            Console.WriteLine("First collection");
            firstSortableCollection.PrintAllItemsOnConsole();

            for (var i = 0; i < 5; i++)
            {
                var number = random.Next(min, max);
                Console.WriteLine("Found {0} at index {1}", number, firstSortableCollection.LinearSearch(number));
            }

            Console.WriteLine();

            // Collection has to be sorted
            collection.Clear();
            for (var i = min; i <= max; i++)
            {
                collection.Add(i);
            }

            var secondSortableCollection = new SortableCollection<int>(collection);
            Console.WriteLine("Second collection");
            secondSortableCollection.PrintAllItemsOnConsole();

            for (var i = 0; i < 5; i++)
            {
                var number = random.Next(min, max);
                Console.WriteLine("Found {0} at index {1}", number, secondSortableCollection.BinarySearch(number));
            }

            Console.WriteLine();

            Console.WriteLine("Shuffle the sorted collection");
            secondSortableCollection.Shuffle();
            secondSortableCollection.PrintAllItemsOnConsole();
        }
    }
}
