using System;
using System.Collections.Generic;

namespace Minesweeper
{
    public class Mine
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            char[,] field = CreatePlayfield();
            char[,] bombs = PlaceBombs();
            int counter = 0;
            bool boom = false;
            List<Point> champions = new List<Point>(6);
            int row = 0;
            int col = 0;
            bool firstFlag = true;
            const int max = 35;
            bool secondFlag = false;

            do
            {
                if (firstFlag)
                {
                    Console.WriteLine("Lets play Minesweeper. Try your luck to find fields" +
                                      " without mines. Commang 'top' shows the rankings, 'restart' starts a new game, 'exit' exits");
                    RenderField(field);
                    firstFlag = false;
                }
                Console.Write("Give a row and col : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }
                switch (command)
                {
                    case "top":
                        Ranking(champions);
                        break;
                    case "restart":
                        field = CreatePlayfield();
                        bombs = PlaceBombs();
                        RenderField(field);
                        boom = false;
                        firstFlag = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, bye, bye!");
                        break;
                    case "turn":
                        if (bombs[row, col] != '*')
                        {
                            if (bombs[row, col] == '-')
                            {
                                ChangeTurn(field, bombs, row, col);
                                counter++;
                            }
                            if (max == counter)
                            {
                                secondFlag = true;
                            }
                            else
                            {
                                RenderField(field);
                            }
                        }
                        else
                        {
                            boom = true;
                        }
                        break;
                    default:
                        Console.WriteLine("\nGreshka! nevalidna command\n");
                        break;
                }
                if (boom)
                {
                    RenderField(bombs);
                    Console.Write("\nHrrrrrr! Died with {0} Points. " +
                        "Nickname: ", counter);
                    string nick = Console.ReadLine();
                    Point top = new Point(nick, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(top);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < top.Points)
                            {
                                champions.Insert(i, top);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }
                    champions.Sort((Point pointOne, Point pointSecond) => pointSecond.Name.CompareTo(pointOne.Name));
                    champions.Sort((Point pointOne, Point pointSecond) => pointSecond.Points.CompareTo(pointOne.Points));
                    Ranking(champions);

                    field = CreatePlayfield();
                    bombs = PlaceBombs();
                    counter = 0;
                    boom = false;
                    firstFlag = true;
                }
                if (secondFlag)
                {
                    Console.WriteLine("\nGood job! You found 35 cells without mines.");
                    RenderField(bombs);
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Point point = new Point(name, counter);
                    champions.Add(point);
                    Ranking(champions);
                    field = CreatePlayfield();
                    bombs = PlaceBombs();
                    counter = 0;
                    secondFlag = false;
                    firstFlag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
            Console.WriteLine("AREEEEEEeeeeeee.");
            Console.Read();
        }

        private static void Ranking(List<Point> points)
        {
            Console.WriteLine("\nPoints:");

            if (points.Count > 0)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes",
                        i + 1, points[i].Name, points[i].Points);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty!\n");
            }
        }

        private static void ChangeTurn(char[,] field,
            char[,] bombs, int row, int column)
        {
            char bombsCount = BombsCount(bombs, row, column);
            bombs[row, column] = bombsCount;
            field[row, column] = bombsCount;
        }

        private static void RenderField(char[,] board)
        {
            int rows = board.GetLength(0);
            int cols = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < cols; j++)
                {
                    Console.Write("{0} ", board[i, j]);
                }
                Console.Write("|");
                Console.WriteLine();
            }
            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreatePlayfield()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];

            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] PlaceBombs()
        {
            int rows = 5;
            int cols = 10;
            char[,] playfield = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    playfield[i, j] = '-';
                }
            }

            List<int> numbers = new List<int>();
            while (numbers.Count < 15)
            {
                Random random = new Random();
                int number = random.Next(50);
                if (!numbers.Contains(number))
                {
                    numbers.Add(number);
                }
            }

            foreach (int i2 in numbers)
            {
                int col = (i2 / cols);
                int row = (i2 % cols);
                if (row == 0 && i2 != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }
                playfield[col, row - 1] = '*';
            }

            return playfield;
        }

        private static void Calculations(char[,] field)
        {
            int col = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < col; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char count = BombsCount(field, i, j);
                        field[i, j] = count;
                    }
                }
            }
        }

        private static char BombsCount(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }
            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }
            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }
            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }
            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }
            return char.Parse(count.ToString());
        }
    }
}
