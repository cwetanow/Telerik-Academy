namespace FastAndFurious.ConsoleApplication.Common.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class TypeCaster
    {
        public static int DecimalToInt(decimal number)
        {
            return Convert.ToInt32(number);
        }

        public static int DoubleToInt(double number)
        {
            return Convert.ToInt32(number);
        }

        public static int FloatToInt(float number)
        {
            return Convert.ToInt32(number);
        }

        public static decimal IntToDecimal(int number)
        {
            return Convert.ToDecimal(number);
        }

        public static decimal FloatToDecimal(float number)
        {
            return Convert.ToDecimal(number);
        }

        public static decimal DoubleToDecimal(double number)
        {
            return Convert.ToDecimal(number);
        }
    }
}
