using System.Globalization;

namespace TemplateMethod.Importing
{
    /// <summary>
    /// Reads a CSV export from the accounting software: "id,customer,amount" with a header row.
    /// </summary>
    internal class CsvOrderImporter : OrderImporter
    {
        protected override string SourceName => "CSV file";

        protected override IReadOnlyList<ImportedOrder> Parse(string content) => content
            .Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Skip(1)
            .Select(line => line.Split(','))
            .Select(fields => new ImportedOrder(
                fields[0],
                fields[1],
                // A value that isn't a number becomes 0 and is rejected by the validation step
                decimal.TryParse(fields[2], NumberStyles.Number, CultureInfo.InvariantCulture, out var amount) ? amount : 0m))
            .ToList();
    }
}
