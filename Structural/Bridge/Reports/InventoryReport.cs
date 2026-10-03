using System.Text;
using Bridge.Renderers;

namespace Bridge.Reports
{
    internal class InventoryReport : Report
    {
        private readonly IReadOnlyList<StockItem> _items;

        public InventoryReport(IReportRenderer renderer, IReadOnlyList<StockItem> items) : base(renderer)
        {
            _items = items;
        }

        public override string Generate()
        {
            var rows = _items
                .Select(item => new[] { item.Product, item.Quantity.ToString(), item.ReorderLevel.ToString() })
                .ToList();

            var report = new StringBuilder()
                .Append(Renderer.Title("Inventory status"))
                .Append(Renderer.Table(["Product", "In stock", "Reorder level"], rows));

            // Same primitives, composed differently: one note for each product to reorder
            foreach (var item in _items.Where(item => item.NeedsReorder))
                report.Append(Renderer.Note($"Reorder {item.Product} ({item.Quantity} left)"));

            return report.ToString();
        }
    }
}
