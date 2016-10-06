using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Common;
namespace Cosmetics.Products
{
    public abstract class Product : IProduct
    {
        private decimal price;
        private string name;
        private string brand;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Price = price;
            this.Name = name;
            this.Brand = brand;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, Name));
                Validator.CheckIfStringLengthIsValid(
                    value,
                    Constants.maxProductNameLen,
                    Constants.minProductNameLen,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Product name",
                        Constants.minProductNameLen,
                        Constants.maxProductNameLen));
                this.name = value;

            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, Brand));
                Validator.CheckIfStringLengthIsValid(
                    value,
                    Constants.maxBrandNameLen,
                    Constants.minBrandNameLen,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Product brand",
                        Constants.minBrandNameLen,
                        Constants.maxBrandNameLen));
                this.brand = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {

                this.price = value;
            }
        }

        public GenderType Gender { get; set; }

        public virtual string Print()
        {
            
            var builder = new StringBuilder();
            
            builder.AppendLine(string.Format("- {0} - {1}:", this.Brand, this.Name));
            builder.AppendLine(string.Format("  * Price: ${0}", this.Price));
            builder.Append(string.Format("  * For gender: {0}", this.Gender));
            return builder.ToString();
        }
    }
}
