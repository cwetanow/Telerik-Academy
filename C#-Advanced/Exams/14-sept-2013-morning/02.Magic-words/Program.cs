using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Magic_words
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            List<string> words=new List<string>();
            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }
            int index;
            for (int i = 0; i < n; i++)
            {
                index = (words[i].Length) % (n + 1);
                words.Insert(index,words[i]);
                
                if (i>index)
                {
                    words.RemoveAt(i+1);
                }
                else
                {
                    words.RemoveAt(i);
                }
               
                
            }
            int max = 0;
            foreach (var item in words)
            {
                if (max<item.Length)
                {
                    max = item.Length;
                }
            }
            var result = new StringBuilder();
            for (int i = 1; i <= max; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (words[j].Length >= i)
                    {
                        result.Append(words[j][i - 1]);
                    }
                }
                
            }
            Console.WriteLine(result.ToString());

        }
    }
}