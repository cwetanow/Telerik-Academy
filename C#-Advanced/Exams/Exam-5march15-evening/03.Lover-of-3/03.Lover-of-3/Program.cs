using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Lover_of_3
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var rows = dimensions[0];
            var cols = dimensions[1];
            var matrix = new int[rows, cols];
            var visited=new bool[rows,cols];
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = (rows - 1 - i) * 3 + j * 3;
                }
            }
            var n = int.Parse(Console.ReadLine());
            var acc=new string[2];
            var directions = new string[n];
            var moves = new int[n];
            for (int i = 0; i < n; i++)
            {
                acc = Console.ReadLine().Split();
                moves[i] = int.Parse(acc[1]);
                directions[i] = acc[0];

            }
            long sum = 0;
            
            int currentCol = 0;
            int currentRow = rows - 1;
            for (int i = 0; i < n; i++)
            {
                switch (directions[i])
                {
                        //right down
                    case "RD":
                    case "DR":
                        for (int j = 0; j < moves[i] - 1; j++)
                        {                           
                                                     
                            currentCol++;
                            currentRow++;
                            if (currentRow <rows && currentCol < cols && !visited[currentRow, currentCol])
                            {
                                sum += matrix[currentRow, currentCol];
                                visited[currentRow, currentCol] = true;
                                if (currentCol == cols - 1 || currentRow == rows-1)
                                {
                                    break;
                                }
                            }
                            if (currentCol == cols || currentRow == rows)
                            {
                                currentCol--;
                                currentRow--;
                                break;
                            }   
                        }
                        break;
                    case "DL":
                    case "LD":
                        for (int j = 0; j < moves[i] - 1; j++)
                        {                            
                            
                            currentCol--;
                            currentRow++;
                            if (currentRow <rows && currentCol >-1 && !visited[currentRow, currentCol])
                            {
                                sum += matrix[currentRow, currentCol];
                                visited[currentRow, currentCol] = true;
                                if (currentCol == 0 || currentRow == 0)
                                {
                                    break;
                                }
                            }
                            if (currentCol == -1 || currentRow == rows)
                            {
                                currentCol++;
                                currentRow--;
                                break;
                            }
                        }
                        break;

                    case "LU":
                    case "UL":
                        for (int j = 0; j < moves[i]-1; j++)
                        {
                                                
                            currentCol--;
                            currentRow--;
                            if (currentRow > -1 && currentCol >-1 && !visited[currentRow, currentCol])
                            {
                          
                                sum += matrix[currentRow, currentCol];
                                visited[currentRow, currentCol] = true;
                                if (currentCol==0 || currentRow==0)
                                {
                                    break;
                                }
                            }
                            if (currentCol == -1 || currentRow == -1)
                            {
                                currentCol++;
                                currentRow++;
                                break;
                            }      
                        }
                        break;

                    case "RU":
                    case "UR":
                        for (int j = 0; j < moves[i] - 1; j++)
                        {
                                                  
                            currentCol++;
                            currentRow--;
                            if (currentRow > -1 && currentCol <cols && !visited[currentRow, currentCol])
                            {
                                sum += matrix[currentRow, currentCol];
                                visited[currentRow, currentCol] = true;
                                if (currentCol == cols-1 || currentRow == 0)
                                {
                                    break;
                                }
                            }
                            if (currentCol == cols || currentRow == -1)
                            {
                                currentCol--;
                                currentRow++;
                                break;
                            }      
                        }
                        break;
                   
                    default:
                        break;
                }
                
            }
            Console.WriteLine(sum);
           

        }
    }
}
