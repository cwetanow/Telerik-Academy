using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework05.Shapes
{
    public abstract class Shape
    {
        private double width;
        private double height;

        public double Width
        {
            get { return width; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid width");
                }
                this.width = value;
            }
        }
        public double Height
        {
            get { return this.height; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid width");
                }
                this.height = value;
            }
        }
        public Shape(double w, double h)
        {
            this.Width = w;
            this.Height = h;
        }
        public Shape()
            : this(0 , 0)
        {

        }
        public abstract double CalculateSurface();
        

    }
}
