using System;

namespace Abstraction
{
    public abstract class Figure
    {
        private double width;
        private double height;
        private double radius;

        protected Figure()
        {
        }

        protected Figure(double radius)
        {
            this.Radius = radius;
        }

        protected Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }


        public virtual double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.IsSideValid(value);

                this.width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.IsSideValid(value);

                this.height = value;
            }
        }

        public virtual double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                this.IsSideValid(value);

                this.radius = value;
            }
        }

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        protected void IsSideValid(double side)
        {
            if (side < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}
