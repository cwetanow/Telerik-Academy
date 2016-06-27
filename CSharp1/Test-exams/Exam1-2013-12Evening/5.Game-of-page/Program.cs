using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Game_of_page
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] plate = new string[16];
            double paycheck = 1.79;
            for (int i = 0; i < 16; i++)
            {
                plate[i] = Console.ReadLine();
            }
            int row, col;
            do
            {

                Console.WriteLine("asdad");
                string question = Console.ReadLine();
                if (question=="what is")
	            {
		            row = int.Parse(Console.ReadLine());
                    col = int.Parse(Console.ReadLine());
                    if (plate[row][col] == '1' && (row == 0 || col == 0 || row == 15 || col == 15) ||
                        (plate[row][col] == '1' &&
                      (plate[row - 1][col - 1] == '0' || plate[row - 1][col] == '0' || plate[row - 1][col + 1] == '0' || plate[row][col - 1] == '0' || plate[row][col + 1] == '0'
                      || plate[row + 1][col - 1] == '0' || plate[row + 1][col] == '0' || plate[row + 1][col + 1] == '0')))
	                {
		                Console.WriteLine("broken cookie");
                    }
                    else if (plate[row][col]=='1' && 
                        plate[row-1][col-1]=='1' && plate[row-1][col]=='1' && plate[row-1][col+1]=='1' && plate[row][col-1]=='1' && plate[row][col+1]=='1' 
                        && plate[row+1][col-1]=='1' && plate[row+1][col]=='1' && plate[row+1][col+1]=='1')
                    {
                        Console.WriteLine("cookie");
                    }
                    else if (plate[row][col] == '1' &&
                      plate[row - 1][col - 1] == '0' && plate[row - 1][col] == '0' && plate[row - 1][col + 1] == '0' && plate[row][col - 1] == '0' && plate[row][col + 1] == '0'
                      && plate[row + 1][col - 1] == '0' && plate[row + 1][col] == '0' && plate[row + 1][col + 1] == '0')
                    {
                        Console.WriteLine("cookie crumb");
                    }
                }
                else if (question=="buy")
                {
                    row = int.Parse(Console.ReadLine());
                    col = int.Parse(Console.ReadLine());
                    if (plate[row][col]=='0')
                    {
                        Console.WriteLine("smile");
                    }
                    else if ((plate[row][col] == '1' && (row == 0 || col == 0 || row == 15 || col == 15) ||
                        (plate[row][col] == '1' &&
                      (plate[row - 1][col - 1] == '0' || plate[row - 1][col] == '0' || plate[row - 1][col + 1] == '0' || plate[row][col - 1] == '0' || plate[row][col + 1] == '0'
                      || plate[row + 1][col - 1] == '0' || plate[row + 1][col] == '0' || plate[row + 1][col + 1] == '0'))) || (plate[row][col] == '1' &&
                      plate[row - 1][col - 1] == '0' && plate[row - 1][col] == '0' && plate[row - 1][col + 1] == '0' && plate[row][col - 1] == '0' && plate[row][col + 1] == '0'
                      && plate[row + 1][col - 1] == '0' && plate[row + 1][col] == '0' && plate[row + 1][col + 1] == '0'))
                    {
                        Console.WriteLine("page");
                    }
                    else
                    {
                        paycheck += paycheck;
                    }
                }
                else if (question=="paypal")
                {
                    Console.WriteLine(paycheck);
                    break;
                }

            } while (true);
        }
    }
}
