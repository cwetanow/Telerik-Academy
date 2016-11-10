using System;

namespace Cosmetics.Products
{
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;

    internal abstract class Product : IProduct
    {
        private const int MinBrandLength = 2;
        private const int MinStringLength = 3;
        private const int MaxStringLength = 10;

        private const string ProductName = "Product name";
        private const string ProductBrand = "Product brand";
        private const string InvalidStringLength = "{0} must be between {1} and {2} symbols long!";
        private const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";

        private string name;
        private string brand;

        protected Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException(string.Format(StringCannotBeNullOrEmpty, ProductName));
                }

                if (value.Length < MinStringLength || MaxStringLength < value.Length)
                {
                    throw new IndexOutOfRangeException(string.Format(InvalidStringLength, ProductName, MinStringLength, MaxStringLength));
                }

                this.name = value;
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NullReferenceException(string.Format(StringCannotBeNullOrEmpty, ProductBrand));
                }

                if (value.Length < MinBrandLength || MaxStringLength < value.Length)
                {
                    throw new IndexOutOfRangeException(string.Format(InvalidStringLength, ProductBrand, MinBrandLength, MaxStringLength));
                }

                this.brand = value;
            }
        }

        public decimal Price { get; protected set; }

        public GenderType Gender { get; private set; }

        public virtual string Print()
        {
            var result = new StringBuilder();
            result.AppendLine($"- {this.Brand} - {this.Name}:");
            result.AppendLine($"  * Price: ${this.Price}");
            result.Append($"  * For gender: {this.Gender}");
            return result.ToString();
        }
    }
}
