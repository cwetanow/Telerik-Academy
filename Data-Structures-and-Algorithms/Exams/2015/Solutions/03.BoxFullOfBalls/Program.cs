using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.BoxFullOfBalls
{
    class Program
    {
        private static List<int> moves;


        static void Main(string[] args)
        {
            moves = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            moves.Sort();

            var ballsInterval = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var a = ballsInterval[0];
            var b = ballsInterval[1];

            var mikisWins = 0;

            var totals = PlayMemorized(b);

            for (var balls = a; balls <= b; balls++)
            {
                if (totals[balls])
                {
                    mikisWins++;
                }
            }

            Console.WriteLine(mikisWins);
        }

        public static bool Play(int ballsLeft, bool isFirstPlayer)
        {
            if (moves.Contains(ballsLeft))
            {
                return true;
            }

            foreach (var move in moves)
            {
                var balls = ballsLeft - move;
                if (balls < 0)
                {
                    break;
                }

                if (!Play(balls, !isFirstPlayer))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool[] PlayMemorized(int balls)
        {
            var plays = new bool[balls + 1];
            plays[0] = false;

            for (var i = 1; i <= balls; i++)
            {
                foreach (var move in moves)
                {
                    if (move > i)
                    {
                        break;
                    }

                    if (!plays[i - move])
                    {
                        plays[i] = true;
                    }
                }
            }

            return plays;
        }
    }
}
