
using Mediator.Checkout;
using Mediator.Components;

var country = new CountrySelector();
var shipping = new ShippingSelector();
var coupon = new CouponField();
var terms = new TermsCheckbox();
var summary = new OrderSummary();
var button = new PlaceOrderButton();

// The mediator connects the components: they never reference each other
_ = new CheckoutFormMediator(120.00m, country, shipping, coupon, terms, summary, button);

// Simulating what the user does on the page
country.Select("IT");
shipping.Choose("Express");
coupon.Enter("WELCOME");
coupon.Enter("SAVE10");
button.Click();
terms.Toggle();
country.Select("DE");
button.Click();

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
