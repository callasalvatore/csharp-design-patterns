namespace Facade.Subsystems
{
    internal class ShippingService
    {
        private int _nextTrackingNumber = 1;

        public string CreateShipment(string orderId, string address)
        {
            var trackingNumber = $"TRK-{_nextTrackingNumber++:0000}";
            Console.WriteLine($"  [Shipping] Shipment {trackingNumber} for order {orderId} to {address}");
            return trackingNumber;
        }
    }
}
