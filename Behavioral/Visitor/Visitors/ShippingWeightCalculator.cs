using System.Globalization;
using Visitor.Products;

namespace Visitor.Visitors
{
    /// <summary>
    /// Adds up the weight of the items that must be shipped.
    /// </summary>
    internal class ShippingWeightCalculator : ICartVisitor
    {
        public decimal TotalWeightKg { get; private set; }

        public void Visit(PhysicalProduct product)
        {
            TotalWeightKg += product.WeightKg;
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture, $"  {product.Name,-22} {product.WeightKg:0.0} kg"));
        }

        public void Visit(DigitalProduct product) =>
            Console.WriteLine($"  {product.Name,-22} download, not shipped");

        public void Visit(GiftCard giftCard) =>
            Console.WriteLine($"  {giftCard.Name,-22} sent by email, not shipped");
    }
}
