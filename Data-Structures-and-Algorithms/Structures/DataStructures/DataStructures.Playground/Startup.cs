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
                "viagra                -100",
            "selection sort fast 10"
            };

            var words = "The selection sort algorithm could be applied to linked lists. viagra";

            var trie = new Trie();

            foreach (var s in dictionary)
            {
                var input = s.Split(' ')
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToArray();

                var result = input[0];

                for (int i = 1; i < input.Length - 1; i++)
                {
                    result += (' ' + input[i]);
                }

                trie.AddWord(result.ToLower(), double.Parse(input[input.Length - 1]));
            }

            var score = 0.0;
            var spaceCounters = 0;
            var currentWord = string.Empty;

            words = words.ToLower();
            for (var i = 0; i < words.Length; i++)
            {
                if (!char.IsLetter(words[i]))
                {
                    continue;
                }

                if (currentWord.Length == 0)
                {
                    currentWord = words[i].ToString();
                    i++;
                }

                while (i < words.Length && char.IsLetter(words[i]))
                {
                    currentWord += words[i];
                    i++;
                }

                spaceCounters++;

                if (!trie.HasWord(currentWord))
                {
                    currentWord = string.Empty;
                    continue;
                }

                var currentScore = 0.0;

                while (trie.HasWord(currentWord))
                {
                    currentWord += ' ';
                    var j = i;
                    while (trie.GetWordWeight(currentWord) == 0)
                    {
                        j++;

                        while (j < words.Length && char.IsLetter(words[j]))
                        {
                            currentWord += words[j];
                            j++;
                        }
                        
                        currentWord += ' ';

                        if (!trie.HasWord(currentWord))
                        {
                            break;
                        }

                        spaceCounters++;
                        i = j;
                    }

                    var weight = trie.GetWordWeight(currentWord);
                    currentScore = weight == 0 ? currentScore : weight;
                }

                score += currentScore;
                currentWord = string.Empty;
            }

            Console.WriteLine(score / spaceCounters);
        }
    }
}
