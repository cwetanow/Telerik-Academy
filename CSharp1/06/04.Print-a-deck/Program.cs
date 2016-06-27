using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Print_a_deck
{
    class Program
    {
        static void Main(string[] args)
        {
            string card = Console.ReadLine();   
            string[] suits=new string[4];
            suits[0] = " of spades";
            suits[1] = " of clubs";
            suits[2] = " of hearts";
            suits[3] = " of diamonds";
            string[] cards = {"2","3","4","5","6","7","8","9","10","J","Q","K","A"};
            int k=-1;
            for (int i = 0; i < 13; i++)
            {
                if (card == cards[i]) {
                    k = i;
                }
            }
            
            for (int i = 0; i <=k; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    
                    
                        if (j == 3)
                        {
                            Console.Write(cards[i] + suits[j]);
                        }
                        else { Console.Write(cards[i] + suits[j] + ", "); }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
