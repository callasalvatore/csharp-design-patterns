namespace Strategy.Shipping
{
    /// <summary>
    /// The strategy: one way of shipping a parcel, with its own pricing rules.
    /// </summary>
    internal interface IShippingStrategy
    {
        string Name { get; }
        bool IsAvailableFor(Parcel parcel);
        decimal CalculateCost(Parcel parcel);
    }
}
