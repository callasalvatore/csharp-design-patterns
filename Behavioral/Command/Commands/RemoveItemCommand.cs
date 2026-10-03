using Command.Cart;

namespace Command.Commands
{
    internal class RemoveItemCommand : ICartCommand
    {
        private readonly ShoppingCart _cart;
        private readonly string _product;

        // State saved by Execute() and needed by Undo()
        private CartLine? _removedLine;

        public RemoveItemCommand(ShoppingCart cart, string product)
        {
            _cart = cart;
            _product = product;
        }

        public string Description => $"Remove {_product}";

        public void Execute() => _removedLine = _cart.RemoveItem(_product);

        public void Undo()
        {
            if (_removedLine is not null)
                _cart.AddItem(_removedLine.Product, _removedLine.UnitPrice, _removedLine.Quantity);
        }
    }
}
