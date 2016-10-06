using System;

namespace FastAndFurious.ConsoleApplication.Common.Utils
{
    public static class MetricUnitsConverter
    {
        private const decimal MetersInKilometer = 1000m;
        private const int MinutesInHour = 60;
        private const int SecondsInMinute = 60;

        public static int GetMetersPerSecondFrom(int kilometersPerHour)
        {
            var expression = ((kilometersPerHour * MetersInKilometer) / (MinutesInHour * SecondsInMinute));
            var metersPerSecond = Convert.ToInt32(Math.Ceiling(expression));

            return metersPerSecond;
        }
    }
}
