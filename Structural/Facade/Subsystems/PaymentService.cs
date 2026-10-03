using System.Globalization;

namespace Facade.Subsystems
{
    internal class PaymentService
    {
        private int _nextTransactionId = 7001;

        /// <summary>
        /// Returns the transaction id, or null if the payment is declined.
        /// </summary>
        public string? Charge(string paymentToken, decimal amount)
        {
            if (paymentToken == "tok_declined")
            {
                Console.WriteLine("  [Payment] Card declined");
                return null;
            }

            var transactionId = $"PAY-{_nextTransactionId++}";
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"  [Payment] Charged {amount:0.00} EUR ({transactionId})"));
            return transactionId;
        }
    }
}
