
using Iterator.Customers;
using Iterator.Iteration;

var customers = new PagedCustomerCollection(new CustomerApi(), pageSize: 10);

// 1. The client just uses foreach: paging is hidden inside the iterator
Console.WriteLine("First 3 customers:");
foreach (var customer in customers.Take(3))
    Console.WriteLine($"  #{customer.Id} {customer.Name} ({customer.City})");

// 2. LINQ stops as soon as it finds a match: only the needed pages are loaded
Console.WriteLine();
Console.WriteLine("First customer in Torino:");
var fromTorino = customers.First(customer => customer.City == "Torino");
Console.WriteLine($"  #{fromTorino.Id} {fromTorino.Name}");

// 3. Counting needs all the pages
Console.WriteLine();
Console.WriteLine("Counting all customers:");
Console.WriteLine($"  Total: {customers.Count()}");

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
