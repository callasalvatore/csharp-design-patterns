namespace Command.Cart
{
    internal class CartLine
    {
        public string Product { get; }
        public decimal UnitPrice { get; }
        public int Quantity { get; set; }

        public CartLine(string product, decimal unitPrice, int quantity)
        {
            Product = product;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }
    }
}
