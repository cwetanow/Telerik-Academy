using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo 
    {
       

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage):base(name,brand,price,gender)
        {
            this.Milliliters = milliliters;
            this.Price = price * milliliters;
            this.Usage = usage;

        }      

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public override string Print()
        {
            var builder = new StringBuilder(5);
            builder.AppendLine(base.Print());
            builder.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            builder.Append(string.Format("  * Usage: {0}", this.Usage));            
            return builder.ToString();
        }
    }
}
