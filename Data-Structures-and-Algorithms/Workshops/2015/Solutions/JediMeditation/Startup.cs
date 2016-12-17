using System;
using System.Collections.Generic;
using System.Text;

namespace JediMeditation
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var jedis = Console.ReadLine()
                .Split(' ');

            var dictionary = new Dictionary<char, List<string>>();

            dictionary['m'] = new List<string>();
            dictionary['k'] = new List<string>();
            dictionary['p'] = new List<string>();

            foreach (var jedi in jedis)
            {
                dictionary[jedi[0]].Add(jedi);
            }

            var result = new StringBuilder();
            foreach (var jedi in dictionary)
            {
                result.Append(string.Join(" ", jedi.Value) + ' ');
            }

            Console.WriteLine(result.ToString());
        }
    }
}
