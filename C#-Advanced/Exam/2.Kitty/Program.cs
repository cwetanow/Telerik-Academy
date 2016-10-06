using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Kitty
{
    class Program
    {

        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToArray();
            var path = Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();

            var souls = 0;
            var food = 0;
            var locks = 0;
            var jumps = 0;
            var busted = false;

            if (input[0] == 'x')
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine($"Jumps before deadlock: {jumps}");
            }
            else
            {
                if (input[0] == '@')
                {
                    souls++;
                }
                else
                {
                    food++;
                }

                input[0] = 'c';

                var currentPlace = 0;

                for (int i = 0; i < path.Length; i++)
                {
                    jumps = i + 1;

                    path[i] %= input.Length;
                    currentPlace += path[i];

                    //Make sure the kitty is always in the field
                    if (currentPlace > input.Length - 1)
                    {
                        currentPlace -= input.Length;
                    }
                    else if (currentPlace < 0)
                    {
                        currentPlace += input.Length;
                    }

                    if (input[currentPlace] == '@')
                    {
                        souls++;
                        input[currentPlace] = 'c';
                    }
                    else if (input[currentPlace] == '*')
                    {
                        food++;
                        input[currentPlace] = 'c';
                    }
                    else if (input[currentPlace] == 'x')
                    {
                        if (currentPlace % 2 == 0)
                        {
                            if (souls > 0)
                            {
                                souls--;
                                locks++;
                                input[currentPlace] = '*';
                            }
                            else if (souls == 0)
                            {
                                Console.WriteLine("You are deadlocked, you greedy kitty!");
                                Console.WriteLine($"Jumps before deadlock: {jumps}");
                                busted = true;
                                break;
                            }
                        }
                        else if (currentPlace % 2 == 1)
                        {
                            if (food > 0)
                            {
                                food--;
                                locks++;
                                input[currentPlace] = '@';
                            }
                            else if (food == 0)
                            {
                                Console.WriteLine("You are deadlocked, you greedy kitty!");
                                Console.WriteLine($"Jumps before deadlock: {jumps}");
                                busted = true;
                                break;
                            }
                        }
                    }
                }

                if (!busted)
                {
                    Console.WriteLine($"Coder souls collected: {souls}");
                    Console.WriteLine($"Food collected: {food}");
                    Console.WriteLine($"Deadlocks: {locks}");
                }

            }

        }
    }
}
