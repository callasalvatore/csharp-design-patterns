namespace Decorator.Rates
{
    /// <summary>
    /// The concrete component: simulates a remote API that is slow and sometimes fails.
    /// It only knows how to fetch a rate: no caching, no retries, no logging.
    /// </summary>
    internal class ApiExchangeRateProvider : IExchangeRateProvider
    {
        private readonly Dictionary<string, decimal> _rates = new()
        {
            ["EUR/USD"] = 1.0842m,
            ["EUR/GBP"] = 0.8571m
        };

        private int _calls;

        public decimal GetRate(string from, string to)
        {
            _calls++;
            Console.WriteLine($"    [API] Request #{_calls}: {from}/{to}");

            // Simulates a network problem on the very first request
            if (_calls == 1)
                throw new TimeoutException("The rates API did not respond in time.");

            return _rates[$"{from}/{to}"];
        }
    }
}
