using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Compare_char_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            bool equal = true;
            int comparer = Math.Min(first.Length,second.Length);
            
            for (int i = 0; i < comparer; i++)
            {
                if (first[i]>second[i])
                    {
                        Console.WriteLine(">");
                        equal = false;
                        break;
                    }
                    else if (first[i]<second[i])
                    {
                        Console.WriteLine("<");
                        equal = false;
                        break;
                    }
            }
            if (equal)
            {
                if (first.Length > second.Length)
                {
                    Console.WriteLine(">");
                }
                else if (first.Length < second.Length)
	
                {
                    Console.WriteLine("<");
                }   else{Console.WriteLine("=");}
                
            }
           // if (first.Length==second.Length)
           // {
           //     for (int i = 0; i < first.Length; i++)
           //     {
           //         if (first[i]>second[i])
           //         {
           //             Console.WriteLine(">");
           //             equal = false;
           //             break;
           //         }
           //         else if (first[i]<second[i])
           //         {
           //             Console.WriteLine("<");
           //             equal = false;
           //             break;
           //         }
           //         
           //     }
           //     if (equal)
           //     {
           //         Console.WriteLine("=");
           //     }
           // }
                 
        }
    }
}
