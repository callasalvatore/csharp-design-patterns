using System.Globalization;
using Mediator.Components;

namespace Mediator.Checkout
{
    /// <summary>
    /// The concrete mediator: the only class that knows all the components
    /// and contains the rules about how a change in one affects the others.
    /// </summary>
    internal class CheckoutFormMediator : ICheckoutMediator
    {
        private static readonly IReadOnlyList<ShippingOption> DomesticOptions =
            [new("Standard", 4.90m), new("Express", 9.90m), new("Store pickup", 0m)];

        private static readonly IReadOnlyList<ShippingOption> InternationalOptions =
            [new("Standard", 14.90m), new("Express", 29.90m)];

        private readonly decimal _subtotal;
        private readonly CountrySelector _country;
        private readonly ShippingSelector _shipping;
        private readonly CouponField _coupon;
        private readonly TermsCheckbox _terms;
        private readonly OrderSummary _summary;
        private readonly PlaceOrderButton _button;
        private decimal _discount;

        public CheckoutFormMediator(decimal subtotal, CountrySelector country, ShippingSelector shipping,
            CouponField coupon, TermsCheckbox terms, OrderSummary summary, PlaceOrderButton button)
        {
            _subtotal = subtotal;
            _country = country;
            _shipping = shipping;
            _coupon = coupon;
            _terms = terms;
            _summary = summary;
            _button = button;

            foreach (FormComponent component in new FormComponent[] { country, shipping, coupon, terms, summary, button })
                component.SetMediator(this);
        }

        public void Notify(FormComponent sender)
        {
            if (sender == _button)
            {
                Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                    $"  Order placed: {_summary.Total:0.00} EUR, {_shipping.Selected!.Name} shipping to {_country.Country}"));
                return;
            }

            if (sender == _country)
                _shipping.SetOptions(_country.Country == "IT" ? DomesticOptions : InternationalOptions);

            if (sender == _coupon)
                _discount = ValidateCoupon(_coupon.Code);

            // Any of these changes may affect the price and whether the order can be placed
            _summary.Update(_subtotal, _discount, _shipping.Selected?.Cost ?? 0m);
            _button.SetEnabled(_country.Country is not null && _shipping.Selected is not null && _terms.IsChecked);
        }

        private decimal ValidateCoupon(string? code)
        {
            if (code == "SAVE10")
            {
                Console.WriteLine("  [Coupon] SAVE10 is valid: -10%");
                return _subtotal * 0.10m;
            }

            Console.WriteLine($"  [Coupon] '{code}' is not valid");
            return 0m;
        }
    }
}
