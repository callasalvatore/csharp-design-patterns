using System.Globalization;
using Observer.Catalog;

namespace Observer.Observers
{
    /// <summary>
    /// A customer's alert: notifies them once when the price reaches their target,
    /// then unsubscribes itself.
    /// </summary>
    internal class WishlistAlert : IPriceObserver
    {
        private readonly string _customerEmail;
        private readonly decimal _targetPrice;

        public WishlistAlert(string customerEmail, decimal targetPrice)
        {
            _customerEmail = customerEmail;
            _targetPrice = targetPrice;
        }

        public void OnPriceChanged(Product product, decimal oldPrice, decimal newPrice)
        {
            if (newPrice > _targetPrice)
                return;

            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"  [Email to {_customerEmail}] {product.Name} is now {newPrice:0.00} EUR (your target: {_targetPrice:0.00})"));

            product.Unsubscribe(this);
        }
    }
}
