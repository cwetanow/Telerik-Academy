using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework03.ExtensionMethods
{
    //Task 2
    public static class  IEnumerableExtensionMethods
        
    {
        public static T Sum<T>(this IEnumerable<T> collection)
        {
            dynamic sum = 0;
            foreach (var item in collection)
            {
                sum += item;
            }
            return sum;
        }
        public static T Product<T>(this IEnumerable<T> collection)
        {
            dynamic product = 1;
            foreach (var item in collection)
            {
                product *= item;
            }
            return product;
        }
        public static T Min<T>(this IEnumerable<T> collection)
        {
          
            dynamic result = collection.FirstOrDefault();
            foreach (var item in collection)
            {
                if (result>item)
                {
                    result = item;
                }
            }
            
            return result;
        }
        public static T Max<T>(this IEnumerable<T> collection)
        {
            dynamic result = collection.FirstOrDefault();
            foreach (var item in collection)
            {
                if (result < item)
                {
                    result = item;
                }
            }

            return result;
        }
        public static T Average<T>(this IEnumerable<T> collection)
        {
            dynamic average = Sum(collection);
            average /= collection.Count();
            return average;
        }

    }
}
