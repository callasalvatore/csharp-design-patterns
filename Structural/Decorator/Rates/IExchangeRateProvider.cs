namespace Decorator.Rates
{
    /// <summary>
    /// The component: the interface shared by the real provider and all its decorators.
    /// </summary>
    internal interface IExchangeRateProvider
    {
        decimal GetRate(string from, string to);
    }
}
