
using Builder.Builders;
using Builder.Directors;

IComputerBuilder builder = new ComputerBuilder();

// 1. Predefined configurations through the director
var director = new ComputerDirector(builder);

Console.WriteLine("Office PC:");
Console.WriteLine(director.BuildOfficePc());

Console.WriteLine("Gaming PC:");
Console.WriteLine(director.BuildGamingPc());

// 2. Custom configuration using the builder directly
var customPc = builder
    .WithCpu("Apple M3")
    .WithRam(24)
    .WithStorage(1000)
    .WithWifi()
    .Build();

Console.WriteLine("Custom PC:");
Console.WriteLine(customPc);

// 3. The builder enforces required parts before creating the product
try
{
    builder.WithRam(8).Build();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Invalid configuration: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
