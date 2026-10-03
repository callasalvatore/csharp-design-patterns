
using Proxy.Documents;

var currentUser = new User("Anna", "Sales");

// The client only works with IDocument: it doesn't know these are proxies
IDocument[] documents =
[
    new DocumentProxy("sales-q3-2026.pdf", "Sales report Q3", "Sales", currentUser),
    new DocumentProxy("price-list-2026.xlsx", "Price list 2026", "Sales", currentUser),
    new DocumentProxy("payroll-2026-09.pdf", "Payroll September", "HR", currentUser)
];

// 1. Listing the titles doesn't download anything
Console.WriteLine("Documents:");
foreach (var document in documents)
    Console.WriteLine($"  - {document.Title}");

// 2. The content is downloaded on first access only
Console.WriteLine();
Console.WriteLine($"Opening '{documents[0].Title}':");
Console.WriteLine($"  {documents[0].GetContent()}");

Console.WriteLine($"Opening '{documents[0].Title}' again:");
Console.WriteLine($"  {documents[0].GetContent()}");

// 3. Access is checked before downloading
Console.WriteLine();
Console.WriteLine($"Opening '{documents[2].Title}':");
try
{
    documents[2].GetContent();
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"  Access denied: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
