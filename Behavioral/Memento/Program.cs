
using Memento.History;
using Memento.Invoices;

var draft = new InvoiceDraft();
var history = new DraftHistory(draft);

// Editing the draft, saving a version before each risky change
Console.WriteLine("Editing:");
draft.SetCustomer("ACME Corp");
draft.AddLine("Consulting - 10 hours", 800.00m);
history.Backup();

draft.AddLine("Travel expenses", 150.00m);
history.Backup();

draft.SetDiscount(5);
draft.SetCustomer("ACME Corporation S.p.A.");
Console.WriteLine($"  Current: {draft}");

// Going back through the saved versions
Console.WriteLine();
Console.WriteLine("Undoing:");
history.Undo();
Console.WriteLine($"  Current: {draft}");

history.Undo();
Console.WriteLine($"  Current: {draft}");

history.Undo();

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
