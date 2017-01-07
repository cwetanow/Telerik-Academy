using System;
using System.Linq;

namespace _06.Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var word = Console.ReadLine();
            var text = Console.ReadLine();

            var result = 0l;
            var wordLen = word.Length;

            var searcher = new StringSearcher(text.ToCharArray());

            for (var i = 1; i <= wordLen; i++)
            {
                var left = word.Substring(0, i).ToCharArray();
                var right = word.Substring(i, wordLen - i).ToCharArray();
                var leftCounter = 0;

                if (left.Length > 1)
                {
                    var index = searcher.Search(left);

                    while (index < text.Length && index > -1)
                    {
                        leftCounter++;
                        index++;
                        index = searcher.Search(left, index);
                    }
                }
                else
                {
                    var index = text.IndexOf(left[0]);
                    while (index > -1)
                    {
                        leftCounter++;
                        index = text.IndexOf(left[0], index + 1);
                    }
                }

                var rightCounter = 0;

                if (right.Length > 1)
                {
                    var index = searcher.Search(right);

                    while (index < text.Length && index > -1)
                    {
                        rightCounter++;
                        index++;
                        index = searcher.Search(right, index);
                    }
                }
                else if (right.Length == 1)
                {
                    var index = text.IndexOf(right[0]);
                    while (index > -1)
                    {
                        rightCounter++;
                        index = text.IndexOf(right[0], index + 1);
                    }
                }

                if (i == wordLen)
                {
                    rightCounter = 1;
                }

                result += leftCounter * rightCounter;
            }

            Console.WriteLine(result);
        }
    }

    public class StringSearcher  // Knuth-Morris-Pratt string search
    {
        private char[] W;  // the (small) pattern to search for
        private int[] T;   // lets the search function to skip ahead
        private char[] S;

        public StringSearcher(char[] S)
        {
            this.S = S;
        }

        private int[] BuildTable(char[] W)
        {
            int[] result = new int[W.Length];
            int pos = 2;
            int cnd = 0;
            result[0] = -1;
            result[1] = 0;
            while (pos < W.Length)
            {
                if (W[pos - 1] == W[cnd])
                {
                    ++cnd; result[pos] = cnd; ++pos;
                }
                else if (cnd > 0)
                    cnd = result[cnd];
                else
                {
                    result[pos] = 0; ++pos;
                }
            }
            return result;
        }

        public int Search(char[] W, int m = 0)
        {
            this.W = new char[W.Length];
            Array.Copy(W, this.W, W.Length);
            this.T = BuildTable(W);

            // look for this.W inside of S
            int i = 0;
            while (m + i < this.S.Length)
            {
                if (this.W[i] == this.S[m + i])
                {
                    if (i == this.W.Length - 1)
                    {
                        return m;
                    }

                    ++i;
                }
                else
                {
                    m = m + i - this.T[i];
                    if (this.T[i] > -1)
                    {
                        i = this.T[i];
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }

            return -1;  // not found
        }
    }
}
