using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework02.VerAttribute;

namespace Homework02.Matrix2D
{
    [Version(1,2)]
    class Matrix<T>
        where T : struct, IComparable, IComparable<T>,
                  IConvertible, IEquatable<T>, IFormattable
    {
        private T[,] matriks;
        private int rows;
        private int cols;
        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value");
                }
                this.rows = value;
            }
        }
        public int Cols
        {
            get
            {
                return this.cols;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid value");
                }
                this.cols = value;
            }
        }

        public T[,] Matriks
        {
            get
            {
                return this.matriks;
            }
            private set
            {
                this.matriks = value;
            }
        }
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.Matriks = new T[this.Rows, this.Cols];
            Console.WriteLine();
        }

        public T this[int rows, int cols]
        {
            get
            {
                if (rows < 0 || rows >= this.Rows || cols < 0 || cols >= this.Cols)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }
                else
                {
                    return this.Matriks[rows, cols];
                }
            }
            set
            {
                if (rows < 0 || rows >= this.Rows || cols < 0 || cols >= this.Cols)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }
                else
                {

                    this.matriks[rows, cols] = value;

                }
            }
        }
        public static Matrix<T> operator +(Matrix<T> A, Matrix<T> B)
        {
            if (A.Rows != B.Rows || A.Cols != B.Cols)
            {
                throw new ArgumentException("Matrixes not the same size");
            }
            var newMatrix = new Matrix<T>(A.Rows, B.Cols);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    dynamic a = A[i, j];
                    dynamic b = B[i, j];
                    newMatrix[i, j] = a + b;
                }
            }
            return newMatrix;
        }
        public static Matrix<T> operator -(Matrix<T> A, Matrix<T> B)
        {
            if (A.Rows != B.Rows || A.Cols != B.Cols)
            {
                throw new ArgumentException("Matrixes not the same size");
            }
            var newMatrix = new Matrix<T>(A.Rows, B.Cols);

            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    dynamic a = A[i, j];
                    dynamic b = B[i, j];
                    newMatrix[i, j] = a - b;
                }
            }
            return newMatrix;
        }

        public static bool operator true(Matrix<T> a)
        {
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    dynamic val = a[i, j];
                    if (val == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator false(Matrix<T> a)
        {
            for (int i = 0; i < a.Rows; i++)
            {
                for (int j = 0; j < a.Cols; j++)
                {
                    dynamic val = a[i, j];
                    if (val == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static Matrix<T> operator *(Matrix<T> A, Matrix<T> B) {
            if (A.Cols!=B.Rows)
            {
                throw new ArgumentException("Matrixes cannot be multiplied");
            }
            var c = new Matrix<T>(A.Rows,B.Cols);
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    dynamic product = 0;
                    for (int k = 0; k < B.Rows; k++)
                    {
                        dynamic a=A[i,k];
                        dynamic b=B[k,j];
                        product += a * b;
                    }
                    c[i, j] = product;
                }
            }
            return c;
        }
      //  public override string ToString()
      //  {
      //      var result = new StringBuilder();
      //      for (int i = 0; i < this.Rows; i++)
      //      {
      //          for (int j = 0; j < this.Cols; j++)
      //          {
      //              result.Append();
      //          }
      //      }
      //      return base.ToString();
      //  }
        
    }
}
