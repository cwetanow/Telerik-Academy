using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02.Point3D
{
    static class PointDistance
    {
        public static double DistanceBetweenPoints(Point A, Point B) {
            var dX = Math.Pow((B.X - A.X),2);
            var dY = Math.Pow((B.Y - A.Y), 2);
            var dZ = Math.Pow((B.Z - A.Z), 2);
            return Math.Sqrt(dX+dY+dZ);
        }
    }
}
