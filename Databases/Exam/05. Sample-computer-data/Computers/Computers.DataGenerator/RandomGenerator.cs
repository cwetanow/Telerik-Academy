using System;

namespace Computers.DataGenerator
{
    public class RandomGenerator : IRandomGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static RandomGenerator instance;

        private readonly Random random;

        private RandomGenerator()
        {
            this.random = new Random();
        }

        public static RandomGenerator Instance
        {
            get
            {
                return instance ?? (instance = new RandomGenerator());
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = Letters[this.GetRandomNumber(0, Letters.Length - 1)];
            }

            return new string(chars);
        }
    }
}
