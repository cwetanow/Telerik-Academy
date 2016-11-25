namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            for (var i = 0; i < collection.Count - 1; i++)
            {
                var bestIndex = i;

                for (var j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[bestIndex]) < 0)
                    {
                        bestIndex = j;
                    }
                }

                if (!bestIndex.Equals(i))
                {
                    var temp = collection[bestIndex];
                    collection[bestIndex] = collection[i];
                    collection[i] = temp;
                }
            }
        }
    }
}
