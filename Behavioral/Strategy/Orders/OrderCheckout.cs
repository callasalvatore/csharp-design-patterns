using System.Globalization;
using Strategy.Shipping;

namespace Strategy.Orders
{
    /// <summary>
    /// The context: calculates the order total using the shipping strategy
    /// chosen by the customer. It doesn't know any pricing rule.
    /// </summary>
    internal class OrderCheckout
    {
        private readonly Parcel _parcel;
        private IShippingStrategy _shipping;

        public OrderCheckout(Parcel parcel, IShippingStrategy shipping)
        {
            _parcel = parcel;
            _shipping = shipping;
        }

        public void ChangeShipping(IShippingStrategy shipping)
        {
            if (!shipping.IsAvailableFor(_parcel))
            {
                Console.WriteLine($"  {shipping.Name} is not available for this order");
                return;
            }

            _shipping = shipping;
        }

        public void PrintTotal()
        {
            var shippingCost = _shipping.CalculateCost(_parcel);
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"  {_parcel.OrderTotal:0.00} + {shippingCost:0.00} ({_shipping.Name}) = {_parcel.OrderTotal + shippingCost:0.00} EUR"));
        }
    }
}
