using System.Globalization;

namespace Command.Cart
{
    /// <summary>
    /// The receiver: it knows how to change the cart, but nothing about undo or history.
    /// </summary>
    internal class ShoppingCart
    {
        private readonly List<CartLine> _lines = [];

        public int DiscountPercent { get; private set; }

        public decimal Total =>
            decimal.Round(_lines.Sum(line => line.UnitPrice * line.Quantity) * (100 - DiscountPercent) / 100, 2);

        public void AddItem(string product, decimal unitPrice, int quantity)
        {
            var line = _lines.Find(l => l.Product == product);
            if (line is null)
                _lines.Add(new CartLine(product, unitPrice, quantity));
            else
                line.Quantity += quantity;
        }

        public void RemoveQuantity(string product, int quantity)
        {
            var line = _lines.Single(l => l.Product == product);
            line.Quantity -= quantity;
            if (line.Quantity == 0)
                _lines.Remove(line);
        }

        public CartLine? RemoveItem(string product)
        {
            var line = _lines.Find(l => l.Product == product);
            if (line is not null)
                _lines.Remove(line);
            return line;
        }

        public void SetDiscount(int percent) => DiscountPercent = percent;

        public override string ToString()
        {
            var items = _lines.Count == 0 ? "empty" : string.Join(", ", _lines.Select(l => $"{l.Product} x{l.Quantity}"));
            var discount = DiscountPercent > 0 ? $" | -{DiscountPercent}%" : "";
            return string.Create(CultureInfo.InvariantCulture, $"[{items}{discount} | total {Total:0.00} EUR]");
        }
    }
}
