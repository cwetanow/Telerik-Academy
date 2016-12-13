using System.Collections;
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

            public Node(char character, int weight = 0)
            {
                this.Character = character;
                this.Weight = weight;
                this.Children = new List<Node>();
            }

            public IList<Node> Children { get; private set; }

            public char Character { get; private set; }

            public int Weight { get; private set; }

            public Node FindChild(char c)
            {
                for (int i = 0; i < this.Children.Count; i++)
                {
                    if (Children.ElementAt(i).Character == c)
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

        public void AddWord(string word, int weight)
        {
            if (word.Length == 0)
            {
                return;
            }

            var current = this.root;

            for (var i = 0; i < word.Length; i++)
            {
                var currentCharacter = word[i];
                var child = current.FindChild(currentCharacter);

                if (child != null)
                {
                    current = child;
                }
                else
                {
                    Node newNode;

                    if (i == word.Length - 2)
                    {
                        newNode = new Node(currentCharacter, weight);
                    }
                    else
                    {
                        newNode = new Node(currentCharacter);
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
                var child = current.FindChild(word[i]);

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

        public int GetWordWeight(string word)
        {
            if (this.HasWord(word))
            {
                var current = this.root;

                for (int i = 0; i < word.Length; i++)
                {
                    var child = current.FindChild(word[i]);

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

            return 0;
        }
    }
}
