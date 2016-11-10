namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Contracts;
    using Cosmetics.Common;

    internal class Category : ICategory
    {
        private const int MinCategoryNameLength = 2;
        private const int MaxCategoryNameLength = 15;

        public const string InvalidStringLength = "{0} must be between {1} and {2} symbols long!";
        public const string ObjectCannotBeNull = "{0} cannot be null!";
        public const string StringCannotBeNullOrEmpty = "{0} cannot be null or empty!";

        private string name;
        protected readonly IList<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
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
                    throw new NullReferenceException(string.Format(StringCannotBeNullOrEmpty, "Category name"));
                }

                if (value.Length < MinCategoryNameLength || MaxCategoryNameLength < value.Length)
                {
                    throw new IndexOutOfRangeException(string.Format(InvalidStringLength, "Category name", MinCategoryNameLength, MaxCategoryNameLength));
                }

                this.name = value;
            }
        }

        public void AddProduct(IProduct product)
        {
            if (product == null)
            {
                throw new NullReferenceException(string.Format(ObjectCannotBeNull, "Cosmetics to add to category"));
            }

            this.products.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            if (product == null)
            {
                throw new NullReferenceException(string.Format(ObjectCannotBeNull, "Cosmetics to remove from category"));
            }

            if (!this.products.Contains(product))
            {
                throw new InvalidOperationException($"Product {product.Name} does not exist in category {this.Name}!");
            }

            this.products.Remove(product);
        }

        public string Print()
        {
            var categoryString =
                $"{this.Name} category - {this.products.Count} {(this.products.Count != 1 ? "products" : "product")} in total";

            var result = new StringBuilder();
            result.AppendLine(categoryString);

            var sortedProducts =
                this.products
                    .OrderBy(pr => pr.Brand)
                    .ThenByDescending(pr => pr.Price);

            foreach (var product in sortedProducts)
            {
                result.AppendLine(product.Print());
            }

            return result.ToString().Trim();
        }
    }
}
