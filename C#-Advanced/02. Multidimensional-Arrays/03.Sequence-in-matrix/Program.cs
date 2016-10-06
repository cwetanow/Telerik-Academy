using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sequence_in_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] numbers = Console.ReadLine()
      .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
      .Select(item => int.Parse(item))
      .ToArray();
           int n = numbers[0];
           int m =  numbers[1];
           int[,] matrix = new int[n, m];
     
           for (int i = 0; i < n; i++)
           {
               int[] lines = Console.ReadLine()
       .Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
       .Select(item => int.Parse(item))
       .ToArray();
               for (int j = 0; j < m; j++)
               {
                   matrix[i, j] = lines[j];
               }
     
           }
            int currentMax = 1;
            int max = 1;
            //by rows
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {                    
                    if (j<m-1 && matrix[i,j]==matrix[i,j+1])
                    {
                        currentMax++;
                        if (currentMax>max)
                        {
                            max = currentMax;
                        }
                    }
                    else
                    {
                        currentMax = 1;
                    }
           
                   
                    //Console.WriteLine("{0}{1}:{2}",i,j,currentMax);
                }
            }
            currentMax = 1;
            //by columns
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < n - 1 && matrix[j,i] == matrix[j+1, i])
                    {
                        currentMax++;
                        if (currentMax > max)
                        {
                            max = currentMax;
                        }
                    }
                    else
                    {
                        currentMax = 1;
                    }
           
           
                   // Console.WriteLine("{0}{1}:{2}", i, j, currentMax);
                }
            }
          //by diagonals
         for (int i = 0; i < n; i++)
         {
             int k = i;
             for (int j = 0; j < m; j++)
             {
                 if ((j < m - 1 && k<n-1 )&& matrix[k, j] == matrix[k+1, j + 1])
                 {
                     currentMax++;
                     if (currentMax > max)
                     {
                         max = currentMax;
                     }
                 }
                 else
                 {
                     currentMax = 1;
                 }
                 
         
               //  Console.WriteLine("{0}{1}:{2}", k, j, currentMax);
                 k++;
             }
            // Console.WriteLine();
         }
         for (int i = 0; i < n; i++)
         {
             int k = i;
             for (int j = 0; j < m; j++)
             {
                 if ((j < n - 1 && k < m - 1) && matrix[j,k] == matrix[j + 1, k + 1])
                 {
                     currentMax++;
                     if (currentMax > max)
                     {
                         max = currentMax;
                     }
                 }
                 else
                 {
                     currentMax = 1;
                 }
        
        
                // Console.WriteLine("{0}{1}:{2}", k, j, currentMax);
                 k++;
             }
            // Console.WriteLine();
         }
          for (int i = n-1; i >=0; i--)
          {
              int k = i;
              for (int j = 0; j < m; j++)
              {
                  if ((j < m - 1 && k > 0) && matrix[k, j] == matrix[k - 1, j + 1])
                  {
                      currentMax++;
                      if (currentMax > max)
                      {
                          max = currentMax;
                      }
                  }
                  else
                  {
                      currentMax = 1;
                  }


                //  Console.WriteLine("{0}{1}:{2}", k, j, currentMax);
                  k--;
              }
             // Console.WriteLine();
          }
          for (int i = n-1; i < n; i++)
          {
              int k = i;
              for (int j = 0; j < m; j++)
              {
                  if ((j < n - 1 && k < m - 1) && matrix[j, k] == matrix[j + 1, k + 1])
                  {
                      currentMax++;
                      if (currentMax > max)
                      {
                          max = currentMax;
                      }
                  }
                  else
                  {
                      currentMax = 1;
                  }


                  //Console.WriteLine("{0}{1}:{2}", k, j, currentMax);
                  k++;
              }
           //   Console.WriteLine();
          }
         // Console.WriteLine();
          for (int i = 0; i < n; i++)
          {
              for (int j = 0; j < m; j++)
              {
               //   Console.Write("{0} ",matrix[i,j]);
              }
             // Console.WriteLine();
          }
            Console.WriteLine(max);
        }
    }
}
