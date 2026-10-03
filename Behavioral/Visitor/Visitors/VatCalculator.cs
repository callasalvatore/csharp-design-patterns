using System.Globalization;
using Visitor.Products;

namespace Visitor.Visitors
{
    /// <summary>
    /// Calculates the VAT with a different rate for each kind of item (Italian rates).
    /// </summary>
    internal class VatCalculator : ICartVisitor
    {
        public decimal TotalVat { get; private set; }

        public void Visit(PhysicalProduct product) => AddVat(product, 22);

        // E-books have a reduced rate, other digital products the standard one
        public void Visit(DigitalProduct product) => AddVat(product, product.IsEbook ? 4 : 22);

        // Gift cards are a payment method, not a sale: no VAT until they're spent
        public void Visit(GiftCard giftCard) => AddVat(giftCard, 0);

        private void AddVat(ICartItem item, int ratePercent)
        {
            var vat = decimal.Round(item.Price * ratePercent / 100, 2, MidpointRounding.AwayFromZero);
            TotalVat += vat;

            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"  {item.Name,-22} {item.Price,8:0.00}  VAT {ratePercent,2}%  {vat,7:0.00}"));
        }
    }
}
