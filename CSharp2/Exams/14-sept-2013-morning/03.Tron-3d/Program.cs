using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Tron_3d
{
    class Program
    {
        static char DirectionChange(char current, char wherePosoka)
        {
            switch (current)
            {
                case 'u':
                    if (wherePosoka=='L')
                    {
                        return 'l';
                    }
                    else
                    {
                        return 'r';
                    }  
                    
                case 'd':
                    if (wherePosoka == 'L')
                    {
                        return 'r';
                    }
                    else
                    {
                        return 'l';
                    }  
                case 'l':
                    if (wherePosoka == 'L')
                    {
                        return 'd';
                    }
                    else
                    {
                        return 'u';
                    }  
                   
                default:
                    if (wherePosoka == 'L')
                    {
                        return 'u';
                    }
                    else
                    {
                        return 'd';
                    }  

            }
        }
        static void Main(string[] args)
        {
            //input
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var x = dimensions[0];
            var y = dimensions[1];
            var z = dimensions[2];
            var red = Console.ReadLine();
            var blue = Console.ReadLine();
            var height = x + 1;
            var width = 2 * (y + z) + 4;
            var matrix = new byte[height, width];
            matrix[x / 2, y / 2] = 1;
            matrix[x / 2, y + z + 2 + y / 2] = 2;
            var redPosoka = 'r';
            var bluePosoka = 'l';
            int redX = x / 2, redY = y / 2;
            int blueX = x / 2, blueY = y + z + 2 + y / 2;
            string winner = "";
            bool redChange;
            bool blueChange;
            bool redCrash = false;
            int redStartX = redX;
            int redStartY = redY;
            bool blueCrash = false; ;
       
            for (int i = 0; i < red.Length; i++)
            {
                redChange = false;
                blueChange = false;
                //change direction of going
                switch (red[i])
                {
                    case 'R':
                    case 'L':
                        redPosoka = DirectionChange(redPosoka, red[i]);
                        redChange = true;
                        break;
                    default:
                        break;
                }
                switch (blue[i])
                {
                    case 'R':
                    case 'L':
                        bluePosoka = DirectionChange(bluePosoka, blue[i]);
                        blueChange = true;
                        break;
                    default:
                        break;
                }
                //red movement
                if (!redCrash)
                {
                    if (!redChange)
                    {
                        switch (redPosoka)
                        {
                            case 'u':
                                if (CanGoThere(redX-1, redY, matrix, height, width, 'u', 2))
                                {
                                    matrix[redX - 1, redY] = 1;
                                    redX--;
                                }
                                else
                                {
                                    redCrash = true;
                                    
                                }
                                break;
                            case 'd':
                                if (CanGoThere(redX+1, redY, matrix, height, width, 'd', 2))
                                {
                                    matrix[redX + 1, redY] = 1;
                                    redX++;
                                }
                                else
                                {
                                    redCrash = true;
                                    
                                }
                                break;
                            case 'l':
                                if (CanGoThere(redX, redY-1, matrix, height, width, 'l', 2))
                                {
                                    matrix[redX , redY-1] = 1;
                                    redY--;
                                }
                                else
                                {
                                    redCrash = true;
                                 
                                }
                                break;
                            case 'r':
                                if (CanGoThere(redX, redY+1, matrix, height, width, 'r', 2))
                                {
                                    matrix[redX, redY+1] = 1;
                                    redY++;
                                }
                                else
                                {
                                    redCrash = true;
                                    
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    
                }
                //blue movement
                if (!blueCrash)
                {
                    if (!blueChange)
                    {
                        switch (bluePosoka)
                        {
                            case 'u':
                                if (CanGoThere(blueX - 1, blueY, matrix, height, width, 'u', 1))
                                {
                                    matrix[blueX - 1, blueY] = 2;
                                    blueX--;
                                }
                                else
                                {
                                    blueCrash = true;
                                    
                                }
                                break;
                            case 'd':
                                if (CanGoThere(blueX + 1, blueY, matrix, height, width, 'd', 1))
                                {
                                    matrix[blueX + 1, blueY] = 1;
                                    blueX++;
                                }
                                else
                                {
                                    blueCrash = true;
                                   
                                }
                                break;
                            case 'l':
                                if (CanGoThere(blueX, blueY - 1, matrix, height, width, 'l', 1))
                                {
                                    matrix[blueX, blueY - 1] = 1;
                                    blueY--;
                                }
                                else
                                {
                                    blueCrash = true;
                                    
                                }
                                break;
                            case 'r':
                                if (CanGoThere(blueX, blueY + 1, matrix, height, width, 'r', 1))
                                {
                                    matrix[blueX, blueY + 1] = 1;
                                    blueY++;
                                }
                                else
                                {
                                    blueCrash = true;
                                   
                                }
                                break;
                            default:
                                break;
                        }
                    }

                }

                if (redCrash || blueCrash)
                {
                    break;
                }

            }
            if (redCrash && blueCrash)
            {
                winner = "DRAW";
            }
            else if (redCrash)
            {
                winner = "BLUE";
            }
            else if (blueCrash)
            {
                winner = "RED";
            }
            else
            {
                winner = "DRAW";
            }
            int redDist = Math.Abs(redX - redStartX) + Math.Abs(redY-redStartY);
            Console.WriteLine(redX);
            Console.WriteLine(redY);
            Console.WriteLine(winner);
            Console.WriteLine(redDist);
        }
        static bool CanGoThere(int x, int y, byte[,] matrix, int mH, int mW, char direction, int numberOfOther)
        {
            switch (direction)
            {
                case 'u':
                    if (x==0)
                    {
                        return false;
                    }
                    else if (matrix[x-1,y]==numberOfOther)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    
                case 'd':
                    if (x == mH-1)
                    {
                        return false;
                    }
                    else if (matrix[x + 1, y] == numberOfOther)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case 'l':
                    if (y == 0)
                    {
                        return false;
                    }
                    else if (matrix[x , y-1] == numberOfOther)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                case 'r':
                    if (y==mW-1)
                    {
                        return false;
                    }
                    else if (matrix[x,y+1] == numberOfOther)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                default:
                    break;
            }
            return true;
        }
    }
}
