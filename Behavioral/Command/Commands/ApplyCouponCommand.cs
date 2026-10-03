using Command.Cart;

namespace Command.Commands
{
    internal class ApplyCouponCommand : ICartCommand
    {
        private readonly ShoppingCart _cart;
        private readonly string _code;
        private readonly int _discountPercent;
        private int _previousDiscount;

        public ApplyCouponCommand(ShoppingCart cart, string code, int discountPercent)
        {
            _cart = cart;
            _code = code;
            _discountPercent = discountPercent;
        }

        public string Description => $"Apply coupon {_code} (-{_discountPercent}%)";

        public void Execute()
        {
            _previousDiscount = _cart.DiscountPercent;
            _cart.SetDiscount(_discountPercent);
        }

        public void Undo() => _cart.SetDiscount(_previousDiscount);
    }
}
