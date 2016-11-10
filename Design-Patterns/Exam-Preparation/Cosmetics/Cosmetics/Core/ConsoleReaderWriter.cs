using System;
using Cosmetics.Contracts;

namespace Cosmetics.Core
{
    public class ConsoleReaderWriter : IReader, IWriter
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
