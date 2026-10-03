namespace Strategy.Shipping
{
    /// <summary>
    /// Next-day delivery: priced on the whole weight, doubled abroad. Never free.
    /// </summary>
    internal class ExpressShipping : IShippingStrategy
    {
        public string Name => "Express";

        public bool IsAvailableFor(Parcel parcel) => true;

        public decimal CalculateCost(Parcel parcel)
        {
            var cost = 9.90m + parcel.WeightKg * 1.50m;
            return parcel.Country == "IT" ? cost : cost * 2;
        }
    }
}
