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
            var path = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
           
            int souls = 0;
            int food = 0;
            int locks = 0;
            int jumps = 0;
            bool busted = false;
            if (input[0]=='x')
            {
                Console.WriteLine("You are deadlocked, you greedy kitty!");
                Console.WriteLine("Jumps before deadlock: 0");
            }
            else
            {
                if (input[0]=='@')
                {
                    souls++;
                }
                else
                {
                    food++;
                }
                input[0] = 'c';
                
                int currentPlace=0;
                for (int i = 0; i < path.Length; i++)
                {
                    jumps = i+1;
                    path[i] %= input.Length;                    

                    currentPlace += path[i];                                     
                  
                    if (currentPlace>input.Length-1)
                    {
                        currentPlace -= input.Length ;
                    }
                    else if (currentPlace<0)
                    {
                        currentPlace += input.Length;
                    }
              //  Console.WriteLine(input[currentPlace]);
              //  Console.WriteLine(i);
              //  Console.WriteLine();
                    if (input[currentPlace]=='@')
                    {
                       
                        souls++;
                        input[currentPlace] = 'c';
                    }
                    else if (input[currentPlace]=='*')
                    {
                        food++;
                        input[currentPlace] = 'c';
                    }
                    else if (input[currentPlace] == 'x')
                    {
                        if (currentPlace%2==0 )
                        {
                            if (souls>0)
                            {
                                souls--;
                                locks++;
                                input[currentPlace] = '*';
                            }
                            else if(souls==0)
                            {
                                Console.WriteLine("You are deadlocked, you greedy kitty!");
                                Console.WriteLine("Jumps before deadlock: {0}",jumps);
                                busted = true;
                                break;
                            }
                        }
                        else if (currentPlace%2==1)
                        {
                            
                            if (food > 0)
                            {
                                food--;
                                locks++;
                                input[currentPlace] = '@';
                            }
                            else if(food==0)
                            {
                                Console.WriteLine("You are deadlocked, you greedy kitty!");
                                Console.WriteLine("Jumps before deadlock: {0}", jumps);
                                busted = true;
                                break;
                            }
                        }
                    }
                }
                if (!busted)
                {
                    Console.WriteLine("Coder souls collected: {0}", souls);
                    Console.WriteLine("Food collected: {0}", food);
                    Console.WriteLine("Deadlocks: {0}", locks);
                }
                
            }

        }
    }
}
