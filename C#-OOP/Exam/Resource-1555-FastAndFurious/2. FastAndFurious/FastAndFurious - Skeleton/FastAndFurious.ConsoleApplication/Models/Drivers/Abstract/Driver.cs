using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : IDriver
    {
        private readonly int id;
        private string name;
        private bool inRace;
        private ICollection<IMotorVehicle> vehicles;

        public Driver(string name, GenderType gender)
        {
            this.id = DataGenerator.GenerateId();
            this.Name = name;
            this.vehicles = new List<IMotorVehicle>();
        }

        public IMotorVehicle ActiveVehicle
        {
            get; set;
        }

        public GenderType Gender
        {
            get
            {
                return this.Gender;
            }
            protected set
            {
                this.Gender = value;
            }
        }

        public int Id
        {
            get;
        }

        public string Name
        {
            get; protected set;
        }

        public IEnumerable<IMotorVehicle> Vehicles
        {
            get
            {
                return this.vehicles;
            }
        }

        public void AddVehicle(IMotorVehicle vehicle)
        {
            this.vehicles.Add(vehicle);
        }
        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            return this.vehicles.Remove(vehicle);
        }
        public void SetActiveVehicle(IMotorVehicle vehicle)
        {           
            if (!inRace)
            {
                this.ActiveVehicle = vehicle;
            }
        }
    }
}
