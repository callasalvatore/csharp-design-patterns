using System.Globalization;

namespace Composite.Catalog
{
    /// <summary>
    /// The composite: contains products or other bundles and applies its discount
    /// to the sum of its children. Every operation is delegated recursively to the children.
    /// </summary>
    internal class Bundle : ICatalogItem
    {
        private readonly List<ICatalogItem> _items = [];
        private readonly decimal _discountPercent;

        public string Name { get; }

        public Bundle(string name, decimal discountPercent)
        {
            Name = name;
            _discountPercent = discountPercent;
        }

        public Bundle Add(ICatalogItem item)
        {
            // A bundle that contains itself would cause infinite recursion
            if (item == this || (item is Bundle bundle && bundle.Contains(this)))
                throw new InvalidOperationException($"'{item.Name}' cannot be added to '{Name}': it would create a cycle.");

            _items.Add(item);
            return this;
        }

        public decimal GetPrice()
        {
            var subtotal = _items.Sum(item => item.GetPrice());
            return decimal.Round(subtotal * (1 - _discountPercent / 100), 2, MidpointRounding.AwayFromZero);
        }

        public void Display(int depth = 0)
        {
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"{new string(' ', depth * 2)}+ {Name} (-{_discountPercent}%): {GetPrice():0.00} EUR"));

            foreach (var item in _items)
                item.Display(depth + 1);
        }

        private bool Contains(ICatalogItem target) =>
            _items.Any(item => item == target || (item is Bundle bundle && bundle.Contains(target)));
    }
}
