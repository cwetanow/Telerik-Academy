using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Models.Abstract;

namespace Computers.Common.Models.VideoCards
{
    public class ColorfulVideoCard : VideoCard
    {
        public ColorfulVideoCard()
        {
            this.Color = ConsoleColor.Green;
        }
    }
}
