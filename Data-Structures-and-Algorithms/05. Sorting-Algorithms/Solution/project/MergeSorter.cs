using System.Linq;

namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var sorted = MergeSort(collection);

            collection.Clear();
            foreach (var element in sorted)
            {
                collection.Add(element);
            }
        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            var left = new List<T>();
            var right = new List<T>();

            var middle = collection.Count / 2;
            var index = 0;

            foreach (var element in collection)
            {
                if (index < middle)
                {
                    left.Add(element);
                }
                else
                {
                    right.Add(element);
                }

                index++;
            }

            left = MergeSort(left).ToList();
            right = MergeSort(right).ToList();

            return Merge(left, right);
        }

        private IList<T> Merge(IList<T> leftList, IList<T> rightList)
        {
            var result = new List<T>();

            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    if (leftList[0].CompareTo(rightList[0]) < 1)
                    {
                        result.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }
                else if (leftList.Count > 0)
                {
                    result.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }
                else if (rightList.Count > 0)
                {
                    result.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            return result;
        }
    }
}
