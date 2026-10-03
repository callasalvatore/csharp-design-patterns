using System.Globalization;
using Decorator.Rates;

namespace Decorator.Decorators
{
    /// <summary>
    /// Adds logging: writes every request and its result.
    /// </summary>
    internal class LoggingExchangeRateProvider : ExchangeRateProviderDecorator
    {
        public LoggingExchangeRateProvider(IExchangeRateProvider inner) : base(inner)
        {
        }

        public override decimal GetRate(string from, string to)
        {
            Console.WriteLine($" [Log] GetRate({from}, {to})");

            var rate = Inner.GetRate(from, to);

            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $" [Log] {from}/{to} = {rate:0.0000}"));
            return rate;
        }
    }
}
