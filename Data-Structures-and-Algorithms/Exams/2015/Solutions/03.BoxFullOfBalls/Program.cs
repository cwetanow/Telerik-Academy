using System;
using System.Linq;

namespace _03.BoxFullOfBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            var possibleTurns = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToList();

            var ballsInterval = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var a = ballsInterval[0];
            var b = ballsInterval[1];
            var gamesPlayed = b - a + 1;

            var mikisWins = 0;

            for (var i = a; i <= b; i++)
            {
                
            }

            Console.WriteLine(mikisWins);
        }
    }
}
