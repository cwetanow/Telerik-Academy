using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Piglets
{
    class Program
    {
        static void Main(string[] args)
        {
            var col = int.Parse(Console.ReadLine());
            var rows = int.Parse(Console.ReadLine());
            var cols = col * (rows / 2);
            var forest=new int[rows,cols];
            var forestDark=new bool[rows,cols];
            for (int i = 0; i < rows/2; i++)
            {
                for (int j = 0; j < (i+1)*2; j++)
                {
                    forest[i,j]=(j+1)*(i+1);
                }
            }
            for (int i = rows/2; i < rows / 2; i++)
            {
                for (int j = 0; j < (i + 1) * 2; j++)
                {
                    forest[i, j] = (j + 1) * (i + 1);
                }
            }
            var colscount=new int[rows];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (forest[i,j]>0)
                    {
                        colscount[i]++;
                    }
                }
               
            }
            for (int i = rows/2; i < rows; i++)
            {
                colscount[i] = colscount[rows/2-(i-rows/2)-1];
            }
      
            //now it begins
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var porcX = numbers[0];
            var porcY = numbers[1];
            var porPts = 0;
            numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var rabX = numbers[0];
            var rabY = numbers[1];
            var rabPts = 0;
            var instructions=new List<string[]>();
           forestDark[rabX,rabY]=true;
            forestDark[porcX,porcY]=true;
            for (int i = 0; i < 50; i++)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else
                {
                    instructions.Add(input.Split(' '));
                }
            }
            int tempp;
            for (int i = 0; i < instructions.Count; i++)
            {
                if (instructions[i][0]=="R")
                {
                    
                    switch (instructions[i][1])
                    {
                        case "L":
                        case "R":
                            {
                                
                                forestDark[rabX, rabY] = false;
                                if (instructions[i][1]=="L")
                                {
                                    tempp= -int.Parse( instructions[i][2]) % colscount[rabX];
                                }
                                else
                                {
                                    tempp = int.Parse(instructions[i][2]) % colscount[rabX];
                                }
                               
                                rabY += tempp;

                                if (rabY > colscount[rabX]-1)
                                {
                                    rabY -= colscount[rabX];
                                }
                                else if (rabY < 0)
                                {
                                    rabY += colscount[rabX];
                                }
                                if (forestDark[rabX,rabY])
                                {
                                    if (instructions[i][1]=="L")
                                    {
                                        rabY++;
                                    }
                                    else
                                    {
                                        rabY--;
                                    }
                                    
                                }
                               
                                rabPts += forest[rabX, rabY];
                                
                                forestDark[rabX, rabY] = true;

                            }                            
                            break;
                        default:
                            {
                                forestDark[rabX, rabY] = false;
                                if (instructions[i][1] == "T")
                                {
                                    tempp = -int.Parse(instructions[i][2]) % rows;
                                }
                                else
                                {
                                    tempp = int.Parse(instructions[i][2]) % rows;
                                }

                                rabX += tempp;

                                if (rabX > rows - 1)
                                {
                                    rabX -= rows;
                                }
                                else if (rabX < 0)
                                {
                                    rabX += rows;
                                }
                                if (forestDark[rabX, rabY])
                                {
                                    if (instructions[i][1] == "T")
                                    {
                                        rabY++;
                                    }
                                    else
                                    {
                                        rabY--;
                                    }

                                }
                                rabPts += forest[rabX, rabY];
                                forestDark[rabX, rabY] = true;
                            }

                            break;
                    }
                }
                else
                {

                }
            }

            //output
            Output(rabPts, porPts);
           
        }
        static void Output(int rabbit, int piglet) {
            if (rabbit > piglet)
            {
                Console.WriteLine("The rabbit WON with {0} points. The porcupine scored {1} points only.", rabbit, piglet);
            }
            else if (rabbit < piglet)
            {
                Console.WriteLine("The porcupine destroyed the rabbit with {0} points. The rabbit must work harder. He scored {1} points only.", piglet, rabbit);
            }
            else
            {
                Console.WriteLine("Both units scored {0} points. Maybe we should play again?", piglet);
            }
        }
        
    }
}
