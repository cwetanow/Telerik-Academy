namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Quicksort(collection, 0, collection.Count - 1);
        }

        private static void Quicksort(IList<T> collection, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = collection[(leftIndex + rightIndex) / 2];

            while (i <= j)
            {
                while (collection[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (collection[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    var temp = collection[i];
                    collection[i] = collection[j];
                    collection[j] = temp;

                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
            {
                Quicksort(collection, leftIndex, j);
            }

            if (rightIndex > i)
            {
                Quicksort(collection, i, rightIndex);
            }
        }
    }
}
