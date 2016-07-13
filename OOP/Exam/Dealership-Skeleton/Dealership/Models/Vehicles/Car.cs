using Dealership.Common;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models.Vehicles
{
   public class Car : Vehicle, ICar
    {
        private int seats;

        public Car(string make, string model, decimal price, int seats) : base(make, model, price, 4)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }
            protected set
            {

                Validator.ValidateIntRange(value, Constants.MinSeats, Constants.MaxSeats,
                    string.Format(Constants.NumberMustBeBetweenMinAndMax, "Seats", Constants.MinSeats, Constants.MaxSeats));
                this.seats = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.ToString());
            builder.AppendLine(string.Format("  Seats: {0}",this.Seats));
            if (this.Comments.Count==0)
            {
                builder.Append("    --NO COMMENTS--");
            }
            else
            {
                builder.AppendLine("    --COMMENTS--");
            }           
           
            if (this.Comments.Count>0)
            {
                foreach (var item in this.Comments)
                {
                    builder.AppendLine("  "+item.ToString());
                }
                builder.Append("    --COMMENTS--");
            }
            return builder.ToString();
        }
    }
}
