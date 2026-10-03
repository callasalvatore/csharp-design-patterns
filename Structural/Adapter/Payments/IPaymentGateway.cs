namespace Adapter.Payments
{
    /// <summary>
    /// The target interface: what our application expects from any payment provider.
    /// </summary>
    internal interface IPaymentGateway
    {
        PaymentResult Charge(decimal amount, string currency);
    }
}
