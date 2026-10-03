using Adapter.Payments;
using Adapter.ThirdParty.PayFast;

namespace Adapter.Adapters
{
    /// <summary>
    /// Adapts PayFastClient to IPaymentGateway: converts the amount to cents,
    /// generates the idempotency key and maps the status code to a PaymentResult.
    /// </summary>
    internal class PayFastAdapter : IPaymentGateway
    {
        private readonly PayFastClient _client;

        public PayFastAdapter(PayFastClient client)
        {
            _client = client;
        }

        public PaymentResult Charge(decimal amount, string currency)
        {
            var amountInCents = (long)decimal.Round(amount * 100, MidpointRounding.AwayFromZero);
            var idempotencyKey = Guid.NewGuid().ToString("N");

            var response = _client.MakePayment(amountInCents, currency.ToUpperInvariant(), idempotencyKey);

            return response.StatusCode == 200
                ? PaymentResult.Success(response.PaymentId!)
                : PaymentResult.Failure($"PayFast error {response.StatusCode}: {response.Message}");
        }
    }
}
