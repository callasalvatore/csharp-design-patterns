using System.Globalization;

namespace Adapter.Payments
{
    /// <summary>
    /// The client: it only knows IPaymentGateway, never the third-party SDKs.
    /// </summary>
    internal class CheckoutService
    {
        private readonly IPaymentGateway _gateway;

        public CheckoutService(IPaymentGateway gateway)
        {
            _gateway = gateway;
        }

        public void PlaceOrder(string orderId, decimal total, string currency)
        {
            var result = _gateway.Charge(total, currency);

            Console.WriteLine(result.IsSuccess
                ? string.Create(CultureInfo.InvariantCulture, $"Order {orderId}: paid {total:0.00} {currency} (transaction {result.TransactionId})")
                : $"Order {orderId}: payment failed - {result.Error}");
        }
    }
}
