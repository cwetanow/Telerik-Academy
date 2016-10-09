using System;
using SchoolSystem.UI.Models.Contracts;

namespace SchoolSystem.UI.Models
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
