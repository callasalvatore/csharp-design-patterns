
using System.Globalization;
using Decorator.Decorators;
using Decorator.Rates;

// Each decorator wraps the previous one and adds a single behavior.
// The client only sees an IExchangeRateProvider.
IExchangeRateProvider provider =
    new LoggingExchangeRateProvider(
        new CachingExchangeRateProvider(
            new RetryExchangeRateProvider(
                new ApiExchangeRateProvider(),
                maxAttempts: 3)));

Convert(100m, "EUR", "USD");
Convert(250m, "EUR", "USD");
Convert(80m, "EUR", "GBP");

Console.WriteLine("Press any key to exit...");
Console.ReadLine();

void Convert(decimal amount, string from, string to)
{
    Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Converting {amount:0.00} {from} to {to}:"));

    var rate = provider.GetRate(from, to);

    Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Result: {amount * rate:0.00} {to}"));
    Console.WriteLine();
}
