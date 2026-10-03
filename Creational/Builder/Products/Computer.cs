namespace Builder.Products
{
    /// <summary>
    /// The product: an immutable object with required and optional parts.
    /// Its constructor is internal so that the builder is the only way to create it.
    /// </summary>
    internal class Computer
    {
        public string Cpu { get; }
        public int RamGb { get; }
        public int StorageGb { get; }
        public string? Gpu { get; }
        public bool HasWifi { get; }

        internal Computer(string cpu, int ramGb, int storageGb, string? gpu, bool hasWifi)
        {
            Cpu = cpu;
            RamGb = ramGb;
            StorageGb = storageGb;
            Gpu = gpu;
            HasWifi = hasWifi;
        }

        public override string ToString() =>
            $"CPU: {Cpu} | RAM: {RamGb} GB | Storage: {StorageGb} GB | " +
            $"GPU: {Gpu ?? "Integrated"} | Wi-Fi: {(HasWifi ? "Yes" : "No")}";
    }
}
