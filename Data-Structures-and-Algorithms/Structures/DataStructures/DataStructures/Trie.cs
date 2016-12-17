using System.Collections.Generic;
using System.Linq;

namespace DataStructures
{
    public class Trie
    {
        private class Node
        {
            public Node()
            {
                this.Children = new List<Node>();
            }

            public Node(string word, double weight = 0)
            {
                this.Word = word;
                this.Weight = weight;
                this.Children = new List<Node>();
            }

            public IList<Node> Children { get; private set; }

            public string Word { get; private set; }

            public double Weight { get; set; }

            public Node FindChild(string wordToSearch)
            {
                for (var i = 0; i < this.Children.Count; i++)
                {
                    if (Children.ElementAt(i).Word == wordToSearch)
                    {
                        return Children.ElementAt(i);
                    }
                }

                return null;
            }
        }

        private Node root;

        public Trie()
        {
            this.root = new Node();
        }

        public void AddWord(string word, double weight)
        {
            if (word.Length == 0)
            {
                return;
            }

            var current = this.root;

            for (int i = 0; i < word.Length; i++)
            {
                var currentWord = word[i].ToString();
                i++;

                while (i < word.Length && char.IsLetter(word[i]))
                {
                    currentWord += word[i];
                    i++;
                }

                var child = current.FindChild(currentWord);

                if (child != null)
                {
                    current = child;
                    if (currentWord == word)
                    {
                        current.Weight = weight;
                    }
                }
                else
                {
                    Node newNode;

                    if (i >= word.Length - 2)
                    {
                        newNode = new Node(currentWord, weight);
                    }
                    else
                    {
                        newNode = new Node(currentWord);
                    }

                    current.Children.Add(newNode);
                    current = newNode;
                }
            }
        }

        public bool HasWord(string word)
        {
            var current = root;

            for (int i = 0; i < word.Length; i++)
            {
                var currentWord = word[i].ToString();
                i++;

                while (i < word.Length && char.IsLetter(word[i]))
                {
                    currentWord += word[i];
                    i++;
                }

                var child = current.FindChild(currentWord);

                if (child != null)
                {
                    current = child;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public double GetWordWeight(string word)
        {
            var current = this.root;

            for (int i = 0; i < word.Length; i++)
            {
                var currentWord = word[i].ToString();
                i++;

                while (i < word.Length && char.IsLetter(word[i]))
                {
                    currentWord += word[i];
                    i++;
                }

                var child = current.FindChild(currentWord);

                if (child != null)
                {
                    current = child;
                }
                else
                {
                    return 0;
                }
            }

            return current.Weight;
        }
    }
}
