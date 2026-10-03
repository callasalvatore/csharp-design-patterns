using Decorator.Rates;

namespace Decorator.Decorators
{
    /// <summary>
    /// The base decorator: implements the same interface as the component
    /// and wraps another IExchangeRateProvider, which can be the real API or another decorator.
    /// By default it simply forwards the call.
    /// </summary>
    internal abstract class ExchangeRateProviderDecorator : IExchangeRateProvider
    {
        protected readonly IExchangeRateProvider Inner;

        protected ExchangeRateProviderDecorator(IExchangeRateProvider inner)
        {
            Inner = inner;
        }

        public virtual decimal GetRate(string from, string to) => Inner.GetRate(from, to);
    }
}
