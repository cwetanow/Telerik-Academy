using System.Collections.Generic;
using Computers.Common.Contracts;
using Computers.Common.Models.Abstract;

namespace Computers.Common.Models.Computers
{
    public class Server : Computer
    {
        public Server(IRam ram, ICpu cpu, IEnumerable<IHardDrive> drives, IVideoCard videoCard)
            : base(ram, cpu, drives, videoCard)
        {
        }

        public void ProcessRequest(int data)
        {
            this.Ram.SaveValue(data);
            this.Cpu.SquareNumber();
        }
    }
}
