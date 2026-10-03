
using Observer.Catalog;
using Observer.Observers;

var laptop = new Product("Laptop", 899.00m);

// Observers subscribe at runtime; the product doesn't know their types
laptop.Subscribe(new PriceHistoryLog());
laptop.Subscribe(new WishlistAlert("anna@example.com", targetPrice: 800.00m));
laptop.Subscribe(new WishlistAlert("marco@example.com", targetPrice: 850.00m));

laptop.ChangePrice(879.00m);
laptop.ChangePrice(849.00m);
laptop.ChangePrice(799.00m);
laptop.ChangePrice(799.00m);
laptop.ChangePrice(749.00m);

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
