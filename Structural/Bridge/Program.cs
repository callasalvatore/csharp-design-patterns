
using Bridge.Renderers;
using Bridge.Reports;

Sale[] sales =
[
    new("Laptop", 3, 899.00m),
    new("Monitor", 5, 179.90m),
    new("Keyboard", 12, 49.50m)
];

StockItem[] stock =
[
    new("Laptop", 4, 5),
    new("Monitor", 20, 8),
    new("Keyboard", 2, 10)
];

var markdown = new MarkdownRenderer();
var plainText = new PlainTextRenderer();

// Any report can be combined with any renderer: 2 + 2 classes instead of 2 x 2
Report[] reports =
[
    new SalesReport(markdown, sales),
    new SalesReport(plainText, sales),
    new InventoryReport(plainText, stock)
];

foreach (var report in reports)
{
    Console.WriteLine(report.Generate());
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
