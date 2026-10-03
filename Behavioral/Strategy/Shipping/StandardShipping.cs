namespace Strategy.Shipping
{
    /// <summary>
    /// Base price plus a fee for each kg above 2 kg. Free in Italy for orders from 50 EUR.
    /// </summary>
    internal class StandardShipping : IShippingStrategy
    {
        public string Name => "Standard";

        public bool IsAvailableFor(Parcel parcel) => true;

        public decimal CalculateCost(Parcel parcel)
        {
            var isDomestic = parcel.Country == "IT";

            if (isDomestic && parcel.OrderTotal >= 50m)
                return 0m;

            var extraKg = Math.Max(0m, parcel.WeightKg - 2m);
            return isDomestic
                ? 4.90m + extraKg * 1.00m
                : 12.90m + extraKg * 2.00m;
        }
    }
}
