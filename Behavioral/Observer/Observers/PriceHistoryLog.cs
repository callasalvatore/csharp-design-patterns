using System.Globalization;
using Observer.Catalog;

namespace Observer.Observers
{
    /// <summary>
    /// Records every price change, e.g. to show a price chart on the product page.
    /// </summary>
    internal class PriceHistoryLog : IPriceObserver
    {
        public void OnPriceChanged(Product product, decimal oldPrice, decimal newPrice)
        {
            var change = (newPrice - oldPrice) / oldPrice * 100;
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"  [History] {product.Name}: {oldPrice:0.00} -> {newPrice:0.00} ({change:+0.0;-0.0}%)"));
        }
    }
}
