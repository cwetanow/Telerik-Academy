using System;
using Task_3.Compare_advanced_maths.Utils;

namespace Task_3.Compare_advanced_maths.Operations
{
    public static class Sqrt
    {
        public static void DisplayAll()
        {
            Console.WriteLine("Time for Sqrting float:");
            Helper.DisplayExecutionTime(SqrtFloat);

            Console.WriteLine("Time for Sqrting double:");
            Helper.DisplayExecutionTime(SqrtDouble);

            Console.WriteLine("Time for Sqrting decimal:");
            Helper.DisplayExecutionTime(SqrtDecimal);
        }

        public static void SqrtFloat()
        {
            var result = 2f;
            for (var i = 0f; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = (float)Math.Sqrt((double)result);
            }
        }

        public static void SqrtDouble()
        {
            var result = 2.0;
            for (var i = 0.0; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = Math.Sqrt(result);
            }
        }

        public static void SqrtDecimal()
        {
            var result = 2m;
            for (var i = 0m; i < Helper.ActionExecutionTimesCount; i++)
            {
                result = (decimal)Math.Sqrt((double)result);
            }
        }
    }
}
