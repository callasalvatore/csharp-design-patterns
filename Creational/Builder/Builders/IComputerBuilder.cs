using Builder.Products;

namespace Builder.Builders
{
    /// <summary>
    /// Declares the construction steps. Each step returns the builder itself
    /// to allow a fluent (chained) syntax.
    /// </summary>
    internal interface IComputerBuilder
    {
        IComputerBuilder WithCpu(string cpu);
        IComputerBuilder WithRam(int gigabytes);
        IComputerBuilder WithStorage(int gigabytes);
        IComputerBuilder WithGpu(string gpu);
        IComputerBuilder WithWifi();
        Computer Build();
    }
}
