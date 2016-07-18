using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Shapes
{
    public class Square:Shape
    {
        public Square(double w)
        {
            this.Width = w;
            this.Height = w;
        }
        public override double CalculateSurface()
        {
            return (this.Width * this.Height);
        }
        public override string ToString()
        {
            return string.Format("Square with dimensions {0}x{1}", this.Width, this.Height);
        }
    }
}
