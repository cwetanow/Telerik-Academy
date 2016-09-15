using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Correct_brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            bool isCorrect = true;
            int numOfLeft = 0;
            int numOfRight = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i]=='(')
                {
                    numOfLeft++;
                }
                if (input[i] == ')')
                {
                    numOfRight++;
                }
                if (numOfRight>numOfLeft)
                {
                    isCorrect = false;
                    break;
                }
                
            }
            if (numOfLeft!=numOfRight)
            {
                isCorrect = false;
            }
            if (isCorrect)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
        }
    }
}
