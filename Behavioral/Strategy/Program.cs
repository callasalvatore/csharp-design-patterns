
using System.Globalization;
using Strategy.Orders;
using Strategy.Shipping;

IShippingStrategy[] strategies = [new StandardShipping(), new ExpressShipping(), new StorePickup()];

(string Description, Parcel Parcel)[] parcels =
[
    ("Small order to Italy (1.5 kg, 39.90 EUR)", new Parcel(1.5m, "IT", 39.90m)),
    ("Heavy order to Italy (8 kg, 129.00 EUR)", new Parcel(8m, "IT", 129.00m)),
    ("Order to Germany (3 kg, 89.00 EUR)", new Parcel(3m, "DE", 89.00m))
];

// 1. The same parcel priced with every strategy: the shipping options page
foreach (var (description, parcel) in parcels)
{
    Console.WriteLine(description);

    foreach (var strategy in strategies)
    {
        var price = strategy.IsAvailableFor(parcel)
            ? string.Create(CultureInfo.InvariantCulture, $"{strategy.CalculateCost(parcel):0.00} EUR")
            : "not available";
        Console.WriteLine($"  {strategy.Name,-13} {price}");
    }

    Console.WriteLine();
}

// 2. The customer changes the shipping method at checkout
Console.WriteLine("Checkout of the order to Germany:");
var checkout = new OrderCheckout(parcels[2].Parcel, new StandardShipping());
checkout.PrintTotal();

checkout.ChangeShipping(new ExpressShipping());
checkout.PrintTotal();

checkout.ChangeShipping(new StorePickup());
checkout.PrintTotal();

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
