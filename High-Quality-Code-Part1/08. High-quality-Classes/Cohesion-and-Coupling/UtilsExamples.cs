using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            Console.WriteLine(Utils.GetFileExtension("example"));
            Console.WriteLine(Utils.GetFileExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(Utils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(Utils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine($"Distance in the 2D space = {Utils.CalcDistance2D(1, -2, 3, 4):f2}");
            Console.WriteLine("Distance in the 3D space = {0:f2}",
                Utils.CalcDistance3D(5, 2, -1, 3, -6, 4));

            Utils.Width = 3;
            Utils.Height = 4;
            Utils.Depth = 5;
            Console.WriteLine($"Volume = {Utils.CalcVolume():f2}");
            Console.WriteLine($"Diagonal XYZ = {Utils.CalcDiagonalXYZ():f2}");
            Console.WriteLine($"Diagonal XY = {Utils.CalcDiagonalXY():f2}");
            Console.WriteLine($"Diagonal XZ = {Utils.CalcDiagonalXZ():f2}");
            Console.WriteLine($"Diagonal YZ = {Utils.CalcDiagonalYZ():f2}");
        }
    }
}
