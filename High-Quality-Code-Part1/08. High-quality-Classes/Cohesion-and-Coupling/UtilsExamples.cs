using System;
using CohesionAndCoupling.Utils;

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(FileNameHelper.GetFileExtension("example"));
            Console.WriteLine(FileNameHelper.GetFileExtension("example.pdf"));
            Console.WriteLine(FileNameHelper.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileNameHelper.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileNameHelper.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileNameHelper.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine($"Distance in the 2D space = {TwoDimensionalCalculator.CalcDistance2D(1, -2, 3, 4):f2}");
            Console.WriteLine(
                $"Distance in the 3D space = {ThreeDimensionalCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4):f2}");

            var width = 3;
            var height = 4;
            var depth = 5;

            Console.WriteLine($"Volume = {ThreeDimensionalCalculator.CalcVolume(width, height, depth):f2}");
            Console.WriteLine($"Diagonal XYZ = {ThreeDimensionalCalculator.CalcDiagonalXYZ(width, height, depth):f2}");

            Console.WriteLine($"Diagonal XY = {TwoDimensionalCalculator.CalcDiagonalXY(width, height):f2}");
            Console.WriteLine($"Diagonal XZ = {TwoDimensionalCalculator.CalcDiagonalXZ(width, depth):f2}");
            Console.WriteLine($"Diagonal YZ = {TwoDimensionalCalculator.CalcDiagonalYZ(height, depth):f2}");
        }
    }
}
