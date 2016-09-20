using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Compare_simple_maths.Utils;

namespace Task_2.Compare_simple_maths.Operations
{
    namespace Task_2.Compare_simple_maths
    {
        public static class Increment
        {
            public static void DisplayAll()
            {
                Console.WriteLine("Time for Incrementing integers:");
                Helper.DisplayExecutionTime(IncrementIntegers);

                Console.WriteLine("Time for Incrementing long:");
                Helper.DisplayExecutionTime(IncrementLong);

                Console.WriteLine("Time for Incrementing float:");
                Helper.DisplayExecutionTime(IncrementFloat);

                Console.WriteLine("Time for Incrementing double:");
                Helper.DisplayExecutionTime(IncrementDouble);

                Console.WriteLine("Time for Incrementing decimal:");
                Helper.DisplayExecutionTime(IncrementDecimal);
            }

            public static void IncrementIntegers()
            {
                int result = 0;
                for (int i = 0; i < Helper.ActionExecutionTimesCount; i++)
                {
                    result++;
                }
            }

            public static void IncrementLong()
            {
                var result = 0L;
                for (var i = 0L; i < Helper.ActionExecutionTimesCount; i++)
                {
                    result++;
                }
            }

            public static void IncrementFloat()
            {
                var result = 0f;
                for (var i = 0f; i < Helper.ActionExecutionTimesCount; i++)
                {
                    result++;
                }
            }

            public static void IncrementDouble()
            {
                var result = 0.0;
                for (var i = 0.0; i < Helper.ActionExecutionTimesCount; i++)
                {
                    result++;
                }
            }

            public static void IncrementDecimal()
            {
                var result = 0m;
                for (var i = 0m; i < Helper.ActionExecutionTimesCount; i++)
                {
                    result++;
                }
            }
        }
    }

}
