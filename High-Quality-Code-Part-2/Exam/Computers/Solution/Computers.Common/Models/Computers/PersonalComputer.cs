using System.Collections.Generic;
using Computers.Common.Contracts;
using Computers.Common.Models.Abstract;
using Computers.Common.Utils;

namespace Computers.Common.Models.Computers
{
    public class PersonalComputer : Computer
    {
        public PersonalComputer(IRam ram, ICpu cpu, IEnumerable<IHardDrive> drives, IVideoCard videoCard)
            : base(ram, cpu, drives, videoCard)
        {
        }

        public void PlayGame(int guessedNumber)
        {
            this.Cpu.GenerateRandom(1, 10);
            var number = this.Ram.LoadValue();

            if (guessedNumber != number)
            {
                this.VideoCard.Draw(string.Format(GlobalConstants.WrongNumberStringFormat, number));
            }
            else
            {
                this.VideoCard.Draw(GlobalConstants.WinMessage);
            }
        }
    }
}
