using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
