using System;
using System.Text;

namespace GameFifteen
{
    public class Matrix
    {
        public static int[] DeltaX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        public static int[] DeltaY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static void Change(ref int dimensionX, ref int dimensionY)
        {
            var counter = 0;
            for (var index = 0; index < 8; index++)
            {
                if (DeltaX[index] == dimensionX && DeltaY[index] == dimensionY)
                {
                    counter = index;
                    break;
                }
            }

            if (counter == 7)
            {
                dimensionX = DeltaX[0];
                dimensionY = DeltaY[0];
                return;
            }

            dimensionX = DeltaX[counter + 1];
            dimensionY = DeltaY[counter + 1];
        }

        public static bool Check(int[,] arr, int x, int y)
        {
            for (var i = 0; i < 8; i++)
            {
                if (x + DeltaX[i] >= arr.GetLength(0) || x + DeltaX[i] < 0)
                {
                    DeltaX[i] = 0;
                }

                if (y + DeltaY[i] >= arr.GetLength(0) || y + DeltaY[i] < 0)
                {
                    DeltaY[i] = 0;
                }
            }

            for (var i = 0; i < 8; i++)
            {
                if (arr[x + DeltaX[i], y + DeltaY[i]] == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public static void FindCell(int[,] arr, out int x, out int y)
        {
            x = 0;
            y = 0;

            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(0); j++)
                {
                    if (arr[i, j] == 0)
                    {
                        x = i;
                        y = j;

                        return;
                    }
                }
            }

        }

        public static int[,] GetMatrixByDimensions(int dimensions)
        {
            return new int[dimensions, dimensions];
        }

        public static void Main(string[] args)
        {
            //Console.WriteLine( "Enter a positive number " );
            //string input = Console.ReadLine(  );
            //int n = 0;
            //while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            //{
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            //}

            var dimensions = 3;
            var matrix = GetMatrixByDimensions(dimensions);

            var counter = 1;
            var row = 0;
            var col = 0;
            PlaceMatrixNumbers(ref matrix, ref row, ref col, ref counter, dimensions);

            var printedMatrix = GetFinalMatrix(matrix, dimensions);

            Console.WriteLine(printedMatrix);

            FindCell(matrix, out row, out col);

            if (row != 0 && col != 0)
            {
                PlaceMatrixNumbers(ref matrix, ref row, ref col, ref counter, dimensions);
            }

            printedMatrix = GetFinalMatrix(matrix, dimensions);

            Console.WriteLine(printedMatrix);
        }

        public static void PlaceMatrixNumbers(ref int[,] matrix, ref int row, ref int col, ref int counter, int n)
        {
            var dimensionX = 1;
            var dimensionY = 1;
            matrix[row, col] = counter;

            while (Check(matrix, row, col))
            {
                if (row + dimensionX >= n ||
                    row + dimensionX < 0 ||
                    col + dimensionY >= n ||
                    col + dimensionY < 0 ||
                    matrix[row + dimensionX, col + dimensionY] != 0)
                {
                    while ((row + dimensionX >= n ||
                        row + dimensionX < 0 ||
                        col + dimensionY >= n ||
                        col + dimensionY < 0 ||
                        matrix[row + dimensionX, col + dimensionY] != 0))
                    {
                        Change(ref dimensionX, ref dimensionY);
                    }
                }

                row += dimensionX;
                col += dimensionY;
                counter++;

                matrix[row, col] = counter;
            }
        }

        public static string GetFinalMatrix(int[,] array, int dimension)
        {
            var result = new StringBuilder();

            for (var i = 0; i < dimension; i++)
            {
                for (var j = 0; j < dimension; j++)
                {
                    result.Append($"{array[i, j],3}");
                }

                if (i < dimension - 1)
                {
                    result.AppendLine();
                }
            }

            return result.ToString();
        }
    }
}
