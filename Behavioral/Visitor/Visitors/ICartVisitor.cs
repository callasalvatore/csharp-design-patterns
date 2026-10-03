using Visitor.Products;

namespace Visitor.Visitors
{
    /// <summary>
    /// The visitor: one Visit method for each kind of cart item.
    /// Each operation on the cart (VAT, shipping weight...) is a class implementing it.
    /// </summary>
    internal interface ICartVisitor
    {
        void Visit(PhysicalProduct product);
        void Visit(DigitalProduct product);
        void Visit(GiftCard giftCard);
    }
}
