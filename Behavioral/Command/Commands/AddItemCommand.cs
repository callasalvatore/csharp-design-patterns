using Command.Cart;

namespace Command.Commands
{
    internal class AddItemCommand : ICartCommand
    {
        private readonly ShoppingCart _cart;
        private readonly string _product;
        private readonly decimal _unitPrice;
        private readonly int _quantity;

        public AddItemCommand(ShoppingCart cart, string product, decimal unitPrice, int quantity)
        {
            _cart = cart;
            _product = product;
            _unitPrice = unitPrice;
            _quantity = quantity;
        }

        public string Description => $"Add {_quantity} x {_product}";

        public void Execute() => _cart.AddItem(_product, _unitPrice, _quantity);

        public void Undo() => _cart.RemoveQuantity(_product, _quantity);
    }
}
