using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private readonly string ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients) : base(name, brand, price, gender)
        {
            foreach (var item in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(
                    item,
                    Constants.maxIngredientNameLen,
                    Constants.minIngredientNameLen,
                    string.Format(
                        GlobalErrorMessages.InvalidStringLength,
                        "Each "+this.GetType().Name,
                        Constants.minIngredientNameLen,
                        Constants.maxIngredientNameLen));
               
            }
            this.ingredients = string.Join(", ", ingredients);

        }

        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
        }

        public override string Print()
        {
            var builder = new StringBuilder();
            builder.AppendLine(base.Print());
            builder.Append(string.Format("  * Ingredients: {0}",this.Ingredients));
            return builder.ToString();
        }
    }
}
