
using State.Orders;

// The same calls behave differently depending on the order's current state
var first = new Order("ORD-1");
Console.WriteLine($"{first.Id} (from new to delivered):");
first.Ship();
first.Pay();
first.Ship();
first.Cancel();
first.Deliver();
first.Pay();
Console.WriteLine($"  Final status: {first.Status}");

Console.WriteLine();
var second = new Order("ORD-2");
Console.WriteLine($"{second.Id} (cancelled after payment):");
second.Pay();
second.Cancel();
second.Ship();
Console.WriteLine($"  Final status: {second.Status}");

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
