using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Exceptions;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;
using System.Threading;
using System.Diagnostics;
using Microsoft.TeamFoundation.TestManagement.Client;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract
{
    public abstract class MotorVehicle : IMotorVehicle, IWeightable, IValuable
    {
        private int id;
        private ICollection<ITunningPart> tunningParts;
        private decimal price;

        public MotorVehicle(decimal price, int weight, int acceleration,int topSpeed)
        {
            this.id = DataGenerator.GenerateId();
            this.Price = price;
            this.Weight = weight;
            this.Acceleration = acceleration;
            this.TopSpeed = topSpeed;
            this.tunningParts = new List<ITunningPart>();
        }

        
        public int Weight
        {
            get; protected set;
        }
        public int Acceleration
        {
            get; protected set;
        }
        public int TopSpeed
        {
            get; protected set;
        }
        public IEnumerable<ITunningPart> TunningParts
        {
            get
            {
                return this.tunningParts;
            }

        }
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price + this.TunningParts.Sum(x => x.Price);
            }
            set
            {
                this.price = value;
            }
        }

        public void AddTunning(ITunningPart part)
        {
            this.tunningParts.Add(part);
        }
        public TimeSpan Race(int trackLengthInMeters)
        {
            var timer = new Stopwatch();
            timer.Start();
            var distance = 0.0;
            while (distance!=(double)trackLengthInMeters)
            {
                distance = 0.5 * this.Acceleration * Math.Pow(timer.Elapsed.Seconds, 2);
            }
            timer.Stop();
            return timer.Elapsed;

        }
        public bool RemoveTunning(ITunningPart part)
        {
            return this.tunningParts.Remove(part);
        }
    }
}
