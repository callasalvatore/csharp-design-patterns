using Builder.Builders;
using Builder.Products;

namespace Builder.Directors
{
    /// <summary>
    /// The director knows the order and the values of the steps needed
    /// to produce well-known configurations, so clients don't have to repeat them.
    /// </summary>
    internal class ComputerDirector
    {
        private readonly IComputerBuilder _builder;

        public ComputerDirector(IComputerBuilder builder)
        {
            _builder = builder;
        }

        public Computer BuildOfficePc() =>
            _builder
                .WithCpu("Intel Core i5")
                .WithRam(16)
                .WithStorage(512)
                .WithWifi()
                .Build();

        public Computer BuildGamingPc() =>
            _builder
                .WithCpu("AMD Ryzen 9")
                .WithRam(32)
                .WithStorage(2000)
                .WithGpu("NVIDIA RTX 4080")
                .Build();
    }
}
