
using Command.Cart;
using Command.Commands;

var cart = new ShoppingCart();
var history = new CommandHistory();

// Every user action becomes a command executed through the history
void Run(Action action)
{
    action();
    Console.WriteLine($"      {cart}");
}

Run(() => history.Execute(new AddItemCommand(cart, "Laptop", 899.00m, 1)));
Run(() => history.Execute(new AddItemCommand(cart, "Mouse", 25.00m, 2)));
Run(() => history.Execute(new ApplyCouponCommand(cart, "WELCOME10", 10)));
Run(() => history.Execute(new RemoveItemCommand(cart, "Mouse")));

Console.WriteLine();
Run(history.Undo);
Run(history.Undo);
Run(history.Redo);

Console.WriteLine();
Run(() => history.Execute(new AddItemCommand(cart, "USB-C cable", 12.90m, 1)));
Run(history.Redo);

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
