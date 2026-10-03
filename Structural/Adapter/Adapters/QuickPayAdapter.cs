using System.Globalization;
using Adapter.Payments;
using Adapter.ThirdParty.QuickPay;

namespace Adapter.Adapters
{
    /// <summary>
    /// Adapts the string-based QuickPayApi to IPaymentGateway:
    /// builds the request payload and parses the "OK|..." / "KO|..." response.
    /// </summary>
    internal class QuickPayAdapter : IPaymentGateway
    {
        private readonly QuickPayApi _api;

        public QuickPayAdapter(QuickPayApi api)
        {
            _api = api;
        }

        public PaymentResult Charge(decimal amount, string currency)
        {
            // InvariantCulture: the API expects "49.90", not "49,90" as on an Italian machine
            var payload = string.Create(CultureInfo.InvariantCulture, $"AMOUNT={amount:0.00};CUR={currency.ToUpperInvariant()}");

            var parts = _api.Submit(payload).Split('|', 2);

            return parts[0] == "OK"
                ? PaymentResult.Success(parts[1])
                : PaymentResult.Failure($"QuickPay error: {parts[1]}");
        }
    }
}
