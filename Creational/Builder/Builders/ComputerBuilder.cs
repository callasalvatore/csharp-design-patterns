using Builder.Products;

namespace Builder.Builders
{
    internal class ComputerBuilder : IComputerBuilder
    {
        private string? _cpu;
        private int _ramGb;
        private int _storageGb;
        private string? _gpu;
        private bool _hasWifi;

        public IComputerBuilder WithCpu(string cpu)
        {
            _cpu = cpu;
            return this;
        }

        public IComputerBuilder WithRam(int gigabytes)
        {
            _ramGb = gigabytes;
            return this;
        }

        public IComputerBuilder WithStorage(int gigabytes)
        {
            _storageGb = gigabytes;
            return this;
        }

        public IComputerBuilder WithGpu(string gpu)
        {
            _gpu = gpu;
            return this;
        }

        public IComputerBuilder WithWifi()
        {
            _hasWifi = true;
            return this;
        }

        /// <summary>
        /// Validates the collected parts, returns the product and resets the builder
        /// so the same instance can be reused for the next build.
        /// </summary>
        public Computer Build()
        {
            if (string.IsNullOrWhiteSpace(_cpu))
                throw new InvalidOperationException("A CPU is required.");
            if (_ramGb <= 0)
                throw new InvalidOperationException("RAM must be greater than zero.");
            if (_storageGb <= 0)
                throw new InvalidOperationException("Storage must be greater than zero.");

            var computer = new Computer(_cpu, _ramGb, _storageGb, _gpu, _hasWifi);
            Reset();
            return computer;
        }

        private void Reset()
        {
            _cpu = null;
            _ramGb = 0;
            _storageGb = 0;
            _gpu = null;
            _hasWifi = false;
        }
    }
}
