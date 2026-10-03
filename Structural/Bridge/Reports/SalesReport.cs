using System.Globalization;
using Bridge.Renderers;

namespace Bridge.Reports
{
    internal class SalesReport : Report
    {
        private readonly IReadOnlyList<Sale> _sales;

        public SalesReport(IReportRenderer renderer, IReadOnlyList<Sale> sales) : base(renderer)
        {
            _sales = sales;
        }

        public override string Generate()
        {
            var rows = _sales
                .Select(sale => new[] { sale.Product, sale.Quantity.ToString(), Money(sale.UnitPrice), Money(sale.Total) })
                .ToList();

            return Renderer.Title("Monthly sales")
                 + Renderer.Table(["Product", "Qty", "Unit price", "Total"], rows)
                 + Renderer.Note($"Revenue: {Money(_sales.Sum(sale => sale.Total))} EUR");
        }

        private static string Money(decimal amount) => amount.ToString("0.00", CultureInfo.InvariantCulture);
    }
}
