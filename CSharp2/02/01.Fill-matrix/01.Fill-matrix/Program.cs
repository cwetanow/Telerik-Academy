using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Fill_matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char ch = Console.ReadLine()[0];
            int[,] matrix = new int[n, n];
            int k;
            switch (ch)
            {
                case 'a':
                    k = 1;
                    for (int j  = 0; j < n; j++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            matrix[i,j] = k;
                            k++;
                        }
                    }
                    break;
                case 'b':
                    k = 1;
                    for (int j = 0; j < n; j++)
                    {
                        if (j%2==1)
                        {
                            for (int i = n-1; i >=0; i--)
                            {
                                matrix[i, j] = k;
                                k++;
                            }
                        }
                        else
                        {
                            for (int i = 0; i < n; i++)
                            {
                                matrix[i, j] = k;
                                k++;
                            }
                        }
                        
                    }
                    break;

                case 'c':
                    k = 1;
                    
                    for (int i = n; i >=0 ; i--)
                    {
                        int counter = 0;
                        for (int j = 0; j <n-i; j++)
                        {
                            
                                matrix[i+counter,j] = k;
                            k++;
                            counter++;
                            
                        }
                    }
                    for (int i = 1; i < n; i++)
                    {
                        int count = 0;
                        for (int j = i; j < n; j++)
                        {

                            matrix[count, j] = k;
                            k++;
                            count++;

                        }
                    }                                      
                   break;

                default:
                   
                   int row = 0;
                   int col = 0;
                   char direction = 'd';
                   int max = n;
                   int min = 0;
                 
                   for (int i = 1; i < n*n+1; i++)
                   {
                      
                       if (matrix[row, col] == 0)
                       {
                           matrix[row, col] = i;
                       }
                       if (direction=='l' && col==min+1)
                       {
                           max--;
                           min++;
                           
                       }
                       
                       
                      
                       switch (direction)
                       {
                           case 'u':
                               if (row > min)
                               {
                                   row--;
                               }
                               else
                               {
                                   direction = 'l';
                                   col--;
                                   
                               }
                               
                               break;
                           case 'l':
                               if (col > min)
                               {
                                   col--;
                               }
                               else
                               {
                                   direction = 'd';
                                   row++;
                                   
                               }
                               break;
                           case 'r':
                               if (col < max - 1)
                               {
                                   col++;
                               }
                               else
                               {
                                   direction = 'u';
                                   row--;
                                  
                               }
                               break;
                           case 'd':
                               if (row < max - 1)
                               {
                                   row++;
                               }
                               else
                               {
                                   direction = 'r';
                                   col++;
                                   
                               }

                               break;
                           default:
                               break;
                       }
                       
                     
                   }
                    break;
            }
           
            //output
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j==n-1)
                    {
                        Console.Write("{0}", matrix[i, j]);
                    }
                    else
                    {
                        Console.Write("{0} ", matrix[i, j]);
                    }
                    
                }
                Console.WriteLine();
            }
            

        }
    }
}
