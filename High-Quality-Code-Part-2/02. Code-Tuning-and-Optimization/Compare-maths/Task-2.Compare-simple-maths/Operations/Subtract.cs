using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Compare_simple_maths.Utils;

namespace Task_2.Compare_simple_maths.Operations
{
    public static class Subtract
    {
        public static void DisplayAll()
        {
            Console.WriteLine("Time for Subtracting integers:");
            Helper.DisplayExecutionTime(SubtractIntegers);

            Console.WriteLine("Time for Subtracting long:");
            Helper.DisplayExecutionTime(SubtractLong);

            Console.WriteLine("Time for Subtracting float:");
            Helper.DisplayExecutionTime(SubtractFloat);

            Console.WriteLine("Time for Subtracting double:");
            Helper.DisplayExecutionTime(SubtractDouble);

            Console.WriteLine("Time for Subtracting decimal:");
            Helper.DisplayExecutionTime(SubtractDecimal);
        }

        public static void SubtractIntegers()
        {
            int sum = 10000000;
            for (int i = 0; i < Helper.ActionExecutionTimesCount; i++)
            {
                sum -= i;
            }
        }

        public static void SubtractLong()
        {
            var sum = 10000000L;
            for (var i = 0L; i < Helper.ActionExecutionTimesCount; i++)
            {
                sum -= i;
            }
        }

        public static void SubtractFloat()
        {
            var sum = 10000000f;
            for (var i = 0f; i < Helper.ActionExecutionTimesCount; i++)
            {
                sum -= i;
            }
        }

        public static void SubtractDouble()
        {
            var sum = 10000000.0;
            for (var i = 0.0; i < Helper.ActionExecutionTimesCount; i++)
            {
                sum -= i;
            }
        }

        public static void SubtractDecimal()
        {
            var sum = 10000000m;
            for (var i = 0m; i < Helper.ActionExecutionTimesCount; i++)
            {
                sum -= i;
            }
        }
    }
}
