using Decorator.Rates;

namespace Decorator.Decorators
{
    /// <summary>
    /// Adds retries: if the wrapped provider times out, the call is repeated.
    /// </summary>
    internal class RetryExchangeRateProvider : ExchangeRateProviderDecorator
    {
        private readonly int _maxAttempts;

        public RetryExchangeRateProvider(IExchangeRateProvider inner, int maxAttempts) : base(inner)
        {
            _maxAttempts = maxAttempts;
        }

        public override decimal GetRate(string from, string to)
        {
            for (var attempt = 1; ; attempt++)
            {
                try
                {
                    return Inner.GetRate(from, to);
                }
                catch (TimeoutException ex) when (attempt < _maxAttempts)
                {
                    Console.WriteLine($"   [Retry] Attempt {attempt} failed: {ex.Message} Retrying...");
                }
            }
        }
    }
}
