using Visitor.Visitors;

namespace Visitor.Products
{
    internal class PhysicalProduct : ICartItem
    {
        public string Name { get; }
        public decimal Price { get; }
        public decimal WeightKg { get; }

        public PhysicalProduct(string name, decimal price, decimal weightKg)
        {
            Name = name;
            Price = price;
            WeightKg = weightKg;
        }

        // "this" is a PhysicalProduct here, so the compiler picks Visit(PhysicalProduct)
        public void Accept(ICartVisitor visitor) => visitor.Visit(this);
    }
}
