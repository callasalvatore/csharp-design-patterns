
using Prototype.Documents;
using Prototype.Registry;

// The templates are built once (in a real app they could be loaded from files or a database)
var invoiceTemplate = new Document(
    "Invoice",
    new Style("Arial", 11),
    [
        new Section("Header", "Company name and address"),
        new Section("Payment terms", "30 days from the invoice date")
    ]);

var contractTemplate = new Document(
    "Contract",
    new Style("Times New Roman", 12),
    [
        new Section("Parties", "Provider and customer details"),
        new Section("Termination", "Either party may terminate with 60 days notice")
    ]);

var registry = new DocumentTemplateRegistry();
registry.Register("invoice", invoiceTemplate);
registry.Register("contract", contractTemplate);

// 1. New documents are created by cloning the templates, then customized
var invoice = registry.Create("invoice");
invoice.Title = "Invoice #001 - ACME Corp";
invoice.Style.FontSize = 14;
invoice.Sections.Add(new Section("Items", "10 x Consulting hours"));

var contract = registry.Create("contract");
contract.Title = "Contract - ACME Corp";
contract.Sections[0].Body = "Contoso Ltd and ACME Corp";

Console.WriteLine("Customized documents:");
Console.WriteLine(invoice);
Console.WriteLine(contract);

// 2. Deep copy: the templates are unchanged
Console.WriteLine("Templates after deep clones:");
Console.WriteLine(invoiceTemplate);
Console.WriteLine(contractTemplate);

// 3. Shallow copy pitfall: the copy shares Style and Sections with the template
var shallowInvoice = invoiceTemplate.ShallowClone();
shallowInvoice.Title = "Invoice #002 - Shallow copy";
shallowInvoice.Style.FontSize = 20;
shallowInvoice.Sections.Add(new Section("Notes", "This section leaks into the template!"));

Console.WriteLine("Template after a shallow clone was modified:");
Console.WriteLine(invoiceTemplate);

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
