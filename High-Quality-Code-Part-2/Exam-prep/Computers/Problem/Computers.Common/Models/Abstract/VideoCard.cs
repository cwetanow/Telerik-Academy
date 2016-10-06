using System;
using Computers.Common.Contracts;

namespace Computers.Common.Models.Abstract
{
    public abstract class VideoCard : IVideoCard
    {
        protected ConsoleColor Color { get; set; }

        public void Draw(string message)
        {
            Console.ForegroundColor = this.Color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
