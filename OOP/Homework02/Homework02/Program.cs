using System;
using Homework02.Matrix2D;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework02.Point3D;
using Homework02.Paths;
using Homework02.Generic;
using Homework02.VerAttribute;
using System.Reflection;

namespace Homework02
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var a = new Point(1, 2, 3);
            var b = new Point(2, 3, 4);
            var c = Point.StartPoint;
            var path = new Path();
            path.Add(a);
            path.Add(c);
            path.Add(b);
            PathStorage.SavePath(path, "path");
            path = PathStorage.LoadPath("path");
            var list = new GenericList<int>(10);



            for (int i = 0; i < 10; i++)
            {
                list[i] = i + 1;
                Console.WriteLine(list[i]);
            }
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());
            list[10] = 11;
            Console.WriteLine(list);
            list.Insert(5, 4);
            Console.WriteLine(list);
            list.Remove(2);
            Console.WriteLine(list);            
            Console.WriteLine(list.FindElement(2));
            list.Clear();
            Console.WriteLine(list);
            Console.WriteLine();
            var A = new Matrix<int>(3,3);
            var B = new Matrix<int>(3, 3);
            Console.WriteLine("A:");
            int k = 1;
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Cols; j++)
                {
                    A[i, j] = k;
                    k++;
                }
            }
            k = 10;
            Console.WriteLine("B:");
            for (int i = 0; i < B.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    B[i, j] = k;
                    k--;
                }
            }
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Cols; j++)
                {
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            
            for (int i = 0; i < B.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Sum");
            var C = A + B;
            for (int i = 0; i < B.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    Console.Write(C[i, j] + " ");
                }
                Console.WriteLine();
            }

            var D = A - B;
            Console.WriteLine("Difference");
            for (int i = 0; i < B.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    Console.Write(D[i, j] + " ");
                }
                Console.WriteLine();
            }
            var E = A * B;
            
            Console.WriteLine("Multiplication");
            for (int i = 0; i < B.Rows; i++)
            {
                for (int j = 0; j < B.Cols; j++)
                {
                    Console.Write(E[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();

            Console.WriteLine(typeof(Matrix<int>).GetCustomAttribute(typeof(VersionAttribute)));
            
        }
    }
}
