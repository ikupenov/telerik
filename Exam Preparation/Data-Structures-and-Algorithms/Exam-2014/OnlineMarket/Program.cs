using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineMarket
{
    class Program
    {
        private static HashSet<Product> products;
        private static HashSet<string> productNames;
        private static SortedSet<double> productPrices;

        private static Dictionary<double, SortedSet<Product>> sortedByPrice;
        private static Dictionary<string, SortedSet<Product>> sortedByType;

        static void Main()
        {
            products = new HashSet<Product>();
            productNames = new HashSet<string>();
            productPrices = new SortedSet<double>();

            sortedByPrice = new Dictionary<double, SortedSet<Product>>();
            sortedByType = new Dictionary<string, SortedSet<Product>>();

            string command = Console.ReadLine();
            while (command != "end")
            {
                Console.WriteLine(ReadCommands(command));
                command = Console.ReadLine();
            }
        }

        static string ReadCommands(string command)
        {
            var commandInfo = command.Split(' ');
            var commandName = commandInfo[0];

            switch (commandName)
            {
                case "add":
                    return AddProduct(commandInfo[1], double.Parse(commandInfo[2]), commandInfo[3]);

                case "filter":
                    if (commandInfo[2] == "type")
                    {
                        return FilterByType(commandInfo[3]);
                    }
                    else
                    {
                        if (commandInfo.Length == 5)
                        {
                            double minPrice = 0;
                            double maxPrice = double.MaxValue;

                            if (commandInfo[3] == "from")
                            {
                                minPrice = double.Parse(commandInfo[4]);
                            }
                            else
                            {
                                maxPrice = double.Parse(commandInfo[4]);
                            }

                            return FilterByPrice(minPrice, maxPrice);
                        }
                        else
                        {
                            double minPrice = double.Parse(commandInfo[4]);
                            double maxPrice = double.Parse(commandInfo[6]);

                            return FilterByPrice(minPrice, maxPrice);
                        }
                    }

                default: throw new InvalidOperationException();
            }
        }

        static string AddProduct(string productName, double productPrice, string productType)
        {
            if (productNames.Contains(productName))
            {
                return string.Format("Error: Product {0} already exists", productName);
            }

            if (!sortedByType.ContainsKey(productType))
            {
                sortedByType.Add(productType, new SortedSet<Product>());
            }

            if (!sortedByPrice.ContainsKey(productPrice))
            {
                sortedByPrice.Add(productPrice, new SortedSet<Product>());
            }

            productNames.Add(productName);
            productPrices.Add(productPrice);

            var product = new Product(productName, productPrice, productType);

            products.Add(product);
            sortedByType[productType].Add(product);
            sortedByPrice[productPrice].Add(product);

            return string.Format("Ok: Product {0} added successfully", productName);
        }

        static string FilterByType(string typeName)
        {
            if (!sortedByType.ContainsKey(typeName))
            {
                return string.Format("Error: Type {0} does not exists", typeName);
            }

            var filteredProducts = sortedByType[typeName].Take(10);

            string output = "Ok: " + string.Join(", ", filteredProducts);
            return output;
        }

        static string FilterByPrice(double minPrice, double maxPrice)
        {
            var pricesInRange = productPrices.GetViewBetween(minPrice, maxPrice);

            var products = new List<Product>();

            foreach (var price in pricesInRange)
            {
                foreach (var product in sortedByPrice[price])
                {
                    if (products.Count == 10)
                    {
                        return "Ok: " + string.Join(", ", products);
                    }

                    products.Add(product);
                }
            }

            string output = "Ok: " + string.Join(", ", products);
            return output;
        }
    }

    class Product : IComparable<Product>
    {
        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Type { get; set; }

        public int CompareTo(Product other)
        {
            int priceCompareResult = this.Price.CompareTo(other.Price);
            if (priceCompareResult == 0)
            {
                int nameComparedResult = this.Name.CompareTo(other.Name);
                if (nameComparedResult == 0)
                {
                    return this.Type.CompareTo(other.Type);
                }
                else
                {
                    return nameComparedResult;
                }
            }
            else
            {
                return priceCompareResult;
            }
        }

        public override int GetHashCode()
        {
            return 23 + this.Name.GetHashCode() >> 17 ^
                   (23 + this.Price.GetHashCode() >> 17 ^
                    (23 + this.Type.GetHashCode() >> 17));
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Price);
        }
    }
}
