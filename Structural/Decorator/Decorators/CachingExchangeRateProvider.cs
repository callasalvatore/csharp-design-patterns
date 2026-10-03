using Decorator.Rates;

namespace Decorator.Decorators
{
    /// <summary>
    /// Adds caching: a rate already requested is returned without calling the wrapped provider.
    /// </summary>
    internal class CachingExchangeRateProvider : ExchangeRateProviderDecorator
    {
        private readonly Dictionary<string, decimal> _cache = [];

        public CachingExchangeRateProvider(IExchangeRateProvider inner) : base(inner)
        {
        }

        public override decimal GetRate(string from, string to)
        {
            var key = $"{from}/{to}";

            if (_cache.TryGetValue(key, out var cachedRate))
            {
                Console.WriteLine($"  [Cache] Hit for {key}");
                return cachedRate;
            }

            var rate = Inner.GetRate(from, to);
            _cache[key] = rate;
            return rate;
        }
    }
}
