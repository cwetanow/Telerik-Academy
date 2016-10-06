using System;
using Computers.Common.Models.Abstract;

namespace Computers.Common.Models.VideoCards
{
    public class MonochromeVideoCard : VideoCard
    {
        public MonochromeVideoCard()
        {
            this.Color = ConsoleColor.Gray;
        }
    }
}
