using System.Text.Json;

namespace TemplateMethod.Importing
{
    /// <summary>
    /// Reads the JSON sent by a marketplace and, when done, confirms the import to it.
    /// </summary>
    internal class JsonOrderImporter : OrderImporter
    {
        private static readonly JsonSerializerOptions Options = new() { PropertyNameCaseInsensitive = true };

        protected override string SourceName => "marketplace JSON";

        protected override IReadOnlyList<ImportedOrder> Parse(string content) =>
            (JsonSerializer.Deserialize<List<MarketplaceOrder>>(content, Options) ?? [])
                .Select(order => new ImportedOrder(order.Id ?? "", order.Buyer ?? "", order.Total))
                .ToList();

        // Overrides the hook: only this source needs a confirmation
        protected override void OnImportCompleted(int importedCount) =>
            Console.WriteLine($"  [Marketplace] Sent confirmation for {importedCount} order(s)");

        // The marketplace uses its own field names
        private sealed record MarketplaceOrder(string? Id, string? Buyer, decimal Total);
    }
}
