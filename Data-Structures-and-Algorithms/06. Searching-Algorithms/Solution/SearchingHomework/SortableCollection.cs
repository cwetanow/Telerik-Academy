namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        public SortableCollection()
        {
            this.Items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.Items = new List<T>(items);
        }

        public IList<T> Items { get; }

        public int LinearSearch(T item)
        {
            for (var i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].Equals(item))
                {
                    return i;
                }
            }

            return -1;
        }

        public int BinarySearch(T item)
        {
            var middleIndex = this.Items.Count / 2;
            return this.BinarySearchCollection(0, this.Items.Count - 1, item);
        }

        private int BinarySearchCollection(int startIndex, int endIndex, T item)
        {
            var middleIndex = (startIndex + endIndex) / 2;
            var middleItem = this.Items[middleIndex];

            if (middleItem.Equals(item))
            {
                return middleIndex;
            }

            if (startIndex == endIndex && !this.Items[startIndex].Equals(item))
            {
                return -1;
            }

            if (item.CompareTo(middleItem) < 0)
            {
                return this.BinarySearchCollection(startIndex, middleIndex, item);
            }
            else
            {
                return this.BinarySearchCollection(middleIndex, endIndex, item);
            }
        }

        public void Shuffle()
        {
            // I have used the Fisher-Yates shuffle algorithm, it runs in O(n*logn) time
            var random = new Random();
            var n = this.Items.Count;

            for (var i = 0; i < n; i++)
            {
                // Exchange a[i] with random element in a[i..n-1]
                var r = i + random.Next(0, n - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.Items[i]);
                }
                else
                {
                    Console.Write(" " + this.Items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
