
using Interpreter.Parsing;
using Interpreter.Rules;

// Promotion rules written by the marketing team, e.g. in an admin panel
(string Name, string Rule)[] promotions =
[
    ("Free shipping in Italy", "country = 'IT' AND total >= 50"),
    ("Members deal", "isMember = true AND (items >= 3 OR total > 200)"),
    ("Welcome coupon", "NOT isMember = true AND total >= 100")
];

// 1. Each rule is parsed once into a tree of expressions
Console.WriteLine("Parsed rules:");
var parsedRules = promotions
    .Select(promotion => (promotion.Name, Expression: RuleParser.Parse(promotion.Rule)))
    .ToList();

foreach (var (name, expression) in parsedRules)
    Console.WriteLine($"  {name}: {expression}");

// 2. The same trees are interpreted against different orders
var orders = new (string Description, OrderContext Context)[]
{
    ("Order #1 (IT, 79.90 EUR, 2 items, guest)", new OrderContext
    {
        ["country"] = "IT", ["total"] = 79.90m, ["items"] = 2m, ["isMember"] = false
    }),
    ("Order #2 (DE, 249.00 EUR, 1 item, member)", new OrderContext
    {
        ["country"] = "DE", ["total"] = 249.00m, ["items"] = 1m, ["isMember"] = true
    }),
    ("Order #3 (FR, 120.00 EUR, 4 items, guest)", new OrderContext
    {
        ["country"] = "FR", ["total"] = 120.00m, ["items"] = 4m, ["isMember"] = false
    })
};

foreach (var (description, context) in orders)
{
    Console.WriteLine();
    Console.WriteLine(description);

    var applied = parsedRules.Where(rule => rule.Expression.Interpret(context)).Select(rule => rule.Name).ToList();
    Console.WriteLine(applied.Count > 0 ? $"  Promotions: {string.Join(", ", applied)}" : "  Promotions: none");
}

// 3. Invalid rules are rejected when parsed
Console.WriteLine();
try
{
    RuleParser.Parse("total >= AND country = 'IT'");
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid rule: {ex.Message}");
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
