namespace Adapter.Payments
{
    internal record PaymentResult(bool IsSuccess, string? TransactionId, string? Error)
    {
        public static PaymentResult Success(string transactionId) => new(true, transactionId, null);
        public static PaymentResult Failure(string error) => new(false, null, error);
    }
}
