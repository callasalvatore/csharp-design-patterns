namespace Adapter.ThirdParty.PayFast
{
    // Simulates a type from a third-party SDK: we can't change this code.
    public class PayFastResponse
    {
        public int StatusCode { get; init; }
        public string? PaymentId { get; init; }
        public string? Message { get; init; }
    }
}
