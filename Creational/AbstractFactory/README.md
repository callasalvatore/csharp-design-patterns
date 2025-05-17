# 🧱 Abstract Factory Pattern – Cross-Platform UI Example (C#)

This example demonstrates the **Abstract Factory Pattern** in C#.  
It focuses on creating **families of related UI components** (like Buttons and Checkboxes) for different platforms (Windows and Mac), without specifying their concrete classes in client code.

---

## 💡 Intent

> Provide an interface for creating families of related or dependent objects without specifying their concrete classes.

This pattern enables you to create sets of related objects (e.g., Windows UI or Mac UI components) that are consistent and interchangeable, while keeping your client code completely decoupled from concrete implementations.

---

## 🧠 Key Concepts in This Example

| Role                   | Class                        | Responsibility                                         |
|------------------------|------------------------------|--------------------------------------------------------|
| Abstract Factory       | `IGuiFactory`                | Declares creation methods for each abstract product    |
| Concrete Factories     | `WindowsFactory`, `MacFactory` | Implement creation methods for platform-specific products |
| Abstract Products      | `IButton`, `ICheckbox`       | Declare interfaces for products                        |
| Concrete Products      | `WindowsButton`, `MacButton`, etc. | Implement the UI components for each platform      |
| Client                 | `Program.cs`                 | Uses the abstract factory to create platform-agnostic UI |

---

## 🧪 Example Use Case

A cross-platform UI application needs to render different buttons and checkboxes depending on the OS (Windows or Mac).  
By using the Abstract Factory, the application can remain OS-agnostic and delegate all platform-specific instantiation logic to factory classes.

---

## 📦 Example Execution

```csharp
Console.Write("Enter OS (win/mac): ");
var input = Console.ReadLine();

IGuiFactory factory = input?.ToLower() switch
{
    "mac" => new MacFactory(),
    "win" => new WindowsFactory(),
    _ => throw new Exception("Unsupported OS")
};

var button = factory.CreateButton();
var checkbox = factory.CreateCheckbox();

button.Render();
checkbox.Render();
```

## ✅ Benefits

| Feature                           | Benefit                                                     |
| --------------------------------- | ----------------------------------------------------------- |
| ✅ Encapsulates object creation    | The client never needs to know which concrete class is used |
| ✅ Promotes consistency            | Ensures that only compatible components are used together   |
| 🧱 Supports Open/Closed Principle | New platforms can be added without modifying existing code  |
| 🧪 Improves testability           | Interfaces and factories are easy to mock in unit tests     |


## 🔄 Alternatives & Related Patterns

- Use **[Factory Method](Creational/FactoryMethod/README.md)** when only one product is needed.
- Combine with Dependency Injection for runtime flexibility.
- Use Builder Pattern if construction of individual products is complex.