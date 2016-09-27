using System;
using System.Text;
using NUnit.Framework;

namespace Matrica.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        private static int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        private const int n = 3;

        [TestCase]
        public void GetFinalMatrixTests_ShouldReturnCorrectString()
        {
            var result = GameFifteen.Matrix.GetFinalMatrix(matrix, n);

            var expected = new StringBuilder();

            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    expected.Append($"{matrix[i, j],3}");
                }

                if (i < n - 1)
                {
                    expected.AppendLine();
                }
            }

            Assert.AreEqual(expected.ToString(), result);
        }
    }
}
