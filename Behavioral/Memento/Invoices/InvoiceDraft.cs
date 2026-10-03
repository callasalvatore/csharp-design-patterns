using System.Globalization;

namespace Memento.Invoices
{
    /// <summary>
    /// The originator: the object whose state is saved and restored.
    /// Only this class can create a snapshot and read it back.
    /// </summary>
    internal class InvoiceDraft
    {
        private string _customer = "(no customer)";
        private List<InvoiceLine> _lines = [];
        private int _discountPercent;

        public decimal Total => decimal.Round(_lines.Sum(line => line.Amount) * (100 - _discountPercent) / 100, 2);

        public void SetCustomer(string customer) => _customer = customer;

        public void AddLine(string description, decimal amount) => _lines.Add(new InvoiceLine(description, amount));

        public void SetDiscount(int percent) => _discountPercent = percent;

        public IInvoiceMemento Save() => new Snapshot(_customer, _lines, _discountPercent);

        public void Restore(IInvoiceMemento memento)
        {
            if (memento is not Snapshot snapshot)
                throw new ArgumentException("This memento was not created by an invoice draft.", nameof(memento));

            _customer = snapshot.Customer;
            _lines = snapshot.Lines.ToList();
            _discountPercent = snapshot.DiscountPercent;
        }

        public override string ToString()
        {
            var lines = _lines.Count == 0
                ? "no lines"
                : string.Join("; ", _lines.Select(line => string.Create(CultureInfo.InvariantCulture, $"{line.Description} {line.Amount:0.00}")));
            var discount = _discountPercent > 0 ? $" | -{_discountPercent}%" : "";

            return string.Create(CultureInfo.InvariantCulture, $"{_customer}: {lines}{discount} | total {Total:0.00} EUR");
        }

        /// <summary>
        /// The concrete memento. Being a private nested class, its state is visible
        /// only to InvoiceDraft: the rest of the code sees just IInvoiceMemento.
        /// </summary>
        private sealed class Snapshot : IInvoiceMemento
        {
            public string Customer { get; }
            public IReadOnlyList<InvoiceLine> Lines { get; }
            public int DiscountPercent { get; }

            public Snapshot(string customer, IEnumerable<InvoiceLine> lines, int discountPercent)
            {
                Customer = customer;
                // Copy the list: later changes to the draft must not alter the snapshot
                Lines = lines.ToList();
                DiscountPercent = discountPercent;
            }

            public string Description => $"{Customer}, {Lines.Count} line(s), discount {DiscountPercent}%";
        }
    }
}
