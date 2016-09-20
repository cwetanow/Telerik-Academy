using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Compare_simple_maths.Utils;

namespace Task_2.Compare_simple_maths.Operations
{
    public static class Add
    {
        public static void DisplayAll()
        {
            Console.WriteLine("Time for adding integers:");
            Helper.DisplayExecutionTime(AddIntegers);

            Console.WriteLine("Time for adding long:");
            Helper.DisplayExecutionTime(AddLong);

            Console.WriteLine("Time for adding float:");
            Helper.DisplayExecutionTime(AddFloat);

            Console.WriteLine("Time for adding double:");
            Helper.DisplayExecutionTime(AddDouble);

            Console.WriteLine("Time for adding decimal:");
            Helper.DisplayExecutionTime(AddDecimal);
        }

        public static void AddIntegers()
        {
            int result = 0;
            for (int i = 0; i < Helper.ActionExecutionTimesCount; i++)
            {
                result += i;
            }
        }

        public static void AddLong()
        {
            var result = 0L;
            for (var i = 0L; i < Helper.ActionExecutionTimesCount; i++)
            {
                result += i;
            }
        }

        public static void AddFloat()
        {
            var result = 0f;
            for (var i = 0f; i < Helper.ActionExecutionTimesCount; i++)
            {
                result += i;
            }
        }

        public static void AddDouble()
        {
            var result = 0.0;
            for (var i = 0.0; i < Helper.ActionExecutionTimesCount; i++)
            {
                result += i;
            }
        }

        public static void AddDecimal()
        {
            var result = 0m;
            for (var i = 0m; i < Helper.ActionExecutionTimesCount; i++)
            {
                result += i;
            }
        }
    }
}
