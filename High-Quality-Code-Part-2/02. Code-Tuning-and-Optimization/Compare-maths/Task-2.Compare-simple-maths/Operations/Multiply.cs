using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Compare_simple_maths.Utils;

namespace Task_2.Compare_simple_maths.Operations
{
    public static class Multiply
    {
        public static void DisplayAll()
        {
            Console.WriteLine("Time for Multiplying integers:");
            Helper.DisplayExecutionTime(MultiplyIntegers);

            Console.WriteLine("Time for Multiplying long:");
            Helper.DisplayExecutionTime(MultiplyLong);

            Console.WriteLine("Time for Multiplying float:");
            Helper.DisplayExecutionTime(MultiplyFloat);

            Console.WriteLine("Time for Multiplying double:");
            Helper.DisplayExecutionTime(MultiplyDouble);

            Console.WriteLine("Time for Multiplying decimal:");
            Helper.DisplayExecutionTime(MultiplyDecimal);
        }

        public static void MultiplyIntegers()
        {
            int result = 1;
            for (int i = 1; i < Helper.ActionExecutionTimesCount; i++)
            {
                result *= 1;
            }
        }

        public static void MultiplyLong()
        {
            var result = 1L;
            for (var i = 1L; i < Helper.ActionExecutionTimesCount; i++)
            {
                result *= 1;
            }
        }

        public static void MultiplyFloat()
        {
            var result = 1f;
            for (var i = 1f; i < Helper.ActionExecutionTimesCount; i++)
            {
                result *= 1;
            }
        }

        public static void MultiplyDouble()
        {
            var result = 1.0;
            for (var i = 1.0; i < Helper.ActionExecutionTimesCount; i++)
            {
                result *= 1;
            }
        }

        public static void MultiplyDecimal()
        {
            var result = 1m;
            for (var i = 1m; i < Helper.ActionExecutionTimesCount; i++)
            {
                result *= 1;
            }
        }
    }
}
