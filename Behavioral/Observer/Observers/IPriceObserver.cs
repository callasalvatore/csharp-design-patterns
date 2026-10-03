using Observer.Catalog;

namespace Observer.Observers
{
    /// <summary>
    /// The observer: anything that wants to react to a price change.
    /// </summary>
    internal interface IPriceObserver
    {
        void OnPriceChanged(Product product, decimal oldPrice, decimal newPrice);
    }
}
