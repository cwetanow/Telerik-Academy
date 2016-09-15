using System;

namespace Abstraction
{
    class FiguresExample
    {
        static void Main()
        {
            var circle = new Circle(5);
            Console.WriteLine("I am a circle. " +
                              $"My perimeter is {circle.CalcPerimeter():f2}. My surface is {circle.CalcSurface():f2}.");

            var rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. " +
                              $"My perimeter is {rect.CalcPerimeter():f2}. My surface is {rect.CalcSurface():f2}.");
        }
    }
}
