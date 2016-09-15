using System;

namespace CohesionAndCoupling.Utils
{
    class TwoDimensionalCalculator
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            var distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        public static double CalcDiagonalXY(double width, double height)
        {
            var distance = CalcDistance2D(0, 0, width, height);
            return distance;
        }

        public static double CalcDiagonalXZ(double width, double depth)
        {
            var distance = CalcDistance2D(0, 0, width, depth);
            return distance;
        }

        public static double CalcDiagonalYZ(double height, double depth)
        {
            var distance = CalcDistance2D(0, 0, height, depth);
            return distance;
        }
    }
}
