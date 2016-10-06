using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decoding
{
    class Program
    {
        static void Main(string[] args)
        {
            int salt = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            
           
            double[] encoded = new double[text.Length];
            //int i=0;
            
           
            for (int i = 0; i < text.Length-1; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    encoded[i] = text[i] * salt + 1000;
                }
                else if (char.IsDigit(text[i]))
                {
                    encoded[i] = text[i] + salt + 500;
                }
                else if (text[i]=='@')
                {
                    break;
                }
                else
                {
                    encoded[i] = text[i] - salt;
                }
              
                
            }
           
            for (int j = 0; j < encoded.Length-1; j++)
            {
                if (j % 2 == 0)
                {
                    encoded[j] /= 100;
                }
                else {
                    encoded[j] *= 100;
                }
            }
            for (int j = 0; j < encoded.Length-1; j++)
            {
                if (j % 2 == 0)
                {
                    Console.WriteLine("{0:F2}", encoded[j]);
                }
                else {
                    Console.WriteLine(encoded[j]);
                }
                
            }


        }
    }
}
