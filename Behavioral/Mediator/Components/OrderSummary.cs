using System.Globalization;

namespace Mediator.Components
{
    internal class OrderSummary : FormComponent
    {
        public decimal Total { get; private set; }

        public void Update(decimal subtotal, decimal discount, decimal shipping)
        {
            Total = subtotal - discount + shipping;
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"  [Summary] {subtotal:0.00} - {discount:0.00} discount + {shipping:0.00} shipping = {Total:0.00} EUR"));
        }
    }
}
