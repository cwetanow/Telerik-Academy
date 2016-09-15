using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Largest_area_matrix
{
    class Program
    {
        private static bool[,] isVisited;
        private static short[,] matrix;
        private static short max = 0;
        private static short current = 0;
        private static short n; // matrix.GetLength(0) is slow 
        private static short m; // matrix.GetLength(1) is slow
        static void Spreading(short row, short col, short currentElement) {
            if ((row < 0 || col < 0 || row >= n || col >= m || currentElement != matrix[row, col]))
            {
                return;
            }
            if (isVisited[row,col])
            {
                return;
            }
            isVisited[row, col] = true;
            current++;
            Spreading((short)(row - 1), col, currentElement); // up
            Spreading((short)(row + 1), col, currentElement); // down    
            Spreading(row, (short)(col - 1), currentElement); // left        
            Spreading(row, (short)(col + 1), currentElement); // right 
        }
        static void Main(string[] args)
        {
          short[] numbers = Console.ReadLine()
        .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
       .Select(item => short.Parse(item))
        .ToArray();
          n = numbers[0];
          m = numbers[1];
     matrix = new short[n, m];
            
          isVisited = new bool[n, m];
          for (int i = 0; i < n; i++)
          {
             short[] lines = Console.ReadLine()
               .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
               .Select(item => short.Parse(item))
              .ToArray();
             for (int j = 0; j < m; j++)
              {
                  matrix[i, j] = lines[j];
                  isVisited[i, j] = false;

              }
     //  
         }
           
          
            
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    
                    Spreading((short)i,(short)j,matrix[i,j]);
                   
                    if (current>max)
                    {
                        max = current;
                    }
                    current = 0;
                }
            }
         ;
          
            Console.WriteLine("{0}", max);
            
            
        }
    }
}
