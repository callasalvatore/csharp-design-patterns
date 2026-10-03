
using Adapter.Adapters;
using Adapter.Payments;
using Adapter.ThirdParty.PayFast;
using Adapter.ThirdParty.QuickPay;

// The same CheckoutService works with both providers, thanks to the adapters
Console.WriteLine("Checkout with PayFast:");
var payFastCheckout = new CheckoutService(new PayFastAdapter(new PayFastClient()));
payFastCheckout.PlaceOrder("A-100", 49.90m, "EUR");
payFastCheckout.PlaceOrder("A-101", 1500.00m, "EUR");

Console.WriteLine();
Console.WriteLine("Checkout with QuickPay:");
var quickPayCheckout = new CheckoutService(new QuickPayAdapter(new QuickPayApi()));
quickPayCheckout.PlaceOrder("B-200", 49.90m, "EUR");
quickPayCheckout.PlaceOrder("B-201", 25.00m, "USD");

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
