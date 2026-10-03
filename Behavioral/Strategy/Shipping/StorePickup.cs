namespace Strategy.Shipping
{
    /// <summary>
    /// Free pickup in an Italian store, for parcels up to 20 kg.
    /// </summary>
    internal class StorePickup : IShippingStrategy
    {
        public string Name => "Store pickup";

        public bool IsAvailableFor(Parcel parcel) => parcel.Country == "IT" && parcel.WeightKg <= 20m;

        public decimal CalculateCost(Parcel parcel) => 0m;
    }
}
