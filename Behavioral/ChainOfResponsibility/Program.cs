
using System.Globalization;
using ChainOfResponsibility.Approvers;
using ChainOfResponsibility.Expenses;

// Building the chain: Team lead -> Manager -> Director
var approvalChain = new TeamLead();
approvalChain
    .SetNext(new Manager())
    .SetNext(new Director(annualBudget: 30_000m));

ExpenseRequest[] requests =
[
    new("Anna", "Train ticket to Rome", 120m),
    new("Marco", "Developer laptop", 2_400m),
    new("Sara", "Team offsite", 18_000m),
    new("Luca", "Conference sponsorship", 15_000m)
];

// The client always talks to the first link: it doesn't know who will approve
foreach (var request in requests)
{
    Console.WriteLine(string.Create(CultureInfo.InvariantCulture,
        $"{request.Employee} asks {request.Amount:0.00} EUR for '{request.Description}':"));
    approvalChain.Handle(request);
    Console.WriteLine();
}

Console.WriteLine("Press any key to exit...");
Console.ReadLine();
