﻿using System;
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
