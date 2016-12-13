using System;
using System.Linq;

namespace DataStructures.Playground
{
    class Startup
    {

        static void Main(string[] args)
        {
            var dictionary = new[] { "algorithm          10",
                "selection sort    20",
                "linked list           20",
                "program            5",
                "viagra                -100" };

            var words = "The selection sort algorithm could be applied to linked lists.";

            var trie = new Trie();

            foreach (var s in dictionary)
            {
                var input = s.Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

                var result = string.Empty;

                for (int i = 0; i < input.Length - 1; i++)
                {
                    result += (input[i] + ' ');
                }

                trie.AddWord(result.ToLower(), int.Parse(input[input.Length - 1]));
            }

            var current = string.Empty;
            var score = 0;
            var spaceCounters = 0;

            words = words.ToLower();
            for (var i = 0; i < words.Length; i++)
            {
                current += words[i];

                if (words[i] == ' ')
                {
                    spaceCounters++;

                    if (!trie.HasWord(current))
                    {
                        current = string.Empty;
                    }
                }

                if (trie.GetWordWeight(current) != 0)
                {
                    if (!char.IsLetter(words[i + 1]))
                    {
                        score += trie.GetWordWeight(current);
                        current = string.Empty;
                    }
                }
            }

            Console.WriteLine(score / spaceCounters);
        }
    }
}
