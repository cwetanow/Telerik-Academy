using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework02.Point3D
{
    struct Point
    {
        private static readonly Point startPoint = new Point(0, 0, 0);
        public static Point StartPoint
        {
            get
            {
                return startPoint;
            }
        }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;

        }
        public override string ToString()
        {
            return string.Format("[{0};{1};{2}]", this.X, this.Y, this.Z);
        }
        public static bool operator == (Point A, Point B){
            if (A.X==B.X && A.Y==B.Y && A.Z==B.Z)
            {
                return true;
            }
            return false;
        }
        public static bool operator != (Point A, Point B){
            if (!(A.X==B.X && A.Y==B.Y && A.Z==B.Z))
            {
                return false;
            }
            return false;
        }



    }
}
