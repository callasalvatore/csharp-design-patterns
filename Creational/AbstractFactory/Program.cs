
using AbstractFactory.Interfaces;
using AbstractFactory.MacUI;
using AbstractFactory.WindowsUI;

IGuiFactory factory;

// Simulating runtime decision
Console.Write("Enter OS (win/mac): ");
var input = Console.ReadLine();

factory = input?.ToLower() switch
{
    "mac" => new MacFactory(),
    "win" => new WindowsFactory(),
    _ => throw new Exception("Unsupported OS")
};

var button = factory.CreateButton();
var checkbox = factory.CreateCheckbox();

button.Render();
checkbox.Render();

Console.WriteLine("Press any key to exit...");
Console.ReadLine();