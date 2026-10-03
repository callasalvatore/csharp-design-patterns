namespace Composite.Catalog
{
    /// <summary>
    /// The component: the common interface for single products and bundles,
    /// so that clients can treat both in the same way.
    /// </summary>
    internal interface ICatalogItem
    {
        string Name { get; }
        decimal GetPrice();
        void Display(int depth = 0);
    }
}
