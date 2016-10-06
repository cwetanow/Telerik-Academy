using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
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
