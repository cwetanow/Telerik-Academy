using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Extract_sentence
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = new StringBuilder();
            w.Append(" ");
            w.Append(Console.ReadLine());
            w.Append(" ");
            var word = w.ToString().ToLower();
            string text = Console.ReadLine();
            string[] sentences = text.Split(new char[]{'.','!','?'});
            char[] enders=new char[sentences.Length];
            int k=0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]=='.' || text[i]=='!' || text[i]=='?')
                {
                    enders[k] = text[i];
                    k++;
                }
            }
            
           var output = new StringBuilder();
           string temp;
           for (int i = 0; i < sentences.Length; i++)
           {
               
               temp = sentences[i].ToLower();
               if (temp.IndexOf(word) != -1)
               {
                   output.Append(sentences[i] + enders[i]);
               }
           }
           
           Console.WriteLine(output.ToString());
        }
    }
}