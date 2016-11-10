using System;
using Dealership.Contracts;

namespace Dealership.Core
{
    public class ConsoleInputOutputProvider : IInputOutputProvider
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
