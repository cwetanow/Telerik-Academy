using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Common;

namespace Cosmetics.Engine
{
    public class Category : ICategory
    {
        private string name;
        private ICollection<IProduct> productsList;

        public Category(string name)
        {
            this.Name = name;
            productsList = new List<IProduct>();

        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringLengthIsValid(
                        value,
                        Constants.maxCategoryNameLen,
                        Constants.minCategoryNameLen,
                        string.Format(
                            GlobalErrorMessages.InvalidStringLength,
                            this.GetType().Name + " name",
                            Constants.minCategoryNameLen,
                            Constants.maxCategoryNameLen));
                this.name = value;
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.productsList.Add(cosmetics);
        }

        public string Print()
        {
            this.Sort();
            var builder = new StringBuilder();
            if (this.productsList.Count==0)
            {
                builder.Append(string.Format("{0} category - {1} {2} in total", this.Name, this.productsList.Count, this.productsList.Count == 1 ? "product" : "products"));
            }
            else
            {
                builder.AppendLine(string.Format("{0} category - {1} {2} in total", this.Name, this.productsList.Count, this.productsList.Count == 1 ? "product" : "products"));
                foreach (var item in this.productsList)
                {

                    if (item == this.productsList.ElementAt(this.productsList.Count - 1))
                    {
                        builder.Append(item.Print());
                    }
                    else
                    {
                        builder.AppendLine(item.Print());
                    }
                }
            }
            
            return builder.ToString();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.productsList.Remove(cosmetics))
            {
                Console.WriteLine(string.Format("Product {0} does not exist in category {1}!", cosmetics.Name, this.Name));
            }


        }
        private void Sort()
        {
            this.productsList = this.productsList.OrderBy(product => product.Brand).ThenByDescending(product => product.Price).Select(product => product).ToList();
        }
    }
}
