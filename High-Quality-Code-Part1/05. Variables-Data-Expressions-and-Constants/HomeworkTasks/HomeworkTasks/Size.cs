using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkTasks
{
    public class Size
    {
        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width { get; set; }

        public double Height { get; set; }

        public static Size GetRotatedSize(Size s, double angleToRotate)
        {
            var width = Math.Abs(Math.Cos(angleToRotate)) * s.Width +
                        Math.Abs(Math.Sin(angleToRotate)) * s.Height;

            var height = Math.Abs(Math.Sin(angleToRotate)) * s.Width +
                    Math.Abs(Math.Cos(angleToRotate)) * s.Height;

            return new Size(width, height);
        }
    }
}
