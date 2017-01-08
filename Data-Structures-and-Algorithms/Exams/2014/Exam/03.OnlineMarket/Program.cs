using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.OnlineMarket
{
    class Program
    {
        private const string SuccessAdd = "Ok: Product {0} added successfully";
        private const string FailAdd = "Error: Product {0} already exists";
        private const string Result = "Ok: {0}";

        private static readonly IDictionary<string, Product> productsByName = new Dictionary<string, Product>();
        private static readonly IDictionary<string, SortedSet<Product>> productsByType = new Dictionary<string, SortedSet<Product>>();
        private static readonly SortedSet<Product> products = new SortedSet<Product>();

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            var command = Console.ReadLine();
            while (!command.StartsWith("end"))
            {
                var splittedCommand = command.Split(' ');

                var commandType = splittedCommand[0];

                if (commandType == "add")
                {
                    Add(splittedCommand);
                }
                else if (commandType == "filter")
                {
                    if (splittedCommand[2] == "type")
                    {
                        FilterByType(splittedCommand[3]);
                    }
                    else if (splittedCommand[2] == "price")
                    {
                        if (splittedCommand.Length == 7)
                        {
                            FilterByPriceBoth(splittedCommand);
                        }
                        else
                        {
                            if (splittedCommand[3] == "to")
                            {
                                FilterByPriceTo(splittedCommand);
                            }
                            else
                            {
                                FilterByPriceFrom(splittedCommand);
                            }
                        }
                    }
                }

                command = Console.ReadLine();
            }
        }

        private static void FilterByPriceFrom(string[] splittedCommand)
        {
            var price = double.Parse(splittedCommand[4]);
            var result = products.Where(p => p.Price >= price).Take(10);

            Console.WriteLine(Result, string.Join(", ", result));
        }

        private static void FilterByPriceTo(string[] splittedCommand)
        {
            var price = double.Parse(splittedCommand[4]);
            var result = products.Where(p => p.Price <= price).Take(10);

            Console.WriteLine(Result, string.Join(", ", result));
        }

        private static void FilterByPriceBoth(string[] splittedCommand)
        {
            var min = double.Parse(splittedCommand[4]);
            var max = double.Parse(splittedCommand[6]);

            var result = products.Where(p => p.Price >= min && p.Price <= max).Take(10);

            Console.WriteLine(Result, string.Join(", ", result));
        }

        private static void FilterByType(string type)
        {
            if (productsByType.ContainsKey(type))
            {
                var productsType = productsByType[type]
                    .Take(10);

                Console.WriteLine(Result, string.Join(", ", productsType));
            }
            else
            {
                Console.WriteLine("Error: Type {0} does not exists", type);
            }
        }

        private static void Add(string[] parameters)
        {
            var unitName = parameters[1];
            if (productsByName.ContainsKey(unitName))
            {
                Console.WriteLine(FailAdd, unitName);
            }
            else
            {
                var unitType = parameters[3];
                var price = double.Parse(parameters[2]);

                var product = new Product
                {
                    Name = unitName,
                    Price = price,
                    UnitType = unitType
                };

                if (productsByType.ContainsKey(unitType))
                {
                    productsByType[unitType].Add(product);
                }
                else
                {
                    productsByType[unitType] = new SortedSet<Product> { product };
                }

                productsByName.Add(unitName, product);
                products.Add(product);

                Console.WriteLine(SuccessAdd, unitName);
            }
        }
    }

    class Product : IComparable<Product>
    {
        public string Name { get; set; }

        public string UnitType { get; set; }

        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            var result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }

            if (result == 0)
            {
                result = this.UnitType.CompareTo(other.UnitType);
            }

            return result;
        }

        public override string ToString()
        {
            return string.Format("{0}({2})", this.Name, this.UnitType, this.Price);
        }
    }
}
