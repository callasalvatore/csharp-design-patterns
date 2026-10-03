
using TemplateMethod.Importing;

const string csv = """
    id,customer,amount
    A-100,ACME Corp,250.00
    A-101,Globex,abc
    A-102,Initech,99.90
    """;

const string json = """
    [
      { "id": "M-500", "buyer": "Umbrella Inc", "total": 120.50 },
      { "id": "", "buyer": "Stark Industries", "total": 80.00 }
    ]
    """;

// Same algorithm, different formats
OrderImporter[] importers = [new CsvOrderImporter(), new JsonOrderImporter()];
string[] contents = [csv, json];

for (var i = 0; i < importers.Length; i++)
{
    importers[i].Import(contents[i]);
    Console.WriteLine();
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
