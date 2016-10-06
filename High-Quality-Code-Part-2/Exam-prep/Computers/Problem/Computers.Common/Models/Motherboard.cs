using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Contracts;

namespace Computers.Common.Models
{
    public class Motherboard : IMotherboard
    {
        private IRam ram;
        private IVideoCard videoCard;

        public Motherboard(IRam ram, ICpu cpu, IVideoCard videoCard)
        {
            this.ram = ram;
            this.videoCard = videoCard;
            cpu.AttachToMotherboard(this);
        }

        public int LoadRamValue()
        {
            return this.ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string data)
        {
            this.videoCard.Draw(data);
        }
    }
}
