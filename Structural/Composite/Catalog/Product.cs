using System.Globalization;

namespace Composite.Catalog
{
    /// <summary>
    /// The leaf: a single product with its own price and no children.
    /// </summary>
    internal class Product : ICatalogItem
    {
        private readonly decimal _price;

        public string Name { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            _price = price;
        }

        public decimal GetPrice() => _price;

        public void Display(int depth = 0) =>
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"{new string(' ', depth * 2)}- {Name}: {_price:0.00} EUR"));
    }
}
