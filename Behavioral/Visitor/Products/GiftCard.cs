using Visitor.Visitors;

namespace Visitor.Products
{
    internal class GiftCard : ICartItem
    {
        public string Name { get; }
        public decimal Price { get; }

        public GiftCard(string name, decimal amount)
        {
            Name = name;
            Price = amount;
        }

        public void Accept(ICartVisitor visitor) => visitor.Visit(this);
    }
}
