using System.Text;

namespace Bridge.Renderers
{
    internal class PlainTextRenderer : IReportRenderer
    {
        public string Title(string text) => $"{text.ToUpperInvariant()}\n{new string('=', text.Length)}\n\n";

        public string Table(IReadOnlyList<string> headers, IReadOnlyList<string[]> rows)
        {
            // Each column is as wide as its longest value
            var widths = headers
                .Select((header, column) => rows.Select(row => row[column].Length).Append(header.Length).Max())
                .ToArray();

            string FormatRow(IEnumerable<string> cells) =>
                string.Join("  ", cells.Select((cell, column) => cell.PadRight(widths[column]))).TrimEnd();

            var table = new StringBuilder();
            table.Append(FormatRow(headers)).Append('\n');
            table.Append(FormatRow(widths.Select(width => new string('-', width)))).Append('\n');

            foreach (var row in rows)
                table.Append(FormatRow(row)).Append('\n');

            return table.Append('\n').ToString();
        }

        public string Note(string text) => $"NOTE: {text}\n";
    }
}
