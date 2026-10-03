using System.Globalization;
using Observer.Observers;

namespace Observer.Catalog
{
    /// <summary>
    /// The subject: keeps a list of observers and notifies them when its price changes.
    /// It doesn't know what the observers do with the notification.
    /// </summary>
    internal class Product
    {
        private readonly List<IPriceObserver> _observers = [];

        public string Name { get; }
        public decimal Price { get; private set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public void Subscribe(IPriceObserver observer) => _observers.Add(observer);

        public void Unsubscribe(IPriceObserver observer) => _observers.Remove(observer);

        public void ChangePrice(decimal newPrice)
        {
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"{Name}: price set to {newPrice:0.00} EUR"));

            if (newPrice == Price)
            {
                Console.WriteLine("  Same price, nobody is notified");
                return;
            }

            var oldPrice = Price;
            Price = newPrice;

            // Iterate over a copy: an observer may unsubscribe while being notified
            foreach (var observer in _observers.ToList())
                observer.OnPriceChanged(this, oldPrice, newPrice);
        }
    }
}
