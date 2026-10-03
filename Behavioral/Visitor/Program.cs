
using System.Globalization;
using Visitor.Products;
using Visitor.Visitors;

ICartItem[] cart =
[
    new PhysicalProduct("Laptop", 899.00m, weightKg: 2.1m),
    new PhysicalProduct("Monitor", 179.90m, weightKg: 5.4m),
    new DigitalProduct("C# Patterns (e-book)", 39.90m, isEbook: true),
    new DigitalProduct("Antivirus license", 49.00m, isEbook: false),
    new GiftCard("Gift card", 50.00m)
];

// Each operation is a visitor: the item classes don't change
Console.WriteLine("VAT:");
var vat = new VatCalculator();
foreach (var item in cart)
    item.Accept(vat);
Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"  Total VAT: {vat.TotalVat:0.00} EUR"));

Console.WriteLine();
Console.WriteLine("Shipping weight:");
var weight = new ShippingWeightCalculator();
foreach (var item in cart)
    item.Accept(weight);
Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"  Total weight: {weight.TotalWeightKg:0.0} kg"));

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
