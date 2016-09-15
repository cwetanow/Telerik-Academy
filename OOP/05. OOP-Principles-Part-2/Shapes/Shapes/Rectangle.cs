using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double w, double h)
        {
            this.Width = w;
            this.Height = h;
        }
        public override double CalculateSurface()
        {
            return (this.Width * this.Height);
        }
        public override string ToString()
        {
            return string.Format("Rectangle with dimensions {0}x{1}",this.Width,this.Height);
        }
    }
}
