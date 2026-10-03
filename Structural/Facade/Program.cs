
using Facade.Checkout;
using Facade.Orders;
using Facade.Subsystems;

var checkout = new CheckoutFacade(new InventoryService(), new PaymentService(), new ShippingService(), new EmailService());

Order[] orders =
[
    new("ORD-1", "mario.rossi@example.com", "Via Roma 1, Milano", "LAPTOP-15", 1, 899.00m, "tok_valid"),
    new("ORD-2", "laura.bianchi@example.com", "Corso Italia 5, Torino", "LAPTOP-15", 2, 1798.00m, "tok_declined"),
    new("ORD-3", "luca.verdi@example.com", "Piazza Dante 3, Napoli", "MONITOR-27", 1, 249.00m, "tok_valid")
];

// The client places an order with one call, without knowing the subsystems involved
foreach (var order in orders)
{
    Console.WriteLine($"Placing order {order.Id}:");
    var result = checkout.PlaceOrder(order);
    Console.WriteLine($"{(result.IsSuccess ? "OK" : "FAILED")}: {result.Message}");
    Console.WriteLine();
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
