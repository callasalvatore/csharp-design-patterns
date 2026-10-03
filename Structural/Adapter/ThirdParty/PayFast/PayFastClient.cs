namespace Adapter.ThirdParty.PayFast
{
    // Simulates a third-party SDK: we can't change this code.
    // Its API differs from ours: amounts in cents, an idempotency key, HTTP-like status codes.
    public class PayFastClient
    {
        private const long CardLimitInCents = 100_000;
        private int _nextPaymentId = 5001;

        public PayFastResponse MakePayment(long amountInCents, string currencyCode, string idempotencyKey)
        {
            if (amountInCents > CardLimitInCents)
                return new PayFastResponse { StatusCode = 402, Message = "Card limit exceeded" };

            return new PayFastResponse { StatusCode = 200, PaymentId = $"pf_{_nextPaymentId++}" };
        }
    }
}
