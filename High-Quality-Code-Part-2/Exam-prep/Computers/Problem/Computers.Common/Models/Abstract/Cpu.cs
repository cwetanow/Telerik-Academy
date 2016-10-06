using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Contracts;
using Computers.Common.Utils;

namespace Computers.Common.Models.Abstract
{
    public abstract class Cpu : ICpu
    {
        private const string SquareInfoString = "Square of {0} is {1}.";

        protected int MaxValue;

        private IMotherboard motherboard;

        private static readonly Random randomGenerator = new Random();

        internal Cpu(byte numberOfCores)
        {
            this.NumberOfCores = numberOfCores;
        }

        public byte NumberOfCores { get; private set; }

        public void AttachToMotherboard(IMotherboard motherboard)
        {
            this.motherboard = motherboard;
        }

        public void GenerateRandom(int maxValue, int minValue)
        {
            var randomNumber = Cpu.randomGenerator.Next(minValue, maxValue + 1);
            this.motherboard.SaveRamValue(randomNumber);
        }

        public void SquareNumber()
        {
            var data = this.motherboard.LoadRamValue();

            if (data < 0)
            {
                this.motherboard.DrawOnVideoCard(GlobalConstants.NumberTooLowMessage);
            }
            else if (data > this.MaxValue)
            {
                this.motherboard.DrawOnVideoCard(GlobalConstants.NumberTooHighMessage);
            }

            var square = data * data;

            this.motherboard.DrawOnVideoCard(string.Format(SquareInfoString, data, square));
        }
    }
}
