using Computers.Common.Models.Computers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Computers.Common.Contracts;
using Computers.Common.Exceptions;
using Computers.Common.Models;

namespace Computers.UI
{
    public static class CommandEngine
    {
        private const string ExitCommand = "Exit";
        private const string PlayCommand = "Play";
        private const string ProcessCommand = "Process";
        private const string ChargeCommand = "Charge";

        private static PersonalComputer pc;

        private static Laptop laptop;

        private static Server server;

        public static void Start()
        {
            CreateComputers();
            ProcessCommands();
        }

        private static void CreateComputers()
        {
            var manufacturerName = Console.ReadLine();
            IComputerManufacturer manufacturer;
            try
            {
                manufacturer = ComputerManufacturerFactory.GetManufacturer(manufacturerName);

                pc = manufacturer.CreatePersonalComputer();
                laptop = manufacturer.CreateLaptop();
                server = manufacturer.CreateServer();
            }
            catch (InvalidArgumentException e)
            {
                Console.WriteLine(e.Message);
                CreateComputers();
            }
        }

        private static void ProcessCommands()
        {
            var command = Console.ReadLine();

            while (command != ExitCommand)
            {
                if (command == null)
                {
                    break;
                }

                if (command == ExitCommand)
                {
                    break;
                }

                var commandParts = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (commandParts.Length != 2)
                {
                    Console.WriteLine("Invalid command");
                }

                var commandName = commandParts[0];
                var commandArgument = commandParts[1];

                if (commandName == PlayCommand)
                {
                    Play(commandArgument);
                }

                if (commandName == ProcessCommand)
                {
                    Process(commandArgument);
                }

                if (commandName == ChargeCommand)
                {
                    Charge(commandArgument);
                }

                command = Console.ReadLine();
            }
        }

        private static void Play(string argument)
        {
            try
            {
                var guess = int.Parse(argument);

                pc.PlayGame(guess);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
        }

        private static void Process(string argument)
        {
            try
            {
                var data = int.Parse(argument);

                server.ProcessRequest(data);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
        }

        private static void Charge(string argument)
        {
            try
            {
                var percentage = int.Parse(argument);

                laptop.ChargeBattery(percentage);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number");
            }
        }
    }
}
