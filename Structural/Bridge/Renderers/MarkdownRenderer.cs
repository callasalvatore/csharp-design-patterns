using System.Text;

namespace Bridge.Renderers
{
    internal class MarkdownRenderer : IReportRenderer
    {
        public string Title(string text) => $"# {text}\n\n";

        public string Table(IReadOnlyList<string> headers, IReadOnlyList<string[]> rows)
        {
            var table = new StringBuilder();
            table.Append($"| {string.Join(" | ", headers)} |\n");
            table.Append($"|{string.Join("|", headers.Select(_ => "---"))}|\n");

            foreach (var row in rows)
                table.Append($"| {string.Join(" | ", row)} |\n");

            return table.Append('\n').ToString();
        }

        public string Note(string text) => $"> {text}\n";
    }
}
