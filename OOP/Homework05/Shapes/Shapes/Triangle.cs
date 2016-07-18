using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Shapes
{
    public class Triangle : Shape
    {

        public Triangle(double w, double h)
        {
            this.Width = w;
            this.Height = h;
        }
        public override double CalculateSurface()
        {
            return (this.Width * this.Height) / 2;
        }
        public override string ToString()
        {
            return string.Format("Triangle with dimensions {0}x{1}", this.Width, this.Height);
        }
    }
}
