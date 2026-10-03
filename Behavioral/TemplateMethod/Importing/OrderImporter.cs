using System.Globalization;

namespace TemplateMethod.Importing
{
    /// <summary>
    /// The abstract class: Import() is the template method. It fixes the steps
    /// and their order; subclasses only fill in the steps that depend on the format.
    /// </summary>
    internal abstract class OrderImporter
    {
        protected abstract string SourceName { get; }

        // The template method: not virtual, so subclasses can't change the sequence
        public void Import(string content)
        {
            Console.WriteLine($"Importing from {SourceName}:");

            var orders = Parse(content);
            var imported = 0;

            foreach (var order in orders)
            {
                var error = Validate(order);
                if (error is not null)
                {
                    var label = string.IsNullOrWhiteSpace(order.Id) ? $"order of {order.Customer}" : order.Id;
                    Console.WriteLine($"  Rejected {label}: {error}");
                    continue;
                }

                Save(order);
                imported++;
            }

            Console.WriteLine($"  Imported {imported}, rejected {orders.Count - imported}");
            OnImportCompleted(imported);
        }

        // Step that changes with the format: every subclass must implement it
        protected abstract IReadOnlyList<ImportedOrder> Parse(string content);

        // Hook: an optional step, empty by default
        protected virtual void OnImportCompleted(int importedCount)
        {
        }

        // Steps shared by every format
        private static string? Validate(ImportedOrder order)
        {
            if (string.IsNullOrWhiteSpace(order.Id))
                return "missing order id";

            if (order.Amount <= 0)
                return "amount must be a positive number";

            return null;
        }

        private static void Save(ImportedOrder order) =>
            Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
                $"  Saved {order.Id}: {order.Customer}, {order.Amount:0.00} EUR"));
    }
}
