using System;
using System.Collections.Generic;

namespace ReversePolishNotation
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var expression = Console.ReadLine();

            var result = CalculateExpression(expression);

            Console.WriteLine(result);
        }

        private static int CalculateExpression(string expression)
        {
            var stack = new Stack<int>();

            var result = 0;

            var splittedExpression = expression.Split(' ');

            for (var i = 0; i < splittedExpression.Length; i++)
            {
                var current = splittedExpression[i];
                int num;

                if (int.TryParse(current, out num))
                {
                    stack.Push(num);
                }
                else
                {
                    var rightSide = stack.Pop();
                    var leftSide = stack.Pop();

                    var resultOfCalculation = Evaluate(leftSide, rightSide, current);
                    stack.Push(resultOfCalculation);
                }
            }

            result = stack.Pop();

            return result;
        }

        private static int Evaluate(int left, int right, string sign)
        {
            var result = 0;
            switch (sign)
            {
                case "+":
                    result = left + right;
                    break;
                case "-":
                    result = left - right;
                    break;
                case "*":
                    result = left * right;
                    break;
                case "/":
                    result = left / right;
                    break;
                case "&":
                    result = left & right;
                    break;
                case "|":
                    result = left | right;
                    break;
                case "^":
                    result = left ^ right;
                    break;
                default:
                    throw new ArgumentException();
            }

            return result;
        }
    }
}
