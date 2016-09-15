using HomeworkTasks.Utils;

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

        public static Size GetRotatedSize(Size size, double angleToRotate)
        {
            var width = Calculator.AbsoluteCos(angleToRotate) * size.Width +
                        Calculator.AbsoluteSin(angleToRotate) * size.Height;

            var height = Calculator.AbsoluteSin(angleToRotate) * size.Width +
                    Calculator.AbsoluteCos(angleToRotate) * size.Height;

            return new Size(width, height);
        }
    }
}
