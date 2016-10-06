using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace _4.Decode_decryph
{
    class Program
    {   
        //works
        static char Encrypt(char mes, char cyp)
        {
            int code = (mes - 65) ^ (cyp - 65);
            return (char)(code + 65);
        }
        //works
        static int FindCypherLength(string message)
        {
            int length = 0;
            int deg;
            for (int i = message.Length - 1; i > -1; i--)
            {
                deg = message.Length - i - 1;
                if (!char.IsDigit(message[i]))
                {
                    break;
                }
                length += (int)((message[i] - '0') * Math.Pow(10, deg));

            }
            return length;
        }
        //works
        static string FindCypher(string message, int length)
        {
            var result = new StringBuilder();

            for (int i = message.Length - length - length.ToString().Length; i < message.Length - length.ToString().Length; i++)
            {
                result.Append(message[i]);
            }
            return result.ToString();
        }
        //works
        static string UnEncode(string message, int cypLen)
        {
            var temp = new StringBuilder();
            var cypherLenLen=cypLen.ToString().Length;
            var t = message;
            
            var digits = new int[message.Length / 3 + 1];
            
            List<int> numbers=new List<int>();
            
            for (int i = 0; i < message.Length - cypherLenLen; i++)
            {
                if (Char.IsDigit(message[i]))
                {
                    temp.Append(message[i]);
                    
                }
                else if (i>0 && Char.IsDigit(message[i-1]) )
                {
                    
                    numbers.Add(int.Parse(temp.ToString()));                    
                    temp.Clear();
                }            
                
            }
            int z = 0;
            for (int i = 0; i < message.Length - cypherLenLen; i++)
            {
                if (Char.IsDigit(message[i]))
                {
                    int numlen = numbers[z].ToString().Length;
                    for (int j = 0; j < numbers[z]-1; j++)
                    {
                        temp.Append(message[i+numlen]);
                    }
                }
                else
                {
                    temp.Append(message[i]);
                }
            }

            temp.Append(cypLen);
            return temp.ToString();
        }
        //works
        static string FindMessage(string input, string cypher, int cypherLength)
        {
            var result = new StringBuilder();
            var messageLen = input.Length - cypher.Length - cypherLength.ToString().Length;
            for (int i = 0; i < messageLen; i++)
            {
                result.Append(input[i]);
            }
            return result.ToString();
        }
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var temp = new StringBuilder();
            var c = FindCypherLength(input);
            //Console.WriteLine(cypherLength);
            input = UnEncode(input, c);
            temp.Append(FindCypher(input, c));
            //var cypher = FindCypher(input,c);
            var message = FindMessage(input, temp.ToString(), c);
            //Console.WriteLine(cypher);
           // Console.WriteLine(message);
            int r = message.Length;
             var result = new StringBuilder();
             for (int i = 0; i < Math.Min(r, c); i++)
                 {
                     result.Append(Encrypt(message[i], temp.ToString()[i]));
                    
                 }
             string tempp;
             if (r > c)
                 {
                     for (int i = 0; i < (r - c) / c; i++)
                     {
                         temp.Append(temp.ToString());
                     }
                    
                     tempp = temp.ToString();
                     for (int i = 0; i < r - c + 1; i++)
                     {
                         temp.Append(tempp[i]);
                     }
                    
                 }
             var cypher = temp.ToString();
             if (r < c)
             {
                
                 tempp = result.ToString();
                 result.Clear();
                 for (int i = 0; i < c-r; i++)
                 {
                     result.Append(Encrypt(tempp[i], cypher[i + Math.Min(r, c)]));
                 }
                 for (int i = c-r; i < tempp.Length; i++)
                 {
                     result.Append(tempp[i]);
                 }
             }
             else {
                 for (int i = Math.Min(r,c); i < Math.Max(r, c); i++)
                 {
                     result.Append(Encrypt(message[i], cypher[i]));
                    
                 }
             }
            
            
             Console.WriteLine(result.ToString());

        }
    }
}