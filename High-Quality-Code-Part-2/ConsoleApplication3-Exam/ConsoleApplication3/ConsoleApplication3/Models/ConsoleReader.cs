using System;
using SchoolSystem.UI.Models.Contracts;

namespace SchoolSystem.UI.Models
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
