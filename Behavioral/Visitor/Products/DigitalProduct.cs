using Visitor.Visitors;

namespace Visitor.Products
{
    internal class DigitalProduct : ICartItem
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool IsEbook { get; }

        public DigitalProduct(string name, decimal price, bool isEbook)
        {
            Name = name;
            Price = price;
            IsEbook = isEbook;
        }

        public void Accept(ICartVisitor visitor) => visitor.Visit(this);
    }
}
