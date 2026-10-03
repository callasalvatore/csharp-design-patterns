
using System.Globalization;
using Composite.Catalog;

var laptop = new Product("Laptop", 899.00m);
var monitor = new Product("Monitor", 179.90m);
var keyboard = new Product("Keyboard", 49.50m);
var mouse = new Product("Mouse", 25.00m);
var cable = new Product("USB-C cable", 12.90m);

// Bundles can contain products and other bundles
var peripheralsPack = new Bundle("Peripherals pack", 10)
    .Add(keyboard)
    .Add(mouse);

var homeOfficeKit = new Bundle("Home office kit", 5)
    .Add(laptop)
    .Add(monitor)
    .Add(peripheralsPack);

// The cart treats single products and bundles in the same way
ICatalogItem[] cart = [cable, homeOfficeKit];

Console.WriteLine("Cart:");
foreach (var item in cart)
    item.Display(1);

var total = cart.Sum(item => item.GetPrice());
Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"Total: {total:0.00} EUR"));

// Cycles are rejected
try
{
    peripheralsPack.Add(homeOfficeKit);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine();
    Console.WriteLine($"Error: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
