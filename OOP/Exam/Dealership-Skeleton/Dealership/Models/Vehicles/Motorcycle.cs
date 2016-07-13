using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models.Vehicles
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category) : base(make, model, price, 2)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            protected set
            {
                Validator.ValidateNull(value, Constants.VehicleCannotBeNull);
                Validator.ValidateIntRange(value.Length, Constants.MinCategoryLength, Constants.MaxCategoryLength,
                    string.Format(Constants.StringMustBeBetweenMinAndMax,"Category", Constants.MinCategoryLength, Constants.MaxCategoryLength));
                this.category = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine(string.Format("  Category: {0}", this.Category));
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
