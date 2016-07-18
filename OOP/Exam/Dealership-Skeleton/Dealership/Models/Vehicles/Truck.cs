using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models.Vehicles
{
    public class Truck : Vehicle, ITruck
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) : base(make, model, price, 8)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get
            {
                return this.weightCapacity;
            }
            protected set
            {
                Validator.ValidateIntRange(value, Constants.MinCapacity, Constants.MaxCapacity,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Weight capacity", Constants.MinCapacity, Constants.MaxCapacity));
                this.weightCapacity = value;
            }
        }
        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine(string.Format("  Weight Capacity: {0}t", this.WeightCapacity));
            if (this.Comments.Count == 0)
            {
                builder.Append("    --NO COMMENTS--");
            }
            else
            {
                builder.AppendLine("    --COMMENTS--");
            }

            if (this.Comments.Count > 0)
            {
                foreach (var item in this.Comments)
                {
                    builder.AppendLine("  " + item.ToString());
                }
                builder.Append("    --COMMENTS--");
            }
            return builder.ToString();
        }
    }
}
