using Visitor.Visitors;

namespace Visitor.Products
{
    /// <summary>
    /// The element: every cart item accepts a visitor and tells it its concrete type.
    /// </summary>
    internal interface ICartItem
    {
        string Name { get; }
        decimal Price { get; }
        void Accept(ICartVisitor visitor);
    }
}
