using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework01.GSM
{
    class Display
    {
        private double? size;
        private int? numberColors;

        public double? Size
        {
            get
            {
                return this.size;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid size of display");
                }
                this.size = value;
            }
        }
        public int? NumberColors
        {
            get
            {
                return this.numberColors;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid number of colors");
                }
                this.numberColors = value;
            }
        }

        public Display(double? size, int? numberOfCol)
        {
            this.Size = size;
            this.numberColors = numberOfCol;
        }
        public Display()
            : this(null, null)
        {

        }
        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Size: ");
            result.Append(this.Size);
            result.Append(" / Number of colors: ");
            result.Append(this.NumberColors);
            return result.ToString();
        } 
    }
}
