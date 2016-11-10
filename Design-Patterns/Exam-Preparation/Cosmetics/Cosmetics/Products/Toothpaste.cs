namespace Cosmetics.Products
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Contracts;
    using Common;

    internal class Toothpaste : Product, IToothpaste, IProduct
    {
        private const int MinLengthIngredient = 4;
        private const int MaxLengthIngredient = 12;

        private const string InvalidStringLength = "{0} must be between {1} and {2} symbols long!";

        private readonly IList<string> ingredients;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            this.ValidateIngredients(ingredients);
            this.ingredients = ingredients;
        }

        public string Ingredients
        {
            get { return string.Join(", ", this.ingredients); }
        }

        public override string Print()
        {
            var result = new StringBuilder();
            result.AppendLine(base.Print());
            result.Append($"  * Ingredients: {this.Ingredients}");
            return result.ToString();
        }

        private void ValidateIngredients(IList<string> ingredients)
        {
            if (ingredients.Any(i => i.Length < MinLengthIngredient || i.Length > MaxLengthIngredient))
            {
                throw new IndexOutOfRangeException(string.Format(InvalidStringLength, "Each ingredient", MinLengthIngredient, MaxLengthIngredient));
            }
        }
    }
}
