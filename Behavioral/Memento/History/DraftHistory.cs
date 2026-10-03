using Memento.Invoices;

namespace Memento.History
{
    /// <summary>
    /// The caretaker: decides when to save and when to restore,
    /// and keeps the mementos without looking inside them.
    /// </summary>
    internal class DraftHistory
    {
        private readonly InvoiceDraft _draft;
        private readonly Stack<IInvoiceMemento> _versions = new();

        public DraftHistory(InvoiceDraft draft)
        {
            _draft = draft;
        }

        public void Backup()
        {
            var memento = _draft.Save();
            _versions.Push(memento);
            Console.WriteLine($"  [History] Saved version {_versions.Count}: {memento.Description}");
        }

        public void Undo()
        {
            if (!_versions.TryPop(out var memento))
            {
                Console.WriteLine("  [History] Nothing to restore");
                return;
            }

            _draft.Restore(memento);
            Console.WriteLine($"  [History] Restored version {_versions.Count + 1}: {memento.Description}");
        }
    }
}
